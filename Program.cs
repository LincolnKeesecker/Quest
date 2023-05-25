using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static int GamesPlayed = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name Adventurer: ");
            string name = Console.ReadLine();
            Game(name);
        }

        static void Game(string name)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Console.WriteLine();

            Robe adventurerRobe = new Robe()
            {
                Colors = new List<string>
                    {
                        "Gold",
                        "Blue",
                        "Blurple"
                    },
                Length = 100
            };

            Hat myHat = new Hat(60);

            Prize prize = new Prize("A new Rubber Ducky!");

            // Make a new "Adventurer" object using the "Adventurer" class
            Adventurer theAdventurer = new Adventurer(name, adventurerRobe, myHat);

            theAdventurer.Awesomeness = (50 + 10 * GamesPlayed);

            Console.WriteLine(theAdventurer.GetDescription());
            Console.WriteLine();
            Console.WriteLine($"Your current Awesomeness level is: {theAdventurer.Awesomeness}");
            Console.WriteLine();

            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            Challenge war = new Challenge(
                "What year did The War of 1812 start?", 1812, 10);

            Challenge predators = new Challenge(
                "In what year was the NHL Hockey team The Predators' inaugural season", 1998, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of? (1-10)", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
                1) John
                2) Paul
                3) George
                4) Ringo
                ",
                4, 20
            );

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;


            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                predators,
                war
            };

            List<int> indicies = new List<int>();

            List<Challenge> usedChallenges = new List<Challenge>();

            while (indicies.Count < 5)
            {
                Random r = new Random();
                int candidate = r.Next(0, challenges.Count - 1);
                if (!indicies.Contains(candidate))
                {
                    indicies.Add(candidate);
                }
            }

            for (int i = 0; i < indicies.Count; i++)
            {
                int index = indicies[i];
                usedChallenges.Add(challenges[index]);
            }

            // Loop through all the challenges and subject the Adventurer to them
            foreach (Challenge challenge in usedChallenges)
            {
                challenge.RunChallenge(theAdventurer);
            }


            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }
            Console.WriteLine();

            prize.ShowPrize(theAdventurer);

            // Ask the Adventurer if they would like to repeat the quest
            Console.WriteLine("Would you like to repeat this quest? (yes/no):");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "yes")
            {
                GamesPlayed += 1;
                Game(name);
            }
        }
    }
}