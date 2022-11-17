using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTest
{
    //Player class defining a player in game

    //Class contains:
    //- How many coins does user hold?
    //- Player's username (String)
    //- Player's friends (Array of String)
    //- Player's stats (Stats object, but Dictionary<String, int> inside)

    class Player
    {
        //************
        //Class settings
        //************
        private int _playerNameMinLength = 5;
        private int _playerNameMaxLength = 20;

        //************
        //Properties
        //************

        //Private properties
        private List<String> _friends;  //Player's friends list
        private Attributes _stats;  //Player's stats

        //Public properties
        public int Coins { get; set; }  //Coins amount
        public string Username { get; private set; }  //Player's username


        //************
        //Constructors
        //************
        public Player(int coins, string userName, List<String> friends, Attributes stats)
        {
            //Validate player name only, as everything else is already validated in their on processes
            ValidatePlayerName(userName);

            //Validation complete, write to variables
            Coins = coins;
            Username = userName;
            _friends = friends;
            _stats = stats;
        }


        //************
        //Methods
        //************
        //No methods for GetCoins and GetUsername as they are already direct native properties

        //Set coins to specific amount
        public void SetCoins(int value)
        {
            //Set the coin to desired value
            Coins = value;
        }

        //Increment coins by a requested amount
        public int IncrementCoins(int increment)
        {
            //Calculate and update coin value
            Coins += increment;

            //Returns new coin count
            return Coins;

        }


        //Returns user's list of friends
        public List<String> GetFriends()
        {
            return _friends;
        }

        //Adds another player to their friends list
        public void AddFriend(string userName)
        {
            if (_friends.Contains(userName))
            {
                //Proposed user already in friends list, raise error
                throw new Exception("User is already in friends list.");
            }
            else if (Username.Equals(userName))
            {
                //User tried to add themselves to friends list, raise error
                throw new Exception("Cannot add yourself as friend!");
            }
            else
            {
                //Perform standard username validation
                ValidatePlayerName(userName);
            }

            //All tests passed, add friend to list
            _friends.Add(userName);
        }

        //Returns all player stats as dictionary
        public Dictionary<String, int> GetStats()
        {
            return _stats.GetAllStats();
        }

        //Returns a specific stat by name
        public int GetStatByName(string attribute)
        {
            return _stats.GetStatByName(attribute);
        }

        //Updates a specific stat by name with absolute value
        public void SetStat(string attributeName, int attributeValue)
        {
            //Call UpdateStat in Attribute class
            _stats.SetStat(attributeName, attributeValue);
        }

        //Updates a specific stat by name by increment
        public int IncrementStat(string attributeName, int increment)
        {
            //Call IncrementStat in Attribute class
            return _stats.IncrementStat(attributeName, increment);
        }

        //Returns player details as string
        public new string ToString()
        {
            string outputString = "";

            //Concat all details and print in readable way
            outputString = "Details for player " + Username + ":" + Environment.NewLine;
            outputString += "Coins: " + Coins + Environment.NewLine;
            outputString += "Friends count: " + _friends.Count + Environment.NewLine;
            outputString += "Stats: " + _stats.ToString();

            return outputString;
        }


        //************
        //Validation
        //************

        //Validate player name
        private void ValidatePlayerName(string playerName)
        {
            if(playerName.Length < _playerNameMinLength || playerName.Length > _playerNameMaxLength)
            {
                //Player name is not the correct length, raise error
                throw new Exception("Player names must be at least " + _playerNameMinLength + " and no more than " + _playerNameMaxLength + " characters.");
            }
        }

    }
}
