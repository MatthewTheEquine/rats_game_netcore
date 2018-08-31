using System;
using System.Linq;

namespace rats_game_client_dotnet
{
    internal class Discard : IPhase
    {
        private readonly Client _client;

        public Discard(Client client) => _client = client;

        public void Execute(Table table)
        {
            var cards = table.cards_in_hand.Take(3).ToList();
            var response = _client.Discard(cards.ToArray());

            Console.WriteLine($"Discard: {string.Join(", ", cards)} [{response}]");
        }
    }
}