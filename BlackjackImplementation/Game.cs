using System;
using System.Collections.Generic;

namespace BlackjackImplementation
{
    public class Game
    {
        public int CuttentPlayerCount = 0;
        public int RoundCount = 0;
        public Player WinnerPlayer;
        public List<GenericCards> GameCards = new List<GenericCards>();
        public List<Player> Players = new List<Player>();
        public Game()
        {
            GenerateAllCards();
           
            StartGame(2);
        }

        public void GeneratePlayers(int playerCount)
        {
            for (int i = 0; i <= playerCount; i++)
            {
                Players.Add(new Player());
            }
        }

        public void StartGame(int playerCount)
        {
            GeneratePlayers(playerCount);
            this.CuttentPlayerCount = playerCount;
            DistrubeFirstRoundCards();
        }

        public void TickRound()
        {
            if(WinnerPlayer != null)
            {
                PresentWinner(WinnerPlayer);
                return;
            }
            List<Player> losers = new List<Player>();
            foreach (var player in Players)
            {
                if (player.PlayerPoint > 21)
                    losers.Add(player);

                if (player.PlayerPoint == 21)
                    WinnerPlayer = player;
            }

            foreach (var loser in losers)
            {
                Players.Remove(loser);
            }

            if (Players.Count == 1)
                WinnerPlayer = Players[0];

            if (WinnerPlayer != null)
                PresentWinner(WinnerPlayer);
            else
            {
                foreach (var player in Players)
                {
                    GiveCard(player);
                }
                
            }

            CuttentPlayerCount = Players.Count;

        }

        public void PresentWinner(Player player)
        {
            Console.WriteLine("The Winner Point is " + player.PlayerPoint);
        }

        public void DistrubeFirstRoundCards()
        {
            foreach (var item in Players)
            {
                GiveCard(item);
                GiveCard(item);
            }
            TickRound();
        }

        public void GiveCard(Player player)
        {
           
            Random random = new Random();
            int i = random.Next(GameCards.Count);
            if(GameCards[i] == null)
                GiveCard(player);
            player.PlayerHands.Add(GameCards[i]);
            GameCards.RemoveAt(i);
            UpdatePlayerPoint(player);
        }

        public void UpdatePlayerPoint(Player player)
        {
            foreach (var card in player.PlayerHands)
            {
                player.AddPoint((int)card.CardNumber);
            }
        }

        public void GenerateAllCards()
        {
            for (int i = 1; i <= 13; i++)
            {
                for (int t = 0; t <= 3; t++)
                {
                    GameCards.Add(new GenericCards((CardNumbers)i,(CardSymbols)t));
                }
            }
        }
    }
}
