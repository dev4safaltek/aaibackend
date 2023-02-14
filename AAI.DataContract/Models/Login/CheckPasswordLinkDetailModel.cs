using System;
using System.Collections.Generic;
using System.Text;

namespace AAI.DataContract.Models.Login
{
    public class CheckPasswordLinkDetailModel
    {
        public bool InActive { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}
