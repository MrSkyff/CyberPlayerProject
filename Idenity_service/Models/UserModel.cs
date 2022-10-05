namespace Idenity_service.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Hashcode { get; set; }
        public string Password { get;set; }
        public string Avatar { get; set; }
    }
}
