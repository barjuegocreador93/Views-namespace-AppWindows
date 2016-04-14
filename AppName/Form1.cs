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
            MyViews.InsertNewControlOnView<Label>(label2,"static Example View");
            MyViews.InsertNewControlOnView<Label>(label1, "Page 1");
            MyViews.InsertNewControlOnView<Button>(button1, "Index");

            

            comboBox1.Items.Add("Page 2");
            comboBox1.Items.Add("Page 3");
                        
            MyViews.CreateNewView("*Dinamic View 1");
            MyViews.InsertNewControlOnView<Label>(label2);
            MyViews.InsertNewControlOnView<Label>(label1);
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
                    MyViews.MoveToOtherView("Hello World");
                    break;
                default:
                    MyViews.MoveToOtherView(button1.Text);
                    break;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(MyViews.ActualView)
            {
                case "Index":
                    switch(comboBox1.Text)
                    {
                        case "Page 2":
                            MyViews.ReplaceViewName("*Dinamic View 1", "Page 2");
                            MyViews.ChangeControlOnView<Label>("Page 2", label1, "Page 2");
                            MyViews.ChangeControlOnView<Label>("Page 2", label2, "this is a dnamic view");
                            MyViews.MoveToOtherView("Page 2");
                            break;
                        case "Page 3":
                            MyViews.ReplaceViewName("*Dinamic View 1", "Page 3");
                            MyViews.ChangeControlOnView<Label>("Page 3", label1, "Page 3");
                            MyViews.ChangeControlOnView<Label>("Page 3", label2, "this is a other dnamic view");
                            MyViews.MoveToOtherView("Page 3");
                            break;
                        default:
                            MyViews.MoveToOtherView(comboBox1.Text);
                            break;
                    }
                    break;

                default:
                    MyViews.MoveToOtherView(comboBox1.Text);
                    break;
            }
            
        }
    }
}
