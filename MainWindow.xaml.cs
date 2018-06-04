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

namespace u5GameOfLIfe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        int counter = 0;
        double[,] myCells;
        string temp;
        Rectangle[,] myRectangles;
        int[] cordList = new int[800];
        int x_cord = 0;
        int y_cord = 0;
        public MainWindow()
        {



            InitializeComponent();
            MessageBox.Show("Welcome to Game of Life! Please type you're starting Coordinates in x and y format, seperated by a comma.");
            
           
            Console.WriteLine(temp);
            
        }

        private void DrawGrid(out string temp, out Rectangle[,] myRectangles)
        {
            myCells = new double[20, 20];
            temp = "";
            int offset = 4;
            myRectangles = new Rectangle[20, 20];


            //MessageBox.Show(myCells.GetLength(1).ToString());
            for (int col = 0; col < myCells.GetLength(0); col++)
            {
                for (int row = 0; row < myCells.GetLength(1); row++)
                {
                    myRectangles[row, col] = new Rectangle();
                    myRectangles[row, col].Stroke = Brushes.Black;
                    myRectangles[row, col].Fill = Brushes.White;
                    if (this.Width < this.Height)
                    {
                        myRectangles[row, col].Width = this.Width / 20 - offset;
                        myRectangles[row, col].Height = this.Width / 20 - offset;
                    }
                    else
                    {
                        myRectangles[row, col].Width = this.Height / 20 - offset;
                        myRectangles[row, col].Height = this.Height / 20 - offset;
                    }
                    myCanvas.Children.Add(myRectangles[row, col]);
                    Canvas.SetTop(myRectangles[row, col], row * myRectangles[row, col].Height + 25);
                    Canvas.SetLeft(myRectangles[row, col], col * myRectangles[row, col].Width + 50);
                    myCells[row, col] = 0;
                    temp += myCells[row, col].ToString() + " ";
                    
                }
                temp += "\n";
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                extractCords();
                DrawGrid(out temp, out myRectangles);
                drawCell();
            }
        }

        private void drawCell()
        {
           
                if (x_cord + y_cord <= 40)
                {
                    myRectangles[cordList[i], cordList[i + 1]].Fill = Brushes.Red;
                    
                }
                else
                {
                    MessageBox.Show("This cordinate is too big! Try something smaller than the Coordinates: 21,21");
                }
            }
        

        private void extractCords()
        {
            string InputCoordinates = txtInput.Text;
           
            
                int.TryParse(InputCoordinates.Substring(0, InputCoordinates.IndexOf(",")), out x_cord);
                //MessageBox.Show(x_cord.ToString());
                InputCoordinates = InputCoordinates.Substring(InputCoordinates.IndexOf(",") + 1);
                int.TryParse(InputCoordinates.Substring(0, InputCoordinates.Length), out y_cord);
                cordList[i] = x_cord;
                cordList[i + 1] = y_cord;
                MessageBox.Show("x_cord: " + cordList[i] + "y_cord: " + cordList[i + 1] + "i int: " + i.ToString());
                i += 2;
                
                //MessageBox.Show(y_cord.ToString());
                

            
        }
            
    }
}
