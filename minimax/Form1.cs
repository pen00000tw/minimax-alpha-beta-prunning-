using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minimax
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int branch = 5;
        int depth = 2;
        int[] sampletree = new int[] {0,0,0,0,0,0, 15, 4, 1, 17, 9, -20, -19, 12, 23, -22, 10, 19, -17, 0, -16, 11, -8, 2, -3, 16, -21, -15, -6, -10, -24 };
        string cut = "";
        int count = 0;
        //int[] tmp = new int[40];
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            cut = ",裁掉了: ";
            count = 0;
            /*foreach (int i in tmp)
            {
                tmp[i] = 0;
            }*/
            foreach (int i in sampletree)
            {
                textBox2.AppendText(i + " ");
            }
            textBox1.AppendText("結束, root = " + minimax(0, depth, -99999, 99999, true));
            textBox1.AppendText(cut + " ,共 " + count + "個節點\r\n");
            /*for (int i = 13; i < 40; i++) 
            {
                if (tmp[i] == 0)
                {
                    textBox1.AppendText(sampletree[i] + " ,");
                }
            }*/
                foreach (int i in sampletree)
                {
                    textBox3.AppendText(i + " ");
                }
            
        }
        public int minimax(int node, int dep, int alpha, int beta, bool ismax) {
            textBox1.AppendText("進入節點 " + node + "\r\n");
            if (dep == 0) 
            {
                //tmp[node] = 1;
                textBox1.AppendText("回傳節點 " + node + ", 值 = "+sampletree[node] + " 給父節點 \r\n");
                Application.DoEvents();
                return sampletree[node];
            }
            if (ismax)
            {
                int maxvalue = -999;
                for (int i = 1; i < branch + 1; i++)
                {
                    int value = minimax(node * branch + i, dep - 1, alpha, beta, false);
                    maxvalue = Math.Max(maxvalue, value);
                    alpha = Math.Max(alpha, value);
                    textBox1.AppendText("節點 = " + node + ", 層數 = " + dep + ", 拿到子節點值 = " + value + ", 目前最大值 = " + maxvalue + ", alpha = " + alpha + ", beta = " + beta +"\r\n");
                    Application.DoEvents();
                    if (beta <= alpha)
                    {
                        textBox1.AppendText("alpha >= beta, 剪枝");
                        textBox1.AppendText(", 裁掉了:");
                        for (int j = i + 1; j < branch + 1; j++)
                        {
                            //textBox1.AppendText("node: " + (node * branch + j));
                            textBox1.AppendText(" " + sampletree[node * branch + j]);
                            cut = cut + " " + sampletree[node * branch + j];
                            count++;
                        }
                        textBox1.AppendText("\r\n");
                        Application.DoEvents();
                        break;
                    }
                }
                textBox1.AppendText("此節點已結束,值為" + maxvalue + "\r\n");
                sampletree[node] = maxvalue;
                return maxvalue;

            }
            else 
            {
                int minvalue = 999;
                for (int i = 1; i < branch + 1; i++)
                {
                    int value = minimax(node * branch + i, dep - 1, alpha, beta, true);
                    minvalue = Math.Min(minvalue, value);
                    beta = Math.Min(beta, value);
                    textBox1.AppendText("節點 = " + node + ", 層數 = " + dep + ", 拿到子節點值 = " + value + ", 目前最小值 = " + minvalue + ", alpha = " + alpha + ", beta = " + beta + "\r\n");
                    Application.DoEvents();
                    if (beta <= alpha)
                    {
                        textBox1.AppendText("alpha >= beta, 剪枝");
                        textBox1.AppendText(", 裁掉了:");
                        for (int j = i + 1; j < branch + 1; j++) 
                        {
                            //textBox1.AppendText("node: " + (node * branch + j));
                            textBox1.AppendText(" " + sampletree[node * branch + j]);
                            cut = cut + " " + sampletree[node * branch + j];
                            count++;
                        }
                        textBox1.AppendText("\r\n");
                            Application.DoEvents();
                        break;
                    }
                }
                textBox1.AppendText("此節點已結束,值為" + minvalue + "\r\n");
                sampletree[node] = minvalue;
                return minvalue;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
