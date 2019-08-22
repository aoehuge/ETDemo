using System;
using System.Collections.Generic;
using ETModel;
namespace ETHotfix
{
    public static class CardHelper
    {
        private readonly static List<int> mCards = new List<int>();

        private const int oneStarCardsCount     = 30;
        private const int twoStarCardsCount     = 25;
        private const int threeStarCardsCount   = 20;
        private const int fourStarCardsCount    = 15;
        private const int fiveStarCardsCount    = 10;

        private const int oneStarCardsTypes = 11;
        private const int twoStarCardsTypes = 13;
        private const int threeStarCardsTypes = 11;
        private const int fourStarCardsTypes = 9;
        private const int fiveStarCardsTypes = 6;


        static CardHelper()
        {
            for (int i = 1; i <= oneStarCardsTypes; i++)
            {
                for (int j = 0; j < oneStarCardsCount; j++)
                {
                    mCards.Add(i+1000);
                }
            }

            for (int i = 1; i <= twoStarCardsTypes; i++)
            {
                for (int j = 0; j < twoStarCardsCount; j++)
                {
                    mCards.Add(i+2000);
                }
            }

            for (int i = 1; i <= threeStarCardsTypes; i++)
            {
                for (int j = 0; j < threeStarCardsCount; j++)
                {
                    mCards.Add(i+3000);
                }
            }

            for (int i = 1; i <= fourStarCardsTypes; i++)
            {
                for (int j = 0; j < fourStarCardsCount; j++)
                {
                    mCards.Add(i+4000);
                }
            }

            for (int i = 1; i <= fiveStarCardsTypes; i++)
            {
                for (int j = 0; j < fiveStarCardsCount; j++)
                {
                    mCards.Add(i+5000);
                }
            }

        }



    }
}
