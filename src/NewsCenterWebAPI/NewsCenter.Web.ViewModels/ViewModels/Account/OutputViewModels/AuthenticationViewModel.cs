namespace NewsCenter.Web.ViewModels.ViewModels.Account.OutputViewModels
{
    public class AuthenticationViewModel
    {
        public string Message { get; set; }

        public string Token { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public bool IsAdmin { get; set; }
    }
}
