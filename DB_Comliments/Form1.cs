using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DB_Comliments
{
    public partial class Form1 : Form
    {
        int count_compl = 3;
        List<string> mass_compl = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " " && textBox1.Text == null && textBox1.Text.Length < 1) 
            {
                count_compl = 3;
            }
            count_compl = Int32.Parse(textBox1.Text);
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://castlots.org/generator-komplimentov-devushke/");

            IWebElement generate_button = driver.FindElement(By.Id("random-button"));
            IWebElement compl_text = driver.FindElement(By.ClassName("compliment"));

            for (int i = 0; i < count_compl; i++) 
            {
                generate_button.Click();
                System.Threading.Thread.Sleep(1300);
                mass_compl.Add(compl_text.GetAttribute("innerText"));
                label1.Text = "Собрано строк: " + i + 1;
                System.Threading.Thread.Sleep(1500);
            }

            string path = "compl.txt";
            StreamWriter file = new StreamWriter(path);

            for (int j = 0; j < mass_compl.Count; j++)
            {
                file.WriteLine(mass_compl[j]); 
            }
            file.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "3";
        }
    }
}
