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
            // create a INT array that holds a deck of 52 cards (1 = card in deck, 0 = card already drawn)
            int[] deck = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                           1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 
                           1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
           // List<string> userHand = new List<string>();//userhand holds the string of the card number & suit drawn by the user
            List<Cards> gameUser = new List<Cards>();//not really used in this program, but will be used in the multiplayer version. 
            getNumOfPlayers(gameUser);//calls the method to load the GAMEUSER list with players
            drawCards(gameUser,deck);//calls the drawCards sends the gameUser & the deck
            Console.ReadLine();//pause to read
        }








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
                for (int i = 0; i < numberOfDraws; i++)//loops through the selecting cards, adding to hand and removing from the deck
                {
                    do//This will loop until the random number generates an available card.
                    {
                        tempCard = gameUser[x].drawCard(); //drawCard Method generates a random number between 1&52
                        isCardGone = gameUser[x].checkIfAvailableCard(tempCard, deck);//sends deck & drawn card to method to check if card drawn is still in deck, returns true if card has already been drawn
                    } while (isCardGone == true); ////check that card hasn't been drawn yet

                    gameUser[x].addCardtoHand(tempCard);//add the card to the userHand
                    gameUser[x].removeCard(tempCard, deck);//remove card from the deck
                }
                gameUser[x].displayHand();//display the users hand.
            }
        }
    }
}
