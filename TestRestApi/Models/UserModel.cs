using Newtonsoft.Json;

namespace TestRestApi.Models
{
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password{ get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress
        /// </summary>
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }
    }
}
