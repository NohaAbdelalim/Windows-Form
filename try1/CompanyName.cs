using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace try1
{
    public partial class CompanyName : Form
    {


        string tbox1;
        string tbox2;
        Color text_Color;
        Color temp_color;
        Brush text_brush;
        string font;
        int size;
        string old_name;
        string new_name;
        bool redioButton;





        //textbox1 is privet so we intialize public property to deal with it
        public string Compony_old_Name
        {
            set { old_name = value; }
            get { return old_name; }
        }
        public string Compony_new_Name
        {
            set { new_name = value; }
            get { return new_name; }
        }
        public string Tbox2
        {
            set { textBox2.Text = value; }
            get { return textBox2.Text; }
        }
        public Color Text_Color
        {
            set { text_Color = value;
                temp_color = value; }
            get { return text_Color; }



        }
        public string textFont
        {

            set { font = value; }
            get { return font; }
        }
        public int FontSize
        {

            set { size = value; }
            get { return size; }

        }
        public Brush Text_brush
        {
            set { text_brush = value; }
            get { return text_brush; }
        }


        private Form1 form1Instance;
        public CompanyName()
        {
            InitializeComponent();

            //form1Instance = form1;
            //button3.Click += eventhandler;
        }







        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            new_name = textBox2.Text;
            text_Color = temp_color;

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog clr = new ColorDialog();
            DialogResult dlg = clr.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                temp_color = clr.Color;
                // text_brush = new SolidBrush(text_Color);
                Invalidate();
            }
        }



        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {

                font = "Times New Roman";

            }

            else if (radioButton5.Checked)
            {
                font = "Courier New";

            }
            else if (radioButton6.Checked)
            {
                font = "Arial";


            }


        }

        private void radioButton_size_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                size = 16;
            }
            else if (radioButton2.Checked)
            {
                size = 20;
            }
            else if (radioButton3.Checked)
            {
                size = 24;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void CompanyName_Load(object sender, EventArgs e)
        {
            textBox1.Text = old_name;

            if (size == 16)
            {
                radioButton1.Checked = true;

            }
            else if (size == 20)
            {

                radioButton2.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;
            }

        }
    }
}
