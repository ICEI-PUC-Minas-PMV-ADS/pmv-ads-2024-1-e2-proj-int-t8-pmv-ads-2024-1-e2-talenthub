using System;
using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
  public static string GetDescription(this Enum value)
  {
    FieldInfo? fi = value?.GetType().GetField(value.ToString());

    if (fi != null)
    {
      DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

      if (attributes != null && attributes.Length > 0)
      {
        return attributes[0].Description;
      }
    }

    return value!.ToString();
  }
}
