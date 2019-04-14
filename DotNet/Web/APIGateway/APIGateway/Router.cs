using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGateway {
    public class Router {
        public List<Route> Routes { get; set; }
        public Destination AuthenticationService { get; set; }

        public Router(string routeConfigFilePath) {
            dynamic router = JsonLoader.LoadFromFile<dynamic>(routeConfigFilePath);

            Routes = JsonLoader.Deserialize<List<Route>>(Convert.ToString(router.routes));
            AuthenticationService = JsonLoader.Deserialize<Destination>(Convert.ToString(router.authenticationService));
        }

        public async Task<HttpResponseMessage> RouteRequest(HttpRequest request) {
            string path = request.Path.ToString();
            string basePath = '/' + path.Split('/')[1];

            Destination destination;

            try {
                destination = Routes.First(r => r.Endpoint.Equals(basePath)).Destination;
            }
            catch {
                return ConstructErrorMessage("The path could not be found.");
            }

            if(destination.RequiresAuthentication == true) {
                string token = request.Headers["token"];
                request.Query.Append(new KeyValuePair<string, Microsoft.Extensions.Primitives.StringValues>("token", new Microsoft.Extensions.Primitives.StringValues(token)));
                HttpResponseMessage authResponse = await AuthenticationService.SendRequest(request);
                if(authResponse.IsSuccessStatusCode == false)
                    return ConstructErrorMessage("Authentication failed.");
            }

            return await destination.SendRequest(request);
        }

        private HttpResponseMessage ConstructErrorMessage(string error) {
            HttpResponseMessage errorMessage = new HttpResponseMessage {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Content = new StringContent(error)
            };

            return errorMessage;
        }
    }
}
