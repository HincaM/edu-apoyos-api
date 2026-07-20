using EduApoyos.Application.Common.Helpers;
using EduApoyos.Application.Helpers;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Entities;
using EduApoyos.Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EduApoyos.IntegrationTest;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public const string AdvisorEmail = "advisor@test.com";
    public const string StudentEmail = "student@test.com";
    public const int AcademicProgramId = 1;
    public const int StudentId = 1;
    public const int RequestSupportId = 1;

    private readonly string _dbName = Guid.NewGuid().ToString();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<EduApoyosContext>));
            if (dbContextDescriptor is not null)
                services.Remove(dbContextDescriptor);

            services.AddDbContext<EduApoyosContext>(opt => opt.UseInMemoryDatabase(_dbName));

            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<EduApoyosContext>();
            SeedData(context);
        });
    }

    public string GenerateAdvisorToken(int userId = 2)
    {
        var tokenGenerator = new TokenGeneratorHelper(Options.Create(new TokenOption
        {
            Issuer = "EduApoyos",
            Audience = "EduApoyosUsers",
            Key = "P11hC2QYz5nr7tjQoxMMZftoO2Is8iGB",
            ExpireMinutes = 60
        }));
        return tokenGenerator.Generate(userId, AdvisorEmail, Role.Advisor);
    }

    public string GenerateStudentToken(int userId = 1)
    {
        var tokenGenerator = new TokenGeneratorHelper(Options.Create(new TokenOption
        {
            Issuer = "EduApoyos",
            Audience = "EduApoyosUsers",
            Key = "P11hC2QYz5nr7tjQoxMMZftoO2Is8iGB",
            ExpireMinutes = 60
        }));
        return tokenGenerator.Generate(userId, StudentEmail, Role.Student);
    }

    private static void SeedData(EduApoyosContext context)
    {
        var passwordHash = new PasswordHashHelper().Hash("Password123!");

        var studentUser = User.Create("Estudiante Test", StudentEmail, passwordHash, Role.Student);
        var advisorUser = User.Create("Asesor Test", AdvisorEmail, passwordHash, Role.Advisor);
        context.Set<User>().AddRange(studentUser, advisorUser);
        context.SaveChanges();

        var academicProgram = new AcademicProgram { Name = "Ingenieria de Sistemas", Description = "Programa de sistemas" };
        context.Set<AcademicProgram>().Add(academicProgram);
        context.SaveChanges();

        var student = Student.Create(studentUser.Id, "123456", DocumentType.Cedula, academicProgram.Id, 3);
        context.Set<Student>().Add(student);
        context.SaveChanges();

        var requestSupport = RequestSupport.Create(student.Id, TypeSupport.Scholarship, 100000, "Ayuda economica", advisorUser.Id);
        context.Set<RequestSupport>().Add(requestSupport);
        context.SaveChanges();
    }
}
