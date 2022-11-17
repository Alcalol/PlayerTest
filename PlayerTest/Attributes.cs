using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerTest
{
    //Stats class defining what stats are available
    //This is its own class because potentially
    //entities other than players may use this in the future
    //eg. NPCs.  However the spec of Dictionary<String, int>
    //is still followed here

    //Stats are:
    //-Strength
    //-Magic
    //-Dexterity
    //-Endurance

    class Attributes
    {
        //************
        //Class settings
        //************
        private int _attributeMin = 1;  //The min value an attribute can be
        private int _attributeMax = 50; //The max value an attribute can be


        //************
        //Properties
        //************

        //Private properties
        private Dictionary<String, int> _statsDictionary; //Dictionary that stores all stats

        //Public properties
        //Gets or sets Strength attribute
        public int Strength
        {
            get => _statsDictionary["Strength"];
            set
            {
                //Validate value and set
                ValidateAttribute("Strength", value);
                _statsDictionary["Strength"] = value;
            }
        }

        //Gets or sets Magic attribute
        public int Magic
        {
            get => _statsDictionary["Magic"];
            set
            {
                //Validate value and set
                ValidateAttribute("Magic", value);
                _statsDictionary["Magic"] = value;
            }
        }

        //Gets or sets Dexterity attribute
        public int Dexterity
        {
            get => _statsDictionary["Dexterity"];
            set
            {
                //Validate value and set
                ValidateAttribute("Dexterity", value);
                _statsDictionary["Dexterity"] = value;
            }
        }

        //Gets or sets Endurance attribute
        public int Endurance
        {
            get => _statsDictionary["Endurance"];
            set
            {
                //Validate value and set
                ValidateAttribute("Endurance", value);
                _statsDictionary["Endurance"] = value;
            }
        }

        //************
        //Constructors
        //************
        public Attributes(int strength, int magic, int dexterity, int endurance)
        {
            //Constructor method to initialize stats object

            //Initialize dictionary
            _statsDictionary = new Dictionary<string, int>();

            //First validate all values
            ValidateAll(strength, magic, dexterity, endurance);

            //If we're here values are legal, proceed to add values to dictionary
            Strength = strength;
            Magic = magic;
            Dexterity = dexterity;
            Endurance = endurance;
        }

        public Attributes(string playerClass)
        {
            //Method overload example for default settings, such as starting a new character

            //Initialize dictionary
            _statsDictionary = new Dictionary<string, int>();

            //Validation not done, assuming default values are legal
            switch (playerClass)
            {
                case "Wizard":
                    //Apply default settings for wizard
                    Strength = 5;
                    Magic = 20;
                    Dexterity = 15;
                    Endurance = 7;
                    break;
            }
        }

        //************
        //Methods
        //************

        //Returns all stats
        public Dictionary<String, int> GetAllStats()
        {
            return _statsDictionary;
        }

        //Get a specific stat by name
        public int GetStatByName(string attribute)
        {
            return _statsDictionary[attribute];
        }

        //Updates a specific stat by name with absolute value
        public void UpdateStat(string attributeName, int attributeValue)
        {
            //First check that the requested attribute name exists
            if (_statsDictionary.ContainsKey(attributeName))
            {
                //Validate value to make sure it's legal
                ValidateAttribute(attributeName, attributeValue);

                //Validated, perform update
                _statsDictionary[attributeName] = attributeValue;
            }
        }

        //Updates a specific stat by name by increment
        public int IncrementStat(string attributeName, int increment)
        {
            //First check that the requested attribute name exists
            if (_statsDictionary.ContainsKey(attributeName))
            {
                //Calculate desired value
                int result = _statsDictionary[attributeName] + increment;

                //Validate value to make sure it's legal
                ValidateAttribute(attributeName, result);

                //Validated, perform update
                _statsDictionary[attributeName] = result;

                return result;
            }
            else
            {
                //If the attribute doesn't exist in dictionary, throw error
                throw new Exception("Specified stat " + attributeName + " could not be found.");
            }
        }

        //Returns stats as string
        public new string ToString()
        {
            //Concat all details and print in readable way
            return "Strength: " + Strength + ", Magic: " + Magic + ", Dexterity: " + Dexterity + ", Endurance: " + Endurance;
        }



        //************
        //Validation
        //************

        //Global validation method because all attributes
        //currently conforms to the same rule.  Can have
        //multiple methods for different attributes later

        //Method to validate all attributes using ValidateAttribute
        private void ValidateAll(int strength, int magic, int dexterity, int endurance)
        {
            ValidateAttribute("Strength", strength);
            ValidateAttribute("Magic", magic);
            ValidateAttribute("Dexterity", dexterity);
            ValidateAttribute("Endurance", endurance);
        }

        //Method to validate a single attribute
        private void ValidateAttribute(string attributeName, int attributeValue)
        {
            
            if (attributeValue < _attributeMin)
            {
                //Value is below allowed range, raise error
                throw new Exception("Attribute " + attributeName + " cannot be below " + _attributeMin);
            }
            else if (attributeValue > _attributeMax)
            {
                //Value is above allowed range, raise error
                throw new Exception("Attribute " + attributeName + " cannot be above " + _attributeMax);
            }
        }
    }
}
