using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppName
{
    public partial class Form1 : Form
    {
        Views MyViews = new Views();
        /// <summary>
        /// Inser your views
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            
            MyViews.CreateNewView("Hello World");
            MyViews.InsertNewControlOnView<Button>(button1, "Index");
            MyViews.InsertNewControlOnView<Label>(label1, "Hello World");

            MyViews.CreateNewView("Index");
            MyViews.InsertNewControlOnView<Button>(button1, "Back");
            MyViews.InsertNewControlOnView<Label>(label1, "Index");
            MyViews.InsertNewControlOnView<ComboBox>(comboBox1);

            comboBox1.Items.Add("Page 1");
            MyViews.CreateNewView("Page 1");
            MyViews.InsertNewControlOnView<TextBox>(textBox1);
            MyViews.InsertNewControlOnView<Label>(label1, "Page 1");
            MyViews.InsertNewControlOnView<Button>(button1, "Index");

            MyViews.InitViews();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (MyViews.ActualView)
            {
                case "Index":
                    MyViews.MoveToOtherVista("Hello World");
                    break;
                default:
                    MyViews.MoveToOtherVista(button1.Text);
                    break;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            MyViews.MoveToOtherVista(comboBox1.Text);
        }
    }
}
