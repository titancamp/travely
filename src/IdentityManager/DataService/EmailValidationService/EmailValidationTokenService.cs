using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.DataService.EmailValidationService
{

    //UserEmailValidationModel userVerificationCode = new UserEmailValidationModel()
    //{
    //    UserId = user.Id,
    //    Token = Guid.NewGuid().ToString(),
    //    CreatedDate = DateTimeOffset.Now
    //};


    class EmailValidationTokenService : IEmailValidationTokenService
    {


        private readonly IUserRepository _userRepository;
        private readonly IUserEmailValidationModelRepository _userEmailValidationModel;

        public EmailValidationTokenService(IUserEmailValidationModelRepository userEmailValidationModel, IUserRepository userRepository)
        {
            _userEmailValidationModel = userEmailValidationModel;
            _userRepository = userRepository;
        }


        public Task<string> CreateTokenAsync(string email, CancellationToken cancellationToken = default)
        {
           // var user=_userRepository.FindAsync(u=>u.e)
           // var e = _userEmailValidationModel.FindAsync(t => t.UserId == userVerificationCode.UserId && t.

            return null;
        }

        public Task<bool> ValidateTokenAsync(string token, CancellationToken cancellationToken = default)
        {
            return null;
        }
    }


    //public class RegisterUserInDTO
    //{
    //    public long Id { get; set; }
    //    [Required]
    //    [MaxLength(200)]
    //    public string Email { get; set; }
    //    [Required]
    //    [MaxLength(250)]
    //    public string Password { get; set; }
    //}





    public async Task<RegisterUserOutDTO> RegisterUserAsync(RegisterUserInDTO inModel)
    {
        RegisterUserOutDTO result = new RegisterUserOutDTO();

        var email = inModel.Email.ToLower();

        var exists = await _userRepository.AnyAsync(a => a.Email == email);

        if (exists)
        {
            result.AddError(CustomErrorCodeEnum.UserExists, ErrorTypeEnum.Error, "user exists");

            return result;
        }

        User user = new User()
        {
            Email = inModel.Email.ToLower(),
            EmailIsVerified = false,
            MustChangePassword = false,
            Password = Helper.GenerateSHA512String(inModel.Password),
        };

        _userRepository.Add(user);

        await _unitOfWork.SaveAsync();

        UserEmailValidationModel userVerificationCode = new UserEmailValidationModel()
        {
            UserId = user.Id,
            Token = Guid.NewGuid().ToString(),
            CreatedDate = DateTimeOffset.Now
        };

        _userVerificationCodeRepository.Add(userVerificationCode);

        await _unitOfWork.SaveAsync();

        var successSendEmail = await _emailSender.SendEmail(email, "", _emailConfirmUrl + $"?UserId={user.Id}&UserVerificationCode={userVerificationCode.Code}");

        if (!successSendEmail)
        {
            result.AddError(CustomErrorCodeEnum.EmailSendingError, ErrorTypeEnum.Error, "email sending error");

            return result;
        }

        result.User = new UserDTO()
        {
            Email = user.Email,
            EmailIsVerified = user.EmailIsVerified,
            Id = user.Id,
            MustChangePassword = user.MustChangePassword
        };

        return result;
    }
}
