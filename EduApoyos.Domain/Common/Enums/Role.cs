using System.ComponentModel;

namespace EduApoyos.Domain.Common.Enums
{
    public enum Role
    {
        [Description(RoleConstants.Advisor)]
        Advisor = 1,
        [Description(RoleConstants.Student)]
        Student = 2
    }
}
