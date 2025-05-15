namespace MyExpenseTrackerEntity.DTOs.User
{
    public class UserListDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }
        public string Role { get; set; }
    }

}