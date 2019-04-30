using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExceptionsSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (isValidAge(txtAge.Text))
            {
                errorLabel.Text = "Thanks for the valid age!";
            }
            else
            {
                errorLabel.Text = "This is not a valid age!";
            }
        }

        private bool IsValidByte(string input, Label errorLabel)
        {
            try
            {
                Convert.ToByte(input);
                return true;
            }
            catch (Exception)
            {
                errorLabel.Text = "must be betweeen 0 and 255";
                return false;
            }
        }

        /// <summary>
        /// Ensure username is not one of the blacklisted names
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <param name="userName">The username to check</param>
        /// <returns></returns>
        private bool isValidUsername(String userName)
        {
            try
            {
                if (userName.ToLower() == "admin")
                {
                    throw new Exception("Invalid username!");
                }
            }
            catch (Exception ex)
            {
                //log the exception to a text file          ??why would you do this??
                MessageBox.Show("Invalid input");
                throw ex;
            }           
            return true;
        }

        private bool isValidAge(string input)
        {
            try
            {
                //can use this instead of the if/else statement
                byte age = Convert.ToByte(input);
                if(age < 12 || age > 125)
                {
                    throw new OverflowException("Your age is not valid");
                }
                return true;
                
                //if(age >= 12 && age <= 125)
                //{
                //    return true;
                //}
                //return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnValUsername_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValidUsername(txtUsername.Text))
                {
                    MessageBox.Show("Username is valid!");
                }
                else
                {
                    MessageBox.Show("Pick a different name!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("That username CANNOT be used!");
            }
        }

        /// <summary>
        /// Checks if a textbox contains text
        /// </summary>
        /// <param name="box">The textbox that we are checking</param>
        /// <param name="name">A human-readable name for the textbox</param>
        /// <returns></returns>
        private bool isPresent(TextBox box, string name)
        {
            //if(box.Text.Trim() == string.Empty)
            if(string.IsNullOrWhiteSpace(box.Text))
            {
                MessageBox.Show($"{name} is required!", 
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                box.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box">Textbox that you are pulling information out of</param>
        /// <param name="name">Readable name given to the textbox</param>
        /// <param name="min">The inclusive minimum value</param>
        /// <param name="max">The inclusive maximum value</param>
        /// <returns></returns>
        private bool isWithinRange(TextBox box, string name, 
                                   double min, double max)
        {
            //What you put when you do not habe any code to go inside of it
            throw new NotImplementedException();
        }

        private bool IsFormDataValid()
        {
            if(isPresent(txtAge, "Age") && isPresent(txtUsername, "Username") &&
                isValidAge(txtAge.Text))
            {
                return true;
            }
            return false;
        }
    }
}


