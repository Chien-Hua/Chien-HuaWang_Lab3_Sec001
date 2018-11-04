using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chien_HuaWang_Lab3_Exerise1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            long number = 0;
            bool isNumber = long.TryParse(textBox1.Text, out number);
            CheckInputFormat(isNumber);
            await Task.WhenAll(Task.Run(() => Factorial(number)));
            label7.Visible = true;
            label7.Text = Factorial(number).ToString();
        }
        private long Factorial(long number)
        {
            if (number == 1 || number == 2)
            {
                return number;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private delegate bool delFuncation(int number);
        private void button2_Click(object sender, EventArgs e)
        {
            int number = 0;
            bool isNumber = int.TryParse(textBox2.Text, out number);
            CheckInputFormat(isNumber);

            delFuncation IsEven = new delFuncation(inputNum => inputNum % 2 == 0);
            Func<int, bool> IsOdd = inputNum => inputNum % 2 != 0;

            if (IsEven(number) == true)
            {
                label8.Visible = true;
                label8.Text = "It is Even";
            }
            else if (IsOdd(number) == true)
            {
                label8.Visible = true;
                label8.Text = "It is Odd";
            }

        }
        protected List<int> intList;
        protected List<double> doubleList;
        protected List<char> charList;
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (radioButton1.Checked)
            {
                intList = new List<int>();
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int randomNumber = random.Next(10, 99);
                    intList.Add(randomNumber);
                    listBox1.Items.Add(randomNumber.ToString() + "\n");
                    
                }
            }
            else if (radioButton2.Checked)
            {
                
                doubleList = new List<double>();
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    int randomNumber = random.Next(10, 99);
                    double decimalNumber = randomNumber + (0.01 * random.Next(10, 99));
                    doubleList.Add(decimalNumber);
                    listBox1.Items.Add (decimalNumber.ToString() + "\n");
                }
            }
            else if (radioButton3.Checked)
            {
                charList = new List<char>();
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    char randomChar = chars[random.Next(chars.Length)];
                    charList.Add(randomChar);
                    listBox1.Items.Add( randomChar.ToString() + "\n");
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                int input = 0;
                bool isNumber = int.TryParse(textBox3.Text.ToString(), out input);
                CheckInputFormat(isNumber);
                DisplaySearchResult(SearchData(intList, input));

            }
            else if (radioButton2.Checked)
            {
                double input = 0;
                bool isDouble = double.TryParse(textBox3.Text.ToString(), out input);
                CheckInputFormat(isDouble);
                DisplaySearchResult(SearchData(doubleList, input));
            }
            else if (radioButton3.Checked)
            {
                char input = '\0';
                bool isChar = char.TryParse(textBox3.Text.ToString(), out input);
                CheckInputFormat(isChar);
                DisplaySearchResult(SearchData(charList, input));
            }
        }
        private void DisplaySearchResult(bool result)
        {
            if (result == true)
            {
                label9.Visible = true;
                label9.Text = "Input is found";
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Input is NOT found";
            }
        }

        private bool SearchData<T>(List<T> list, object input)
        {
            CheckEmptyList(list);
            bool isFind = false;
            foreach (var item in list)
            {
                if (input.ToString() == item.ToString())
                {
                    isFind = true;
                    break;
                }
                else
                {
                    isFind = false;
                }
            }
            return isFind;
        }
        private void CheckInputFormat(bool NotEmpty)
        {
            if (NotEmpty == false)
            {
                throw new Exception("Input is ERROR!");
            }
        }
        private void CheckEmptyList<T>(List<T> list)
        {
            if (list == null)
            {
                throw new Exception("List is EMPTY!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int lowIndex;
            int highIndex;
            bool isLowIndexInt = int.TryParse(textBox4.Text.ToString(), out lowIndex);
            CheckInputFormat(isLowIndexInt);
            bool isHighIndexInt = int.TryParse(textBox5.Text.ToString(), out highIndex);
            CheckInputFormat(isHighIndexInt);

            if (radioButton1.Checked)
            {
                foreach (string item in PrintData(intList, lowIndex, highIndex))
                {
                    listBox2.Items.Add(item);
                }
            }
            else if (radioButton2.Checked)
            {
                foreach (string item in PrintData(doubleList, lowIndex, highIndex))
                {
                   listBox2.Items.Add(item);
                }
            }
            else if (radioButton3.Checked)
            {
                foreach (string item in PrintData(charList, lowIndex, highIndex))
                {
                    listBox2.Items.Add(item);
                }
            }
        }

        private List<string> PrintData<T>(List<T> list, int lowIndex, int highIndex)
        {
            CheckEmptyList(list);
            List<string> displayList = new List<string>();
            if (lowIndex < 0 || highIndex < 0)
            {
                throw new Exception("Error! Index is negative");
            }
            else if (lowIndex >= highIndex)
            {
                throw new Exception("Error! Low Index cannot be greater than or equal to High Index");
            }
            else if (highIndex > list.Count)
            {
                throw new IndexOutOfRangeException("Error! Index is out of Range");
            }

            for (int i = lowIndex +1 ; i < highIndex; i++)
            {
                displayList.Add(list[i].ToString());
            }
            return displayList;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
    }



