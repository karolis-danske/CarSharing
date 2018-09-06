namespace CarSharing.Users
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public CreateCarRequest Car { get; set; }
    }
}