using _7_20_15_Charles_ExtraCredit_CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Gregory Scott Norris - ExperienceIT 7-16-15
//Exercise 2: CardGame adds players 
//Write a program to create a standard 52 card deck and then deal a random hand to a  several players player. Once a card is dealt then it can't be used again.

namespace _7_16_15_ExperIT_Charles_ExtraCredit_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char again = 'Y';
           
                // create a INT array that holds a deck of 52 cards (1 = card in deck, 0 = card already drawn)
                int[] deck = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                           1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 
                           1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                // List<string> userHand = new List<string>();//userhand holds the string of the card number & suit drawn by the user

                List<Cards> gameUser = new List<Cards>();
                getNumOfPlayers(gameUser);//calls the method to load the GAMEUSER list with players
                do
            {

                 drawCards(gameUser, deck);//calls the drawCards sends the gameUser & the deck

                //Console.ReadLine();

                Console.WriteLine("\nWould you like to Deal Again?(Y/N)");
               

                again = Console.ReadKey().KeyChar;

                gameUser.Clear();

            } while (again == 'Y' || again == 'y');
            
        }


        //This method prompts the user for the number of players then add them to the GAMEUSER list
        public static void getNumOfPlayers(List<Cards> gameUser)
        {
            int numberOfPlayers = 0;//user input number of cards to draw
            Console.WriteLine("\n How many PLAYERS would you like to play");//prompts user for number of cards to draw
            Console.Write(" >");//user prompt
            numberOfPlayers = int.Parse(Console.ReadLine());//takes in the number of users, used in FORLOOP while drawing cards
            Console.Clear();
            //adds the selected number of users to the game 
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Cards tempPlayer = new Cards();//creates a CARDS class called tempPlayer and puts it into the LIST GAMEUSER
                gameUser.Add(tempPlayer);
            }

            string tempName;//temp User Name
            for (int i = 0; i < gameUser.Count; i++)
            {
                Console.WriteLine("\n Enter Player #" + (i + 1) + "'s Name");
                Console.Write(" >");//user prompt
                tempName = Console.ReadLine();
                gameUser[i].playerName = tempName;
                Console.Clear();
            }
        }
        public static void drawCards(List<Cards>gameUser, int[] deck)
        {
            int tempCard;//holds the drawn card
            int numberOfDraws = 0;//user input number of cards to draw
            bool isCardGone = true;//determines if a card is available or already taken from the deck

            Console.WriteLine("\n How many cards would you like to draw?");//prompts user for number of cards to draw
            Console.Write(" >");//user prompt
            numberOfDraws = int.Parse(Console.ReadLine());//parses in the user input for number of draws
            Console.Clear();

            for (int x = 0; x < gameUser.Count; x++)
            {
                for (int i = 0; i < 5; i++)//loops through the selecting cards, adding to hand and removing from the deck
                {
                    do//This will loop until the random number generates an available card.
                    {
                        tempCard = gameUser[x].drawCard(); //drawCard Method generates a random number between 1&52
                        isCardGone = gameUser[x].checkIfAvailableCard(tempCard, deck);//sends deck & drawn card to method to check if card drawn is still in deck, returns true if card has already been drawn
                    } while (isCardGone == true); ////check that card hasn't been drawn yet

                    gameUser[x].addCardValue(tempCard,i);//loads the array with the cards value to compare with other users later.
                   
                    gameUser[x].addCardtoHand(tempCard);//add the card to the userHand
                    gameUser[x].removeCard(tempCard, deck);//remove card from the deck
                }
                gameUser[x].sortValueArray();//sorts array in accending order
                gameUser[x].displayHand();//display the users hand.
                valueHand(gameUser, x);

                
            }
        }



        public static  void valueHand(List<Cards> gameUser, int player=0)
        {


            if (isFlush(gameUser, player) && isStraight(gameUser, player))
                Console.WriteLine("Straight Flush");
            else if (isFourOfAKind(gameUser, player))
                Console.WriteLine("4 of a Kind");
            else if (isFullHouse(gameUser, player))
                Console.WriteLine("Full House");
            else if (isFlush(gameUser, player))
                Console.WriteLine("Flush");
            else if (isStraight(gameUser, player))
                Console.WriteLine("Straight");
            else if (isThreeOfAKind(gameUser, player))
                Console.WriteLine("3 of a Kind");
            else if (isTwoPair(gameUser, player))
                Console.WriteLine("2 pair");
            else if (isPair(gameUser, player))
                Console.WriteLine("1 pair");
            else
                Console.WriteLine("HighCard");



            //returns the highest card in the hand
        }

        public static bool isFlush(List<Cards> gameUser, int player)
        {
            bool hasFlush = false;

            if (gameUser[player].handSuit[4] == gameUser[player].handSuit[0])
               hasFlush = true;
            else
               hasFlush = false;


            return hasFlush;
        }


        public static bool isStraight(List<Cards> gameUser, int player)
        {
            bool hasStraight = false;
            int testRank = 0;


            if (gameUser[player].handValues[4] == 14)
            {

                if (gameUser[player].handValues[0] == 2 && gameUser[player].handValues[1] == 3 && gameUser[player].handValues[2] == 4 && gameUser[player].handValues[3] == 5)
                    hasStraight = true;
                if (gameUser[player].handValues[0] == 10 && gameUser[player].handValues[1] == 11 && gameUser[player].handValues[2] == 12 && gameUser[player].handValues[3] == 13)
                    hasStraight = true;
            }

            else
                testRank = gameUser[player].handValues[0] + 1;

            for (int i = 0; i < 5; i++)
            {

                if (gameUser[player].handValues[i] != testRank)
                    return hasStraight = false;
                testRank++;

            }

            return hasStraight;
        }




        public static bool isStraightFlush(List<Cards> gameUser, int player)
        {
            bool hasStraightFlush = false;


            if (isStraight(gameUser, player) && isFlush(gameUser, player))
                hasStraightFlush = true;
            else
                hasStraightFlush = false;

            return hasStraightFlush;
        }



        public static bool isRoyalFlush(List<Cards> gameUser, int player)
        {
            bool hasRoyalFlush = false;


            if (isStraight(gameUser, player) && isFlush(gameUser, player) && gameUser[player].handValues[4] == 14)
                hasRoyalFlush = true;
            else
                hasRoyalFlush = false;

            return hasRoyalFlush;
        }


        public static bool isFourOfAKind(List<Cards> gameUser, int player)
        {
            bool hasFourOfAKind = false;


            if (gameUser[player].handValues[0] == gameUser[player].handValues[1] &&
                gameUser[player].handValues[1] == gameUser[player].handValues[2] &&
                gameUser[player].handValues[2] == gameUser[player].handValues[3])
                hasFourOfAKind = true;
            if (gameUser[player].handValues[1] == gameUser[player].handValues[2] &&
                gameUser[player].handValues[2] == gameUser[player].handValues[3] &&
                gameUser[player].handValues[3] == gameUser[player].handValues[4])
                hasFourOfAKind = true;

            return hasFourOfAKind;

        }


        public static bool isFullHouse(List<Cards> gameUser, int player)
        {
            bool hasFullHouse = false;

            //checking for x x x y y

            if (gameUser[player].handValues[0] == gameUser[player].handValues[1] &&
                gameUser[player].handValues[1] == gameUser[player].handValues[2] &&
                gameUser[player].handValues[3] == gameUser[player].handValues[4])
                hasFullHouse = true;

            //checking for y y x x x
            if (gameUser[player].handValues[0] == gameUser[player].handValues[1] &&
                gameUser[player].handValues[2] == gameUser[player].handValues[3] &&
                gameUser[player].handValues[3] == gameUser[player].handValues[4])
                hasFullHouse = true;

            return hasFullHouse;

        }


        public static bool isThreeOfAKind(List<Cards> gameUser, int player)
        {
            bool hasThreeOfAKind = false;

            if (isFourOfAKind(gameUser, player) || isFullHouse(gameUser, player))
                return (false);


            //checking for x x x a b
            if (gameUser[player].handValues[0] == gameUser[player].handValues[1] &&
                gameUser[player].handValues[1] == gameUser[player].handValues[2])
                hasThreeOfAKind = true;
            //checking for a x x x b
            if (gameUser[player].handValues[1] == gameUser[player].handValues[2] &&
                gameUser[player].handValues[2] == gameUser[player].handValues[3])
                hasThreeOfAKind = true;
            //checking for a b x x x
            if (gameUser[player].handValues[2] == gameUser[player].handValues[3] &&
                gameUser[player].handValues[3] == gameUser[player].handValues[4])
                hasThreeOfAKind = true;


            return hasThreeOfAKind;

        }




        public static bool isTwoPair(List<Cards> gameUser, int player)
        {
            bool hasTwoPair = false;

            if (isFourOfAKind(gameUser, player) || isFullHouse(gameUser, player) || isThreeOfAKind(gameUser, player))
                return (false);//hand not 2 pair but better than


            //checking for a a b b x
            if (gameUser[player].handValues[0] == gameUser[player].handValues[1] &&
                gameUser[player].handValues[2] == gameUser[player].handValues[3])
                hasTwoPair = true;
            //checking for a a x b b
            if (gameUser[player].handValues[0] == gameUser[player].handValues[1] &&
                gameUser[player].handValues[3] == gameUser[player].handValues[4])
                hasTwoPair = true;
            //checking for x a a b b
            if (gameUser[player].handValues[1] == gameUser[player].handValues[2] &&
                gameUser[player].handValues[3] == gameUser[player].handValues[4])
                hasTwoPair = true;


            return hasTwoPair;

        }


        public static bool isPair(List<Cards> gameUser, int player)
        {
            bool hasPair = false;

            if (isFourOfAKind(gameUser, player) || isFullHouse(gameUser, player) || isThreeOfAKind(gameUser, player))
                return (false);//hand not 2 pair but better than


            //checking for a a x y z
            if (gameUser[player].handValues[0] == gameUser[player].handValues[1])
                hasPair = true;
            //checking for x a a y Z
            if (gameUser[player].handValues[1] == gameUser[player].handValues[2])
                hasPair = true;
            //checking for x y a a z
            if (gameUser[player].handValues[2] == gameUser[player].handValues[3])
                hasPair = true;
            //checking for x y z a a
            if (gameUser[player].handValues[3] == gameUser[player].handValues[4])
                hasPair = true;


            return hasPair;

        }

    }
}
