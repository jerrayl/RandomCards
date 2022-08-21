namespace RandomCards
{
    public class Constants
    {
        public enum GameStatus
        {
            InProgress,
            Ended
        }

        public enum Locations
        {
            Hand,
            Deck,
            Discard
        }

        public enum AliasCategories
        {
            Adj,
            Verb,
            Noun,
            Subject,
            Object
        }

        // SignalR Responses
        public const string SUCCESS = "SUCCESS";
    }
}
