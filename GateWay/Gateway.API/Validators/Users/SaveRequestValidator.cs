namespace Gateway.API.Validators.Users
{
    /*public class LoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.user_login).MaximumLength(50).WithMessage("el campo user_login no debe superar los 10 caracteres");
            RuleFor(x => x.password_login).MaximumLength(50).WithMessage("el campo password_login no debe superar los 10 caracteres");
        }
    }

    public class SaveRequestValidator : AbstractValidator<UserSaveRequest>
    {
        public SaveRequestValidator()
        {
            RuleFor(x => x.first_Name).MaximumLength(50).WithMessage("el campo first_name no debe superar los 50 caracteres");
            RuleFor(x => x.second_Name).MaximumLength(50).WithMessage("el campo second_Name no debe superar los 50 caracteres");
            RuleFor(x => x.first_LastName).MaximumLength(50).WithMessage("el campo first_LastName no debe superar los 50 caracteres");
            RuleFor(x => x.second_LastName).MaximumLength(50).WithMessage("el campo second_LastName no debe superar los 50 caracteres");
            RuleFor(x => x.email).EmailAddress().WithMessage("el campo email no tiene el formato correcto");
            RuleFor(x => x.phone).MaximumLength(10).WithMessage("el campo phone no debe superar los 10 caracteres");
            RuleFor(x => x.user_login).MaximumLength(50).WithMessage("el campo user_login no debe superar los 10 caracteres");
            RuleFor(x => x.password_login).MaximumLength(50).WithMessage("el campo password_login no debe superar los 10 caracteres");
            RuleFor(x => x.document_number).Matches(@"([0-9])$").WithMessage("el campo document_number debe ser un valor numerico");
            RuleFor(x => x.isAdmin).Must(x => x == false || x == true).WithMessage("el campo isAdmin debe ser un valor booleano");
        }
    }

    public class TransactionRequestValidator : AbstractValidator<UserTransactionRequest>
    {
        public TransactionRequestValidator()
        {
            RuleFor(x => x.id_destination_user).Matches(@"([0-9])$").WithMessage("el campo id_destination_user debe ser un valor numerico");
            RuleFor(x => x.id_origin_user).Matches(@"([0-9])$").WithMessage("el campo id_origin_user debe ser un valor numerico");
            RuleFor(x => x.amount).Matches(@"([+]?([0-9]*\.[0-9]+|[0-9]+))$").WithMessage("el campo amount debe ser un valor numerico");
            RuleFor(x => x.amount).Must(x => x != "0").WithMessage("el campo amount debe ser mayor a cero");
        }
    }

    public class UpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.first_Name).MaximumLength(50).WithMessage("el campo first_name no debe superar los 50 caracteres");
            RuleFor(x => x.second_Name).MaximumLength(50).WithMessage("el campo second_Name no debe superar los 50 caracteres");
            RuleFor(x => x.first_LastName).MaximumLength(50).WithMessage("el campo first_LastName no debe superar los 50 caracteres");
            RuleFor(x => x.second_LastName).MaximumLength(50).WithMessage("el campo second_LastName no debe superar los 50 caracteres");
            RuleFor(x => x.email).MaximumLength(50).WithMessage("el campo email no debe superar los 50 caracteres");
            RuleFor(x => x.email).EmailAddress().WithMessage("el campo email no tiene el formato correcto");
            RuleFor(x => x.phone).MaximumLength(10).WithMessage("el campo phone no debe superar los 10 caracteres");
            RuleFor(x => x.user_login).MaximumLength(50).WithMessage("el campo user_login no debe superar los 10 caracteres");
            RuleFor(x => x.password_login).MaximumLength(50).WithMessage("el campo password_login no debe superar los 10 caracteres");
            RuleFor(x => x.document_number).Matches(@"([0-9])$").WithMessage("el campo document_number debe ser un valor numerico");
            RuleFor(x => x.id).Matches(@"([0-9])$").WithMessage("el campo id debe ser un valor numerico");
            RuleFor(x => x.isAdmin).Must(x => x == false || x == true).WithMessage("el campo isAdmin debe ser un valor booleano");
        }
    }

    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.id).Matches(@"([0-9])$").WithMessage("el campo id debe ser un valor numerico");
        }
    }*/
}