using GateApp.CardDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace GateApp
{
    class Card
    {
        RepoCard repoCard = new RepoCard();
        public void Initialize()
        {
            // LoadDataFromFile();

            // temp
            //b
            repoCard.Add(new DTOCard("4939343855088508", "user 1", 2.99, ""));
            repoCard.Add(new DTOCard("4868577954451001", "user 2", 232.99, ""));
            repoCard.Add(new DTOCard("4002270321510546", "user 3", 100.0, ""));
            repoCard.Add(new DTOCard("4817814009227686", "user 4", 0.00, ""));
            repoCard.Add(new DTOCard("4901396770289340", "user 5", 15190.91, ""));
            //e
        }

        
        public int GetPosition(string cardId)
        {
            return repoCard.GetPosition(cardId);
        }
        
        public bool Transaction(string cardId, double amount)
        {
            return repoCard.Get(GetPosition(cardId)).Charge(amount);
        }

        public double GetBalance(string cardId)
        {
            int client = GetPosition(cardId);
            if (client != -1)
                return repoCard.Get(client).GetBalance();

            Console.WriteLine("! GetBalance"); //TODO: Assert
            return 0.0;
        }

        public string GetUser(string cardId)
        {
            int client = GetPosition(cardId);
            if (client != -1)
                return repoCard.Get(client).GetUser();

            Console.WriteLine("! GetUser"); //TODO: Assert
            return "";
        }
    }
}
