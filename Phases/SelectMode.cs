using System;

namespace rats_game_client_dotnet
{
    internal class SelectMode : IPhase
    {
        private readonly Client _client;

        public SelectMode(Client client) => _client = client;

        public void Execute(Table table)
        {
            var mode = Mode.grandSlem;
            var response = _client.SelectMode(mode);

            Console.WriteLine($"SelectMode: {mode} [{response}]");
        }
    }
}