using ApiCore.Attributes;

namespace Lootee_Core.Requests.User
{
    [RequestMethod(ApiCore.Attributes.HttpMethod.Post)]
    internal class Login : Base
    {
        [PropertyType(PropertyType.Post, name: "username")]
        public string? Username { get; set; }


        [PropertyType(PropertyType.Post, name: "secret")]
        public string? Secret { get; set; }
    }
}
