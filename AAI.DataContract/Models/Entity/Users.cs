namespace AAI.DataContract.Models.Entity
{
    public class Users
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<DateTime> LastLoginDate { get; set; }
        public Guid UserType { get; set; }
        public bool IsVerified { get; set; }
        public bool IsPasswordReset { get; set; }
        public bool IsLoggedIn { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }
        public Guid? Change_Id { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
