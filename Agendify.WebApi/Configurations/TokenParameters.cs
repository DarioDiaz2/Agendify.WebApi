using Agendify.Abstactions;

namespace Agendify.WebApi.Configurations
{
    public class TokenParameters:ITokenParameters
    {
        public string UserName { get; set; }
        public string PaswordHash { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
