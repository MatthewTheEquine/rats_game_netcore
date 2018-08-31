namespace rats_game_client_dotnet
{
    internal class Card
    {
        public string rank { get; set; }

        public string suit { get; set; }

        public override string ToString() => $"{suit}{rank}";
    }
}