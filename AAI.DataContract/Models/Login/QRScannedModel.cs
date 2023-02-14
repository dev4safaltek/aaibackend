using System;
using System.Collections.Generic;
using System.Text;

namespace AAI.DataContract.Models.Login
{
    public class QRScannedModel
    {
        public string UserName { get; set; }
        public bool IsQRScanned { get; set; }
    }
}
