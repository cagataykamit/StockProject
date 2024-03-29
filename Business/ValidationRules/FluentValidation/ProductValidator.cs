using DataAccess.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Lütfen ürün başlığı giriniz!").MaximumLength(200).WithMessage("Ürün başlığı en fazla 200 karakter olmalıdır!"); ;
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Lütfen kategori giriniz!");
        }
    }
}