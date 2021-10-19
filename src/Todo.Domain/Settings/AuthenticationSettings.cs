namespace Todo.Domain.Settings
{
    public class AuthenticationSettings
    {
        public static readonly string SectionName = "AuthenticationSettings";
        public string Authority { get; set; }
        public string Audience { get; set; }
        public string ValidIssuer { get; set; }
    }
}