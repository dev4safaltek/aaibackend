using System;
using System.Collections.Generic;
using System.Text;

namespace AAI.DataContract.Models.Login
{
    public class ResetPasswordRequestModel
    {
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Link { get; set; }
    }
}
