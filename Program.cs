using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace rats_game_client_dotnet
{
    internal class Program
    {
        private static Client _client;

        private static IDictionary<string, IPhase> _phases;

        private static void Main()
        {
            InitializeGame();

            while (true)
            {
                try
                {
                    _client.Wait();
                    var table = _client.Table();

                    Console.WriteLine($"Round: {table.round} Turn: {table.turn:D2} Phase: {table.phase}");
                    _phases[table.phase].Execute(table);

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Thread.Sleep(1000);
                }
            }
        }

        private static void InitializeGame()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _client = new Client(configuration);
            _phases = new Dictionary<string, IPhase>
            {
                {"selectCard", new SelectCard(_client)},
                {"selectMode", new SelectMode(_client)},
                {"discard", new Discard(_client)}
            };
        }
    }
}
