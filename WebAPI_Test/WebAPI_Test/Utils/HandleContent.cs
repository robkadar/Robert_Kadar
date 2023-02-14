using Newtonsoft.Json;
using RestSharp;

namespace WebAPI_Test.Utils
{
    public class HandleContent
    {
        public static T GetContent<T>(RestResponse response)
        {
            var content = response.Content;
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }
    }
}
