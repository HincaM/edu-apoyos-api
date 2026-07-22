using System.ComponentModel;

namespace EduApoyos.Domain.Common.Enums
{
    public enum Status
    {
        [Description("Pendiente")]
        Pending,
        [Description("En revisión")]
        UnderReview,
        [Description("Aprobado")]
        Approved,
        [Description("Rechazado")]
        Rejected
    }
}
