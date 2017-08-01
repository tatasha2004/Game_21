using System;

namespace Game_21
{
    enum Ranks
    {
        Six = 6, Seven, Eight, Nine, Ten, Jack = 2, Queen, King, Ace = 11
    }

    enum Colors
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    struct Card
    {
        public Colors Color;
        public Ranks Rank;
    }

    struct Deck
    {
        public Card[] Cards;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Colors[] cardColor = (Colors[])Enum.GetValues(typeof(Colors));
            Ranks[] cardRank = (Ranks[])Enum.GetValues(typeof(Ranks));

            int colorLength = cardColor.Length;
            int rankLength = cardRank.Length;
            int numberOfCards = colorLength * rankLength;

            Deck Deck = new Deck();
            //Deck.Cards = new Card[Enum.GetValues(typeof(Colors)).Length * Enum.GetValues(typeof(Ranks)).Length];
            Deck.Cards = new Card[numberOfCards];

            for (int c = 0; c < colorLength; c++)
            {
                int i = c * rankLength;

                for (int r = 0; r < rankLength; r++)
                {
                    /*Deck.Cards[i].Color = (Colors)Enum.GetValues(typeof(Colors)).GetValue(c);  // приведение типа к Enum
                    Deck.Cards[i].Rank = (Ranks)Enum.GetValues(typeof(Ranks)).GetValue(r);*/
                    Deck.Cards[i].Color = cardColor[c];  // приведение типа к Enum
                    Deck.Cards[i].Rank = cardRank[r];
                    i++;
                }
            };

            Random random = new Random();
            for (int i = Deck.Cards.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                Card temp = Deck.Cards[j];
                Deck.Cards[j] = Deck.Cards[i];
                Deck.Cards[i] = temp;
            }

            int scorePlayer = 0;
            int scorePC = 0;
            int winsPlayer = 0;
            int winsPC = 0;
            const int defaultQtyOfCardsPlayer = 2;
            const int defaultQtyOfCardsPC = 2;
            int qtyOfCards;
            string oneMore;
            string selectFirstPlayer;

            Deck Player = new Deck();
            Player.Cards = new Card[17];
            Deck PC = new Deck();
            PC.Cards = new Card[17];


            Console.WriteLine("who receives first cards? You - enter Y, PC - enter N");
            selectFirstPlayer = Console.ReadLine();

