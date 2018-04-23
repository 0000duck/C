using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace TestProg
{
    public partial class DEMO : Form
    {
        public DEMO()
        {
            InitializeComponent();
          //  lbShow.ItemHeight = 30;
        }

        private void DEMO_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
                lbShow.Items.Add(i);


        }
        int x=-1;
        private void lbShow_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            int index = e.Index;
            Graphics g = e.Graphics;
            Rectangle bound = e.Bounds;
            string text = lbShow.Items[index].ToString();
            if (index < 0)
                return;
            else if (index == x)
            {
                Rectangle rect = new Rectangle(bound.Left + 2, bound.Top - 2, bound.Width, bound.Height+3);
                Font font = new System.Drawing.Font("微软雅黑", 9, FontStyle.Bold & FontStyle.Italic);
                TextRenderer.DrawText(g, text, font, rect, Color.Red, TextFormatFlags.VerticalCenter);
                //g.DrawString(text, Font, Brushes.Red, e.Bounds);
            }
           
            else
            {
                using (Brush brush = new SolidBrush(Color.White))
                {
                    g.FillRectangle(brush, bound);//绘制背景色。  
                }
                //填充字体，字体的颜色为黑色  
                TextRenderer.DrawText(g, text, this.Font, bound, Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                //g.DrawString(text, e.Font, Brushes.Black, e.Bounds);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            timer1.Enabled = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            lbShow.Invalidate();            
            if (x > lbShow.Items.Count - 1)
                x = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new GraphicPic().Show();
        }
      


    }
}
