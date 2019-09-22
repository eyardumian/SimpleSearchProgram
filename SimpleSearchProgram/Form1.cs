using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSearchProgram
{
    public partial class Form1 : Form
    {
        public string file;
        public Form1()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            //Clear the ListBox for a new search.
            ListBoxResults.Items.Clear();
            
            //Open the dialog box and select a file.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                    file = openFileDialog1.FileName;               
            }
            //Display a message if user cancels the search.
            else
            {
                MessageBox.Show("Operation canceled.");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            
           StreamReader sr = new StreamReader(path: file);
            while(!sr.EndOfStream)
            {
                //Read each line of file.
                var line = sr.ReadLine();
                if (String.IsNullOrEmpty(line)) continue;
                //Search for word.
                if (line.IndexOf(SearchTextBox.Text, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    //Add lines with matching word to ListBox.
                    ListBoxResults.Items.Add(line);
                }
            }
        }
    }
}
