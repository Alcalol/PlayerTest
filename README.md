An implementaion of a simple player object for a game

Original spec: Design a player class which has the following properties
- Currency (coins)
- Username
- Friends list
- Stats (Dictionary of String,int)

Design decisions:
- Attributes class was created to separate out stats from the player object because stats may potentially be used by entities other than players (eg. NPCs), as such it seems to make sense to create a class on its own.  However, the original requirement of the stats being stored in a dictionary of <String, int> is still fulfilled inside the Attributes class.
- A list was chosen to impliment the friends list due to the simplicity to add and remove objects for this example, however it may be better to use an array in a production environment for most efficient memory usage.
- Methods to both increment and set stat or coin values were implemented, as either may be useful at times.
- Specific settings and values abstracted into variables defined at the top of classes as much as possible to minimize chance for a mistake, and provides a centralized place to edit them that will ensure it is propagated everywhere without risk of missing any locations.
- Basic validations implemented inc. exception throwing, with actual values also abstracted to the top of classes for the same reason as above point
- Increment methods returns the new value to the user, as they may be interested in knowing
- An overload constructor method was added to the Attributes class to easily generate stats objects with "template" values, such as if a user started a new character and chose a pre-defined class (eg. Wizard).

ps. Originally considered separating out a Currency and Wallet class as well in case more than 1 currency exists in the game in the future, but decided against it as it is probably outside the scope of this project

Testing:
A simple set of tests were also written in the main method to demonstrate that the code appears be working as intended, but it is by no means an exhaustive test, nor is it the way I would implement tests in a real system, it is only meant as a visual demonstration.

Public properties/methods for external calls:
  - Player Class:
    - Coins
    - Username
    - SetCoins()
    - IncrementCoins()
    - GetFriends()
    - AddFriend()
    - GetStats()
    - GetStatByName()
    - SetStat()
    - IncrementStat()
    - ToString()
  - Attributes Class:
    - Strength
    - Magic
    - Dexterity
    - Endurance
    - GetAllStats()
    - GetStatByName()
    - SetStat()
    - IncrementStat()
    - ToString()
