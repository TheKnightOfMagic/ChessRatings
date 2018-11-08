using System;
using System.Collections.Generic;
using System.Text;

namespace ChessRatings
{
    public static class ChessRatingCalculations
    {
        
        public static string Calculate(string player1, string player2, int playerWin, int who)
        {

            int playerOne = 0;
            int playerTwo = 0;
            int spread = 0;
            int higherBoard = 0;

            //Check if it's proper input form and converts to int
            try
            {
                playerOne = Convert.ToInt32(player1);
                playerTwo = Convert.ToInt32(player2);
             
            }
            catch (Exception)
            {
                //If format is improper
                return "Invalid Value";
            }
            
            //Calculates the difference between ratings of player1 and ratings of player2
            spread = Math.Abs(playerOne - playerTwo);

            //Checks which player has a higher rating
            if (playerOne > playerTwo)
            {
                higherBoard = 1;
            }
            else
            {
                higherBoard = 2;
            }


            //Checks who is currently being calculated
            //Adds gains and losses to the original rating
            if (who == 1)
            {
                return "" + (playerOne + findGains(spread, playerWin, who, higherBoard));
            }
            else if(who ==2 ){
                return "" + (playerTwo + findGains(spread, playerWin, who, higherBoard));
            }
            else
            {
                //Something went wrong
                return "HmmMMMM";
            }
        }

        //Calculates the gains and losses of the player that's being calculated
        static int findGains(int spread, int playerWon, int currentPlayer, int higherBoard)
        {
            int gains = 0;
            int modifier = 0;

            //Uses spread to find modifier that will modify the gains
            if (spread <= 12)
                modifier = 0;
            else if (spread <= 37)
                modifier = 1;
            else if (spread <= 62)
                modifier = 2;
            else if (spread <= 87)
                modifier = 3;
            else if (spread <= 112)
                modifier = 4;
            else if (spread <= 137)
                modifier = 5;
            else if (spread <= 162)
                modifier = 6;
            else if (spread <= 187)
                modifier = 7;
            else if (spread <= 212)
                modifier = 8;
            else if (spread <= 237)
                modifier = 9;
            else if (spread <= 262)
                modifier = 10;
            else if (spread <= 287)
                modifier = 11;
            else if (spread <= 312)
                modifier = 12;
            else if (spread <= 337)
                modifier = 13;
            else 
                modifier = 14;


            //multiples by -1 if current player is losing points
            if (playerWon == 0 && higherBoard == currentPlayer)
            {
                gains = -1 * modifier;
            }else if(playerWon == 0 && higherBoard != currentPlayer)
            {
                gains = modifier;
            }
            else if (higherBoard == currentPlayer && currentPlayer == playerWon)
            {
                gains = 16 - modifier;
            }
            else if (higherBoard == currentPlayer && currentPlayer != playerWon)
            {
                gains = -1 * (16 + modifier);
            }
            else if(higherBoard !=currentPlayer && currentPlayer == playerWon)
            {
                gains = 16 + modifier;
            }
            else if(higherBoard != currentPlayer && currentPlayer != playerWon)
            {
                gains = -1 * (16 - modifier);
            }
            else
            {
                //Just in case
                gains = 0;
            }


            
            return gains;

        }
       
    }
}
