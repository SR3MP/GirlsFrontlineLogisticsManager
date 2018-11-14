using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace 后勤管理
{
    public partial class 后勤管理 : Form
    {
        public 后勤管理()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public TimeSpan ts1 = new TimeSpan();
        public TimeSpan ts2 = new TimeSpan();
        public TimeSpan ts3 = new TimeSpan();
        public TimeSpan ts4 = new TimeSpan();




        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            string location = Application.StartupPath;
            string connectionStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + location + "/logistics.mdb";
            using (OleDbConnection con = new OleDbConnection(connectionStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    con.Open();
                    cmd.CommandText = string.Format("select task from logistics");
                    cmd.Connection = con;
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader[0]);
                            comboBox2.Items.Add(reader[0]);
                            comboBox3.Items.Add(reader[0]);
                            comboBox4.Items.Add(reader[0]);
                        }
                    }
                    con.Close();
                }
                this.KeyPreview = true;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 后勤管理_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Dispose();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void 后勤管理_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();

                notifyIcon1.BalloonTipTitle = "提示";
                notifyIcon1.BalloonTipText = "程序正在后台运行,请双击任务栏图标打开";
                notifyIcon1.ShowBalloonTip(300);
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 退出ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("请选择#1后勤", "提示");
            }
            else
            {
                string task1 = comboBox1.Text;
                string location = Application.StartupPath;
                string connectionStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + location + "/logistics.mdb";
                using (OleDbConnection con = new OleDbConnection(connectionStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        con.Open();
                        cmd.CommandText = string.Format("select hours from logistics where task='" + task1 + "'");
                        cmd.Connection = con;
                        textBox1.Text = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        con.Open();
                        cmd.CommandText = string.Format("select mins from logistics where task='" + task1 + "'");
                        cmd.Connection = con;
                        textBox5.Text = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                    timer1.Enabled = true;
                    int hour1 = int.Parse(textBox1.Text);
                    int min1 = int.Parse(textBox5.Text);
                    ts1 = new TimeSpan(hour1, min1, 0);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = ts1.Hours.ToString();
            textBox5.Text = ts1.Minutes.ToString();
            textBox12.Text = ts1.Seconds.ToString();
            ts1 = ts1.Subtract(new TimeSpan(0, 0, 1));
            if (ts1.TotalSeconds < 0.0)
            {
                timer1.Enabled = false;
                notifyIcon1.BalloonTipTitle = "后勤#1归来";
                notifyIcon1.BalloonTipText = "后勤" + comboBox1.Text + "归来，请打开游戏";
                notifyIcon1.ShowBalloonTip(3000);
                if (MessageBox.Show("后勤#1 " + comboBox1.Text + "归来,是否再次出击？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    
                    button1_Click(null,null);
                }
                else
                {
                    timer1.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Length == 0)
            {
                MessageBox.Show("请选择#2后勤", "提示");
            }
            else
            {
                string task2 = comboBox2.Text;
                string location = Application.StartupPath;
                string connectionStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + location + "/logistics.mdb";
                using (OleDbConnection con = new OleDbConnection(connectionStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        con.Open();
                        cmd.CommandText = string.Format("select hours from logistics where task='" + task2 + "'");
                        cmd.Connection = con;
                        textBox2.Text = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        con.Open();
                        cmd.CommandText = string.Format("select mins from logistics where task='" + task2 + "'");
                        cmd.Connection = con;
                        textBox6.Text = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                    timer2.Enabled = true;
                    int hour2 = int.Parse(textBox2.Text);
                    int min2 = int.Parse(textBox6.Text);
                    ts2 = new TimeSpan(hour2, min2, 0);
                }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox2.Text = ts2.Hours.ToString();
            textBox6.Text = ts2.Minutes.ToString();
            textBox11.Text = ts2.Seconds.ToString();
            ts2 = ts2.Subtract(new TimeSpan(0, 0, 1));
            if (ts2.TotalSeconds < 0.0)
            {
                timer2.Enabled = false;
                notifyIcon1.BalloonTipTitle = "后勤#2归来";
                notifyIcon1.BalloonTipText = "后勤" + comboBox2.Text + "归来，请打开游戏";
                notifyIcon1.ShowBalloonTip(3000);
                if(MessageBox.Show("后勤#2 " + comboBox2.Text + "归来,是否再次出击？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    button2_Click(null,null);
                }
                else
                {
                    timer2.Enabled = false;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text.Length == 0)
            {
                MessageBox.Show("请选择#3后勤", "提示");
            }
            else
            {
                string task3 = comboBox3.Text;
                string location = Application.StartupPath;
                string connectionStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + location + "/logistics.mdb";
                using (OleDbConnection con = new OleDbConnection(connectionStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        con.Open();
                        cmd.CommandText = string.Format("select hours from logistics where task='" + task3 + "'");
                        cmd.Connection = con;
                        textBox3.Text = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        con.Open();
                        cmd.CommandText = string.Format("select mins from logistics where task='" + task3 + "'");
                        cmd.Connection = con;
                        textBox7.Text = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                    timer3.Enabled = true;
                    int hour3 = int.Parse(textBox3.Text);
                    int min3 = int.Parse(textBox7.Text);
                    ts3 = new TimeSpan(hour3, min3, 0);
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            textBox3.Text = ts3.Hours.ToString();
            textBox7.Text = ts3.Minutes.ToString();
            textBox10.Text = ts3.Seconds.ToString();
            ts3 = ts3.Subtract(new TimeSpan(0, 0, 1));
            if (ts3.TotalSeconds < 0.0)
            {
                timer3.Enabled = false;
                notifyIcon1.BalloonTipTitle = "后勤#3归来";
                notifyIcon1.BalloonTipText = "后勤" + comboBox3.Text + "归来，请打开游戏";
                notifyIcon1.ShowBalloonTip(3000);
                if (MessageBox.Show("后勤#3 " + comboBox3.Text + "归来,是否再次出击？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    button3_Click(null,null);
                }
                else
                {
                    timer3.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text.Length == 0)
            {
                MessageBox.Show("请选择#4后勤", "提示");
            }
            else
            {
                string task4 = comboBox4.Text;
                string location = Application.StartupPath;
                string connectionStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + location + "/logistics.mdb";
                using (OleDbConnection con = new OleDbConnection(connectionStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        con.Open();
                        cmd.CommandText = string.Format("select hours from logistics where task='" + task4 + "'");
                        cmd.Connection = con;
                        textBox4.Text = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }

                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        con.Open();
                        cmd.CommandText = string.Format("select mins from logistics where task='" + task4 + "'");
                        cmd.Connection = con;
                        textBox8.Text = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                    timer4.Enabled = true;
                    int hour4 = int.Parse(textBox4.Text);
                    int min4 = int.Parse(textBox8.Text);
                    ts4 = new TimeSpan(hour4, min4, 0);
                }
            }

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            textBox4.Text = ts4.Hours.ToString();
            textBox8.Text = ts4.Minutes.ToString();
            textBox9.Text = ts4.Seconds.ToString();
            ts4 = ts4.Subtract(new TimeSpan(0, 0, 1));
            if (ts4.TotalSeconds < 0.0)
            {
                timer4.Enabled = false;
                notifyIcon1.BalloonTipTitle = "后勤#4归来";
                notifyIcon1.BalloonTipText = "后勤" + comboBox4.Text + "归来，请打开游戏";
                notifyIcon1.ShowBalloonTip(3000);

                if (MessageBox.Show("后勤#4 " + comboBox4.Text + "归来,是否再次出击？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    button4_Click(null,null);
                }
                else
                {
                    timer4.Enabled = false;
                }
            }
            
        }

        private void 全部开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
            button2_Click(null, null);
            button3_Click(null, null);
            button4_Click(null, null);

        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            notifyIcon1.Text = "后勤管理\r\n#1 " + comboBox1.Text +" " + ts1.Hours.ToString() + ":" + ts1.Minutes.ToString() + "\r\n#2 " + comboBox2.Text + " " + ts2.Hours.ToString() + ":" + ts2.Minutes.ToString() + "\r\n#3 " + comboBox3.Text + " " + ts3.Hours.ToString() + ":" + ts3.Minutes.ToString() + "\r\n#4 " + comboBox4.Text + " " + ts4.Hours.ToString() + ":" + ts4.Minutes.ToString();
        }

        private void 隐藏窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 后勤管理_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }

        private void comboBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                button2_Click(null, null);
            }

        }

        private void comboBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                button3_Click(null, null);
            }

        }

        private void comboBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.Enter)
            {
                button4_Click(null, null);
            }
        }

        private void 显示窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}