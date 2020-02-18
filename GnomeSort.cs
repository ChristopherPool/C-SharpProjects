using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Title: GnomeSort 
 * Description: Windows Forms Application that sorts a list of random numbers by using the Gnome Sort algorithm. 
 * The program uses an Array of 28 integers. After each iteration the program displays the Array. 
 */

namespace GnomeSort
{
    public partial class Form1 : Form
    {
        public GnomeSortAlgorithm()
        {
            InitializeComponent();
            // Call method to fill Array at start up
            FillArray();
        }
        // Array of random integers
        static int max = 28;
        int[] myArray = new int[max];
        private void btnSort_Click(object sender, EventArgs e)
        {
            int pos = 1;
            while (pos < max)

                // Pause here to see each iteration
                // and Displays Array

            if (myArray[pos] >= myArray[pos - 1])
                {
                    pos = pos + 1;
                }
                else
                {
                    Application.DoEvents();
                    Thread.Sleep(50);
                    // Swap routine
                    int temp = myArray[pos - 1];
                    myArray[pos - 1] = myArray[pos];
                    myArray[pos] = temp;
                    ShowArray();

                    if (pos > 1)
                    {
                        pos = pos - 1;
                    }
                }
        }


         // Method to display array
        private void ShowArray()
        {
            listResults.Items.Clear();
            for (int i = 0; i < max; i++)
            {
                listResults.Items.Add(myArray[i]);
            }
        }// end of method ShowArray
         // Method to fill Array with random numbers
        private void FillArray()
        {
            // Create a random number
            Random rand = new Random();
            for (int i = 0; i < max; i++)
            {
                // Random number 0..100
                myArray[i] = rand.Next(100);
            }
            ShowArray();
        }// end of method FillArray
    }
}
