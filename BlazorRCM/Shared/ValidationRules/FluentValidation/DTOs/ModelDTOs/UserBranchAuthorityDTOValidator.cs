using BlazorRCM.Shared.DTOs.ModelDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRCM.Shared.ValidationRules.FluentValidation.DTOs.ModelDTOs
{
    public class UserBranchAuthorityDTOValidator : AbstractValidator<UserBranchAuthorityDTO>
    {
        public UserBranchAuthorityDTOValidator()
        {
            RuleFor(x => x.UId)
                .NotNull()
                .WithMessage("Kullanıcı seçmelisiniz!");

            RuleFor(x => x.UId)
                .NotEqual(0)
                .WithMessage("Kullanıcı seçmelisiniz!");

            RuleFor(x => x.BId)
                .NotNull()
                .WithMessage("Şube seçmelisiniz!");

            RuleFor(x => x.BId)
                .NotEqual(Convert.ToInt16(0))
                .WithMessage("Şube seçmelisiniz!");

            RuleFor(x => x.ATId)
                .NotNull()
                .WithMessage("Yetki seçmelisiniz!");

            RuleFor(x => x.ATId)
                .NotEqual(Convert.ToInt16(0))
                .WithMessage("Yetki seçmelisiniz!");
        }
    }
}
