using System.ComponentModel;
using System;
using System.Reflection;

public static class EnumUtil
{
    public static List<KeyValuePair<TEnum, string>> ToList<TEnum>() where TEnum : struct
    {
        if (!typeof(TEnum).IsEnum) throw new InvalidOperationException();
        return ((TEnum[])Enum.GetValues(typeof(TEnum)))
           .ToDictionary(k => k, v => GetDescription(v))
           .ToList();
    }

    private static string GetDescription<T>(this T enumValue) where T : struct
    {
        if (!typeof(T).IsEnum)
            return null;

        var description = enumValue.ToString();
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

        if (fieldInfo != null)
        {
            var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs != null && attrs.Length > 0)
            {
                description = ((DescriptionAttribute)attrs[0]).Description;
            }
        }

        return description;
    }
}
