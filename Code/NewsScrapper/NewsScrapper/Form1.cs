using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NewsScrapper
{
    public partial class Form1 : Form
    {

        IWebDriver driver = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                driver = new ChromeDriver("chromedriver");
                driver.Navigate().GoToUrl("http://www.dawn.com/pakistan");
                Thread.Sleep(15000);
                StartReadingRows();
                //EnterText(key);
            }
            catch
            {
                MessageBox.Show("There was an error.Program will now close");
                System.Windows.Forms.Application.Exit();
            }
        }

        private void StartReadingRows()
        {
            var newsList = driver.FindElements(By.ClassName("box"));
            foreach (var news in newsList)
            {
                var head = news.FindElement(By.ClassName("story__title"));
                var heading = head.Text;
                var det = news.FindElement(By.ClassName("story__excerpt"));
                var shortDetail = det.Text;

                textBox1.Text += heading + Environment.NewLine;
                textBox1.Text += shortDetail +Environment.NewLine + Environment.NewLine;
            }
        }
    }
}
