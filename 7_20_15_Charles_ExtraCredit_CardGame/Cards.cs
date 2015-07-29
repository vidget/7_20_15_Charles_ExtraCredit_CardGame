using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_20_15_Charles_ExtraCredit_CardGame
{
    class Cards
    {
        CryptoRandom rng = new CryptoRandom();
        //Console.WriteLine(rng.Next());
        //Console.WriteLine(rng.Next(10));
        //Console.WriteLine(rng.Next(18, 22));



        List<string> userHand = new List<string>();//holds the userHand strings
        public string playerName { get; set; }//holds the player NAME
        public int[] handValues = { 0, 0, 0, 0, 0 };
        public int[] handSuit = { 0, 0, 0, 0, 0 }; 
        public int[] deckValue ={14,2,3,4,5,6,7,8,9,10,11,12,13,
                                 14,2,3,4,5,6,7,8,9,10,11,12,13,
                                 14,2,3,4,5,6,7,8,9,10,11,12,13,
                                 14,2,3,4,5,6,7,8,9,10,11,12,13};
        public int[] deckSuit ={1,1,1,1,1,1,1,1,1,1,1,1,1,
                                 2,2,2,2,2,2,2,2,2,2,2,2,2,
                                 3,3,3,3,3,3,3,3,3,3,3,3,3,
                                 4,4,4,4,4,4,4,4,4,4,4,4,4};
        //creates a dictionary that holds 52 card strings with unicode card symbol \u0003 = Hearts \u0004 = Diamonds \u0005 = Clubs \u0006 = Spades
        Dictionary<int, string> cards = new Dictionary<int, string>()
            { 
                { 0,"A\u0006"},
                { 1,"2\u0006"},
                { 2,"3\u0006"},
                { 3,"4\u0006"},
                { 4,"5\u0006"},
                { 5,"6\u0006"},
                { 6,"7\u0006"},
                { 7,"8\u0006"},
                { 8,"9\u0006"},
                { 9,"10\u0006"},
                { 10,"J\u0006"},
                { 11,"Q\u0006"},
                { 12,"K\u0006"},
                { 13,"A\u0005"},
                { 14,"2\u0005"},
                { 15,"3\u0005"},
                { 16,"4\u0005"},
                { 17,"5\u0005"},
                { 18,"6\u0005"},
                { 19,"7\u0005"},
                { 20,"8\u0005"},
                { 21,"9\u0005"},
                { 22,"10\u0005"},
                { 23,"J\u0005"},
                { 24,"Q\u0005"},
                { 25,"K\u0005"},
                { 26,"A\u0003"},
                { 27,"2\u0003"},
                { 28,"3\u0003"},
                { 29,"4\u0003"},
                { 30,"5\u0003"},
                { 31,"6\u0003"},
                { 32,"7\u0003"},
                { 33,"8\u0003"},
                { 34,"9\u0003"},
                { 35,"10\u0003"},
                { 36,"J\u0003"},
                { 37,"Q\u0003"},
                { 38,"K\u0003"},
                { 39,"A\u0004"},
                { 40,"2\u0004"},
                { 41,"3\u0004"},
                { 42,"4\u0004"},
                { 43,"5\u0004"},
                { 44,"6\u0004"},
                { 45,"7\u0004"},
                { 46,"8\u0004"},
                { 47,"9\u0004"},
                { 48,"10\u0004"},
                { 49,"J\u0004"},
                { 50,"Q\u0004"},
                { 51,"K\u0004"},
            };

        public Cards()
        {
            playerName = "";

        }


        public void addCardtoHand(int cardNumber)// List<string> userHand)
        {
            userHand.Add(cards[cardNumber]);

            
        }

        public void addCardValue(int cardNumber, int arrayValue)
        {

            handValues[arrayValue] = deckValue[cardNumber];
            handSuit[arrayValue] = deckSuit[cardNumber];
            
        }

        public void sortValueArray()
        {

            Array.Sort(handValues);
            Array.Sort(handSuit);

        }


        public int drawCard()
        {
            //rng.Next(0, 52);

            //generates a random number between 0-51
           //Random random = new Random((int)DateTime.Now.Ticks);//
            int randomNumber = rng.Next(0, 52);
            return randomNumber;

        }

        public void removeCard(int userCard, int[] deck)//removes the card the user drew from the deck by setting the value of the deck array from 1 to 0
        {
            deck[userCard] = 0;
        }

        public void displayHand()//(List<string> userHand)//displays all the strings stored in the userHand list
        {
            Console.WriteLine("\n"+playerName+" your Hand:\n");

            for (int i = 0; i < userHand.Count; i++)
            {
                Console.Write(" " + userHand[i]);
            }
            Console.WriteLine();

           
            ///USED for testing shows card values in the hand
            for (int i = 0; i <5; i++)
            {
                Console.Write(" " + handValues[i]);
            }


        }

        public bool checkIfAvailableCard(int tempCard, int[] deck)//checks to see if the deck array contains a 1 or 0 taken or not, returns a BOOL
        {
            if (deck[tempCard] == 1)
                return false;//card not taken
            else
                return true;// isTaken
        }

        



    }

}

