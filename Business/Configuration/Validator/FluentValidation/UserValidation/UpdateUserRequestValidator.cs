﻿using DTO.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.UserValidation
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            // Var olan bir kullanıcıyı güncellemeden önce yapılması gereken validasyonlar
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.No).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Lütfen bir Numara girin");
        }
    }
}
