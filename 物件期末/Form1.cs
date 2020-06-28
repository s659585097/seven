using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 物件期末
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string path = "./tmp.txt";//.代表當前位置，暫存位置為目前執行的Debug的tmp.txt
        string tmp = "", tmpOrd = "";//暫存輸入的整個字串;
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter w = new StreamWriter(path);
            tmp = richTextBox1.Text;
            w.WriteLine(tmp);
            string[] words = tmp.Split('\n');
            int n = words.Length;//資料比數
            

            Random rnd = new Random();
            int result = rnd.Next(n);
            DialogResult YN = MessageBox.Show("結果為：" + words[result] + "\n是否顯示店家資訊？", "抽籤結果", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            w.Close();
            
            if(YN== System.Windows.Forms.DialogResult.Yes)
            {
                string http = "https://www.google.com.tw/maps/search/" + words[result];
                System.Diagnostics.Process.Start(http);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = tmpOrd;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            StreamReader r = new StreamReader(path);
            tmpOrd = "";

            while (r.Peek() > -1)
                tmpOrd += r.ReadLine() + "\n";
            richTextBox1.Text = tmpOrd;
            r.Close();
        }
    }
}
