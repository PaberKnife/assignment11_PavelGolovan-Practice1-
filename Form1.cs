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

namespace assignment11_PavelGolovan_Practice1_
{
    public partial class Form1 : Form
    {
        private List<Pet> petList =
            new List<Pet>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ReadFile()
        {
            StreamReader inputFile;
            string line;

            char[] delim = { '-' };

            try
            {
                inputFile = File.OpenText("Pets.txt");
            }
            catch
            {
                StreamWriter outputFile;
                outputFile = File.CreateText("Pets.txt");
                outputFile.Close();
                inputFile = File.OpenText("Pets.txt");
            }

            while (!inputFile.EndOfStream)
            {
                try
                {
                    Pet pet = new Pet();
                    line = inputFile.ReadLine();
                    string[] tokens = line.Split(delim);
                    pet.Name = tokens[0];
                    pet.Type = tokens[1];
                    pet.Age = int.Parse(tokens[2]);
                    petList.Add(pet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            inputFile.Close();
        }

        private void DisplayNames()
        {
            petListBox.Items.Clear();
            foreach (Pet pet in petList)
            {
                petListBox.Items.Add(pet.Name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();
            DisplayNames();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !String.IsNullOrWhiteSpace(typeTextBox.Text) &&
                !String.IsNullOrWhiteSpace(ageTextBox.Text))
            {
                Pet pet = new Pet();
                pet.Name = nameTextBox.Text;
                pet.Type = typeTextBox.Text;

                try
                {
                    pet.Age = int.Parse(ageTextBox.Text);

                    petList.Add(pet);

                    StreamWriter outputFile;
                    outputFile = File.AppendText("Pets.txt");
                    outputFile.WriteLine(pet.Name + "-" + pet.Type + "-" + (pet.Age).ToString());
                    outputFile.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DisplayNames();
            }
            else
            {
                MessageBox.Show("Please enter full details.");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            typeTextBox.Text = "";
            ageTextBox.Text = "";
            nameTextBox.Focus();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = petListBox.SelectedIndex;
                MessageBox.Show(petList[index].Show());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}