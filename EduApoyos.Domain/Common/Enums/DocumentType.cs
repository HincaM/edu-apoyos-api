using System.ComponentModel;

namespace EduApoyos.Domain.Common.Enums
{
    public enum DocumentType
    {
        [Description("Tarjeta de identidad")]
        IdentityCard = 1,
        [Description("Cédula")]
        Cedula = 2,
        [Description("Cédula de extranjería")]
        ForeignCedula = 3
    }
}
