using System;
using System.Collections.Generic;
using System.Text;

namespace GateApp.CardDb
{
    class RepoCard
    {
        List<DTOCard> m_Card = new List<DTOCard>();

        public RepoCard() {}

        public void Add(DTOCard newCard) => m_Card.Add(newCard);

        public int GetPosition(string cardId)
        {
            for (int i = 0; i < m_Card.Count; i++)
                if (m_Card[i].GetCardId() == cardId)
                    return i;

            return -1;
        }

        public DTOCard Get(int pos) => m_Card[pos];

        //public void Delete(int pos) => m_Card.RemoveAt(pos);
        //public void Update(int pos, DTOCard newAdress)
        //{
        //    Delete(pos);
        //    Add(newAdress);
        //}
    }
}
