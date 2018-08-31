using Newtonsoft.Json;

namespace rats_game_client_dotnet
{
    internal static class Requests
    {
        public static string Wait(this Client client) => client.Get("wait");

        public static Table Table(this Client client) => JsonConvert.DeserializeObject<Table>(client.Get("table"));

        public static string SelectMode(this Client client, Mode mode) => client.Post("select_mode", JsonConvert.SerializeObject(new
        {
            slem = mode.ToString()
        }));

        public static string Discard(this Client client, Card[] cards) => client.Post("discard", JsonConvert.SerializeObject(new
        {
            cards
        }));

        public static string SelectCard(this Client client, Card card) => client.Post("select_card", JsonConvert.SerializeObject(new
        {
            card
        }));
    }
}
