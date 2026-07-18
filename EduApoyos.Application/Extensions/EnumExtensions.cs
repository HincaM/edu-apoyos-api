using System.ComponentModel;
using System.Reflection;

namespace EduApoyos.Application.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value, string? defaultValue = null)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field == null)
                return defaultValue ?? value.ToString();

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();

        }
    }
}
