using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace weatherapp
{
    public class weatherModel
    {

        readonly string x_apiKey = "39d21b37e35485a09fdded569701f582";
        public async Task<resultWeatherModel> LoadWeatherInfo(string cityName)
        {
            string url = String.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", cityName, x_apiKey );

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    resultWeatherModel result = await response.Content.ReadAsAsync<resultWeatherModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
    }
}
