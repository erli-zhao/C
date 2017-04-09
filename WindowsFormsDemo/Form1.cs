using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
using System.Xml;
using System.Windows.Forms.Design;

namespace WindowsFormsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<string> ReadXmlDemo(string strFilePath)
        {
            //string strFilePath = @"E:\1_药品信息.xml";
            XMLClass xmlClass = new XMLClass();
            List<string> list = new List<string>();
            list = xmlClass.ReadXMLByFileName(strFilePath);
            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog();
            //string strPath = openFileDialog1.FileName;
            //List<string> list=ReadXmlDemo(strPath);
            //foreach(string s in list)
            //{
            //    MessageBox.Show(s);
            //}
            //List<string> list = ("1:20:100").Split(':').ToList();
            //List<int> intList = new List<int>();
            //foreach (string s in list)
            //{
            //    intList.Add(Convert.ToInt32(s));
            //}
            var io = CalculateStockNum(2, "1:30:200");
            MessageBox.Show(io.ToString());
        }
        public decimal CalculateStockNum(int intCodeLevel, string PkgRatio)
        {
            double  intStockNum = 0;
            List<string> list = (PkgRatio).Split(':').ToList();
            List<int> intList = new List<int>();
            foreach (string s in list)
            {
                intList.Add(Convert.ToInt32(s));
            }
            intStockNum = (double)intList[intList.Count - 1] / intList[intCodeLevel - 1];
            return Convert.ToDecimal(intStockNum);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XMLClass xmlClass = new XMLClass();
            string strmessage=xmlClass.CreateXMLFile("E:\\1.xml");
            MessageBox.Show(strmessage);
        }

    }
}
