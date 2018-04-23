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
    public partial class GraphicPic : Form
    {
        public GraphicPic()
        {
            InitializeComponent();
        }

        private void GraphicPic_Load(object sender, EventArgs e)
        {
            GraphPane mypane = zedGraphControl1.GraphPane;
            mypane.Title = "测试用";
            mypane.XAxis.Title = "时间";
            mypane.YAxis.Title = "温度";

            mypane.XAxis.Min = 0;
            mypane.XAxis.Max = 100;
            mypane.XAxis.MinorStep = 1;
            mypane.XAxis.Step = 10;
            for (int i = 0; i < 50; i++)
            {
                list.Add(i, Math.Sin(i));
            }
            myCurve = mypane.AddCurve("测试", list, Color.Red, SymbolType.Square);
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Validate();

        }
        PointPairList list = new PointPairList();
        LineItem myCurve;
        int x = 50;
        private void tmrDraw_Tick(object sender, EventArgs e)
        {
            if (list.Count >= 50)
                list.RemoveAt(0);
            list.Add(x, Math.Sin(x));
            x++;
           // myCurve = this.zedGraphControl1.GraphPane.AddCurve("测试", list, Color.Red, SymbolType.Square);
            this.zedGraphControl1.AxisChange(); 
            this.zedGraphControl1.Validate();
            this.zedGraphControl1.Refresh();
        }
    }
}
