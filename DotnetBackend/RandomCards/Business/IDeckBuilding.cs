using RandomCards.Models;
using System.Collections.Generic;

namespace RandomCards.Business
{
    public interface IDeckBuilding
    {
        List<ClassModel> GetClasses(); 
        List<CardModel> CreateDeck(int accountId, string className, string deckName);
        List<CardModel> GetDeckCards(int accountId, string deckIdentifier);
        void SelectCard(int accountId, string deckIdentifier, string cardIdentifier);
    }
}
