using System.ComponentModel;

namespace EduApoyos.Domain.Common.Enums
{
    public enum TypeSupport
    {
        [Description("Beca")]
        Scholarship,
        [Description("Crédito")]
        Loan,
        [Description("Subsidio")]
        Subsidy
    }
}
