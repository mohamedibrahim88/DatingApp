namespace API.DTOs
{
    public class UserDto
    {
        public string username { get; set; }
        public string token { get; set; }

        public string photoUrl { get; set; }

        public string KnownAs {get; set;}
    }
}