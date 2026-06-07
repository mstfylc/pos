using FluentValidation;

namespace Mansis.Pos.Application.Core;

public sealed class ProductWriteValidator : AbstractValidator<ProductWriteDto>
{
    public ProductWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.Name).NotEmpty();
        RuleFor(request => request.CategoryId).NotEmpty();
        RuleFor(request => request.ProductUnitType).IsInEnum();
        RuleFor(request => request.TaxType).IsInEnum();
    }
}

public sealed class PosProductWriteValidator : AbstractValidator<PosProductWriteDto>
{
    public PosProductWriteValidator()
    {
        RuleFor(request => request.CompanyId).NotEmpty();
        RuleFor(request => request.UserId).NotEmpty();
        RuleFor(request => request.PosId).NotEmpty();
        RuleFor(request => request.ProductId).NotEmpty();
    }
}
