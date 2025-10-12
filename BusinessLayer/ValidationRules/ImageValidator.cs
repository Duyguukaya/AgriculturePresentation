using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator:AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel başlığını boş geçemezsiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel açıklamasını boş geçemezsiniz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolunu boş geçemezsiniz");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Maxsimim 30 karakter veri girişi yapılabilir");
            RuleFor(x => x.Title).MinimumLength(8).WithMessage("Minimum 8 karakter veri girişi yapılabilir");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Maxsimim 50 karakter veri girişi yapılabilir");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Minimum 20 karakter veri girişi yapılabilir");
        }
    }
}
