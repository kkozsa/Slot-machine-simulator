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

namespace Slot_machine_simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int inputMoney = 0;     
        int won = 0;
        Random random = new Random();       // Random class to generate random number
        string[] fruitImages = { "apple.bmp", "banana.bmp", "cherries.bmp", "grapes.bmp", "lemon.bmp", "lime.bmp" };
        // String array to store files of fruit images.

        private void spinButton_Click(object sender, EventArgs e)
        {
            int insertMoney;
            if (int.TryParse(amountTextbox.Text, out insertMoney))
            {
                if (insertMoney <= 0)       // Check if the amount is above 0
                {
                    MessageBox.Show("Please insert a valid amount.");
                    return;
                }

                inputMoney += insertMoney;

                string fruit1 = Path.Combine("C:\\Users\\KK\\Desktop\\DBS\\Object oriented programming\\CA\\Slot machine simulator\\Images", fruitImages[random.Next(fruitImages.Length)]);
                string fruit2 = Path.Combine("C:\\Users\\KK\\Desktop\\DBS\\Object oriented programming\\CA\\Slot machine simulator\\Images", fruitImages[random.Next(fruitImages.Length)]);
                string fruit3 = Path.Combine("C:\\Users\\KK\\Desktop\\DBS\\Object oriented programming\\CA\\Slot machine simulator\\Images", fruitImages[random.Next(fruitImages.Length)]);
                // Strings   generate a random number between 0 and the length of the fruitImages array.   

                pictureBox1.Image = Image.FromFile(fruit1);     // Adds images to the pictureboxes.
                pictureBox2.Image = Image.FromFile(fruit2);
                pictureBox3.Image = Image.FromFile(fruit3);

                if (fruit1 == fruit2 && fruit2 == fruit3)
                {
                    int match = 3;
                    int winning = inputMoney * match;
                    won += winning;
                    MessageBox.Show("Congratulations, you have won " + winning);

                }

                else if (fruit1 == fruit2 || fruit1 == fruit3 || fruit2 == fruit3)
                {
                    int match = 2;
                    int winning = inputMoney * match;
                    won += winning;
                    MessageBox.Show("Congratulations, you have won " + winning);

                }

                else
                {
                    MessageBox.Show("Sorry, you did not win.");
                }

            }
            else
            {
                MessageBox.Show(" Enter a valid amount.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total amount played: " + inputMoney );
            MessageBox.Show("Total amount won: " + won);
            this.Close();
        }

        
    }
}
