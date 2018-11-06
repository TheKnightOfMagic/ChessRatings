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
            int higherBoard = 1;
            //Check if it's proper input format
           
            try
            {
                playerOne = Convert.ToInt32(player1);
                playerTwo = Convert.ToInt32(player2);
             
            }
            catch (Exception)
            {
                return "Invalid Values";
            }
            

            spread = Math.Abs(playerOne - playerTwo);
            if (playerOne > playerTwo)
            {
                higherBoard = 1;
            }
            else
            {
                higherBoard = 2;
            }

            if(who == 1)
            {
                return "" + (playerOne + findGains(playerOne, spread, playerWin, who, higherBoard));
            }
            else{
                return "" + (playerTwo + findGains(playerTwo, spread, playerWin, who, higherBoard));
            }
        }
        static int findGains(int ratings, int spread, int playerWon, int current, int higherBoard)
        {
            int gains = 0;
            int modifier = 0;
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


            if(playerWon == 0 && higherBoard == current)
            {
                gains = -1 * modifier;
            }else if(playerWon == 0 && higherBoard != current)
            {
                gains = modifier;
            }
            if (higherBoard == current && current == playerWon)
            {
                gains = 16 - modifier;
            }
            else if (higherBoard == current && current != playerWon)
            {
                gains = -1 * (16 + modifier);
            }else if(higherBoard !=current && current == playerWon)
            {
                gains = 16 + modifier;
            }else if(higherBoard != current && current == playerWon)
            {
                gains = -1 * (16 - modifier);
            }
            else
            {
                gains = 0;
            }

                return gains;

        }
       
    }
}
