

using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;


namespace Pickture.Services
{
    static class ApiService
    {
        
        static async void MakeRequest()
        {
            var client = new HttpClient();
            var imageurl = "https://scontent-iad3-1.xx.fbcdn.net/v/t1.0-9/13418766_608548517788_5600955180574060883_n.jpg?oh=f7af268c4d8b51912d14e851efba6da8&oe=57CCBF95";

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");

            var uri = "https://api.projectoxford.ai/emotion/v1.0/recognize?" + imageurl;

            HttpResponseMessage response = new HttpResponseMessage();

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            string responseBody = await response.Content.ReadAsStringAsync();
            

        }
    }
}