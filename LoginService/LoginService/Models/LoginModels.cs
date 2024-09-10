namespace LoginService.Models
{
    public class LoginModels
    {
    }

    public class UserRegisterRequest { 
    
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UserRegisterResponse  : UserRegisterRequest
    { 
        public int Status { get; set; }
        public string Message { get; set; }
    }

    public class UserLoginRequest 
    {
        public string UserId { get; set; }
        public string Password { get; set; }

    }

    public class UserLoginResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string LoyaltyId { get; set; }

    }

}
