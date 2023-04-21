/*Author: Andrew Bach
 *Program Name: Bach Chess Tournament Solutions
 *Date: 11/17/2020
 *Program Description:  A program designed to be used at chess tournaments. The program allows the user to move pieces freely around the board
 *                      to mimick the game happening in person. Every move made gets saved to an autosave file incase of crashes or accidental
 *                      closures of programs. There is also the ability to save and load using the dialog box. The new board button works by
 *                      loading a file (newBoard.default) with the default piece locations. At the top, images are used to indicate who is
 *                      currently making a move. Player names can be edited for personalization. Finally, a corrections menu was added in
 *                      case the user were to click the wrong spot and kill off a piece accidentally.
 *                      
 *                      -----------------------------------------------------------------------------------------------------------------------------
 *                      2. What do we want to know?  Detail what the program should output.  What fields or labels do we need to output?
 *                      We want to know where each piece is on the board. Since its for a tournament I also want to know who is playing.
 *                      The program needs to output what piece is in what space on the game board. In terms of label output, I needed
 *                      to output the names of the players, who is making a turn, and visually where the pieces are.
 *                      
 *                      3. What we already know.  Detail all the known elements of this problem.  What input variables and text boxes can we set up?
 *                      We know a chess board is an 8x8 grid, where the chess pieces start out, and how many players there are. This means I need to
 *                      store all the game pieces in an 8x8 array. For input and textboxes, I only needed to allow users to type in player names.
 *                      The important input from the user is their clicks on the gameboard to move pieces (Manipulate the array.)
 *                      
 *                      4. Description of what needs to be calculated and how you can do it.  You can use formulas or a simple short paragraph.
 *                      The way I programmed it, there really isn't much for calculations. The program simply operates like a hand. If you click
 *                      an array spot and your hands empty it picks it up (stores it in the inHand variable) and then allows you to click else where
 *                      to move the piece.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Exam_Project_3
{
    public partial class FormChessBoard : Form
    {
        //Declare Field Variables
        int turn = 1; //player turn
        string inHand = ""; //Determines what piece has been picked up to move

        //Declare Arrays
        PictureBox[,] chessBoardBoxes = new PictureBox[8, 8]; //Stores individual board pieces picture boxes
        string[,] chessBoard = new string[8, 8]; //Stores the location of the chess pieces
        string[,] boxColor = new string[8, 8]; //Stores the boxColor of each piece ("light" or "dark")

        public FormChessBoard()
        {
            InitializeComponent();

            //Store Chess Board Picture Boxes in the chessBoardBoxes array. This is used to control the images by reference.
            //Row 0
            chessBoardBoxes[0, 0] = pictureBoxBoard00;
            chessBoardBoxes[0, 1] = pictureBoxBoard01;
            chessBoardBoxes[0, 2] = pictureBoxBoard02;
            chessBoardBoxes[0, 3] = pictureBoxBoard03;
            chessBoardBoxes[0, 4] = pictureBoxBoard04;
            chessBoardBoxes[0, 5] = pictureBoxBoard05;
            chessBoardBoxes[0, 6] = pictureBoxBoard06;
            chessBoardBoxes[0, 7] = pictureBoxBoard07;
            //Row 1
            chessBoardBoxes[1, 0] = pictureBoxBoard10;
            chessBoardBoxes[1, 1] = pictureBoxBoard11;
            chessBoardBoxes[1, 2] = pictureBoxBoard12;
            chessBoardBoxes[1, 3] = pictureBoxBoard13;
            chessBoardBoxes[1, 4] = pictureBoxBoard14;
            chessBoardBoxes[1, 5] = pictureBoxBoard15;
            chessBoardBoxes[1, 6] = pictureBoxBoard16;
            chessBoardBoxes[1, 7] = pictureBoxBoard17;
            //Row 2
            chessBoardBoxes[2, 0] = pictureBoxBoard20;
            chessBoardBoxes[2, 1] = pictureBoxBoard21;
            chessBoardBoxes[2, 2] = pictureBoxBoard22;
            chessBoardBoxes[2, 3] = pictureBoxBoard23;
            chessBoardBoxes[2, 4] = pictureBoxBoard24;
            chessBoardBoxes[2, 5] = pictureBoxBoard25;
            chessBoardBoxes[2, 6] = pictureBoxBoard26;
            chessBoardBoxes[2, 7] = pictureBoxBoard27;
            //Row 3
            chessBoardBoxes[3, 0] = pictureBoxBoard30;
            chessBoardBoxes[3, 1] = pictureBoxBoard31;
            chessBoardBoxes[3, 2] = pictureBoxBoard32;
            chessBoardBoxes[3, 3] = pictureBoxBoard33;
            chessBoardBoxes[3, 4] = pictureBoxBoard34;
            chessBoardBoxes[3, 5] = pictureBoxBoard35;
            chessBoardBoxes[3, 6] = pictureBoxBoard36;
            chessBoardBoxes[3, 7] = pictureBoxBoard37;
            //Row 4
            chessBoardBoxes[4, 0] = pictureBoxBoard40;
            chessBoardBoxes[4, 1] = pictureBoxBoard41;
            chessBoardBoxes[4, 2] = pictureBoxBoard42;
            chessBoardBoxes[4, 3] = pictureBoxBoard43;
            chessBoardBoxes[4, 4] = pictureBoxBoard44;
            chessBoardBoxes[4, 5] = pictureBoxBoard45;
            chessBoardBoxes[4, 6] = pictureBoxBoard46;
            chessBoardBoxes[4, 7] = pictureBoxBoard47;
            //Row 5
            chessBoardBoxes[5, 0] = pictureBoxBoard50;
            chessBoardBoxes[5, 1] = pictureBoxBoard51;
            chessBoardBoxes[5, 2] = pictureBoxBoard52;
            chessBoardBoxes[5, 3] = pictureBoxBoard53;
            chessBoardBoxes[5, 4] = pictureBoxBoard54;
            chessBoardBoxes[5, 5] = pictureBoxBoard55;
            chessBoardBoxes[5, 6] = pictureBoxBoard56;
            chessBoardBoxes[5, 7] = pictureBoxBoard57;
            //Row 6
            chessBoardBoxes[6, 0] = pictureBoxBoard60;
            chessBoardBoxes[6, 1] = pictureBoxBoard61;
            chessBoardBoxes[6, 2] = pictureBoxBoard62;
            chessBoardBoxes[6, 3] = pictureBoxBoard63;
            chessBoardBoxes[6, 4] = pictureBoxBoard64;
            chessBoardBoxes[6, 5] = pictureBoxBoard65;
            chessBoardBoxes[6, 6] = pictureBoxBoard66;
            chessBoardBoxes[6, 7] = pictureBoxBoard67;
            //Row 7
            chessBoardBoxes[7, 0] = pictureBoxBoard70;
            chessBoardBoxes[7, 1] = pictureBoxBoard71;
            chessBoardBoxes[7, 2] = pictureBoxBoard72;
            chessBoardBoxes[7, 3] = pictureBoxBoard73;
            chessBoardBoxes[7, 4] = pictureBoxBoard74;
            chessBoardBoxes[7, 5] = pictureBoxBoard75;
            chessBoardBoxes[7, 6] = pictureBoxBoard76;
            chessBoardBoxes[7, 7] = pictureBoxBoard77;

            //Used for setting up the boxColor arrays stored variables.
            string currentColor = "light";

            //Set boxColor Array up
            for (int x = 0; x < boxColor.GetLength(0);x++)
            {
                //Each row it flips the 1st color
                if (currentColor == "light")
                {
                    currentColor = "dark";
                }
                else
                {
                    currentColor = "light";
                }

                for (int y = 0; y < boxColor.GetLength(1);y++)
                {
                    //Set the tile color
                    boxColor[x, y] = currentColor;

                    //Change the color each tile across the row
                    if (currentColor == "light")
                    {
                        currentColor = "dark";
                    }
                    else
                    {
                        currentColor = "light";
                    }
                }
            }

            //Set up onHover eventhandlers
            buttonChangeTurn.MouseEnter += new EventHandler(buttonChangeTurn_MouseEnter);
            buttonChangeTurn.MouseLeave += new EventHandler(buttonChangeTurn_MouseLeave);
            buttonEditPlayerOne.MouseEnter += new EventHandler(buttonEditPlayerOne_MouseEnter);
            buttonEditPlayerOne.MouseLeave += new EventHandler(buttonEditPlayerOne_MouseLeave);
            buttonEditPlayerTwo.MouseEnter += new EventHandler(buttonEditPlayerTwo_MouseEnter);
            buttonEditPlayerTwo.MouseLeave += new EventHandler(buttonEditPlayerTwo_MouseLeave);
            buttonExit.MouseEnter += new EventHandler(buttonExit_MouseEnter);
            buttonExit.MouseLeave += new EventHandler(buttonExit_MouseLeave);
            buttonLoadBoard.MouseEnter += new EventHandler(buttonLoadBoard_MouseEnter);
            buttonLoadBoard.MouseLeave += new EventHandler(buttonLoadBoard_MouseLeave);
            buttonNewBoard.MouseEnter += new EventHandler(buttonNewBoard_MouseEnter);
            buttonNewBoard.MouseLeave += new EventHandler(buttonNewBoard_MouseLeave);
            buttonSaveBoard.MouseEnter += new EventHandler(buttonSaveBoard_MouseEnter);
            buttonSaveBoard.MouseLeave += new EventHandler(buttonSaveBoard_MouseLeave);
            buttonCorrections.MouseEnter += new EventHandler(buttonCorrections_MouseEnter);
            buttonCorrections.MouseLeave += new EventHandler(buttonCorrections_MouseLeave);

            //Run the newBoard method to populate the board with pieces
            newBoard();

            //set the Initial save and load directories to the programs current directory
            saveFile.InitialDirectory = Environment.CurrentDirectory;
            openFile.InitialDirectory = Environment.CurrentDirectory;

            //Filter other file types out. This also protects the newBoard.default file that holds the default board configuration.
            openFile.Filter = "Text|*.chess|All|*.*";
            saveFile.Filter = "Text|*.chess|All|*.*";
        }

        private void updateBoard()
        {
            //Method to update the graphics of the board
            for (int x = 0; x < chessBoard.GetLength(0); x++)
            {
                for (int y = 0; y < chessBoard.GetLength(1); y++)
                {
                    //If-else-if statements to populate board with correct images.
                    //White Pieces
                    //Pawn
                    if (chessBoard[x, y] == "whitePawn" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whitePawn_light));
                    }
                    else if (chessBoard[x, y] == "whitePawn" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whitePawn_dark));
                    }
                    //Rook
                    else if (chessBoard[x, y] == "whiteRook" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteRook_light));
                    }
                    else if (chessBoard[x, y] == "whiteRook" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteRook_dark));
                    }
                    //Knight
                    else if (chessBoard[x, y] == "whiteKnight" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteKnight_light));
                    }
                    else if (chessBoard[x, y] == "whiteKnight" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteKnight_dark));
                    }
                    //Bishop
                    else if (chessBoard[x, y] == "whiteBishop" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteBishop_light));
                    }
                    else if (chessBoard[x, y] == "whiteBishop" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteBishop_dark));
                    }
                    //Queen
                    else if (chessBoard[x, y] == "whiteQueen" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteQueen_light));
                    }
                    else if (chessBoard[x, y] == "whiteQueen" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteQueen_dark));
                    }
                    //King
                    else if (chessBoard[x, y] == "whiteKing" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteKing_light));
                    }
                    else if (chessBoard[x, y] == "whiteKing" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.whiteKing_dark));
                    }
                    //Black Pieces
                    //Pawn
                    else if (chessBoard[x, y] == "blackPawn" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackPawn_light));
                    }
                    else if (chessBoard[x, y] == "blackPawn" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackPawn_dark));
                    }
                    //Rook
                    else if (chessBoard[x, y] == "blackRook" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackRook_light));
                    }
                    else if (chessBoard[x, y] == "blackRook" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackRook_dark));
                    }
                    //Knight
                    else if (chessBoard[x, y] == "blackKnight" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackKnight_light));
                    }
                    else if (chessBoard[x, y] == "blackKnight" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackKnight_dark));
                    }
                    //Bishop
                    else if (chessBoard[x, y] == "blackBishop" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackBishop_light));
                    }
                    else if (chessBoard[x, y] == "blackBishop" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackBishop_dark));
                    }
                    //Queen
                    else if (chessBoard[x, y] == "blackQueen" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackQueen_light));
                    }
                    else if (chessBoard[x, y] == "blackQueen" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackQueen_dark));
                    }
                    //King
                    else if (chessBoard[x, y] == "blackKing" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackKing_light));
                    }
                    else if (chessBoard[x, y] == "blackKing" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.blackKing_dark));
                    }
                    //Blank Spaces
                    else if (chessBoard[x, y] == "" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.lightBoard));
                    }
                    else if (chessBoard[x, y] == "" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.darkBoard));
                    }
                    //Selected Spots
                    else if (chessBoard[x, y] == "selected" && boxColor[x, y] == "light")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.lightBoard_move));
                    }
                    else if (chessBoard[x, y] == "selected" && boxColor[x, y] == "dark")
                    {
                        chessBoardBoxes[x, y].Image = ((System.Drawing.Image)(Properties.Resources.darkBoard_move));
                    }
                }
            }

            //Update In Hand Piece
            if (inHand == "")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.background_inHand));
            }
            else if (inHand == "blackPawn")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.blackPawn_inHand));
            }
            else if (inHand == "blackRook")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.blackRook_inHand));
            }
            else if (inHand == "blackBishop")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.blackBishop_inHand));
            }
            else if (inHand == "blackKnight")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.blackKnight_inHand));
            }
            else if (inHand == "blackQueen")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.blackQueen_inHand));
            }
            else if (inHand == "blackKing")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.blackKing_inHand));
            }
            else if (inHand == "whitePawn")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.whitePawn_inHand));
            }
            else if (inHand == "whiteRook")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.whiteRook_inHand));
            }
            else if (inHand == "whiteBishop")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.whiteBishop_inHand));
            }
            else if (inHand == "whiteKnight")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.whiteKnight_inHand));
            }
            else if (inHand == "whiteQueen")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.whiteQueen_inHand));
            }
            else if (inHand == "whiteKing")
            {
                pictureBoxInHand.Image = ((System.Drawing.Image)(Properties.Resources.whiteKing_inHand));
            }

        }

        private void autoSave()
        {
            //Method to save the board array to an autosave file
            labelAutoSavePrompt.Text = "Autosaved @ " + (DateTime.Now).ToString("f");

            //Create an Autosave File
            StreamWriter outputFile;
            outputFile = File.CreateText("autoSave.chess");

            //Save the chessBoard array
            for (int x = 0; x < chessBoard.GetLength(0); x++)
            {
                for (int y = 0; y < chessBoard.GetLength(1); y++)
                {
                    outputFile.WriteLine(chessBoard[x, y]);
                }
            }

            //Save the player names
            outputFile.WriteLine(labelPlayerOne.Text);
            outputFile.WriteLine(labelPlayerTwo.Text);

            //Close the file
            outputFile.Close();
        }

        private void newBoard()
        {
            //Clear the inHand variable
            inHand = "";

            //Load the new board file and write it to the chessBoard Array
            StreamReader inputFile;
            inputFile = File.OpenText("newBoard.default"); //.default wont show in the saveFile or openFile dialogs

            //Populate the chessBoard array with piece positions
            for (int x = 0; x < chessBoard.GetLength(0); x++)
            {
                for (int y = 0; y < chessBoard.GetLength(1); y++)
                {
                    chessBoard[x, y] = inputFile.ReadLine();
                }
            }

            //Close the File
            inputFile.Close();

            //Update the board
            updateBoard();
        }

        private void saveBoard()
        {
            //Method to save the board to a user defined file
            StreamWriter outputFile;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                outputFile = File.CreateText(saveFile.FileName);

                //Save the chessBoard array
                for (int x = 0; x < chessBoard.GetLength(0); x++)
                {
                    for (int y = 0; y < chessBoard.GetLength(1); y++)
                    {
                        outputFile.WriteLine(chessBoard[x, y]);
                    }
                }

                //Save the player names
                outputFile.WriteLine(labelPlayerOne.Text);
                outputFile.WriteLine(labelPlayerTwo.Text);

                //Close the file
                outputFile.Close();

                //Update the save label
                labelAutoSavePrompt.Text = (saveFile.FileName).ToString() + " was saved at " + (DateTime.Now).ToString("f");
            }
            else
            {
                MessageBox.Show("The game was not saved");
            }
        }

        private void loadBoard()
        {
            //Method to load a user defined board
            //Clear the inHand variable
            inHand = "";

            //Load the file and write it to the chessBoard Array
            StreamReader inputFile;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                inputFile = File.OpenText(openFile.FileName);

                //Populate the chessBoard array with piece positions
                for (int x = 0; x < chessBoard.GetLength(0); x++)
                {
                    for (int y = 0; y < chessBoard.GetLength(1); y++)
                    {
                        chessBoard[x, y] = inputFile.ReadLine();
                    }
                }

                labelPlayerOne.Text = inputFile.ReadLine();
                labelPlayerTwo.Text = inputFile.ReadLine();

                //Close the File
                inputFile.Close();
            }
            else
            {
                MessageBox.Show("No game was loaded");
            }

            //For loop clears any "selected" pieces
            for (int x = 0; x < chessBoard.GetLength(0); x++)
            {
                for (int y = 0; y < chessBoard.GetLength(1); y++)
                {
                    if (chessBoard[x, y] == "selected")
                    {
                        chessBoard[x, y] = "";
                    }
                }
            }

            //Update the board
            updateBoard();
        }

        private void changeTurn()
        {
            //Change the turn images at the top
            if (turn == 1)
            {
                turn = 2;
                pictureBoxPlayerOneTurn.Image = ((System.Drawing.Image)(Properties.Resources.leftPlayer_waiting));
                pictureBoxPlayerTwoTurn.Image = ((System.Drawing.Image)(Properties.Resources.rightPlayer_moving));
            }
            else
            {
                turn = 1;
                pictureBoxPlayerOneTurn.Image = ((System.Drawing.Image)(Properties.Resources.leftPlayer_moving));
                pictureBoxPlayerTwoTurn.Image = ((System.Drawing.Image)(Properties.Resources.rightPlayer_waiting));
            }
        }

        private void boardClicked(int x, int y)
        {
            //If clicked, determine if a piece is in your hand and place it. If no piece is in your hand, pick up the 1 you clicked.
            if (inHand == "")
            {
                if (chessBoard[x, y] != "")
                {
                    inHand = chessBoard[x, y];
                    chessBoard[x, y] = "selected";
                }
            }
            else
            {
                chessBoard[x, y] = inHand;
                inHand = "";
                autoSave();
                changeTurn();

                //Clear the selected board piece once piece is placed
                for (int x2 = 0; x2 < chessBoard.GetLength(0); x2++)
                {
                    for (int y2 = 0; y2 < chessBoard.GetLength(1); y2++)
                    {
                        if (chessBoard[x2, y2] == "selected")
                        {
                            chessBoard[x2, y2] = "";
                        }
                    }
                }
            }

            updateBoard();
        }

        private void correction(string newInHand)
        {
            //Put the piece selected into "inHand" and update the board
            inHand = newInHand;
            updateBoard();
        }

        //buttonChangeTurn Eventhandlers
        private void buttonChangeTurn_Click(object sender, EventArgs e)
        {
            //Change the turn icons
            changeTurn();
        }

        private void buttonChangeTurn_MouseEnter(object sender, EventArgs e)
        {
            //Change the buttons image on hover
            buttonChangeTurn.Image = ((System.Drawing.Image)(Properties.Resources.buttonChangeTurn_onHover));
        }

        private void buttonChangeTurn_MouseLeave(object sender, EventArgs e)
        {
            //Change the buttons image when mouse leaves
            buttonChangeTurn.Image = ((System.Drawing.Image)(Properties.Resources.buttonChangeTurn_static));
        }

        //buttonEditPlayerOne Eventhandlers
        private void buttonEditPlayerOne_Click(object sender, EventArgs e)
        {
            //Show/Hide the Edit Player 1 Panel
            if (!panelEditPlayerOne.Visible)
            {
                panelEditPlayerOne.Visible = true;
            }
            else
            {
                panelEditPlayerOne.Visible = false;
                textBoxEditPlayerOne.Text = "";
            }
        }

        private void buttonEditPlayerOne_MouseEnter(object sender, EventArgs e)
        {
            //Change the buttons image on hover
            buttonEditPlayerOne.Image = ((System.Drawing.Image)(Properties.Resources.buttonEditPlayerOne_onHover));
        }

        private void buttonEditPlayerOne_MouseLeave(object sender, EventArgs e)
        {
            //Change the buttons image when mouse leaves
            buttonEditPlayerOne.Image = ((System.Drawing.Image)(Properties.Resources.buttonEditPlayerOne_static));
        }

        //buttonEditPlayerTwo Eventhandlers
        private void buttonEditPlayerTwo_Click(object sender, EventArgs e)
        {
            //Show/Hide the Edit Player 2 Panel
            if (!panelEditPlayerTwo.Visible)
            {
                panelEditPlayerTwo.Visible = true;
            }
            else
            {
                panelEditPlayerTwo.Visible = false;
                textBoxEditPlayerTwo.Text = "";
            }
        }

        private void buttonEditPlayerTwo_MouseEnter(object sender, EventArgs e)
        {
            //Change the buttons image on hover
            buttonEditPlayerTwo.Image = ((System.Drawing.Image)(Properties.Resources.buttonEditPlayerTwo_onHover));
        }

        private void buttonEditPlayerTwo_MouseLeave(object sender, EventArgs e)
        {
            //Change the buttons image when mouse leaves
            buttonEditPlayerTwo.Image = ((System.Drawing.Image)(Properties.Resources.buttonEditPlayerTwo_static));
        }

        //buttonExit Eventhandlers
        private void buttonExit_Click(object sender, EventArgs e)
        {
            //Close The Program
            this.Close();
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            //Change the buttons image on hover
            buttonExit.Image = ((System.Drawing.Image)(Properties.Resources.buttonExit_onHover));
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            //Change the buttons image when mouse leaves
            buttonExit.Image = ((System.Drawing.Image)(Properties.Resources.buttonExit_static));
        }

        //buttonLoadBoard Eventhandlers
        private void buttonLoadBoard_Click(object sender, EventArgs e)
        {
            //Load a previous game
            loadBoard();        
        }

        private void buttonLoadBoard_MouseEnter(object sender, EventArgs e)
        {
            //Change the buttons image on hover
            buttonLoadBoard.Image = ((System.Drawing.Image)(Properties.Resources.buttonLoadBoard_onHover));
        }

        private void buttonLoadBoard_MouseLeave(object sender, EventArgs e)
        {
            //Change the buttons image when mouse leaves
            buttonLoadBoard.Image = ((System.Drawing.Image)(Properties.Resources.buttonLoadBoard_static));
        }

        //buttonNewBoard Eventhandlers
        private void buttonNewBoard_Click(object sender, EventArgs e)
        {
            //Autosave the board in case newBoard was clicked on accident, then run the newBoard Method
            autoSave();
            newBoard();
        }

        private void buttonNewBoard_MouseEnter(object sender, EventArgs e)
        {
            //Change the buttons image on hover
            buttonNewBoard.Image = ((System.Drawing.Image)(Properties.Resources.buttonNewBoard_onHover));
        }

        private void buttonNewBoard_MouseLeave(object sender, EventArgs e)
        {
            //Change the buttons image when mouse leaves
            buttonNewBoard.Image = ((System.Drawing.Image)(Properties.Resources.buttonNewBoard_static));
        }

        //buttonSaveBoard Eventhandlers
        private void buttonSaveBoard_Click(object sender, EventArgs e)
        {
            //Save the board
            saveBoard();
        }

        private void buttonSaveBoard_MouseEnter(object sender, EventArgs e)
        {
            //Change the buttons image on hover
            buttonSaveBoard.Image = ((System.Drawing.Image)(Properties.Resources.buttonSaveBoard_onHover));
        }

        private void buttonSaveBoard_MouseLeave(object sender, EventArgs e)
        {
            //Change the buttons image when mouse leaves
            buttonSaveBoard.Image = ((System.Drawing.Image)(Properties.Resources.buttonSaveBoard_static));
        }

        //buttonCorrections Eventhandlers
        private void buttonCorrections_Click(object sender, EventArgs e)
        {
            //Toggle the corrections panel
            if (panelCorrections.Visible)
            {
                panelCorrections.Visible = false;
            }
            else
            {
                panelCorrections.Visible = true;
            }
        }

        private void buttonCorrections_MouseEnter(object sender, EventArgs e)
        {
            //Change the buttons image on hover
            buttonCorrections.Image = ((System.Drawing.Image)(Properties.Resources.buttonCorrections_onHover));
        }

        private void buttonCorrections_MouseLeave(object sender, EventArgs e)
        {
            //Change the buttons image when mouse leaves
            buttonCorrections.Image = ((System.Drawing.Image)(Properties.Resources.buttonCorrections_static));
        }

        private void buttonEditPlayerOneCancel_Click(object sender, EventArgs e)
        {
            //Hide the edit player one panel and empty the textbox
            panelEditPlayerOne.Visible = false;
            textBoxEditPlayerOne.Text = "";
        }

        private void buttonEditPlayerTwoCancel_Click(object sender, EventArgs e)
        {
            //Hide the edit player two panel and empty the textbox
            panelEditPlayerTwo.Visible = false;
            textBoxEditPlayerTwo.Text = "";
        }

        private void buttonEditPlayerOneSave_Click(object sender, EventArgs e)
        {
            //Update the Player One name label and hide the edit panel
            panelEditPlayerOne.Visible = false;
            labelPlayerOne.Text = textBoxEditPlayerOne.Text;
            textBoxEditPlayerOne.Text = "";
        }

        private void buttonEditPlayerTwoSave_Click(object sender, EventArgs e)
        {
            //Update the Player Two name label and hide the edit panel
            panelEditPlayerTwo.Visible = false;
            labelPlayerTwo.Text = textBoxEditPlayerTwo.Text;
            textBoxEditPlayerTwo.Text = "";
        }

        /*******************************************Board Clicks****************************************************/
        //Clicking each piece of the board runs the boardClicked method, taking the coordinates of the board piece.
        private void pictureBoxBoard00_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(0, 0);
        }

        private void pictureBoxBoard01_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(0, 1);
        }

        private void pictureBoxBoard02_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(0, 2);
        }

        private void pictureBoxBoard03_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(0, 3);
        }

        private void pictureBoxBoard04_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(0, 4);
        }

        private void pictureBoxBoard05_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(0, 5);
        }

        private void pictureBoxBoard06_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(0, 6);
        }

        private void pictureBoxBoard07_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(0, 7);
        }

        private void pictureBoxBoard10_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(1, 0);
        }

        private void pictureBoxBoard11_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(1, 1);
        }

        private void pictureBoxBoard12_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(1, 2);
        }

        private void pictureBoxBoard13_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(1, 3);
        }

        private void pictureBoxBoard14_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(1, 4);
        }

        private void pictureBoxBoard15_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(1, 5);
        }

        private void pictureBoxBoard16_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(1, 6);
        }

        private void pictureBoxBoard17_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(1, 7);
        }

        private void pictureBoxBoard20_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(2, 0);
        }

        private void pictureBoxBoard21_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(2, 1);
        }

        private void pictureBoxBoard22_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(2, 2);
        }

        private void pictureBoxBoard23_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(2, 3);
        }

        private void pictureBoxBoard24_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(2, 4);
        }

        private void pictureBoxBoard25_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(2, 5);
        }

        private void pictureBoxBoard26_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(2, 6);
        }

        private void pictureBoxBoard27_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(2, 7);
        }

        private void pictureBoxBoard30_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(3, 0);
        }

        private void pictureBoxBoard31_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(3, 1);
        }

        private void pictureBoxBoard32_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(3, 2);
        }

        private void pictureBoxBoard33_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(3, 3);
        }

        private void pictureBoxBoard34_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(3, 4);
        }

        private void pictureBoxBoard35_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(3, 5);
        }

        private void pictureBoxBoard36_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(3, 6);
        }

        private void pictureBoxBoard37_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(3, 7);
        }

        private void pictureBoxBoard40_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(4, 0);
        }

        private void pictureBoxBoard41_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(4, 1);
        }

        private void pictureBoxBoard42_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(4, 2);
        }

        private void pictureBoxBoard43_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(4, 3);
        }

        private void pictureBoxBoard44_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(4, 4);
        }

        private void pictureBoxBoard45_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(4, 5);
        }

        private void pictureBoxBoard46_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(4, 6);
        }

        private void pictureBoxBoard47_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(4, 7);
        }

        private void pictureBoxBoard50_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(5, 0);
        }

        private void pictureBoxBoard51_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(5, 1);
        }

        private void pictureBoxBoard52_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(5, 2);
        }

        private void pictureBoxBoard53_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(5, 3);
        }

        private void pictureBoxBoard54_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(5, 4);
        }

        private void pictureBoxBoard55_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(5, 5);
        }

        private void pictureBoxBoard56_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(5, 6);
        }

        private void pictureBoxBoard57_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(5, 7);
        }

        private void pictureBoxBoard60_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(6, 0);
        }

        private void pictureBoxBoard61_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(6, 1);
        }

        private void pictureBoxBoard62_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(6, 2);
        }

        private void pictureBoxBoard63_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(6, 3);
        }

        private void pictureBoxBoard64_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(6, 4);
        }

        private void pictureBoxBoard65_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(6, 5);
        }

        private void pictureBoxBoard66_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(6, 6);
        }

        private void pictureBoxBoard67_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(6, 7);
        }

        private void pictureBoxBoard70_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(7, 0);
        }

        private void pictureBoxBoard71_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(7, 1);
        }

        private void pictureBoxBoard72_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(7, 2);
        }

        private void pictureBoxBoard73_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(7, 3);
        }

        private void pictureBoxBoard74_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(7, 4);
        }

        private void pictureBoxBoard75_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(7, 5);
        }

        private void pictureBoxBoard76_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(7, 6);
        }

        private void pictureBoxBoard77_Click(object sender, EventArgs e)
        {
            //Send position of the board piece to the boardClicked Method
            boardClicked(7, 7);
        }

        /************************************Correction panel clicks****************************************/
        //Runs the correction method placing the piece selected into the "inHand" variable
        private void pictureBoxCorrectionBlackPawn_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("blackPawn");
        }

        private void pictureBoxCorrectionBlackRook_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("blackRook");
        }

        private void pictureBoxCorrectionBlackKnight_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("blackKnight");
        }

        private void pictureBoxCorrectionBlackBishop_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("blackBishop");
        }

        private void pictureBoxCorrectionBlackQueen_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("blackQueen");
        }

        private void pictureBoxCorrectionBlackKing_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("blackKing");
        }

        private void pictureBoxCorrectionWhitePawn_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("whitePawn");
        }

        private void pictureBoxCorrectionWhiteRook_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("whiteRook");
        }

        private void pictureBoxCorrectionWhiteKnight_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("whiteKnight");
        }

        private void pictureBoxCorrectionWhiteBishop_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("whiteBishop");
        }

        private void pictureBoxCorrectionWhiteQueen_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("whiteQueen");
        }

        private void pictureBoxCorrectionWhiteKing_Click(object sender, EventArgs e)
        {
            //Put the piece needing to be corrected into the "inHand" variable
            correction("whiteKing");
        }
    }
}
