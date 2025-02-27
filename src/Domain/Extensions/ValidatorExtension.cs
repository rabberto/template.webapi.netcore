namespace Template.Webapi.Netcore.Domain.Extensions;

using FluentValidation;
using FluentValidation.Results;


public sealed class ValidatorExtension<TCommand> : IValidatorExtension<TCommand> 
    where TCommand : class
{
    private readonly IValidator<TCommand> _validator;
    public ValidatorExtension(IValidator<TCommand> validator)
    {
        _validator = validator;
    }

    private ValidationResult ValidationResult = new ValidationResult();

    public List<string> GetErrors()
        => ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();

    public async Task<bool> Isvalid(TCommand command)
    {
        ValidationResult = await _validator.ValidateAsync(command);

        return ValidationResult.IsValid;
    }
}