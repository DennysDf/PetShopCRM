using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Web.Resources;
using System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property)]
public class RequiredIfAttribute(string propertyName) : ValidationAttribute, IClientModelValidator
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return ValidationResult.Success;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        var errorMessage = string.Format(ValidationMessages.ResourceManager.GetString(ErrorMessage), context.ModelMetadata.GetDisplayName());
        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-requiredif", errorMessage);

        var instance = (context.ActionContext as ViewContext).ViewData.Model;

        var type = context.ModelMetadata.ContainerMetadata.ModelType;

        MergeAttribute(context.Attributes, "data-val-requiredif-value", type?.GetProperty(propertyName)?.GetValue(instance)?.ToString().ToLower() ?? "false");
    }

    private static bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
    {
        if (attributes.ContainsKey(key))
            return false;
        
        attributes.Add(key, value);

        return true;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class RequiredIfInputAttribute(string propertyName, object desiredValue) : ValidationAttribute, IClientModelValidator
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return ValidationResult.Success;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        var errorMessage = string.Format(ValidationMessages.ResourceManager.GetString(ErrorMessage), context.ModelMetadata.GetDisplayName());
        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-requiredifinput", errorMessage);
        MergeAttribute(context.Attributes, "data-val-requiredifinput-propertyname", propertyName);
        MergeAttribute(context.Attributes, "data-val-requiredifinput-desiredvalue", desiredValue.ToString());
    }

    private static bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
    {
        if (attributes.ContainsKey(key))
            return false;

        attributes.Add(key, value);

        return true;
    }
}
