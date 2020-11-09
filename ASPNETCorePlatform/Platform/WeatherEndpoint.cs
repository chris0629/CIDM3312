using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Platform.Services;

namespace Platform
{
    public class WeatherEndpoint
    {

        // private IResponseFormatter formatter;

        // public WeatherEndpoint(IResponseFormatter responseFormatter)
        // {
        //     formatter = responseFormatter;
        // }

        public async Task Endpoint(HttpContext context, IResponseFormatter formatter)
        {
            // await context.Response.WriteAsync("Endpoint Class: It is cloudy in Milan");
            // change to DI - fetches the requisite service
            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
        }
    }
}