namespace PhotoExchangeApi.Applications.Requests;

public class RegisterRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}