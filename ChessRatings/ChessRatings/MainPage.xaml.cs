using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChessRatings
{
    public partial class MainPage : ContentPage
    {

        /*
         * 1 - player 1 win
         * 2 - player 2 win
         * 0 - draw
         */
        int playerWon = 0;
        string player1Calculated = "";
        string player2Calculated = "";
        public MainPage()
        {
            InitializeComponent();
        }

        private void Player2Won_Clicked(object sender, EventArgs e)
        {
            playerWon = 2;
        }

        private void Player1Won_Clicked(object sender, EventArgs e)
        {
            playerWon = 1;
        }
        //Calculates and outputs the new ratings for both players
        private void OnCalculate(object sender, EventArgs e)
        {
            //Calculate new Player Ratings
            player1Calculated = ChessRatingCalculations.Calculate(Player1Ratings.Text, Player2Ratings.Text, playerWon, 1);
            player2Calculated = ChessRatingCalculations.Calculate(Player1Ratings.Text, Player2Ratings.Text, playerWon, 2);

            player1NewRatings.Text = "Player 1: " + player1Calculated;
            player2NewRatings.Text = "Player 2: " + player2Calculated;

        }

        //If button is pressed - playerWon is tied (0)
        private void Tied_Clicked(object sender, EventArgs e)
        {
            playerWon = 0;
        }
    }
}
