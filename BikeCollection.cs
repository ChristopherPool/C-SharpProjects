using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

/*
 * Title: Bike Collection
 * Description: A Windows Forms Application which allows a person to keep track of their Classic Bike collection
 */

namespace classicCollection
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        // Create a list for bikes
        List<Bikes> myBikes = new List<Bikes>();

        // Method to add bike data to the bike list 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Local variable to check if text box has data
            bool hasData = true;

            // New bike
            Bikes newBike = new Bikes();

            // Get bike data from text box
            newBike.bikeModel = textModel.Text;
            newBike.makeName = textMake.Text;
            newBike.engSize = textEngSize.Text;
            newBike.bikeYear = textYear.Text;
            newBike.bikeCost = textCost.Text;



            // Check if text box has data
            // If null or empty sets hasData to false
            if (String.IsNullOrEmpty(textMake.Text))
            {
                MessageBox.Show("Please enter model name");
                hasData = false;
                return;
            }
            if (String.IsNullOrEmpty(textModel.Text))
            {
                MessageBox.Show("Please enter make");
                hasData = false;
                return;
            }
            if (String.IsNullOrEmpty(textEngSize.Text))
            {
                MessageBox.Show("Please enter engine size");
                hasData = false;
                return;
            }
            if (String.IsNullOrEmpty(textYear.Text))
            {
                MessageBox.Show("Please enter year");
                hasData = false;
                return;
            }
            if (String.IsNullOrEmpty(textCost.Text))
            {
                MessageBox.Show("Please enter bike cost");
                hasData = false;
                return;
            }

            // If all data is valid and there are no duplicates
            // then adds the record to the list
            bool duplicateFound = myBikes.Exists(x => x.bikeModel == textMake.Text);
            if (hasData)
            {
                // Add record to bike List<>
                myBikes.Add(newBike);

                // Empty the fields for the next record
                ResetDetails();

                // Sorts the bike data when a bike is added.
                myBikes.Sort();

                // Display the records in the list box
                DisplayRecords();
            }
            else
            {
                MessageBox.Show("thats never going to work");
            }
        }

        // Check if a record has been selected from the list box
        // then removes that record
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBikes.SelectedIndex == -1)
            {
                MessageBox.Show("Select a record from the List Box");
            }
            else
            {
                var confirmDelete = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.Yes)
                {
                    string curItem = listBikes.SelectedItem.ToString();
                    int indx = listBikes.FindString(curItem);
                    myBikes.RemoveAt(indx);
                    DisplayRecords();
                    ResetDetails();
                }
            }
        }

        // Update a selected record
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Bikes updatedBikes = new Bikes();
            updatedBikes.bikeModel = textModel.Text;
            updatedBikes.makeName = textMake.Text;
            updatedBikes.engSize = textEngSize.Text;
            updatedBikes.bikeYear = textYear.Text;
            updatedBikes.bikeCost = textCost.Text;
            if (listBikes.SelectedIndex == -1)
            {
                MessageBox.Show("Select a record from the List Box");
            }
            else
            {
                var confirmUpdate = MessageBox.Show("Are you sure you want to update this record?", "Confirm Update", MessageBoxButtons.YesNo);
                if (confirmUpdate == DialogResult.Yes)
                {
                    string curItem = listBikes.SelectedItem.ToString();
                    int indx = listBikes.FindString(curItem);

                    myBikes[indx].bikeModel = updatedBikes.bikeModel;
                    myBikes[indx].makeName = updatedBikes.makeName;
                    myBikes[indx].engSize = updatedBikes.engSize;
                    myBikes[indx].bikeYear = updatedBikes.bikeYear;
                    myBikes[indx].bikeCost = updatedBikes.bikeCost;


                    ResetDetails();
                    DisplayRecords();
                    MessageBox.Show("Record Updated");
                }
            }
        }

        // Button method to clear all the TextBoxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetDetails();
        }

        // Method that sorts the bike List<> by model uses the
        // IComparable<bike> in the bike class
        // and the CompareTo method
        private void btnSort_Click(object sender, EventArgs e)
        {
            myBikes.Sort();
            DisplayRecords();
        }

        // Method to obtain a selected record from the ListBox
        private void listBikes_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBikes.SelectedIndex == -1)
            {
                MessageBox.Show("Select a record from the List Box");
            }
            else
            {
                string curItem = listBikes.SelectedItem.ToString();
                int indx = listBikes.FindString(curItem);
                listBikes.SetSelected(indx, true);
                textMake.Text = myBikes[indx].bikeModel;
                textModel.Text = myBikes[indx].makeName;
                textEngSize.Text = myBikes[indx].engSize;
                textYear.Text = myBikes[indx].bikeYear;
                textCost.Text = myBikes[indx].bikeCost;
            }
        }

        // Show all the records in the List<>
        public void DisplayRecords()
        {
            // Clear the list before displaying the records
            listBikes.Items.Clear();
            // Loop through the List<> and show the fullName and Position
            foreach (var emp in myBikes)
            {
                listBikes.Items.Add(emp.makeName + "\t: " + emp.bikeModel + "\t: "  + emp.engSize);
            }
        }

        // Reset the field to empty for the next data input
        private void ResetDetails()
        {
            // Clears the text box fields
            textMake.Text = "";
            textModel.Text = "";
            textEngSize.Text = "";
            textYear.Text = "";
            textCost.Text = "";
        }

        // Uses Binary Search to search bikes 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            {
                int mid;
                int lowBound = 0;
                int highBound = myBikes.Count;

                while (lowBound <= highBound) 
                {
                    // Find the mid-point
                    mid = (lowBound + highBound) / 2;
                  
                    if (myBikes[mid].bikeModel == textModel.Text)
                    {
                        listBikes.SetSelected(mid, true);
                        return;
                    }
                    else if (myBikes[mid].bikeModel.CompareTo(textModel.Text) > 0)
                    {
                        highBound = mid - 1;
                    }
                    else
                    {
                        lowBound = mid + 1;
                    }

                }
                MessageBox.Show("Not Found, try again.");
                ResetDetails();
            }
        }
        
        // On load of program, loads bike information from text file.
        private void form1_Load(object sender, EventArgs e)
        {
            TextReader tr = new StreamReader("data.txt");
            string bikeData;
            while ((bikeData = tr.ReadLine()) != null)
            {
                Bikes temp = new Bikes();
                temp.makeName = bikeData;
                temp.bikeModel = tr.ReadLine();
                temp.engSize = tr.ReadLine();
                temp.bikeYear = tr.ReadLine();
                temp.bikeCost = tr.ReadLine();
                myBikes.Add(temp);


            }
            myBikes.Sort();
            DisplayRecords();
            tr.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var confirmSave = MessageBox.Show("Are you sure you want to save this data?", "Confirm Save", MessageBoxButtons.YesNo);
            if (confirmSave == DialogResult.Yes)  
                {
                TextWriter tw = new StreamWriter("data.txt");

                foreach (var emp in myBikes)
                {
                    tw.WriteLine(emp.makeName);
                    tw.WriteLine(emp.bikeModel);
                    tw.WriteLine(emp.engSize);
                    tw.WriteLine(emp.bikeYear);
                    tw.WriteLine(emp.bikeCost);
                }
                tw.Close();
                MessageBox.Show("Save Completed Successfully", "Save Completed");
            }
        }
        // All data written to text file when program closes
        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TextWriter tw = new StreamWriter("data.txt");
            foreach (var emp in myBikes)
            {
                tw.WriteLine(emp.makeName);
                tw.WriteLine(emp.bikeModel);
                tw.WriteLine(emp.engSize);
                tw.WriteLine(emp.bikeYear);
                tw.WriteLine(emp.bikeCost);
            }
            tw.Close();
        }

        // resets/clears all the bike records (data) from the List. The ListBox and text fields are also cleared.
        private void resetList_Click(object sender, EventArgs e)
        {
            var confirmReset = MessageBox.Show("Are you sure you want to reset?", "Confirm Reset", MessageBoxButtons.YesNo);
            if (confirmReset == DialogResult.Yes)
            {
                listBikes.Items.Clear();
                myBikes.Clear();
                ResetDetails();
            }
            else
            {

            }
    
        }
        //	When a Model is selected from the ListBox the details are displayed in the textboxes.
        private void listBikes_SelectedIndexChanged(object sender, EventArgs e)
        {
            textMake.Text = myBikes[listBikes.SelectedIndex].makeName;
            textModel.Text = myBikes[listBikes.SelectedIndex].bikeModel;
            textEngSize.Text = myBikes[listBikes.SelectedIndex].engSize;
            textYear.Text = myBikes[listBikes.SelectedIndex].bikeYear;
            textCost.Text = myBikes[listBikes.SelectedIndex].bikeCost;
        }
    }
}

// Class of bike fields
 // IComparable<bikes> is used for the sort method.
 public class Bikes : IComparable<Bikes>
{
    [XmlElement("bikeModel")]
    public string bikeModel
    {
        get;
        set;
    }
    [XmlElement("makeName")]
    public string makeName
    {
        get;
        set;
    }
    [XmlElement("engSize")]
    public string engSize
    {
        get;
        set;
    }
    [XmlElement("bikeYear")]
    public string bikeYear
    {
        get;
        set;
    }
    [XmlElement("bikeCost")]
    public string bikeCost
    {
        get;
        set;
    }
    // compare method to sort by bike model
    public int CompareTo(Bikes other)
    {
        return this.bikeModel.CompareTo(other.bikeModel);
    }
}
