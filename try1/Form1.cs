using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace try1
{
    public partial class Form1 : Form
    {
        #region member_var
        #region title and subtitle data
        //title
        string h_text;
        public Font h_textFont;
        public Color h_textColor;
        public Brush h_textBrush;
        PointF h_textStart;
        public string h_fontstyle;
        public int h_fontsize;
        //sub title
        string subh_text;
        Font subh_textFont;
        Color subh_textColor;
        Brush subh_textBrush;
        PointF subh_textStart;
        #endregion

        #region  table data

        // table data

        Color tableColor;
        Pen tableRectPen;
        Font tableDataFont;
        Color tableDataColor;
        Brush tableDataBrush;
        string[] year;
        string[] revenu;
        #endregion
        //chart
        #region charts data


        //arrow and labels

        Brush axisLabelBrush;
        Font axisLabelFont;
        //barchart
        int chart_Organx;
        int chart_Organy;
        Pen chart_Pen;
        Color chart_LineColor;
        Brush chart_Brush;
        Font chart_data;
        Brush chart_bars_Brush;
        HatchStyle brushstyle;
        Color barChartColor;
        int lineEndx;
        int lineEndy;
        //line chart
        Color lineChartColor;
        Pen lineChartPen;

        #endregion

        //dialog
        CompanyName CompanyNameDialogNewVal;
       // public delegate void Action(CompanyName arg1, CompanyName arg2);


        #endregion
        public Form1()
        {

            InitializeComponent();
            CompanyNameDialogNewVal = new CompanyName(); ;

            #region intialize title and subtitle data
            //comapny name
            h_text = "Company ABC";
            h_fontstyle = "times new roman";
            h_fontsize = 26;
            h_textFont = new Font(h_fontstyle, h_fontsize, FontStyle.Underline);
            h_textColor = Color.Black;
            h_textBrush = new SolidBrush(h_textColor);
            //subtitle
            subh_text = "Annual Revenue";
            subh_textColor = Color.Red;
            subh_textBrush = new SolidBrush(subh_textColor);
            subh_textFont = new Font("times new roman", 20, FontStyle.Underline);

            UpdateTextPositions();
            #endregion
            #region  intialize table data
            tableColor = Color.Black;
            tableRectPen = new Pen(tableColor, 1);

            //table data
            tableDataFont = new Font("times new roman", 12);
            tableDataColor = Color.Black;
            tableDataBrush = new SolidBrush(tableDataColor);


            year = new string[] { "1988", "1989", "1990", "1991", "1992", "1993", "1994", "1995", "1996", "1997" };
            revenu = new string[] { "150", "170", "180", "175", "200", "250", "210", "240", "280", "140" };
            #endregion
            #region chart data
            ////chart

            chart_Organx = 150;
            chart_Organy = 850;


            chart_LineColor = Color.Black;
            chart_Pen = new Pen(chart_LineColor, 3);

            chart_Brush = new SolidBrush(Color.Black);
            chart_data = new Font("arial", 10);
            lineEndx = chart_Organx + 650;
            lineEndy = chart_Organy - 600;

            //bars
            barChartColor = Color.Red;
            brushstyle = HatchStyle.BackwardDiagonal;
            chart_bars_Brush = new HatchBrush(brushstyle, Color.Black, barChartColor);

            //line chart

            lineChartColor = Color.Black;
            lineChartPen = new Pen(lineChartColor, 5);

            #endregion



        }



        #region header and subheader

        //update the value of the text points
        private void UpdateTextPositions()
        {
            h_textStart = TextCenter(h_text, h_textFont, 50);
            subh_textStart = TextCenter(subh_text, subh_textFont, 100);
        }

        //center the text in the screen
        private PointF TextCenter(string t, Font f, int y_axis)
        {
            float centerX = ClientSize.Width / 2f;
            float centerY = ClientSize.Height / 2f;
            SizeF textSize = TextRenderer.MeasureText(t, f);
            return new PointF(centerX - textSize.Width / 2, y_axis);
        }
        //display title and sub title
        private void DisplayStrings(Graphics g)
        {

            g.DrawString(h_text, h_textFont, h_textBrush, h_textStart);
            g.DrawString(subh_text, subh_textFont, subh_textBrush, subh_textStart);
        }

        #endregion
        ////table 
        #region table
        Rectangle[] drawTableyear()
        {
            int width = 70;
            int height = 50; // Specify the height of the rectangles
            Rectangle[] table_year = new Rectangle[11];
            int t_x_axis = (ClientSize.Width - 500); // Adjust the starting x-coordinate
            int t_y_axis = ((ClientSize.Height - (height * year.Length)) / 2);

            // "Year" column
            for (int i = 0; i < table_year.Length; i++)
            {
                table_year[i] = new Rectangle(t_x_axis, t_y_axis, width, height);
                t_y_axis += height; // Adjust the value based on the spacing you want between rectangles
            }

            return table_year;
        }
        Rectangle[] drawTablerevnue()
        {
            int width = 70;
            int height = 50; // Specify the height of the rectangles
            Rectangle[] table_revenue = new Rectangle[11];
            int t_x_axis = (ClientSize.Width - 500) + width; // Adjust the starting x-coordinate, adding width + spacing
            int t_y_axis = ((ClientSize.Height - (height * revenu.Length)) / 2);

            // "Revenue" column
            for (int i = 0; i < table_revenue.Length; i++)
            {
                table_revenue[i] = new Rectangle(t_x_axis, t_y_axis, width, height);
                t_y_axis += height; // Adjust the value based on the spacing you want between rectangles
            }

            return table_revenue;
        }
        private void DisplayRectanglesWithText(Rectangle[] tableyear, string[] year)
        {
            using (Graphics g = this.CreateGraphics())
            {
                //Rectangle[] tableyear = drawTableyear();

                // Draw the first rectangle for "Year"
                g.DrawRectangle(tableRectPen, tableyear[0]);
                g.DrawString("Year", tableDataFont, tableDataBrush, tableyear[0], new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
                for (int i = 0, j = 1; i < tableyear.Length - 1 && j < tableyear.Length; i++, j++)
                {
                    g.DrawRectangle(tableRectPen, tableyear[j]);
                    g.DrawString(year[i].ToString(), tableDataFont, tableDataBrush, tableyear[j], new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }


            }
        }
        private void DisplayRectanglesWithText2(Rectangle[] table_revnue, string[] revenu)
        {
            using (Graphics g = this.CreateGraphics())
            {
                //table_revnue = drawTablerevnue();

                // Draw the first rectangle for "revnue"
                g.DrawRectangle(tableRectPen, table_revnue[0]);
                g.DrawString("revnue", tableDataFont, tableDataBrush, table_revnue[0], new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                });
                // Draw rectangles for the years in the 'revnue' array
                for (int i = 0, j = 1; i < table_revnue.Length - 1 && j < table_revnue.Length; i++, j++)
                {
                    g.DrawRectangle(tableRectPen, table_revnue[j]);
                    g.DrawString(revenu[i].ToString(), tableDataFont, tableDataBrush, table_revnue[j], new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }
            }
        }


        #endregion

        #region displaychart


        private void drawChart(Graphics g)
        {
            int revScale = 0;
            string xAxisLabel = "Years";
            string yAxisLabel = "Revenue";
            //x-axise
            g.DrawLine(chart_Pen, chart_Organx, chart_Organy, lineEndx, chart_Organy);
            //y-axise
            g.DrawLine(chart_Pen, chart_Organx, chart_Organy, chart_Organx, lineEndy);
            //labels
            g.DrawString(xAxisLabel, chart_data, chart_Brush, lineEndx, chart_Organy + 5);
            g.DrawString(yAxisLabel, chart_data, chart_Brush, chart_Organx - 70, lineEndy);
            //barchart
            int startp = chart_Organx + 60;

            for (int i = 1; i < 11; i++)
            {
                revScale += 50;
                //drow scale in xaxis

                g.DrawLine(chart_Pen, chart_Organx + (60 * i), chart_Organy + 5, chart_Organx + (60 * i), chart_Organy - 5);
                g.DrawString(year[i - 1], chart_data, chart_Brush, chart_Organx + (60 * i) - 20, chart_Organy + 7);
                //draw scale in y-axise
                g.DrawLine(chart_Pen, chart_Organx + 5, chart_Organy - (50 * i), chart_Organx - 5, chart_Organy - (50 * i));
                g.DrawString($"{revScale}", chart_data, chart_Brush, chart_Organx - 33, chart_Organy - (50 * i) - 8);
                g.FillRectangle(chart_bars_Brush, startp - 20, chart_Organy - Convert.ToInt32(revenu[i - 1]), 40, Convert.ToInt32(revenu[i - 1]));
                startp += 60;
            }

            startp = chart_Organx + 60;

            //line chart
            for (int i = 1; i < 11; i++)
            {


                if (i < 10)
                {

                    g.DrawLine(lineChartPen, startp, chart_Organy - Convert.ToInt32(revenu[i - 1]), startp + 60, chart_Organy - Convert.ToInt32(revenu[i]));

                }

                startp += 60;

            }
        }
        #endregion

        //change linechart colors using short cut
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch ((int)e.KeyChar)
            {
                case 2: //Ctrl + B
                    lineChartColor = Color.Blue;
                    // m_chartLineColor = Color.Blue;
                    break;
                case 7: //Ctrl + G
                    lineChartColor = Color.Green;
                    //m_LineChEColor = Color.Green;

                    break;
                case 18:    //Ctrl + R
                    lineChartColor = Color.Red;
                    // m_LineChEColor = Color.Red;
                    break;
            }

            lineChartPen.Color = lineChartColor;

            Invalidate();
        }

        #region  menues
        #region mnue_strip_line


        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lineChartColor = Color.Red;
            lineChartPen.Color = lineChartColor;
            Invalidate();



        }
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineChartColor = Color.Blue;
            lineChartPen.Color = lineChartColor;
            Invalidate();

        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lineChartColor = Color.Green;
            lineChartPen.Color = lineChartColor;
            Invalidate();

        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {


            lineChartPen.DashStyle = DashStyle.Solid;
            Invalidate();

        }

        private void dashToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lineChartPen.DashStyle = DashStyle.Dash;
            Invalidate();

        }

        private void dottedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lineChartPen.DashStyle = DashStyle.Dot;
            Invalidate();

        }

        #endregion

        #region mnue_strip_rect



        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            barChartColor = Color.Red;
            chart_bars_Brush = new HatchBrush(brushstyle, Color.Black, barChartColor);
            Invalidate();

        }

        private void greenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            barChartColor = Color.Green;

            chart_bars_Brush = new HatchBrush(brushstyle, Color.Black, barChartColor);
            Invalidate();

        }

        private void blueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            barChartColor = Color.Blue;

            chart_bars_Brush = new HatchBrush(brushstyle, Color.Black, barChartColor);
            Invalidate();

        }

        private void rightToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            brushstyle = HatchStyle.ForwardDiagonal;
            chart_bars_Brush = new HatchBrush(brushstyle, Color.Black, barChartColor);
            Invalidate();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brushstyle = HatchStyle.BackwardDiagonal;
            chart_bars_Brush = new HatchBrush(brushstyle, Color.Black, barChartColor);
            Invalidate();
        }

        private void crossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brushstyle = HatchStyle.Cross;
            chart_bars_Brush = new HatchBrush(brushstyle, Color.Black, barChartColor);
            Invalidate();
        }
        #endregion





        #region status_menue
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            int revnue = chart_Organy - e.Y;
            int years = ((e.X - chart_Organx) / 60) + 1987;
            if ((e.X >= chart_Organx && e.X <= lineEndx) && (e.Y <= chart_Organy && e.Y >= lineEndy))
            {
                toolStripStatusLabel1.Text = "revnue=" + revnue;
                toolStripStatusLabel2.Text = "years=" + years;
            }
        }






        #endregion
        #endregion


        //void save_old_values(object sender, EventArgs e)
        //{

        //    if (CompanyNameDialogNewVal.Tbox2 != "")
        //    {
        //        h_text = CompanyNameDialogNewVal.Compony_new_Name;
        //    }

        //    h_fontstyle = CompanyNameDialogNewVal.textFont;
        //    h_fontsize = CompanyNameDialogNewVal.FontSize;
        //    h_textFont = new Font(h_fontstyle, h_fontsize, FontStyle.Underline);
        //    h_textColor = CompanyNameDialogNewVal.Text_Color;
        //    h_textBrush = new SolidBrush(h_textColor);

        //    this.Invalidate();

        //}
        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dialog to change the company name 
            CompanyNameDialogNewVal.Compony_old_Name = h_text;
            CompanyNameDialogNewVal.FontSize = h_fontsize;
            CompanyNameDialogNewVal.textFont = h_fontstyle;
            CompanyNameDialogNewVal.Text_Color = h_textColor;
            DialogResult dresult;
            dresult = CompanyNameDialogNewVal.ShowDialog();
            if (dresult == DialogResult.OK)
            {
                if (CompanyNameDialogNewVal.Tbox2 != "")
                {
                    h_text = CompanyNameDialogNewVal.Compony_new_Name;
                }

                h_fontstyle = CompanyNameDialogNewVal.textFont;
                h_fontsize = CompanyNameDialogNewVal.FontSize;
                h_textFont = new Font(h_fontstyle, h_fontsize, FontStyle.Underline);
                h_textColor = CompanyNameDialogNewVal.Text_Color;
                h_textBrush = new SolidBrush(h_textColor);


                Invalidate();
                //save_old_values(sender, e);




            }


        }



        //make it responsive
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateTextPositions();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DisplayStrings(g);
            DisplayRectanglesWithText(drawTableyear(), year);
            DisplayRectanglesWithText2(drawTablerevnue(), revenu);
            drawChart(g);

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        //private void Form1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        if (e.X >= chart_Organx && e.X <= chart_Organx+ 650 && e.Y >= chart_Organy && e.Y <= chart_Organy - 600)
        //        {


        //            MessageBox.Show($"Year: {clickedyear}\nRevenue: {clickedIndex}");
        //        }
        //    }
        //    else if (e.Button == MouseButtons.Right)
        //    {
        //        if (e.X >= chart_Organx && e.X <= chart_Organx + 700 && e.Y >= chart_Organy && e.Y <= chart_Organy + 635)
        //        {
        //            contextMenuStrip2.Show(this, e.X, e.Y);
        //        }
        //        else
        //        {
        //            //contextMenuStrip1.Show(this, e.X, e.Y);
        //        }
        //    }
       // }
    }
}
