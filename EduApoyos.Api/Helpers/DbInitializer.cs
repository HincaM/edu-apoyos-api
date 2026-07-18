using EduApoyos.Infrastructure.Context;

namespace EduApoyos.Api.Helpers
{
    public static class DbInitializer
    {
        public static void Seed(EduApoyosContext context)
        {
            context.Database.EnsureCreated();

            var programs = context.Set<Domain.Entities.AcademicProgram>();

            if (!programs.Any())
            {
                programs.AddRange(
                    new Domain.Entities.AcademicProgram
                    {
                        Name = "Ingeniería Mecatrónica",
                        Description = "Integra la mecánica, la electrónica, la informática y los sistemas de control para diseñar y automatizar maquinaria, robots y procesos industriales inteligentes."
                    },
                    new Domain.Entities.AcademicProgram
                    {
                        Name = "Ingeniería de Sistemas",
                        Description = "Se enfoca en el diseño, desarrollo y gestión de software, redes de computadores, bases de datos y soluciones tecnológicas para resolver problemas organizacionales."
                    },
                    new Domain.Entities.AcademicProgram
                    {
                        Name = "Medicina",
                        Description = "Programa clínico dedicado a la promoción de la salud, prevención, diagnóstico y tratamiento de enfermedades humanas, con un fuerte enfoque en el servicio y la ética médica."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
