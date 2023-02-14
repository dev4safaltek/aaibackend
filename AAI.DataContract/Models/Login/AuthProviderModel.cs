using System;
using System.Collections.Generic;
using System.Text;

namespace AAI.DataContract.Models.Login
{
    public class AuthProviderModel
    {
        public string Account { get; set; }
        public string ManualEntryKey { get; set; }
        public string QrCodeSetupImageUrl { get; set; }
    }
}