            if (selectFirstPlayer == "Y" || selectFirstPlayer == "y")
            {
                for (int i = 0; i < defaultQtyOfCardsPlayer; i++)
                {
                    Player.Cards[i] = Deck.Cards[i];
                    scorePlayer += Convert.ToInt32(Player.Cards[i].Rank);
                    Console.WriteLine(Player.Cards[i].Color);
                    Console.WriteLine(Player.Cards[i].Rank);
                }
                Console.WriteLine();
                Console.WriteLine("***** Your score is: " + scorePlayer + " *****");
                Console.WriteLine();

                for (int i = 0; i < defaultQtyOfCardsPC; i++)
                {
                    PC.Cards[i] = Deck.Cards[i + 1];
                    scorePC += Convert.ToInt32(PC.Cards[i].Rank);
                    Console.WriteLine(PC.Cards[i].Color);
                    Console.WriteLine(PC.Cards[i].Rank);
                }
                Console.WriteLine();
                Console.WriteLine("***** PC score is: " + scorePC + " *****");
                Console.WriteLine();

                if ((scorePlayer == 21) || (Player.Cards[0].Rank == Ranks.Ace && Player.Cards[1].Rank == Ranks.Ace))
                {
                    Console.WriteLine("***** YOU WONG! *****");
                    winsPlayer++;
                }

                else
                {
                    qtyOfCards = defaultQtyOfCardsPlayer + defaultQtyOfCardsPC;

                    do
                    {
                        Console.WriteLine("????? Do you need one more card? ????? Y/N");
                        oneMore = Console.ReadLine();
                    }
                    while (oneMore == "N" || oneMore == "n");


                    while (oneMore == "Y" || oneMore == "y")
                    {
                        {
                            Player.Cards[defaultQtyOfCardsPlayer + 1] = Deck.Cards[qtyOfCards + 1];
                            scorePlayer += Convert.ToInt32(Player.Cards[defaultQtyOfCardsPlayer + 1].Rank);
                            Console.WriteLine("Your card is:");
                            Console.WriteLine(Player.Cards[defaultQtyOfCardsPlayer + 1].Color);
                            Console.WriteLine(Player.Cards[defaultQtyOfCardsPlayer + 1].Rank);
                            qtyOfCards++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("***** Your score is: " + scorePlayer + " *****");
                        Console.WriteLine();

                        if (scorePlayer == 21)
                        {
                            Console.WriteLine("***** YOU WONG! *****");
                            winsPlayer++;
                        }
                        else
                        {
                            Console.WriteLine("????? Do you need one more card? ????? Y/N");
                            oneMore = Console.ReadLine();
                        }
                    }

                    while (oneMore == "N" || oneMore == "n")
                    {
                        while (scorePC <= 20)
                        {
                            Console.WriteLine("-----PC will get new card------");
                            PC.Cards[defaultQtyOfCardsPC + 1] = Deck.Cards[qtyOfCards + 1];
                            scorePC += Convert.ToInt32(PC.Cards[defaultQtyOfCardsPC + 1].Rank);
                            Console.WriteLine("PC card is:");
                            Console.WriteLine(PC.Cards[defaultQtyOfCardsPC + 1].Color);
                            Console.WriteLine(PC.Cards[defaultQtyOfCardsPC + 1].Rank);
                            qtyOfCards++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("***** PC score is: " + scorePC + " *****");
                        Console.WriteLine();

                        if (scorePC == 21)
                        {
                            Console.WriteLine("***** PC WONG! *****");
                            winsPC++;
                        }

                        else if ((scorePlayer > 21 && scorePC > 21 && scorePlayer < scorePC) ||
                                 (scorePlayer < 21 && scorePC < 21 && scorePlayer > scorePC) ||
                                 (scorePlayer < 21 && scorePC > 21))
                        {
                            Console.WriteLine("***** YOU WONG! *****");
                            winsPlayer++;
                        }
                        else
                        {
                            Console.WriteLine("***** PC WONG! *****");
                            winsPC++;
                        }
                        Console.ReadLine();
                    }
                }
            }

            ///PC first
            else
            {
                for (int i = 0; i < defaultQtyOfCardsPC; i++)
                {
                    PC.Cards[i] = Deck.Cards[i];
                    scorePC += Convert.ToInt32(PC.Cards[i].Rank);
                    Console.WriteLine(PC.Cards[i].Color);
                    Console.WriteLine(PC.Cards[i].Rank);
                }
                Console.WriteLine();
                Console.WriteLine("***** PC score is: " + scorePC + " *****");
                Console.WriteLine();

                for (int i = 0; i < defaultQtyOfCardsPlayer; i++)
                {
                    Player.Cards[i] = Deck.Cards[i + 1];
                    scorePlayer += Convert.ToInt32(Player.Cards[i].Rank);
                    Console.WriteLine(Player.Cards[i].Color);
                    Console.WriteLine(Player.Cards[i].Rank);
                }
                Console.WriteLine();
                Console.WriteLine("***** Your score is: " + scorePlayer + " *****");
                Console.WriteLine();

                if (scorePlayer == scorePC)
                {
                    Console.WriteLine("scorePlayer == scorePC");
                }

                else if (scorePlayer == 21 || (Player.Cards[0].Rank == Ranks.Ace && Player.Cards[1].Rank == Ranks.Ace))
                {
                    Console.WriteLine("***** YOU WONG! *****");
                    winsPlayer++;
                }
                else if (scorePC == 21 || (PC.Cards[0].Rank == Ranks.Ace && PC.Cards[1].Rank == Ranks.Ace))
                {
                    Console.WriteLine("***** PC WONG! *****");
                    winsPC++;
                }

                else
                {
                    qtyOfCards = defaultQtyOfCardsPlayer + defaultQtyOfCardsPC;
                    while (scorePC <= 20)
                    {
                        Console.WriteLine("-----PC will get new card------");
                        PC.Cards[defaultQtyOfCardsPC + 1] = Deck.Cards[qtyOfCards + 1];
                        scorePC += Convert.ToInt32(PC.Cards[defaultQtyOfCardsPC + 1].Rank);
                        Console.WriteLine("Your card is:");
                        Console.WriteLine(PC.Cards[defaultQtyOfCardsPC + 1].Color);
                        Console.WriteLine(PC.Cards[defaultQtyOfCardsPC + 1].Rank);
                        qtyOfCards++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("***** PC score is: " + scorePC + " *****");
                    Console.WriteLine();

                    if (scorePC == 21)
                    {
                        Console.WriteLine("***** PC WONG! *****");
                        winsPC++;
                    }

                    else
                    {
                        do
                        {
                            Console.WriteLine("????? Do you need one more card? ????? Y/N");
                            oneMore = Console.ReadLine();
                        }
                        while (oneMore == "N" || oneMore == "n");

                        while (oneMore == "Y" || oneMore == "y")
                        {
                            {
                                Player.Cards[defaultQtyOfCardsPlayer + 1] = Deck.Cards[qtyOfCards + 1];
                                scorePlayer += Convert.ToInt32(Player.Cards[defaultQtyOfCardsPlayer + 1].Rank);
                                Console.WriteLine("Your card is:");
                                Console.WriteLine(Player.Cards[defaultQtyOfCardsPlayer + 1].Color);
                                Console.WriteLine(Player.Cards[defaultQtyOfCardsPlayer + 1].Rank);
                                qtyOfCards++;
                            }
                            Console.WriteLine();
                            Console.WriteLine("***** Your score is: " + scorePlayer + " *****");
                            Console.WriteLine();

                            if (scorePlayer == 21)
                            {
                                Console.WriteLine("***** YOU WONG! *****");
                                winsPlayer++;
                            }
                            else
                            {
                                Console.WriteLine("????? Do you need one more card? ????? Y/N");
                                oneMore = Console.ReadLine();
                            }
                        }

                        while (oneMore == "N" || oneMore == "n")
                        {
                            if ((scorePlayer > 21 && scorePC > 21 && scorePlayer < scorePC) ||
                                     (scorePlayer < 21 && scorePC < 21 && scorePlayer > scorePC) ||
                                     (scorePlayer < 21 && scorePC > 21))
                            {
                                Console.WriteLine("***** YOU WONG! *****");
                                winsPlayer++;
                            }
                            else
                            {
                                Console.WriteLine("***** PC WONG! *****");
                                winsPC++;
                            }
                            Console.ReadLine();
                        }

                    }
                }
            }
        }

    }
}



