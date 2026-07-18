using System.ComponentModel;

namespace EduApoyos.Domain.Common.Enums
{
    public enum Role
    {
        [Description("Asesor")]
        Advisor = 1,
        [Description("Estudiante")]
        Student = 2
    }
}
