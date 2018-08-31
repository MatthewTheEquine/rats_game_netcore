using System;
using System.Linq;

namespace rats_game_client_dotnet
{
    internal class SelectCard : IPhase
    {
        private readonly Client _client;

        public SelectCard(Client client) => _client = client;

        public void Execute(Table table)
        {
            var card = table.cards_in_hand.First();
            var response = _client.SelectCard(card);

            Console.WriteLine($"SelectCard: {card} [{response}]");
        }
    }
}