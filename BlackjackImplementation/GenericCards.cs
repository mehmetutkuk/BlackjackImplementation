using System;
namespace BlackjackImplementation
{
    public class GenericCards
    {
        public CardNumbers CardNumber { get; set; }

        private CardSymbols CardSymbol { get; set; }

        private CardColors CardColor { get; set; }

        public GenericCards(CardNumbers cardNumber, CardSymbols cardSymbol)
        {
            this.CardSymbol = cardSymbol;
            this.CardNumber = cardNumber;

            if (cardSymbol is CardSymbols.Hearts || cardSymbol is CardSymbols.Diamonds)
                this.CardColor = CardColors.Red;
            else
                this.CardColor = CardColors.Black;
        }
    }

    public enum CardSymbols
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum CardColors
    {
        Black,
        Red
    }

    public enum CardNumbers
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Quen = 12,
        King = 13
    }
}
