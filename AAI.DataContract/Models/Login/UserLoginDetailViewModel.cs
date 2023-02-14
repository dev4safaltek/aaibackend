using System;
namespace AAI.DataContract.Models.Login
{
    public class UserLoginDetailViewModel
    {
        public Guid UserId { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string CompanyName { get; set; }
        public string Email { get; set; }
        public string  Phone { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn {get; set;}
        public int CreatedBy {get; set;}
        public DateTime ModifiedOn {get; set;}
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }

    }
}
