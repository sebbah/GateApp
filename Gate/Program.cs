using GateApp.CardDb;
using System;

namespace GateApp
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Card card = new Card();
            card.Initialize();

            //Clients - check charge cards
            UsedCard(card, "4939343855088508");
            UsedCard(card, "4939343855088508");
            UsedCard(card, "1298343855088508");
            UsedCard(card, "4868577954451001");
            UsedCard(card, "4868577954451001");
            UsedCard(card, "4868577954451001");
            UsedCard(card, "4868577954451001");
            UsedCard(card, "4868577954451001");
            UsedCard(card, "4868577954451003");

            //Check card numbers
            ValidateCardNumber("4417123456789113");
            ValidateCardNumber("4868577954451001");
            ValidateCardNumber("48A8577954451001");

            Console.ReadKey();
        }

        private static void UsedCard(Card card, string usedCard)
        {
            if (card.GetPosition(usedCard) == -1)
            {
                Console.WriteLine("It's not possible to use card {0}", usedCard);
                return;
            }

            double onePoint = Cost.CostProvider.GetCost();

            if (card.Transaction(usedCard, onePoint))
                Console.WriteLine("OK, Charged. User: {0}, Balance: {1}", card.GetUser(usedCard), card.GetBalance(usedCard));
            else
                Console.WriteLine("NO ENTRY. User: {0}, Balance: {1}", card.GetUser(usedCard), card.GetBalance(usedCard));
        }

        private static void ValidateCardNumber(string CardNo)
        {
            Console.WriteLine("{0} is {1}", CardNo, CardValidator.CheckCardNumber(CardNo));
        }
    }
}
