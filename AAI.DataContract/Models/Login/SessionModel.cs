using System.Collections.Generic;

namespace AAI.Service.Login
{
    public class SessionModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullUserName { get; set; }
        public string UserIP { get; set; }
        public string Url { get; set; }
        public string Comment { get; set; }
        public string AccessToken { get; set; }
        public IEnumerable<string> ValidRolesForUser { get; set; }
        public IEnumerable<string> ValidPositionsForUser { get; set; }
        public IEnumerable<string> PurchaseOrderPrivileges { get; set; }
        public bool IsPasswordChangeMandatory { get; set; }
        public bool IsQRScanned { get; set; }
    }

}
