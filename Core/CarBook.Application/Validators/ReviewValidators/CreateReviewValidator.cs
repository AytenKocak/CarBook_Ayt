using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator:AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x=>x.CustomerName).NotEmpty().WithMessage("Müşteri İsmini Boş Geçmeyiniz");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("En az 5 Karakter Girmelisiniz");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen Puan değerini boş geçmeyiniz"); 
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen Yorum değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).MaximumLength(450).WithMessage("Lütfen 450 karakteri  geçmeyiniz");
            



            
        }
    }
}
