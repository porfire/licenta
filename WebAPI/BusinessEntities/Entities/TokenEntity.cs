//using DataModel;

using Newtonsoft.Json;

namespace BusinessEntities.Entities
{
    public class TokenEntity
    {
        public int TokenId { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        public int UserId { get; set; }
        public string AuthToken { get; set; }
        [JsonProperty(".issuedon")]
        public System.DateTime IssuedOn { get; set; }
        [JsonProperty(".expireson")]
        public System.DateTime ExpiresOn { get; set; }
    }
}