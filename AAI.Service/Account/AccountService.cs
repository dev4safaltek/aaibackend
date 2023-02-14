using AAI.Common;
using AAI.DataContract;
using AAI.DataContract.Enums;
using AAI.DataContract.Models;
using AAI.DataContract.Models.Login;
using AAI.RepositoryContract.Account;
using AAI.ServiceContract.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AAI.Service.Account
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;
        private readonly JwtSettingModel _jwtSetting;
        private IHostingEnvironment _environment;

        public AccountService(IAccountRepository accountRepository,
            IHttpContextAccessor accessor,
            IConfiguration configuration,
            IOptions<JwtSettingModel> jwtoption) : base(accessor, configuration)
        {
            _jwtSetting = jwtoption.Value;
            _accountRepository = accountRepository;
            _configuration = configuration;
            _accessor = accessor;
        }

        /// <summary>
        /// Function used to create account
        /// </summary>
        public async Task<APIResponse> SignUpAsync(CreateAccountModel model)
        {
            //string passwordKey = model.Password;
            //model.Password = PasswordSHA512CryptoProvider.CreateHash(model.Password);
            //Guid result = await _accountRepository.SignupAsync(model);
            //if (result != Guid.Empty)
            //{
            //    var accountVerifyURL = AppSetting.AccountActivationLink + "userId=" + result;
            //    var webRoot = _environment.WebRootPath;
            //    var filePath = webRoot + AppSetting.AccountActivationTemplatePath;

            //    StreamReader streamReader = new StreamReader(filePath);
            //    string MailText = streamReader.ReadToEnd();
            //    MailText = MailText.Replace("[Name]", model.FirstName.Trim() + model.LastName.Trim());
            //    MailText = MailText.Replace("[UserName]", model.UserName.Trim());
            //    MailText = MailText.Replace("[Password]", passwordKey.Trim());
            //    MailText = MailText.Replace("[Url]", "<a href='" + accountVerifyURL + "'>" + accountVerifyURL + "</a>");

            //    EmailSettingModel email = new EmailSettingModel()
            //    {
            //        FromAddress = EmailSetting.FromAddress,
            //        ToAddress = model.Email,
            //        Subject = EmailSetting.Subject,
            //        Text = MailText
            //    };
            //    streamReader.Dispose();

            //    _emailservice.MailObject(email.FromAddress, email.ToAddress, email.Subject, email.Text);
            //}

            return new APIResponse(StatusCodesEnum.Success, "");
        }

        /// <summary>
        /// Function used to get user list
        /// </summary>
        public async Task<APIResponse> UserListAsync(PageSortingModel model)
        {
            var result = await _accountRepository.UserListAsync(model);

            return new APIResponse(StatusCodesEnum.Success, result);
        }

        /// <summary>
        /// Function used to get user Detail
        /// </summary>
        public async Task<APIResponse> UserDetailAsync(Guid userId)
        {
            var result = await _accountRepository.UserDetailAsync(userId);

            return new APIResponse(StatusCodesEnum.Success, result);
        }

        /// <summary>
        /// Function used to activate user account
        /// </summary>
        public async Task<APIResponse> ActivateUserAsync(Guid userId)
        {
            var result = await _accountRepository.ActivateUserAsync(userId);

            return new APIResponse(StatusCodesEnum.Success, result);
        }
    }
}
