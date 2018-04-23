using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TestP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            downloadProgram();
        }
        public string filePath;
        private void downloadProgram()
        {
            string regex=@"(((\-)?\d+(\.\d{1,2})?)|\()";
            try
            {
               
                openFileDialog1.Filter = "PMAC程序(*.pmc)|*.pmc";
                string logPath = "";                       //保存log日志
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    filePath = openFileDialog1.FileName;
                if (filePath != null)
                {
                    Hashtable table = new Hashtable();
                    StreamReader sr = new StreamReader(filePath);
                    string Msg = sr.ReadToEnd();
                    sr.Close();
                    string[] programs = Msg.Split('\n');
                    string[] Directionary = {"X", "Y", "Z", "I", "J", "R" };
                    string[] Special = { "ABS", "INC", "FRAX","LIN" };
                    int key = 0;
                    
                    for (int i = 0; i < programs.Length; i++)
                    {
                        Boolean SpecialFlag = false;
                        Boolean DirectionFlag = false;
                        for (int j = 0; j < Special.Length; j++)
                        {
                            if(programs[i].StartsWith(Special[j]))
                            {
                                table.Add(key++, programs[i]);
                                SpecialFlag = true;
                                DirectionFlag = true;
                                break;
                            }                                                        
                        }
                        if (!SpecialFlag)
                        {
                            for (int j = 0; j < Directionary.Length; j++)
                            {
                                Regex regexs=new Regex(@Directionary[j]+regex);
                                if (regexs.IsMatch(programs[i]))
                                {
                                    table.Add(key++, programs[i]);
                                    DirectionFlag = true;
                                    continue;
                                }
                            }
                            SpecialFlag = false;
                        }
                        if (!DirectionFlag)
                        {
                            table.Add(key++, programs[i]);
                            DirectionFlag = false;
                        }

                            //for (int j = 0; j < Directionary.Length; j++)
                            //{
                            //    if (programs[i].IndexOf(Directionary[j]) > 0)
                            //    {
                            //        key++;
                            //        continue;
                            //    }
                            //}
                        //table.Add(key, programs[i]);
                    }
                    MessageBox.Show("");
                }
              //  MessageBox.Show("");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
    }
}
