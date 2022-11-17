using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTest
{

    class Program
    {
        static void Main(string[] args)
        {
            //Add players for testing purposes
            Player playerOne = new Player(
                1000, 
                "PlayerOne", 
                new List<string>( new string[] { "PlayerTwo"}), 
                new Attributes(10, 11, 12, 13));

            Player playerTwo = new Player(
                5000,
                "PlayerTwo",
                new List<String>(new string[] { "PlayerOne"}),
                new Attributes(13, 12, 11, 10));

            Player playerThree = new Player(
                1000,
                "PlayerThree",
                new List<String>(new string[] { }),
                new Attributes("Wizard"));

            //Run some tests for sanity check

            //Case 1, test increment coins and stat
            Console.WriteLine("TEST 1");
            Console.WriteLine("Printing initial info for PlayerOne");
            Console.WriteLine(playerOne.ToString());

            Console.WriteLine("Giving PlayerOne 1000 more coins and increment Strength by 15");
            playerOne.IncrementCoins(1000);
            playerOne.IncrementStat("Strength", 15);

            Console.WriteLine("Printing new info for PlayerOne");
            Console.WriteLine(playerOne.ToString());

            Console.WriteLine("-------------------------");

            //Case 2, test update coins and stat and add friend
            Console.WriteLine("TEST 2");
            Console.WriteLine("Printing initial info for PlayerTwo");
            Console.WriteLine(playerTwo.ToString());

            Console.WriteLine("Set PlayerTwo's coins to 3000 and Dexterity to 10 by absolute value");
            playerTwo.UpdateCoins(3000);
            playerTwo.UpdateStat("Dexterity", 10);

            Console.WriteLine("Add PlayerThree as friend");
            playerTwo.AddFriend("PlayerThree");

            Console.WriteLine("Printing new info for PlayerTwo");
            Console.WriteLine(playerTwo.ToString());

            Console.WriteLine("-------------------------");

            //Case 3, use illegal values to trigger exceptions
            Console.WriteLine("TEST 3");
            Console.WriteLine("Printing initial info for PlayerThree");
            Console.WriteLine(playerThree.ToString());

            Console.WriteLine("Now to set illegal values for PlayerThree");
            try
            {
                playerThree.UpdateStat("Endurance", 51);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                playerThree.AddFriend("PlayerThree");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                playerThree.IncrementStat("Intelligence", 40);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Printing new info for PlayerThree, but should be the same because of error");
            Console.WriteLine(playerThree.ToString());

            Console.WriteLine("-------------------------");

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }

    }
}
