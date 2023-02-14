using System.Collections.Generic;

namespace AAI.DataContract.Models.Login
{
    public class LogInPasswordViewModel
    {
        public List<UserLoginDetailViewModel> UserDetails { get; set; }
        public List<ResetPasswordViewModel> PasswordDetails { get; set; }
        public ResetPasswordViewModel PasswordResetforUser { get; set; }
        public int CheckId { get; set; }
    }
}
