namespace Leave_Management_System.DTOs.User
{
    public class CreateUserRequestDTO
    {
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public long RoleId { get; set; }
        public long? ManagerId { get; set; }
        public DateOnly JoiningDate { get; set; }
    }
}
