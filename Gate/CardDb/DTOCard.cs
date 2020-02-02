using System;
using System.Collections.Generic;
using System.Text;

namespace GateApp.CardDb
{
    public class DTOCard
    {
        //internal double balance;
        private string m_cardId;
        private string m_userId;
        private double m_balance;
        private string m_lastUsed;
        private bool m_useable;

        public DTOCard(string cardId, string userId, double balance, string lastUsed)
        {
            m_cardId = cardId;
            m_userId = userId;
            m_balance = balance;
            m_lastUsed = lastUsed;
            m_useable = true; // TODO: prepare impl.
        }

        public double GetBalance()
        {
            return m_balance;
        }

        public string GetCardId()
        {
            return m_cardId;
        }

        public string GetUser()
        {
            return m_userId;
        }

        public bool Charge(double charge)
        {
            if (m_balance < charge)
                return false;

            m_balance -= charge;
            m_lastUsed = DateTime.Now.ToString();

            return true;
        }
    }
}
