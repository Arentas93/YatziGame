using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YatziGame
{
    class YatziGame
    {
        private Random rng;
        int totalScore;

        public YatziGame()
        {
            rng = new Random();
        }

        public void play()                                              //Start of the game.
        {
            string userChoice;
            userChoice = promptuser();                              //Asking the user if he or she wants to play the game.

            while (userChoice != "Q")                             //While user choice is not to QUIT we are continuing the game.
            {
                int scoreOfThisTurn;
                int[] firstRoll = getFirstRoll();                                               // In this method we are getting first roll of 5 Dices.

                Console.Clear();
                Console.WriteLine("\nYou have rolled 5 Dices!\n");
                displayFirstRoll(firstRoll);                                                  //Dispay of the first roll in the console.

                displayOfPossibleScore(firstRoll);                                          //Display of the possible score after the first roll.
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

                bool playerTakesScore = GetUserDecision();                              //We are getting the decision of the User to take the score or continue playing.
                if (playerTakesScore == true)                                            
                {
                    scoreOfThisTurn = GetScore(firstRoll);                                                               //If playerTakes Score we are geting final score.
                    Console.WriteLine("So The game has came to an end. You have scored {0} points!",scoreOfThisTurn);
                    Console.WriteLine("Press Enter to finish...");
                    Console.ReadLine();
                    userChoice = "Q";                                                                                 // We set UserChoice to string "Q" to exit out of the play mode to program.cs
                }
                else
                {
                    scoreOfThisTurn = ContinueRolling(firstRoll);                                                  //Continuing the Game!
                    Console.WriteLine("So The game has came to an End final score is: {0}!", scoreOfThisTurn);
                    Console.ReadLine();
                    userChoice = "Q";
                }
                
            }                       
        }                           

        private int ContinueRolling(int[] firstRoll)
        {
            Console.Clear();
            displayFirstRoll(firstRoll);
            displayOfPossibleScore(firstRoll);
            int numberOfRollsRemaining = 2;
            int numberOfDicess = 0;
            string PlayerInput;
            int[] NextRolls = firstRoll;
            int NewRollIndex;
            bool PlayerContinuesToPlay = false;
            int finalScore;


            Console.WriteLine("Number of Rolls remaining: {0}\n",numberOfRollsRemaining);
            Console.WriteLine("Enter how many(1-5) dices will you roll for the second time:\n");

            PlayerInput = Console.ReadLine();
            numberOfDicess = int.Parse(PlayerInput);

            int[] reroledDices = new int[numberOfDicess];                       //Array of values of rerroled dices
            int[] reroledIndexes = new int[numberOfDicess];                   //Array of indexes of rerolled dices

            Console.WriteLine("\nSo you would like to roll {0} Dices.\n\nAfter pressing ENTER you will have to insert the index of Dice(s) which you want to reroll...", numberOfDicess);
            Console.ReadLine();

            for (int i = 0; i < numberOfDicess; i++)
            {
                Console.WriteLine("Enter the index(1 - 5) of the Dice:\t\t For example for Dice1 enter: 1 or for Dice3 enter: 3.", i + 1);
                PlayerInput = Console.ReadLine();
                NewRollIndex = int.Parse(PlayerInput);

                NextRolls[NewRollIndex-1] = rng.Next(1, 7);                             //Second table array

                reroledIndexes[i] = NewRollIndex;

                reroledDices[i] = NextRolls[NewRollIndex - 1];                         //Setting the value of reroled dice
            }

            Console.WriteLine(" \n\nYou have Rolled {0} Dice(s):",numberOfDicess);

            for (int i = 0; i < reroledIndexes.Length; i++)
            {
                Console.Write("\nDice{0}: {1}", reroledIndexes[i],reroledDices[i]);
            }

            Console.WriteLine("\n\nTo see the new table press Enter...");
            Console.ReadLine();

            numberOfRollsRemaining--;

            Console.WriteLine("\nAfter the second Roll table looks like this:");
            DisplaySecondRoll(NextRolls);
            displayOfPossibleScore(NextRolls);
            Console.WriteLine("Press Enter To continue...");
            Console.ReadLine();

            PlayerContinuesToPlay = LastPlayerDecision(NextRolls,numberOfRollsRemaining);                           //Here we are getting the final decision to score or continue for the last Roll.

            if (PlayerContinuesToPlay == true)
            {
                Console.Clear();
                DisplaySecondRoll(NextRolls);
                displayOfPossibleScore(NextRolls);
                Console.WriteLine("Number of Rolls remaining: {0}\n", numberOfRollsRemaining);
                Console.WriteLine("Press Enter to Continue the game and roll the Dice(s) for the last time...");
                Console.ReadLine();
                

                finalScore = GetScore(FinalRolling(NextRolls,numberOfRollsRemaining));                          //Getting result out of the final roll
                return finalScore;
            
            }
            else
            {
                finalScore = GetScore(NextRolls);
                return finalScore;
            }
        }                                          //This method returns score after 1 more or 2 more rolls. Includes promt of the user after 2 nd roll.

        private int[] FinalRolling(int[] nextRolls, int numberOfRollsRemaining)
        {
            string finalPlayerInpt;
            int finalNumberOfDices;
            int finalIndexofDices;
            int[] finalTable = nextRolls;

            Console.WriteLine("Enter how many(1-5) dices will you roll for the third time:\n");
            finalPlayerInpt = Console.ReadLine();
            finalNumberOfDices = int.Parse(finalPlayerInpt);

            int[] reroledDices = new int[finalNumberOfDices];
            int[] reroledIndexes = new int[finalNumberOfDices];

            Console.WriteLine("\nSo you would like to roll {0} Dices.\n\nAfter pressing ENTER you will have to insert the index of Dice(s) which you want to reroll...", finalNumberOfDices);
            Console.ReadLine();

            for (int i = 0; i < finalNumberOfDices; i++)
            {
                Console.WriteLine("Enter the index(1 - 5) of the Dice:\t\t For example for Dice1 enter: 1 or for Dice3 enter: 3.", i + 1);
                finalPlayerInpt = Console.ReadLine();
                finalIndexofDices = int.Parse(finalPlayerInpt);

                finalTable[finalIndexofDices - 1] = rng.Next(1, 7);

                reroledIndexes[i] = finalIndexofDices;

                reroledDices[i] = finalTable[finalIndexofDices - 1];
            }

            Console.WriteLine(" \n\nYou have Rolled {0} Dice(s):", finalNumberOfDices);

            for (int i = 0; i < reroledIndexes.Length; i++)
            {
                Console.Write("\nDice{0}: {1}", reroledIndexes[i], reroledDices[i]);
            }

            Console.WriteLine("\nTo see the table press Enter...");
            Console.ReadLine();


            Console.WriteLine("\n\nAfter the third Roll table looks like this:");

            DisplayFinalRoll(finalTable);
            displayOfPossibleScore(finalTable);
            Console.WriteLine("Press Enter to choose the Scoring option...");
            Console.ReadLine();
            numberOfRollsRemaining--;
            return finalTable;

        }            //Final Roll passing the score to Get Score method.

        private void DisplayFinalRoll(int[] finalTable)
        {
            Console.WriteLine("\nTable:");
            for (int i = 0; i < finalTable.Length; i++)
            {
                Console.WriteLine("Dice{0}: {1}", i + 1, finalTable[i]);
            }
        }                                  //Displays Table after last roll.

        private bool LastPlayerDecision(int[] nextRolls, int numberOfRollsRemaining)
        {

            string lastPlayerDecision;
            bool lastPlayerTakesScore;
            Console.WriteLine("\nNumber of Rolls remaining: {0}\n", numberOfRollsRemaining);

            while (true)
            {
                Console.WriteLine("Will you continue to roll the dice or would you like to take the Score?\nEnter (C) to roll more dices or (S) to take the Score:");
                lastPlayerDecision = Console.ReadLine();
                lastPlayerDecision = lastPlayerDecision.ToUpper();

                if (lastPlayerDecision == "S")
                {
                    lastPlayerTakesScore = false;
                    return lastPlayerTakesScore;
                }
                else if (lastPlayerDecision == "C")
                {
                    lastPlayerTakesScore = true;
                    return lastPlayerTakesScore;
                }
                else
                {
                    Console.WriteLine("That is not a valid input!\n");
                }
            }

        }   //Getting the Decision of the User to score or continue playing after the second roll.

        private void DisplaySecondRoll(int[] nextRolls)
        {
            Console.WriteLine("\nTable:");
            for (int i = 0; i < nextRolls.Length; i++)
            {
                Console.WriteLine("Dice{0}: {1}", i + 1, nextRolls[i]);
            }
        }                             //Displays table after the second roll.

        private int GetScore(int[] firstRoll)
        {
            Console.Clear();
            displayFirstRoll(firstRoll);
            displayOfPossibleScore(firstRoll);
            string userScoreDecision;
            int scoreOfFirstRound = 0;
            int ScoreFive = 0;
            int ScorePair = 0;
            int ScoreChanc = 0;
            int[] sorted = firstRoll;

            for (int i = 0; i < firstRoll.Length; i++)
            {
                if (firstRoll[i] == 5)
                {
                    ScoreFive += firstRoll[i];
                }

                ScoreChanc += firstRoll[i];
            }

            Array.Sort(sorted);

            for (int i = 4; i > 0; i--)
            {
                if (firstRoll[i] == sorted[i - 1])
                {
                    ScorePair = ScorePair + sorted[i] + sorted[i - 1];
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("Which Score would you like to take enter (F)ives, (P)airs or (C)chance...");
                userScoreDecision = Console.ReadLine();
                userScoreDecision = userScoreDecision.ToUpper();

                if (userScoreDecision == "F")
                {
                    Console.WriteLine("\nYou are taking the score of Fives! Wise move!");
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    scoreOfFirstRound = ScoreFive;
                    return scoreOfFirstRound;
                }
                else if (userScoreDecision == "P")
                {
                    Console.WriteLine("\nYou are taking the score of Pairs! I hope you are sure!");
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    scoreOfFirstRound = ScorePair;
                    return scoreOfFirstRound;
                }
                else if (userScoreDecision == "C")
                {
                    Console.WriteLine("\nYou are taking the score of Chance! Chance is all you need, HAHA!");
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    scoreOfFirstRound = ScoreChanc;
                    return scoreOfFirstRound;
                }
                else
                {
                    Console.WriteLine("This is not valid Input. Please try again!\n");
                }
            }

            
            
        }                                     //Method Displays the table, possible score and asks User to select Scoring option. Selected scoring option is passed to Play method.

        private bool GetUserDecision()
        {
            int numberOfRollsRemaining = 2;
            string playerDecision;
            bool playerTakesScore;

            Console.WriteLine("\nNumber of Rolls remaining: {0}\n", numberOfRollsRemaining);

            while (true)
            {
                Console.WriteLine("Will you continue to roll the dice or would you like to take the Score?\nEnter (C) to roll more dices or (S) to take the Score:");
                playerDecision = Console.ReadLine();
                playerDecision = playerDecision.ToUpper();

                if (playerDecision == "S")
                {
                    playerTakesScore = true;
                    return playerTakesScore;
                }
                else if (playerDecision == "C")
                {
                    playerTakesScore = false;
                    return playerTakesScore;
                }
                else
                {
                    Console.WriteLine("That is not a valid input!\n");
                }
            }


        }                                          //Method asks ans returns User decision to continue playing or take score.

        private void displayOfPossibleScore(int[] firstRoll)
        {
            int ScoreFives = 0;
            int ScorePairs = 0;
            int ScoreChance = 0;
            int[] sorted = new int[5];

            for (int i = 0; i < firstRoll.Length; i++)
            {
                if (firstRoll[i] == 5)
                {
                    ScoreFives += firstRoll[i];
                }

                ScoreChance += firstRoll[i];
            }

            for (int i = 0; i < firstRoll.Length; i++)
            {
                sorted[i] = firstRoll[i];
            }

            Array.Sort(sorted);

            for (int i = 4; i > 0; i--)
            {
                if (sorted[i] == sorted[i-1])
                {
                    ScorePairs = ScorePairs + sorted[i] + sorted[i-1];
                    break;
                }
            }


            Console.WriteLine("\n\nPossible score points:");
            Console.Write("Fives: {0}\t Pairs: {1}\t Chance: {2}\n\n", ScoreFives, ScorePairs, ScoreChance);
        }                  //Display of the possible score after the first roll. It can be used any time after consecutive roles of the Dices.

        private void displayFirstRoll(int[] firstRoll)
        {
            Console.WriteLine("Table:");
            for (int i = 0; i < firstRoll.Length; i++)
            {
                Console.WriteLine("Dice{0}: {1}", i+1, firstRoll[i]);
            }
        }                      //This method is used to display the table. It can be used any time after consecutive roles of the Dices.

        private int[] getFirstRoll()                                        // In this method we are getting first roll of 5 Dices.
        {
            int[] ArrayOfFiveRolls = new int[5];

            for (int i = 0; i < 5; i++)
            {
                ArrayOfFiveRolls[i] = rng.Next(1, 7);
            }

            return ArrayOfFiveRolls;


        }

        private string promptuser()                                       //Asking the user if he or she wants to play the game.
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Yatzi Game! Enter S to start or Q to quit the game...");
                string choice = Console.ReadLine();
                choice=choice.ToUpper();

                if (choice == "Q" || choice =="S")
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("That is not a valid input! Press Enter to continue...");
                    Console.ReadLine();
                }
            }
        }   
    }
}
