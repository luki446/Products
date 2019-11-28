using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Product.Models
{
    public class ProductCreateInputModel
    {
        public string Name {get; set;}
        
        public decimal Price {get;set;}
    }

    public class ProductCreateValidator: AbstractValidator<ProductCreateInputModel>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is mandatory");
            RuleFor(x => x.Price).GreaterThan(0.0M).WithMessage("Price must be greather than 0.0");
        }
    }
}