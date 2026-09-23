using FastEndpoints;
using FluentValidation;

namespace RiverBooks.Books.BookEndpoints;

public class UpdatePriceRequestValidator : Validator<UpdatePriceRequest>
{
  public UpdatePriceRequestValidator()
  {
    RuleFor(x => x.Id)
      .NotNull()
      .NotEqual(Guid.Empty)
      .WithMessage("A book id is required");

    RuleFor(x => x.NewPrice)
      .GreaterThanOrEqualTo(0)
      .WithMessage("The price must be positive");
  }
}
