using System;
using System.Net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace rats_game_client_dotnet
{
    internal class Client
    {
        private readonly string _server;
        private readonly string _port;
        private readonly string _token;

        public Client(IConfiguration configuration)
        {
            _server = configuration["server"];
            _port = configuration["port"];
            _token = configuration["token"]; 
        }

        public string Post(string command, object parameters = null)
        {
            return Execute(command, parameters, Method.POST);
        }

        public string Get(string command, object parameters = null)
        {
            return Execute(command, parameters, Method.GET, $"?player_token={_token}");
        }

        private string Execute(string command, object parameters, Method method, string query = null)
        {
            var client = new RestClient($"{_server}:{_port}/{command}{query ?? ""}");

            var request = new RestRequest(method);
            request.AddParameter("application/json", parameters, ParameterType.RequestBody);
            if (_token != null)
            {
                request.AddHeader("token", _token);
            }

            var response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {                
                throw new Exception($"StatusCode: {response.StatusCode}, Message: {response.Content}");
            }
            return response.Content;
        }
    }
}