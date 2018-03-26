using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Checkered_Board
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int TILE_W = 40;//sets tile width
        private const int TILE_H = 40;//sets tile height
        /*next two lines are for total number of tiles of board (100 total). This works because the canvas is 400x400 and 
         * the tiles are 40x40 which means that 10 tile columns by 10 tile rows will fill up the canvas
         */
        private const int GRID_ROWS = 10;
        private const int GRID_COLS = 10;
        //next line is both a visual representation of the board and an array of 100 int values
        private int[] grid = new int[] { 1,0,1,0,1,0,1,0,1,0,
                                         0,1,0,1,0,1,0,1,0,1,
                                         1,0,1,0,1,0,1,0,1,0,
                                         0,1,0,1,0,1,0,1,0,1,
                                         1,0,1,0,1,0,1,0,1,0,
                                         0,1,0,1,0,1,0,1,0,1,
                                         1,0,1,0,1,0,1,0,1,0,
                                         0,1,0,1,0,1,0,1,0,1,
                                         1,0,1,0,1,0,1,0,1,0,
                                         0,1,0,1,0,1,0,1,0,1,};

        public MainWindow()
        {
            InitializeComponent();
            drawSquare();//call drawSquare()
        }

        private void drawSquare()
        {
            //the double for loop is used because it's what allow multiple rows to be drawn
            //next line loops through row
            for (int eachRow = 0; eachRow < GRID_ROWS; eachRow++)
            {
                //next line loops through column
                for (int eachCol = 0; eachCol < GRID_COLS; eachCol++)
                {
                    //this line calls a method to return an index
                    int arrayIndex = rowColToArrayIndex(eachCol, eachRow);

                    //if statement check to see if the index returned has a value of 1
                    if (grid[arrayIndex] == 1)
                    {
                        //if it does then the following executes
                        Rectangle square = new Rectangle();
                        //next two lines are for color. made the stroke red for easier visualization
                        square.Stroke = new SolidColorBrush(Colors.Red);
                        square.Fill = new SolidColorBrush(Colors.White);
                        //next two lines set the width and height of square which has already been determined
                        square.Width = TILE_W;
                        square.Height = TILE_H;
                        //next two lines set the position of the square according to the values of eachCol and eachRow
                        Canvas.SetLeft(square, TILE_W * eachCol);
                        Canvas.SetTop(square, TILE_H * eachRow);

                        checkeredBoard.Children.Add(square);
                    }
                }
            }
        }

        private int rowColToArrayIndex(int col, int row)
        {
            /*method takes eachCol and eachRow from drawSquare() to return an index. 
             * For example, the first time it will return 0 and the second time it will return 1.
             */
            return col + GRID_COLS * row;
        }
    }
}
