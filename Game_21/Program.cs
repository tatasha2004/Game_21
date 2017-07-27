using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_21
{
    enum Ranks
    {
        six = 6, seven, eight, nine, ten, Jack = 2, Queen, King, Ace = 11
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
            Deck Deck = new Deck();
            Deck.Cards = new Card[Enum.GetValues(typeof(Colors)).Length * Enum.GetValues(typeof(Ranks)).Length];


            for (int c = 0; c < Enum.GetValues(typeof(Colors)).Length; c++)
            {
                int i = c * Enum.GetValues(typeof(Ranks)).Length;

                for (int r = 0; r < Enum.GetValues(typeof(Ranks)).Length; r++)
                {
                    Deck.Cards[i].Color = (Colors)Enum.GetValues(typeof(Colors)).GetValue(c);  // приведение типа к Enum
                    Deck.Cards[i].Rank = (Ranks)Enum.GetValues(typeof(Ranks)).GetValue(r);
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

            //Вывод перемешенной колоды карт
            /* Console.WriteLine("Вывод перемешенной колоды карт");
             for (int z = 1; z <= 36; z++)
             {
                   Console.WriteLine("---index " + (z - 1) + " ---");
                   Console.WriteLine(Deck.Cards[z - 1].Color);
                   Console.WriteLine(Deck.Cards[z - 1].Rank);
             }*/

            int scorePlayer = 0;
            int scorePC = 0;
            int winsPlayer = 0;
            int winsPC = 0;
            int defaultQtyOfCartsPlayer = 2;
            int defaultQtyOfCartsPC = 2;
            int qtyOfCarts;
            string oneMore;

            Deck Player = new Deck();
            Player.Cards = new Card[18];
            Deck PC = new Deck();
            PC.Cards = new Card[18];

            Console.WriteLine("who receives first cards? You - enter Y, PC - enter N");
            string selectFirstPlayer = Console.ReadLine();

            if (selectFirstPlayer == "Y" || selectFirstPlayer == "y")
            {
                for (int i = 0; i < defaultQtyOfCartsPlayer; i++)
                {
                    Player.Cards[i] = Deck.Cards[i];
                    scorePlayer += Convert.ToInt32(Player.Cards[i].Rank);
                    Console.WriteLine(Player.Cards[i].Color);
                    Console.WriteLine(Player.Cards[i].Rank);
                }
                Console.WriteLine();
                Console.WriteLine("***** Your score is: " + scorePlayer + " *****");
                Console.WriteLine();

                for (int i = 0; i < defaultQtyOfCartsPC; i++)
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

                qtyOfCarts = defaultQtyOfCartsPlayer + defaultQtyOfCartsPC;

                Console.WriteLine("????? Do you need one more cart? ????? Y/N");
                oneMore = Console.ReadLine();

                if (oneMore == "N" || oneMore == "n")
                {
                    while (scorePC <= 20)
                    {
                        Console.WriteLine("-----PC will get new cart------");
                        PC.Cards[defaultQtyOfCartsPC + 1] = Deck.Cards[qtyOfCarts + 1];
                        scorePC += Convert.ToInt32(PC.Cards[defaultQtyOfCartsPC + 1].Rank);
                        Console.WriteLine("Your cart is:");
                        Console.WriteLine(PC.Cards[defaultQtyOfCartsPC + 1].Color);
                        Console.WriteLine(PC.Cards[defaultQtyOfCartsPC + 1].Rank);
                        qtyOfCarts++;
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


                if (oneMore == "Y" || oneMore == "y")
                {
                    Player.Cards[defaultQtyOfCartsPlayer + 1] = Deck.Cards[qtyOfCarts + 1];
                    scorePlayer += Convert.ToInt32(Player.Cards[defaultQtyOfCartsPlayer + 1].Rank);
                    Console.WriteLine("Your cart is:");
                    Console.WriteLine(Player.Cards[defaultQtyOfCartsPlayer + 1].Color);
                    Console.WriteLine(Player.Cards[defaultQtyOfCartsPlayer + 1].Rank);
                    qtyOfCarts++;
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
                    Console.WriteLine("????? Do you need one more cart? ????? Y/N");
                    oneMore = Console.ReadLine();
                }

                if (oneMore == "N" || oneMore == "n")
                {
                    while (scorePC <= 20)
                    {
                        Console.WriteLine("-----PC will get new cart------");
                        PC.Cards[defaultQtyOfCartsPC + 1] = Deck.Cards[qtyOfCarts + 1];
                        scorePC += Convert.ToInt32(PC.Cards[defaultQtyOfCartsPC + 1].Rank);
                        Console.WriteLine("Your cart is:");
                        Console.WriteLine(PC.Cards[defaultQtyOfCartsPC + 1].Color);
                        Console.WriteLine(PC.Cards[defaultQtyOfCartsPC + 1].Rank);
                        qtyOfCarts++;
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
      
            ///PC first
            if (selectFirstPlayer == "N" || selectFirstPlayer == "n")
            {
                for (int i = 0; i < defaultQtyOfCartsPC; i++)
                {
                    PC.Cards[i] = Deck.Cards[i];
                    scorePC += Convert.ToInt32(PC.Cards[i].Rank);
                    Console.WriteLine(PC.Cards[i].Color);
                    Console.WriteLine(PC.Cards[i].Rank);
                }
                Console.WriteLine();
                Console.WriteLine("***** PC score is: " + scorePC + " *****");
                Console.WriteLine();

                for (int i = 0; i < defaultQtyOfCartsPlayer; i++)
                {
                    Player.Cards[i] = Deck.Cards[i + 1];
                    scorePlayer += Convert.ToInt32(Player.Cards[i].Rank);
                    Console.WriteLine(Player.Cards[i].Color);
                    Console.WriteLine(Player.Cards[i].Rank);
                }
                Console.WriteLine();
                Console.WriteLine("***** Your score is: " + scorePlayer + " *****");
                Console.WriteLine();
                // }

                qtyOfCarts = defaultQtyOfCartsPlayer + defaultQtyOfCartsPC;

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

                else if (scorePC <= 20)
                {
                    while (scorePC <= 20)
                    {
                        Console.WriteLine("-----PC will get new cart------");
                        PC.Cards[defaultQtyOfCartsPC + 1] = Deck.Cards[qtyOfCarts + 1];
                        scorePC += Convert.ToInt32(PC.Cards[defaultQtyOfCartsPC + 1].Rank);
                        Console.WriteLine("Your cart is:");
                        Console.WriteLine(PC.Cards[defaultQtyOfCartsPC + 1].Color);
                        Console.WriteLine(PC.Cards[defaultQtyOfCartsPC + 1].Rank);
                        qtyOfCarts++;
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
                        Console.WriteLine("????? Do you need one more cart? ????? Y/N");
                        oneMore = Console.ReadLine();

                        if (oneMore == "N" || oneMore == "n")
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
                        if (oneMore == "Y" || oneMore == "y")

                        {
                            Player.Cards[defaultQtyOfCartsPlayer + 1] = Deck.Cards[qtyOfCarts + 1];
                            scorePlayer += Convert.ToInt32(Player.Cards[defaultQtyOfCartsPlayer + 1].Rank);
                            Console.WriteLine("Your cart is:");
                            Console.WriteLine(Player.Cards[defaultQtyOfCartsPlayer + 1].Color);
                            Console.WriteLine(Player.Cards[defaultQtyOfCartsPlayer + 1].Rank);
                            qtyOfCarts++;
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
                            Console.WriteLine("????? Do you need one more cart? ????? Y/N");
                            oneMore = Console.ReadLine();
                        }

                        if (oneMore == "N" || oneMore == "n")
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
                        if (oneMore == "Y" || oneMore == "y")

                        {
                            Player.Cards[defaultQtyOfCartsPlayer + 1] = Deck.Cards[qtyOfCarts + 1];
                            scorePlayer += Convert.ToInt32(Player.Cards[defaultQtyOfCartsPlayer + 1].Rank);
                            Console.WriteLine("Your cart is:");
                            Console.WriteLine(Player.Cards[defaultQtyOfCartsPlayer + 1].Color);
                            Console.WriteLine(Player.Cards[defaultQtyOfCartsPlayer + 1].Rank);
                            qtyOfCarts++;
                        }
                        Console.WriteLine();
                        Console.WriteLine("***** Your score is: " + scorePlayer + " *****");
                        Console.WriteLine();

                        if (scorePlayer == 21)
                        {
                            Console.WriteLine("***** YOU WONG! *****");
                            winsPlayer++;
                        }
                    }
                }
            }
        }
    }
}


