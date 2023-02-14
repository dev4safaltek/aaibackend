namespace AAI.DataContract.Models.Entity
{
    public class UserType
    {
        public Guid TypeId { get; set; }
        public string TypeName { get; set; }
        public bool IsActive { get; set; }
        public Guid? Change_Id { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
