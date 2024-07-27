using Microsoft.VisualBasic;
using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TIC_TAC_TOE
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private const ushort WIDTH = 200;       //Width of the playing field square
        private const ushort HEIGHT = 200;      //Height of the playing field square
        private const string FONT_FAMILY = "Microsoft Sans Serif";      //font type
        private const byte FONT_SIZE = 70;     //Font size 
        private const byte ROWS = 3;        //Number of rows
        private const byte COLUMNS = 3;         //Number of columns           
        private bool isX = true;        //Is the current symbol x : true - yes, false - no (symbol == 'O')
        private char symbol = 'X';          //The current symbol       
        private Button[,] buttons = new Button[ROWS, COLUMNS];          //A two-dimensional array representing the playing field
        private byte count = 0;         //Number of moves
        private byte number_of_victories_O = 0;         //Number of wins for a player with O symbol
        private byte number_of_victories_X = 0;         //Number of wins for a player with X symbol

        public Form1()
        {
            InitializeComponent();
            for (int row = 0; row < ROWS; row++)        //Cycle for creating cells of the playing field
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    buttons[row, column] = new Button();        //Creating a playing field cell
                    buttons[row, column].Size = new Size(WIDTH, HEIGHT);        //Specifying the size of a playing field cell
                }
            }

            X_victory.Text = $"PLAYER X - {number_of_victories_X}";         //Displaying the number of wins of a player with the X symbol
            O_victory.Text = $"PLAYER O - {number_of_victories_O}";         //Displaying the number of wins of a player with the O symbol

            SetButtons();       
        }

        private void SetButtons()       //Method for specifying: positions, click logic and font type
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    buttons[row, column].Location = new Point(WIDTH * column, HEIGHT * row);        //Indicates the position of the playing field cell
                    buttons[row, column].Click += game_move;        //Adding logic for clicking on a cell of the playing field
                    buttons[row, column].Font = new Font(new FontFamily(FONT_FAMILY), FONT_SIZE);       //Specify the font type that will be used to display the symbol inside the playing field cell
                    this.Controls.Add(buttons[row, column]);        //Adding a matrix consisting of rows and columns of cells on the playing field
                }
            }
        }

        private void game_move(object? sender, EventArgs e)         //Method for processing a click on a cell of the playing field
        {                        
            if (isX)        //A condition that handles the case when the character is X
            {   
                sender?.GetType()?.GetProperty("Text")?.SetValue(sender, "X");      //Displaying the symbol X on the cells of the playing field
                isX = false;        //Change character to O
                Current_symbol.Text = "Current symbol Î";       //Changing the display of information about the current symbol
            }
            else        //A condition that handles the case when the character is O
            {            
                sender?.GetType()?.GetProperty("Text")?.SetValue(sender, "O");          //Displaying the symbol O on the cells of the playing field               
                isX = true;         //Change character to X
                Current_symbol.Text = "Current symbol Õ";       //Changing the display of information about the current symbol
            }

            sender?.GetType()?.GetProperty("Enabled")?.SetValue(sender, false);         //Switching the playing field cell to inactive mode

            count++;        //Increase the number of moves by 1

            if (isX == true) symbol = 'O';
            //Conditions for determining the winning player symbol                                            
            else symbol = 'X';
            CheckWin();

            X_victory.Text = $"PLAYER X - {number_of_victories_X}";
            //Update information on the number of player wins
            O_victory.Text = $"PLAYER O - {number_of_victories_O}";
        }



        private void CheckWin()         //Method for checking whether one of the players wins or draws
        {
            if ((buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text && buttons[0, 0].Text != "")
                || (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text && buttons[1, 0].Text != "")
                || (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text && buttons[2, 0].Text != "")
                || (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text && buttons[0, 0].Text != "")
                || (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text && buttons[0, 1].Text != "")
                || (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text && buttons[0, 2].Text != "")
                || (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && buttons[0, 0].Text != "")
                || (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text && buttons[2, 0].Text != ""))      //Conditions for determining victory
            {
                if (symbol == 'X') number_of_victories_X++;
                //Conditions for determining the winner
                else number_of_victories_O++;
                MessageBox.Show($"The player with the {symbol} symbol wins!");          //Displaying player information winners
                for (int row = 0; row < ROWS; row++)        //Cycle to clear the playing field
                {
                    for (int column = 0; column < COLUMNS; column++)
                    {
                        buttons[row, column].Text = "";         //Removing a symbol from a cell on the playing field
                        buttons[row, column].Enabled = true;        //Switching the playing field cell to active mode
                        count = 0;          //Resetting the number of moves
                    }
                }
                if (symbol == 'X') isX = false;
                //Conditions for changing the first symbol during a round
                else isX = true;
                return;         //Ending the round and exiting the method
            }          
            else if (count >= 9) MessageBox.Show("Draw");          //Condition for determining a draw
        }

        private void Restert_game_Click(object sender, EventArgs e)         //Method for handling clicks on the restart game button
        {
            for (int row = 0; row < ROWS; row++)        //Cycle to clear the playing field
            {
                for (int column = 0; column < COLUMNS; column++)
                {
                    buttons[row, column].Text = "";          //Removing a symbol from a cell on the playing field
                    buttons[row, column].Enabled = true;        //Switching the playing field cell to active mode
                    count = 0;          //Resetting the number of moves
                }
            }
        }
        
        
    }
}
