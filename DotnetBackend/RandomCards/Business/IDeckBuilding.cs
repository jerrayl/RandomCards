using RandomCards.Models;
using System.Collections.Generic;

namespace RandomCards.Business
{
    public interface IDeckBuilding
    {
        List<ClassModel> GetClasses();
        List<DeckModel> GetDecks(int accountId);
        List<CardModel> CreateDeck(int accountId, string className, string deckName, out string errorMessage);
        List<CardModel> GetDeckCards(int accountId, string deckIdentifier, out string errorMessage);
        void SelectCard(int accountId, string cardIdentifier, out string errorMessage);

        // TEMP FOR TESTING
        List<int> GetAccountIds();
    }
}
