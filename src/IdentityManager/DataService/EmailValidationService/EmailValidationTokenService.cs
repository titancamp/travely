using Microsoft.Extensions.Configuration;
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

    class EmailValidationTokenService : IEmailValidationTokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserEmailValidationModelRepository _userEmailValidationModel;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public EmailValidationTokenService(IUserEmailValidationModelRepository userEmailValidationModel, IUserRepository userRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _userEmailValidationModel = userEmailValidationModel;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }


        public async Task<string> CreateTokenAsync(string email, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(u => u.UserName == email);
            if (user == null)
            {
                return null;
            }

            var userVal = new UserEmailValidationModel
            {
                UserEmail = user.UserName,
                CreatedDate = DateTimeOffset.Now,
                Token = Guid.NewGuid().ToString(),
            };

            _userEmailValidationModel.Add(userVal);

            await _unitOfWork.SaveChangesAsync();

            var url = $"{_configuration.GetValue<string>("autenticationHost")}?email={email}&token={userVal.Token}";

            //mail.Send(url);
            return url;
        }

        public async Task<bool> ValidateTokenAsync(string email, string token, CancellationToken cancellationToken = default)
        {
            var uv = await _userEmailValidationModel.FindAsync(t => t.UserEmail == email && t.Token == token);
            if (uv != null && (DateTimeOffset.Now - uv.CreatedDate).Hours < 24)
            {
                return true;
            }
            return false;
        }
    }
}
