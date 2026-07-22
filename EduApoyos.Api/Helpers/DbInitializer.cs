using EduApoyos.Application.Common.Helpers;
using EduApoyos.Domain.Common.Enums;
using EduApoyos.Domain.Entities;
using EduApoyos.Infrastructure.Context;

namespace EduApoyos.Api.Helpers
{
    public static class DbInitializer
    {
        public static void Seed(EduApoyosContext context)
        {
            var programs = context.Set<Domain.Entities.AcademicProgram>();

            if (!programs.Any())
            {
                programs.AddRange(
                    new AcademicProgram
                    {
                        Name = "Ingeniería Mecatrónica",
                        Description = "Integra la mecánica, la electrónica, la informática y los sistemas de control para diseñar y automatizar maquinaria, robots y procesos industriales inteligentes."
                    },
                    new AcademicProgram
                    {
                        Name = "Ingeniería de Sistemas",
                        Description = "Se enfoca en el diseño, desarrollo y gestión de software, redes de computadores, bases de datos y soluciones tecnológicas para resolver problemas organizacionales."
                    },
                    new AcademicProgram
                    {
                        Name = "Medicina",
                        Description = "Programa clínico dedicado a la promoción de la salud, prevención, diagnóstico y tratamiento de enfermedades humanas, con un fuerte enfoque en el servicio y la ética médica."
                    }
                );
                context.SaveChanges();
            }

            var users = context.Set<User>();

            if (!users.Any(u => u.Role == Role.Advisor))
            {
                var passwordHash = new PasswordHashHelper();
                var advisorPassword = passwordHash.Hash("Advisor123*");
                var studentPassword = passwordHash.Hash("Student123*");

                var student = User.Create("Pablo Villamil", "pablo.villamil@micorreo.com", studentPassword, Role.Student);

                users.AddRange(
                    User.Create("Laura Gómez", "laura.gomez@eduapoyos.com", advisorPassword, Role.Advisor),
                    User.Create("Carlos Rodríguez", "carlos.rodriguez@eduapoyos.com", advisorPassword, Role.Advisor),
                    User.Create("María Fernández", "maria.fernandez@eduapoyos.com", advisorPassword, Role.Advisor),
                    User.Create("Andrés Torres", "andres.torres@eduapoyos.com", advisorPassword, Role.Advisor),
                    User.Create("Paula Ramírez", "paula.ramirez@eduapoyos.com", advisorPassword, Role.Advisor),
                    student
                );
                context.SaveChanges();

                var academicProgram = context.Set<AcademicProgram>()
                    .First(p => p.Name == "Ingeniería de Sistemas");

                context.Set<Student>().Add(
                    Student.Create(student.Id, "1020304050", DocumentType.Cedula, academicProgram.Id, 6)
                );
                context.SaveChanges();
            }
        }
    }
}
