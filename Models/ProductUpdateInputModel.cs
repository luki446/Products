using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FluentValidation;

namespace Product.Models
{
    public class ProductUpdateInputModel
    {
        public Guid Id {get; set;}

        public string Name {get; set;}

        public decimal Price {get; set;}
    }

    public class ProductUpdateValidator: AbstractValidator<ProductUpdateInputModel>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is mandatory");
            RuleFor(x => x.Name).Length(1, 100).WithMessage("Name must be between 1 and 100 characters long");
            RuleFor(x => x.Price).GreaterThan(0.0M).WithMessage("Price must be greater than 0.0");
        }
    }
}