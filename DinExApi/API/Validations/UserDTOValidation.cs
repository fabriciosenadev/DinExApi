using DinExApi.API.DTO;
using FluentValidation;

namespace DinExApi.API.Validations
{
    public class UserDTOValidation : AbstractValidator<UserDTO>
    {
        public UserDTOValidation()
            {
            RuleFor(u => u.FullName)
                .MinimumLength(3)
                .WithName("Nome completo");

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .WithName("E-mail");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithName("Senha");

            RuleFor(u => u.VerifyPass)
                .Equal(u => u.Password)
                .WithMessage("Senhas devem ser iguais");
        }
    }
}
