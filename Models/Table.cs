namespace rats_game_client_dotnet
{
    internal class Table
    {
        public Card[] cards_in_hand { get; set; }

        public Card[] cards_on_table { get; set; }

        public int current_player { get; set; }

        public string phase { get; set; }

        public int round { get; set; }

        public int score { get; set; }

        public string scoring_mode { get; set; }

        public int turn { get; set; }

        public int your_position_at_table { get; set; }
    }
}