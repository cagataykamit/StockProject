using DataAccess.Entities;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(s => s.Title).NotEmpty().WithMessage("Lütfen kategori başlığını giriniz!");
        }
    }
}