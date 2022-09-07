namespace Core.Entities.Concrete
{
    public class ChangePasswordModel
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
