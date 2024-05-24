using System;
using System.ComponentModel.DataAnnotations;


[AttributeUsage(AttributeTargets.Property)]
public class RequiredIfPhotoIsNullAttribute : RequiredAttribute
{
    private string PropertyName { get; set; }

    public RequiredIfPhotoIsNullAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        object instance = context.ObjectInstance;
        Type type = instance.GetType();

        bool.TryParse(type.GetProperty(PropertyName).GetValue(instance)?.ToString(), out bool propertyValue);

        if (propertyValue && string.IsNullOrWhiteSpace(value?.ToString()))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
