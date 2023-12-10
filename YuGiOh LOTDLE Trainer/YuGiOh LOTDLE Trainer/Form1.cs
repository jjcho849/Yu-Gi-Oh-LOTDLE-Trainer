using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace YuGiOh_LOTDLE_Trainer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Mem m = new Mem();
        bool openProc = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            openProc = m.OpenProcess("YuGiOh");

            if (!openProc)
            {
                Thread.Sleep(500);
                return;
            }

            Thread.Sleep(500);
            backgroundWorker1.ReportProgress(0);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (openProc) 
            {
                attachLabel.Text = "Attached";
                attachLabel.ForeColor = Color.Lime;
                tabControl1.Enabled = true;
            }
            else
            {
                attachLabel.Text = "Not Attached";
                attachLabel.ForeColor = Color.Red;
                tabControl1.Enabled = false;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void setMoney_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                long money = 0;
                bool parse = long.TryParse(moneyInput.Text, out money);
                if (!string.IsNullOrEmpty(moneyInput.Text) && parse && money > 0)
                {
                    m.WriteMemory("base+2924010,8,28,50,27e0,fe8", "long", moneyInput.Text);
                    moneyInput.ForeColor = Color.Green;
                    moneyInput.Text = "Money Set!";
                    Task.Delay(1000).Wait();
                    moneyInput.ForeColor = Color.Black;
                    moneyInput.Text = Convert.ToString(money);
                }
                else
                {
                    moneyInput.ForeColor = Color.Red;
                    moneyInput.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    moneyInput.ForeColor = Color.Black;
                    moneyInput.Text = Convert.ToString(m.ReadLong("base+2924010,8,28,50,27e0,fe8"));
                }
            }
        }

        private void getMoney_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                long cash = m.ReadLong("base+2924010,8,28,50,27e0,fe8");
                moneyInput.Text = Convert.ToString(cash);
            }
        }

        private void cardCount_CheckedChanged(object sender, EventArgs e)
        {
            if (openProc)
            {
                int count = m.ReadInt("base+34989E4");
                int duelFlag = m.ReadInt("base+278EF0C");

                if (cardCount.Checked && duelFlag > 0 && count > 0)
                {
                    m.WriteMemory("base+34989E4", "int", "0");
                }
                else
                {
                    cardCount.Checked = false;
                }
            }
        }

        private void shopFree_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shopDefault.BackColor = Color.Gainsboro;
                shopFree.BackColor = Color.Lime;
                m.WriteMemory("base+2924230", "int", "0");
                m.WriteMemory("base+2924298", "int", "0");
                m.WriteMemory("base+2924300", "int", "0");
                m.WriteMemory("base+2924368", "int", "0");
                m.WriteMemory("base+29243D0", "int", "0");
                m.WriteMemory("base+2924438", "int", "0");
                m.WriteMemory("base+29244A0", "int", "0");
                m.WriteMemory("base+2924508", "int", "0");
                m.WriteMemory("base+2924570", "int", "0");
                m.WriteMemory("base+29245D8", "int", "0");
                m.WriteMemory("base+2924640", "int", "0");
                m.WriteMemory("base+29246A8", "int", "0");
                m.WriteMemory("base+2924710", "int", "0");
                m.WriteMemory("base+2924778", "int", "0");
                m.WriteMemory("base+29247E0", "int", "0");
                m.WriteMemory("base+2924848", "int", "0");
                m.WriteMemory("base+29248B0", "int", "0");
                m.WriteMemory("base+2924918", "int", "0");
                m.WriteMemory("base+2924980", "int", "0");
                m.WriteMemory("base+29249E8", "int", "0");
                m.WriteMemory("base+2924A50", "int", "0");
                m.WriteMemory("base+2924AB8", "int", "0");
                m.WriteMemory("base+2924B20", "int", "0");
                m.WriteMemory("base+2924BF0", "int", "0");
                m.WriteMemory("base+2924C58", "int", "0");
                m.WriteMemory("base+2924CC0", "int", "0");
                m.WriteMemory("base+2924D28", "int", "0");
                m.WriteMemory("base+2924D90", "int", "0");
                m.WriteMemory("base+2924DF8", "int", "0");
                m.WriteMemory("base+2924F98", "int", "0");
                m.WriteMemory("base+2925000", "int", "0");
                m.WriteMemory("base+2925068", "int", "0");
                m.WriteMemory("base+29250D0", "int", "0");
            }
        }

        private void shopDefault_Click(object sender, EventArgs e)
        {
            if (openProc) 
            {
                shopFree.BackColor = Color.Gainsboro;
                shopDefault.BackColor = Color.Lime;
                m.WriteMemory("base+2924230", "int", "200");
                m.WriteMemory("base+2924298", "int", "400");
                m.WriteMemory("base+2924300", "int", "400");
                m.WriteMemory("base+2924368", "int", "400");
                m.WriteMemory("base+29243D0", "int", "400");
                m.WriteMemory("base+2924438", "int", "400");
                m.WriteMemory("base+29244A0", "int", "400");
                m.WriteMemory("base+2924508", "int", "400");
                m.WriteMemory("base+2924570", "int", "400");
                m.WriteMemory("base+29245D8", "int", "400");
                m.WriteMemory("base+2924640", "int", "400");
                m.WriteMemory("base+29246A8", "int", "400");
                m.WriteMemory("base+2924710", "int", "400");
                m.WriteMemory("base+2924778", "int", "400");
                m.WriteMemory("base+29247E0", "int", "400");
                m.WriteMemory("base+2924848", "int", "400");
                m.WriteMemory("base+29248B0", "int", "400");
                m.WriteMemory("base+2924918", "int", "400");
                m.WriteMemory("base+2924980", "int", "400");
                m.WriteMemory("base+29249E8", "int", "400");
                m.WriteMemory("base+2924A50", "int", "400");
                m.WriteMemory("base+2924AB8", "int", "400");
                m.WriteMemory("base+2924B20", "int", "400");
                m.WriteMemory("base+2924BF0", "int", "400");
                m.WriteMemory("base+2924C58", "int", "400");
                m.WriteMemory("base+2924CC0", "int", "400");
                m.WriteMemory("base+2924D28", "int", "400");
                m.WriteMemory("base+2924D90", "int", "400");
                m.WriteMemory("base+2924DF8", "int", "400");
                m.WriteMemory("base+2924F98", "int", "400");
                m.WriteMemory("base+2925000", "int", "400");
                m.WriteMemory("base+2925068", "int", "400");
                m.WriteMemory("base+29250D0", "int", "400");
            }
        }

        private void tabMain_Enter(object sender, EventArgs e)
        {
            if (openProc)
            {
                moneyInput.Text = Convert.ToString(m.ReadLong("base+2924010,8,28,50,27e0,fe8"));
                int duelFlag = m.ReadInt("base+278EF0C");

                if (m.ReadInt("base+2924230") != 200)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924298") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924300") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924368") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29243D0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924438") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29244A0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924508") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924570") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29245D8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924640") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29246A8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924710") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924778") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29247E0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924848") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29248B0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924918") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924980") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29249E8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924A50") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924AB8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924B20") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924BF0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924C58") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924CC0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924D28") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924D90") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924DF8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924F98") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2925000") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2925068") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29250D0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else
                {
                    shopDefault.BackColor = Color.Lime;
                }

                if (m.ReadInt("base+2924230") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924298") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924300") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924368") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29243D0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924438") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29244A0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924508") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924570") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29245D8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924640") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29246A8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924710") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924778") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29247E0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924848") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29248B0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924918") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924980") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29249E8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924A50") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924AB8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924B20") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924BF0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924C58") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924CC0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924D28") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924D90") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924DF8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924F98") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2925000") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2925068") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29250D0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else
                {
                    shopFree.BackColor = Color.Lime;
                }

                if (duelFlag > 0)
                {
                    int lifePointsKey = m.Read2Byte("base+3330280");
                    int playerLPencrypted = m.ReadInt("base+3497C40");
                    int opponentLPencrypted = m.ReadInt("base+34989D4");
                    oLPbox.Text = Convert.ToString(opponentLPencrypted ^ lifePointsKey);
                    pLPbox.Text = Convert.ToString(playerLPencrypted ^ lifePointsKey);
                }
                else
                {
                    pLPbox.Text = string.Empty;
                    oLPbox.Text = string.Empty;
                }
            }
        }

        private void tabControl1_EnabledChanged(object sender, EventArgs e)
        {
            if (tabControl1.Enabled)
            {
                moneyInput.Text = Convert.ToString(m.ReadLong("base+2924010,8,28,50,27e0,fe8"));
                shop1Box1.Text = Convert.ToString(m.ReadInt("base+2924230"));
                shop1Box2.Text = Convert.ToString(m.ReadInt("base+2924298"));
                shop1Box3.Text = Convert.ToString(m.ReadInt("base+2924300"));
                shop1Box4.Text = Convert.ToString(m.ReadInt("base+2924368"));
                shop1Box5.Text = Convert.ToString(m.ReadInt("base+29243D0"));
                shop1Box6.Text = Convert.ToString(m.ReadInt("base+2924438"));
                shop2Box1.Text = Convert.ToString(m.ReadInt("base+29244A0"));
                shop2Box2.Text = Convert.ToString(m.ReadInt("base+2924508"));
                shop2Box3.Text = Convert.ToString(m.ReadInt("base+2924570"));
                shop2Box4.Text = Convert.ToString(m.ReadInt("base+29245D8"));
                shop2Box5.Text = Convert.ToString(m.ReadInt("base+2924640"));
                shop2Box6.Text = Convert.ToString(m.ReadInt("base+29246A8"));
                shop3Box1.Text = Convert.ToString(m.ReadInt("base+2924710"));
                shop3Box2.Text = Convert.ToString(m.ReadInt("base+2924778"));
                shop3Box3.Text = Convert.ToString(m.ReadInt("base+29247E0"));
                shop3Box4.Text = Convert.ToString(m.ReadInt("base+2924848"));
                shop3Box5.Text = Convert.ToString(m.ReadInt("base+29248B0"));
                shop3Box6.Text = Convert.ToString(m.ReadInt("base+2924918"));
                shop4Box1.Text = Convert.ToString(m.ReadInt("base+2924980"));
                shop4Box2.Text = Convert.ToString(m.ReadInt("base+29249E8"));
                shop4Box3.Text = Convert.ToString(m.ReadInt("base+2924A50"));
                shop4Box4.Text = Convert.ToString(m.ReadInt("base+2924AB8"));
                shop4Box5.Text = Convert.ToString(m.ReadInt("base+2924B20"));
                shop5Box1.Text = Convert.ToString(m.ReadInt("base+2924BF0"));
                shop5Box2.Text = Convert.ToString(m.ReadInt("base+2924C58"));
                shop5Box3.Text = Convert.ToString(m.ReadInt("base+2924CC0"));
                shop5Box4.Text = Convert.ToString(m.ReadInt("base+2924D28"));
                shop5Box5.Text = Convert.ToString(m.ReadInt("base+2924D90"));
                shop6Box1.Text = Convert.ToString(m.ReadInt("base+2924DF8"));
                shop6Box2.Text = Convert.ToString(m.ReadInt("base+2924F98"));
                shop6Box3.Text = Convert.ToString(m.ReadInt("base+2925000"));
                shop6Box4.Text = Convert.ToString(m.ReadInt("base+2925068"));
                shop6Box5.Text = Convert.ToString(m.ReadInt("base+29250D0"));
                int duelFlag = m.ReadInt("base+278EF0C");

                if (m.ReadInt("base+2924230") != 200)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924298") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924300") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924368") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29243D0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924438") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29244A0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924508") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924570") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29245D8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924640") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29246A8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924710") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924778") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29247E0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924848") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29248B0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924918") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924980") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29249E8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924A50") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924AB8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924B20") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924BF0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924C58") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924CC0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924D28") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924D90") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924DF8") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924F98") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2925000") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2925068") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29250D0") != 400)
                {
                    shopDefault.BackColor = Color.Gainsboro;
                }
                else
                {
                    shopDefault.BackColor = Color.Lime;
                }

                if (m.ReadInt("base+2924230") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924298") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924300") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924368") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29243D0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924438") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29244A0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924508") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924570") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29245D8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924640") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29246A8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924710") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924778") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29247E0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924848") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29248B0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924918") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924980") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29249E8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924A50") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924AB8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924B20") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924BF0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924C58") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924CC0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924D28") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924D90") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924DF8") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2924F98") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2925000") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+2925068") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else if (m.ReadInt("base+29250D0") > 0)
                {
                    shopFree.BackColor = Color.Gainsboro;
                }
                else
                {
                    shopFree.BackColor = Color.Lime;
                }

                if (duelFlag > 0)
                {
                    int lifePointsKey = m.Read2Byte("base+3330280");
                    int playerLPencrypted = m.ReadInt("base+3497C40");
                    int opponentLPencrypted = m.ReadInt("base+34989D4");
                    oLPbox.Text = Convert.ToString(opponentLPencrypted ^ lifePointsKey);
                    pLPbox.Text = Convert.ToString(playerLPencrypted ^ lifePointsKey);
                }
            }
            else
            {
                moneyInput.Text = string.Empty;
                shop1Box1.Text = string.Empty;
                shop1Box2.Text = string.Empty;
                shop1Box3.Text = string.Empty;
                shop1Box4.Text = string.Empty;
                shop1Box5.Text = string.Empty;
                shop1Box6.Text = string.Empty;
                shop2Box1.Text = string.Empty;
                shop2Box2.Text = string.Empty;
                shop2Box3.Text = string.Empty;
                shop2Box4.Text = string.Empty;
                shop2Box5.Text = string.Empty;
                shop2Box6.Text = string.Empty;
                shop3Box1.Text = string.Empty;
                shop3Box2.Text = string.Empty;
                shop3Box3.Text = string.Empty;
                shop3Box4.Text = string.Empty;
                shop3Box5.Text = string.Empty;
                shop3Box6.Text = string.Empty;
                shop4Box1.Text = string.Empty;
                shop4Box2.Text = string.Empty;
                shop4Box3.Text = string.Empty;
                shop4Box4.Text = string.Empty;
                shop4Box5.Text = string.Empty;
                shop5Box1.Text = string.Empty;
                shop5Box2.Text = string.Empty;
                shop5Box3.Text = string.Empty;
                shop5Box4.Text = string.Empty;
                shop5Box5.Text = string.Empty;
                shop6Box1.Text = string.Empty;
                shop6Box2.Text = string.Empty;
                shop6Box3.Text = string.Empty;
                shop6Box4.Text = string.Empty;
                shop6Box5.Text = string.Empty;
                addMoney.Checked = false;
                cardCount.Checked = false;
                shopDefault.BackColor = Color.Gainsboro;
                shopFree.BackColor = Color.Gainsboro;
                pLPbox.Text = string.Empty;
                oLPbox.Text = string.Empty;
            }
        }

        private void tabShop1_Enter(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop1Box1.Text = Convert.ToString(m.ReadInt("base+2924230"));
                shop1Box2.Text = Convert.ToString(m.ReadInt("base+2924298"));
                shop1Box3.Text = Convert.ToString(m.ReadInt("base+2924300"));
                shop1Box4.Text = Convert.ToString(m.ReadInt("base+2924368"));
                shop1Box5.Text = Convert.ToString(m.ReadInt("base+29243D0"));
                shop1Box6.Text = Convert.ToString(m.ReadInt("base+2924438"));
            }
        }

        private void tabShop2_Enter(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop2Box1.Text = Convert.ToString(m.ReadInt("base+29244A0"));
                shop2Box2.Text = Convert.ToString(m.ReadInt("base+2924508"));
                shop2Box3.Text = Convert.ToString(m.ReadInt("base+2924570"));
                shop2Box4.Text = Convert.ToString(m.ReadInt("base+29245D8"));
                shop2Box5.Text = Convert.ToString(m.ReadInt("base+2924640"));
                shop2Box6.Text = Convert.ToString(m.ReadInt("base+29246A8"));
            }
        }

        private void tabShop3_Enter(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop3Box1.Text = Convert.ToString(m.ReadInt("base+2924710"));
                shop3Box2.Text = Convert.ToString(m.ReadInt("base+2924778"));
                shop3Box3.Text = Convert.ToString(m.ReadInt("base+29247E0"));
                shop3Box4.Text = Convert.ToString(m.ReadInt("base+2924848"));
                shop3Box5.Text = Convert.ToString(m.ReadInt("base+29248B0"));
                shop3Box6.Text = Convert.ToString(m.ReadInt("base+2924918"));
            }
        }

        private void tabShop4_Enter(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop4Box1.Text = Convert.ToString(m.ReadInt("base+2924980"));
                shop4Box2.Text = Convert.ToString(m.ReadInt("base+29249E8"));
                shop4Box3.Text = Convert.ToString(m.ReadInt("base+2924A50"));
                shop4Box4.Text = Convert.ToString(m.ReadInt("base+2924AB8"));
                shop4Box5.Text = Convert.ToString(m.ReadInt("base+2924B20"));
            }
        }

        private void tabShop5_Enter(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop5Box1.Text = Convert.ToString(m.ReadInt("base+2924BF0"));
                shop5Box2.Text = Convert.ToString(m.ReadInt("base+2924C58"));
                shop5Box3.Text = Convert.ToString(m.ReadInt("base+2924CC0"));
                shop5Box4.Text = Convert.ToString(m.ReadInt("base+2924D28"));
                shop5Box5.Text = Convert.ToString(m.ReadInt("base+2924D90"));
            }
        }

        private void tabShop6_Enter(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop6Box1.Text = Convert.ToString(m.ReadInt("base+2924DF8"));
                shop6Box2.Text = Convert.ToString(m.ReadInt("base+2924F98"));
                shop6Box3.Text = Convert.ToString(m.ReadInt("base+2925000"));
                shop6Box4.Text = Convert.ToString(m.ReadInt("base+2925068"));
                shop6Box5.Text = Convert.ToString(m.ReadInt("base+29250D0"));
            }
        }

        private void shop1Reset_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                m.WriteMemory("base+2924230", "int", "200");
                m.WriteMemory("base+2924298", "int", "400");
                m.WriteMemory("base+2924300", "int", "400");
                m.WriteMemory("base+2924368", "int", "400");
                m.WriteMemory("base+29243D0", "int", "400");
                m.WriteMemory("base+2924438", "int", "400");
                shop1Box1.Text = Convert.ToString(m.ReadInt("base+2924230"));
                shop1Box2.Text = Convert.ToString(m.ReadInt("base+2924298"));
                shop1Box3.Text = Convert.ToString(m.ReadInt("base+2924300"));
                shop1Box4.Text = Convert.ToString(m.ReadInt("base+2924368"));
                shop1Box5.Text = Convert.ToString(m.ReadInt("base+29243D0"));
                shop1Box6.Text = Convert.ToString(m.ReadInt("base+2924438"));
            }
        }

        private void shop2Reset_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                m.WriteMemory("base+29244A0", "int", "400");
                m.WriteMemory("base+2924508", "int", "400");
                m.WriteMemory("base+2924570", "int", "400");
                m.WriteMemory("base+29245D8", "int", "400");
                m.WriteMemory("base+2924640", "int", "400");
                m.WriteMemory("base+29246A8", "int", "400");
                shop2Box1.Text = Convert.ToString(m.ReadInt("base+29244A0"));
                shop2Box2.Text = Convert.ToString(m.ReadInt("base+2924508"));
                shop2Box3.Text = Convert.ToString(m.ReadInt("base+2924570"));
                shop2Box4.Text = Convert.ToString(m.ReadInt("base+29245D8"));
                shop2Box5.Text = Convert.ToString(m.ReadInt("base+2924640"));
                shop2Box6.Text = Convert.ToString(m.ReadInt("base+29246A8"));
            }
        }

        private void shop3Reset_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                m.WriteMemory("base+2924710", "int", "400");
                m.WriteMemory("base+2924778", "int", "400");
                m.WriteMemory("base+29247E0", "int", "400");
                m.WriteMemory("base+2924848", "int", "400");
                m.WriteMemory("base+29248B0", "int", "400");
                m.WriteMemory("base+2924918", "int", "400");
                shop3Box1.Text = Convert.ToString(m.ReadInt("base+2924710"));
                shop3Box2.Text = Convert.ToString(m.ReadInt("base+2924778"));
                shop3Box3.Text = Convert.ToString(m.ReadInt("base+29247E0"));
                shop3Box4.Text = Convert.ToString(m.ReadInt("base+2924848"));
                shop3Box5.Text = Convert.ToString(m.ReadInt("base+29248B0"));
                shop3Box6.Text = Convert.ToString(m.ReadInt("base+2924918"));
            }
        }

        private void shop4Reset_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                m.WriteMemory("base+2924980", "int", "400");
                m.WriteMemory("base+29249E8", "int", "400");
                m.WriteMemory("base+2924A50", "int", "400");
                m.WriteMemory("base+2924AB8", "int", "400");
                m.WriteMemory("base+2924B20", "int", "400");
                shop4Box1.Text = Convert.ToString(m.ReadInt("base+2924980"));
                shop4Box2.Text = Convert.ToString(m.ReadInt("base+29249E8"));
                shop4Box3.Text = Convert.ToString(m.ReadInt("base+2924A50"));
                shop4Box4.Text = Convert.ToString(m.ReadInt("base+2924AB8"));
                shop4Box5.Text = Convert.ToString(m.ReadInt("base+2924B20"));
            }
        }

        private void shop5Reset_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                m.WriteMemory("base+2924BF0", "int", "400");
                m.WriteMemory("base+2924C58", "int", "400");
                m.WriteMemory("base+2924CC0", "int", "400");
                m.WriteMemory("base+2924D28", "int", "400");
                m.WriteMemory("base+2924D90", "int", "400");
                shop5Box1.Text = Convert.ToString(m.ReadInt("base+2924BF0"));
                shop5Box2.Text = Convert.ToString(m.ReadInt("base+2924C58"));
                shop5Box3.Text = Convert.ToString(m.ReadInt("base+2924CC0"));
                shop5Box4.Text = Convert.ToString(m.ReadInt("base+2924D28"));
                shop5Box5.Text = Convert.ToString(m.ReadInt("base+2924D90"));
            }
        }

        private void shop6Reset_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                m.WriteMemory("base+2924DF8", "int", "400");
                m.WriteMemory("base+2924F98", "int", "400");
                m.WriteMemory("base+2925000", "int", "400");
                m.WriteMemory("base+2925068", "int", "400");
                m.WriteMemory("base+29250D0", "int", "400");
                shop6Box1.Text = Convert.ToString(m.ReadInt("base+2924DF8"));
                shop6Box2.Text = Convert.ToString(m.ReadInt("base+2924F98"));
                shop6Box3.Text = Convert.ToString(m.ReadInt("base+2925000"));
                shop6Box4.Text = Convert.ToString(m.ReadInt("base+2925068"));
                shop6Box5.Text = Convert.ToString(m.ReadInt("base+29250D0"));
            }
        }

        private void shop1Get1_Click(object sender, EventArgs e)
        {
            if (openProc) 
            {
                shop1Box1.Text = Convert.ToString(m.ReadInt("base+2924230"));
            }
        }

        private void shop1Get2_Click(object sender, EventArgs e)
        {
            if (openProc) 
            {
                shop1Box2.Text = Convert.ToString(m.ReadInt("base+2924298"));
            }
        }

        private void shop1Get3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop1Box3.Text = Convert.ToString(m.ReadInt("base+2924300"));
            }
        }

        private void shop1Get4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop1Box4.Text = Convert.ToString(m.ReadInt("base+2924368"));
            }
        }

        private void shop1Get5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop1Box5.Text = Convert.ToString(m.ReadInt("base+29243D0"));
            }
        }

        private void shop1Get6_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop1Box6.Text = Convert.ToString(m.ReadInt("base+2924438"));
            }
        }

        private void shop1Set1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop1Box1.Text, out price);
                if (!string.IsNullOrEmpty(shop1Box1.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924230", "int", shop1Box1.Text);
                    shop1Box1.ForeColor = Color.Green;
                    shop1Box1.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop1Box1.ForeColor = Color.Black;
                    shop1Box1.Text = Convert.ToString(price);
                }
                else
                {
                    shop1Box1.ForeColor = Color.Red;
                    shop1Box1.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop1Box1.ForeColor = Color.Black;
                    shop1Box1.Text = Convert.ToString(m.ReadInt("base+2924230"));
                }
            }
        }

        private void shop1Set2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop1Box2.Text, out price);
                if (!string.IsNullOrEmpty(shop1Box2.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924298", "int", shop1Box2.Text);
                    shop1Box2.ForeColor = Color.Green;
                    shop1Box2.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop1Box2.ForeColor = Color.Black;
                    shop1Box2.Text = Convert.ToString(price);
                }
                else
                {
                    shop1Box2.ForeColor = Color.Red;
                    shop1Box2.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop1Box2.ForeColor = Color.Black;
                    shop1Box2.Text = Convert.ToString(m.ReadInt("base+2924298"));
                }
            }
        }

        private void shop1Set3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop1Box3.Text, out price);
                if (!string.IsNullOrEmpty(shop1Box3.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924300", "int", shop1Box3.Text);
                    shop1Box3.ForeColor = Color.Green;
                    shop1Box3.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop1Box3.ForeColor = Color.Black;
                    shop1Box3.Text = Convert.ToString(price);
                }
                else
                {
                    shop1Box3.ForeColor = Color.Red;
                    shop1Box3.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop1Box3.ForeColor = Color.Black;
                    shop1Box3.Text = Convert.ToString(m.ReadInt("base+2924300"));
                }
            }
        }

        private void shop1Set4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop1Box4.Text, out price);
                if (!string.IsNullOrEmpty(shop1Box4.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924368", "int", shop1Box4.Text);
                    shop1Box4.ForeColor = Color.Green;
                    shop1Box4.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop1Box4.ForeColor = Color.Black;
                    shop1Box4.Text = Convert.ToString(price);
                }
                else
                {
                    shop1Box4.ForeColor = Color.Red;
                    shop1Box4.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop1Box4.ForeColor = Color.Black;
                    shop1Box4.Text = Convert.ToString(m.ReadInt("base+2924368"));
                }
            }
        }

        private void shop1Set5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop1Box5.Text, out price);
                if (!string.IsNullOrEmpty(shop1Box5.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+29243D0", "int", shop1Box5.Text);
                    shop1Box5.ForeColor = Color.Green;
                    shop1Box5.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop1Box5.ForeColor = Color.Black;
                    shop1Box5.Text = Convert.ToString(price);
                }
                else
                {
                    shop1Box5.ForeColor = Color.Red;
                    shop1Box5.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop1Box5.ForeColor = Color.Black;
                    shop1Box5.Text = Convert.ToString(m.ReadInt("base+29243D0"));
                }
            }
        }

        private void shop1Set6_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop1Box6.Text, out price);
                if (!string.IsNullOrEmpty(shop1Box6.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924438", "int", shop1Box6.Text);
                    shop1Box6.ForeColor = Color.Green;
                    shop1Box6.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop1Box6.ForeColor = Color.Black;
                    shop1Box6.Text = Convert.ToString(price);
                }
                else
                {
                    shop1Box6.ForeColor = Color.Red;
                    shop1Box6.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop1Box6.ForeColor = Color.Black;
                    shop1Box6.Text = Convert.ToString(m.ReadInt("base+2924438"));
                }
            }
        }

        private void shop2Get1_Click(object sender, EventArgs e)
        {
            if (openProc) 
            {
                shop2Box1.Text = Convert.ToString(m.ReadInt("base+29244A0"));
            }
        }

        private void shop2Get2_Click(object sender, EventArgs e)
        {
            if (openProc) 
            {
                shop2Box2.Text = Convert.ToString(m.ReadInt("base+2924508"));
            }
        }

        private void shop2Get3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop2Box3.Text = Convert.ToString(m.ReadInt("base+2924570"));
            }
        }

        private void shop2Get4_Click(object sender, EventArgs e)
        {
            if (openProc) 
            {
                shop2Box4.Text = Convert.ToString(m.ReadInt("base+29245D8"));
            }
        }

        private void shop2Get5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop2Box5.Text = Convert.ToString(m.ReadInt("base+2924640"));
            }
        }

        private void shop2Get6_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop2Box6.Text = Convert.ToString(m.ReadInt("base+29246A8"));
            }
        }

        private void shop2Set1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop2Box1.Text, out price);
                if (!string.IsNullOrEmpty(shop2Box1.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+29244A0", "int", shop2Box1.Text);
                    shop2Box1.ForeColor = Color.Green;
                    shop2Box1.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop2Box1.ForeColor = Color.Black;
                    shop2Box1.Text = Convert.ToString(price);
                }
                else
                {
                    shop2Box1.ForeColor = Color.Red;
                    shop2Box1.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop2Box1.ForeColor = Color.Black;
                    shop2Box1.Text = Convert.ToString(m.ReadInt("base+29244A0"));
                }
            }
        }

        private void shop2Set2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop2Box2.Text, out price);
                if (!string.IsNullOrEmpty(shop2Box2.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924508", "int", shop2Box2.Text);
                    shop2Box2.ForeColor = Color.Green;
                    shop2Box2.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop2Box2.ForeColor = Color.Black;
                    shop2Box2.Text = Convert.ToString(price);
                }
                else
                {
                    shop2Box2.ForeColor = Color.Red;
                    shop2Box2.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop2Box2.ForeColor = Color.Black;
                    shop2Box2.Text = Convert.ToString(m.ReadInt("base+2924508"));
                }
            }
        }

        private void shop2Set3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop2Box3.Text, out price);
                if (!string.IsNullOrEmpty(shop2Box3.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924570", "int", shop2Box3.Text);
                    shop2Box3.ForeColor = Color.Green;
                    shop2Box3.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop2Box3.ForeColor = Color.Black;
                    shop2Box3.Text = Convert.ToString(price);
                }
                else
                {
                    shop2Box3.ForeColor = Color.Red;
                    shop2Box3.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop2Box3.ForeColor = Color.Black;
                    shop2Box3.Text = Convert.ToString(m.ReadInt("base+2924570"));
                }
            }
        }

        private void shop2Set4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop2Box4.Text, out price);
                if (!string.IsNullOrEmpty(shop2Box4.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+29245D8", "int", shop2Box4.Text);
                    shop2Box4.ForeColor = Color.Green;
                    shop2Box4.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop2Box4.ForeColor = Color.Black;
                    shop2Box4.Text = Convert.ToString(price);
                }
                else
                {
                    shop2Box4.ForeColor = Color.Red;
                    shop2Box4.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop2Box4.ForeColor = Color.Black;
                    shop2Box4.Text = Convert.ToString(m.ReadInt("base+29245D8"));
                }
            }
        }

        private void shop2Set5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop2Box5.Text, out price);
                if (!string.IsNullOrEmpty(shop2Box5.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924640", "int", shop2Box5.Text);
                    shop2Box5.ForeColor = Color.Green;
                    shop2Box5.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop2Box5.ForeColor = Color.Black;
                    shop2Box5.Text = Convert.ToString(price);
                }
                else
                {
                    shop2Box5.ForeColor = Color.Red;
                    shop2Box5.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop2Box5.ForeColor = Color.Black;
                    shop2Box5.Text = Convert.ToString(m.ReadInt("base+2924640"));
                }
            }
        }

        private void shop2Set6_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop2Box6.Text, out price);
                if (!string.IsNullOrEmpty(shop2Box6.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+29246A8", "int", shop2Box6.Text);
                    shop2Box6.ForeColor = Color.Green;
                    shop2Box6.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop2Box6.ForeColor = Color.Black;
                    shop2Box6.Text = Convert.ToString(price);
                }
                else
                {
                    shop2Box6.ForeColor = Color.Red;
                    shop2Box6.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop2Box6.ForeColor = Color.Black;
                    shop2Box6.Text = Convert.ToString(m.ReadInt("base+29246A8"));
                }
            }
        }

        private void shop3Get1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop3Box1.Text = Convert.ToString(m.ReadInt("base+2924710"));
            }
        }

        private void shop3Get2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop3Box2.Text = Convert.ToString(m.ReadInt("base+2924778"));
            }
        }

        private void shop3Get3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop3Box3.Text = Convert.ToString(m.ReadInt("base+29247E0"));
            }
        }

        private void shop3Get4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop3Box4.Text = Convert.ToString(m.ReadInt("base+2924848"));
            }
        }

        private void shop3Get5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop3Box5.Text = Convert.ToString(m.ReadInt("base+29248B0"));
            }
        }

        private void shop3Get6_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop3Box6.Text = Convert.ToString(m.ReadInt("base+2924918"));
            }
        }

        private void shop3Set1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop3Box1.Text, out price);
                if (!string.IsNullOrEmpty(shop3Box1.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924710", "int", shop3Box1.Text);
                    shop3Box1.ForeColor = Color.Green;
                    shop3Box1.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop3Box1.ForeColor = Color.Black;
                    shop3Box1.Text = Convert.ToString(price);
                }
                else
                {
                    shop3Box1.ForeColor = Color.Red;
                    shop3Box1.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop3Box1.ForeColor = Color.Black;
                    shop3Box1.Text = Convert.ToString(m.ReadInt("base+2924710"));
                }
            }
        }

        private void shop3Set2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop3Box2.Text, out price);
                if (!string.IsNullOrEmpty(shop3Box2.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924778", "int", shop3Box2.Text);
                    shop3Box2.ForeColor = Color.Green;
                    shop3Box2.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop3Box2.ForeColor = Color.Black;
                    shop3Box2.Text = Convert.ToString(price);
                }
                else
                {
                    shop3Box2.ForeColor = Color.Red;
                    shop3Box2.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop3Box2.ForeColor = Color.Black;
                    shop3Box2.Text = Convert.ToString(m.ReadInt("base+2924778"));
                }
            }
        }

        private void shop3Set3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop3Box3.Text, out price);
                if (!string.IsNullOrEmpty(shop3Box3.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+29247E0", "int", shop3Box3.Text);
                    shop3Box3.ForeColor = Color.Green;
                    shop3Box3.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop3Box3.ForeColor = Color.Black;
                    shop3Box3.Text = Convert.ToString(price);
                }
                else
                {
                    shop3Box3.ForeColor = Color.Red;
                    shop3Box3.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop3Box3.ForeColor = Color.Black;
                    shop3Box3.Text = Convert.ToString(m.ReadInt("base+29247E0"));
                }
            }
        }

        private void shop3Set4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop3Box4.Text, out price);
                if (!string.IsNullOrEmpty(shop3Box4.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924848", "int", shop3Box4.Text);
                    shop3Box4.ForeColor = Color.Green;
                    shop3Box4.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop3Box4.ForeColor = Color.Black;
                    shop3Box4.Text = Convert.ToString(price);
                }
                else
                {
                    shop3Box4.ForeColor = Color.Red;
                    shop3Box4.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop3Box4.ForeColor = Color.Black;
                    shop3Box4.Text = Convert.ToString(m.ReadInt("base+2924848"));
                }
            }
        }

        private void shop3Set5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop3Box5.Text, out price);
                if (!string.IsNullOrEmpty(shop3Box5.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+29248B0", "int", shop3Box5.Text);
                    shop3Box5.ForeColor = Color.Green;
                    shop3Box5.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop3Box5.ForeColor = Color.Black;
                    shop3Box5.Text = Convert.ToString(price);
                }
                else
                {
                    shop3Box5.ForeColor = Color.Red;
                    shop3Box5.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop3Box5.ForeColor = Color.Black;
                    shop3Box5.Text = Convert.ToString(m.ReadInt("base+29248B0"));
                }
            }
        }

        private void shop3Set6_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop3Box6.Text, out price);
                if (!string.IsNullOrEmpty(shop3Box6.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924918", "int", shop3Box6.Text);
                    shop3Box6.ForeColor = Color.Green;
                    shop3Box6.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop3Box6.ForeColor = Color.Black;
                    shop3Box6.Text = Convert.ToString(price);
                }
                else
                {
                    shop3Box6.ForeColor = Color.Red;
                    shop3Box6.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop3Box6.ForeColor = Color.Black;
                    shop3Box6.Text = Convert.ToString(m.ReadInt("base+2924918"));
                }
            }
        }

        private void shop4Get1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop4Box1.Text = Convert.ToString(m.ReadInt("base+2924980"));
            }
        }

        private void shop4Get2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop4Box2.Text = Convert.ToString(m.ReadInt("base+29249E8"));
            }
        }

        private void shop4Get3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop4Box3.Text = Convert.ToString(m.ReadInt("base+2924A50"));
            }
        }

        private void shop4Get4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop4Box4.Text = Convert.ToString(m.ReadInt("base+2924AB8"));
            }
        }

        private void shop4Get5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop4Box5.Text = Convert.ToString(m.ReadInt("base+2924B20"));
            }
        }

        private void shop4Set1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop4Box1.Text, out price);
                if (!string.IsNullOrEmpty(shop4Box1.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924980", "int", shop4Box1.Text);
                    shop4Box1.ForeColor = Color.Green;
                    shop4Box1.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop4Box1.ForeColor = Color.Black;
                    shop4Box1.Text = Convert.ToString(price);
                }
                else
                {
                    shop4Box1.ForeColor = Color.Red;
                    shop4Box1.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop4Box1.ForeColor = Color.Black;
                    shop4Box1.Text = Convert.ToString(m.ReadInt("base+2924980"));
                }
            }
        }

        private void shop4Set2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop4Box2.Text, out price);
                if (!string.IsNullOrEmpty(shop4Box2.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+29249E8", "int", shop4Box2.Text);
                    shop4Box2.ForeColor = Color.Green;
                    shop4Box2.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop4Box2.ForeColor = Color.Black;
                    shop4Box2.Text = Convert.ToString(price);
                }
                else
                {
                    shop4Box2.ForeColor = Color.Red;
                    shop4Box2.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop4Box2.ForeColor = Color.Black;
                    shop4Box2.Text = Convert.ToString(m.ReadInt("base+29249E8"));
                }
            }
        }

        private void shop4Set3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop4Box3.Text, out price);
                if (!string.IsNullOrEmpty(shop4Box3.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924A50", "int", shop4Box3.Text);
                    shop4Box3.ForeColor = Color.Green;
                    shop4Box3.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop4Box3.ForeColor = Color.Black;
                    shop4Box3.Text = Convert.ToString(price);
                }
                else
                {
                    shop4Box3.ForeColor = Color.Red;
                    shop4Box3.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop4Box3.ForeColor = Color.Black;
                    shop4Box3.Text = Convert.ToString(m.ReadInt("base+2924A50"));
                }
            }
        }

        private void shop4Set4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop4Box4.Text, out price);
                if (!string.IsNullOrEmpty(shop4Box4.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924AB8", "int", shop4Box4.Text);
                    shop4Box4.ForeColor = Color.Green;
                    shop4Box4.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop4Box4.ForeColor = Color.Black;
                    shop4Box4.Text = Convert.ToString(price);
                }
                else
                {
                    shop4Box4.ForeColor = Color.Red;
                    shop4Box4.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop4Box4.ForeColor = Color.Black;
                    shop4Box4.Text = Convert.ToString(m.ReadInt("base+2924AB8"));
                }
            }
        }

        private void shop4Set5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop4Box5.Text, out price);
                if (!string.IsNullOrEmpty(shop4Box5.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924B20", "int", shop4Box5.Text);
                    shop4Box5.ForeColor = Color.Green;
                    shop4Box5.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop4Box5.ForeColor = Color.Black;
                    shop4Box5.Text = Convert.ToString(price);
                }
                else
                {
                    shop4Box5.ForeColor = Color.Red;
                    shop4Box5.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop4Box5.ForeColor = Color.Black;
                    shop4Box5.Text = Convert.ToString(m.ReadInt("base+2924B20"));
                }
            }
        }

        private void shop5Get1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop5Box1.Text = Convert.ToString(m.ReadInt("base+2924BF0"));
            }
        }

        private void shop5Get2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop5Box2.Text = Convert.ToString(m.ReadInt("base+2924C58"));
            }
        }

        private void shop5Get3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop5Box3.Text = Convert.ToString(m.ReadInt("base+2924CC0"));
            }
        }

        private void shop5Get4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop5Box4.Text = Convert.ToString(m.ReadInt("base+2924D28"));
            }
        }

        private void shop5Get5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop5Box5.Text = Convert.ToString(m.ReadInt("base+2924D90"));
            }
        }

        private void shop5Set1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop5Box1.Text, out price);
                if (!string.IsNullOrEmpty(shop5Box1.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924BF0", "int", shop5Box1.Text);
                    shop5Box1.ForeColor = Color.Green;
                    shop5Box1.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop5Box1.ForeColor = Color.Black;
                    shop5Box1.Text = Convert.ToString(price);
                }
                else
                {
                    shop5Box1.ForeColor = Color.Red;
                    shop5Box1.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop5Box1.ForeColor = Color.Black;
                    shop5Box1.Text = Convert.ToString(m.ReadInt("base+2924BF0"));
                }
            }
        }

        private void shop5Set2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop5Box2.Text, out price);
                if (!string.IsNullOrEmpty(shop5Box2.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924C58", "int", shop5Box2.Text);
                    shop5Box2.ForeColor = Color.Green;
                    shop5Box2.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop5Box2.ForeColor = Color.Black;
                    shop5Box2.Text = Convert.ToString(price);
                }
                else
                {
                    shop5Box2.ForeColor = Color.Red;
                    shop5Box2.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop5Box2.ForeColor = Color.Black;
                    shop5Box2.Text = Convert.ToString(m.ReadInt("base+2924C58"));
                }
            }
        }

        private void shop5Set3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop5Box3.Text, out price);
                if (!string.IsNullOrEmpty(shop5Box3.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924CC0", "int", shop5Box3.Text);
                    shop5Box3.ForeColor = Color.Green;
                    shop5Box3.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop5Box3.ForeColor = Color.Black;
                    shop5Box3.Text = Convert.ToString(price);
                }
                else
                {
                    shop5Box3.ForeColor = Color.Red;
                    shop5Box3.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop5Box3.ForeColor = Color.Black;
                    shop5Box3.Text = Convert.ToString(m.ReadInt("base+2924CC0"));
                }
            }
        }

        private void shop5Set4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop5Box4.Text, out price);
                if (!string.IsNullOrEmpty(shop5Box4.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924D28", "int", shop5Box4.Text);
                    shop5Box4.ForeColor = Color.Green;
                    shop5Box4.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop5Box4.ForeColor = Color.Black;
                    shop5Box4.Text = Convert.ToString(price);
                }
                else
                {
                    shop5Box4.ForeColor = Color.Red;
                    shop5Box4.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop5Box4.ForeColor = Color.Black;
                    shop5Box4.Text = Convert.ToString(m.ReadInt("base+2924D28"));
                }
            }
        }

        private void shop5Set5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop5Box5.Text, out price);
                if (!string.IsNullOrEmpty(shop5Box5.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924D90", "int", shop5Box5.Text);
                    shop5Box5.ForeColor = Color.Green;
                    shop5Box5.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop5Box5.ForeColor = Color.Black;
                    shop5Box5.Text = Convert.ToString(price);
                }
                else
                {
                    shop5Box5.ForeColor = Color.Red;
                    shop5Box5.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop5Box5.ForeColor = Color.Black;
                    shop5Box5.Text = Convert.ToString(m.ReadInt("base+2924D90"));
                }
            }
        }

        private void shop6Get1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop6Box1.Text = Convert.ToString(m.ReadInt("base+2924DF8"));
            }
        }

        private void shop6Get2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop6Box2.Text = Convert.ToString(m.ReadInt("base+2924F98"));
            }
        }

        private void shop6Get3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop6Box3.Text = Convert.ToString(m.ReadInt("base+2925000"));
            }
        }

        private void shop6Get4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop6Box4.Text = Convert.ToString(m.ReadInt("base+2925068"));
            }
        }

        private void shop6Get5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                shop6Box5.Text = Convert.ToString(m.ReadInt("base+29250D0"));
            }
        }

        private void shop6Set1_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop6Box1.Text, out price);
                if (!string.IsNullOrEmpty(shop6Box1.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924DF8", "int", shop6Box1.Text);
                    shop6Box1.ForeColor = Color.Green;
                    shop6Box1.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop6Box1.ForeColor = Color.Black;
                    shop6Box1.Text = Convert.ToString(price);
                }
                else
                {
                    shop6Box1.ForeColor = Color.Red;
                    shop6Box1.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop6Box1.ForeColor = Color.Black;
                    shop6Box1.Text = Convert.ToString(m.ReadInt("base+2924DF8"));
                }
            }
        }

        private void shop6Set2_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop6Box2.Text, out price);
                if (!string.IsNullOrEmpty(shop6Box2.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2924F98", "int", shop6Box2.Text);
                    shop6Box2.ForeColor = Color.Green;
                    shop6Box2.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop6Box2.ForeColor = Color.Black;
                    shop6Box2.Text = Convert.ToString(price);
                }
                else
                {
                    shop6Box2.ForeColor = Color.Red;
                    shop6Box2.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop6Box2.ForeColor = Color.Black;
                    shop6Box2.Text = Convert.ToString(m.ReadInt("base+2924F98"));
                }
            }
        }

        private void shop6Set3_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop6Box3.Text, out price);
                if (!string.IsNullOrEmpty(shop6Box3.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2925000", "int", shop6Box3.Text);
                    shop6Box3.ForeColor = Color.Green;
                    shop6Box3.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop6Box3.ForeColor = Color.Black;
                    shop6Box3.Text = Convert.ToString(price);
                }
                else
                {
                    shop6Box3.ForeColor = Color.Red;
                    shop6Box3.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop6Box3.ForeColor = Color.Black;
                    shop6Box3.Text = Convert.ToString(m.ReadInt("base+2925000"));
                }
            }
        }

        private void shop6Set4_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop6Box4.Text, out price);
                if (!string.IsNullOrEmpty(shop6Box4.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+2925068", "int", shop6Box4.Text);
                    shop6Box4.ForeColor = Color.Green;
                    shop6Box4.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop6Box4.ForeColor = Color.Black;
                    shop6Box4.Text = Convert.ToString(price);
                }
                else
                {
                    shop6Box4.ForeColor = Color.Red;
                    shop6Box4.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop6Box4.ForeColor = Color.Black;
                    shop6Box4.Text = Convert.ToString(m.ReadInt("base+2925068"));
                }
            }
        }

        private void shop6Set5_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int price = 0;
                bool parse = int.TryParse(shop6Box5.Text, out price);
                if (!string.IsNullOrEmpty(shop6Box5.Text) && parse && price >= 0)
                {
                    m.WriteMemory("base+29250D0", "int", shop6Box5.Text);
                    shop6Box5.ForeColor = Color.Green;
                    shop6Box5.Text = "Price Set!";
                    Task.Delay(1000).Wait();
                    shop6Box5.ForeColor = Color.Black;
                    shop6Box5.Text = Convert.ToString(price);
                }
                else
                {
                    shop6Box5.ForeColor = Color.Red;
                    shop6Box5.Text = "Invalid!";
                    Task.Delay(1000).Wait();
                    shop6Box5.ForeColor = Color.Black;
                    shop6Box5.Text = Convert.ToString(m.ReadInt("base+29250D0"));
                }
            }
        }

        private void addMoney_CheckedChanged(object sender, EventArgs e)
        {
            if (openProc) 
            { 
                if (addMoney.Checked)
                {
                    m.WriteMemory("base+7F93EE", "bytes", "49 01");
                }
                else
                {
                    m.WriteMemory("base+7F93EE", "bytes", "4C 2B");
                }
            }
        }

        private void pLPget_Click(object sender, EventArgs e)
        {
            if (openProc) 
            {
                int duelFlag = m.ReadInt("base+278EF0C");

                if (duelFlag > 0)
                {
                    int lifePointsKey = m.Read2Byte("base+3330280");
                    int playerLPencrypted = m.ReadInt("base+3497C40");
                    pLPbox.Text = Convert.ToString(playerLPencrypted ^ lifePointsKey);
                }
                else
                {
                    pLPbox.ForeColor = Color.Red;
                    pLPbox.Text = "Not In Duel!";
                    Task.Delay(1000).Wait();
                    pLPbox.ForeColor = Color.Black;
                    pLPbox.Text = string.Empty;
                }
            }
        }

        private void oLPget_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int duelFlag = m.ReadInt("base+278EF0C");

                if (duelFlag > 0)
                {
                    int lifePointsKey = m.Read2Byte("base+3330280");
                    int opponentLPencrypted = m.ReadInt("base+34989D4");
                    oLPbox.Text = Convert.ToString(opponentLPencrypted ^ lifePointsKey);
                }
                else
                {
                    oLPbox.ForeColor = Color.Red;
                    oLPbox.Text = "Not In Duel!";
                    Task.Delay(1000).Wait();
                    oLPbox.ForeColor = Color.Black;
                    oLPbox.Text = string.Empty;
                }
            }
        }

        private void pLPset_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int duelFlag = m.ReadInt("base+278EF0C");

                if (duelFlag > 0)
                {
                    int lifePointsKey = m.Read2Byte("base+3330280");
                    int playerLPencrypted = m.ReadInt("base+3497C40");
                    int setLP = 0;
                    bool parse = int.TryParse(pLPbox.Text, out setLP);

                    if (!string.IsNullOrEmpty(pLPbox.Text) && parse && setLP >= 0)
                    {
                        m.WriteMemory("base+3497C40", "int", Convert.ToString(setLP ^ lifePointsKey));
                        m.WriteMemory("base+2791228", "int", Convert.ToString(setLP));
                        m.WriteMemory("base+2791230", "int", Convert.ToString(setLP));
                        pLPbox.ForeColor = Color.Green;
                        pLPbox.Text = "Life Points Set!";
                        Task.Delay(1000).Wait();
                        pLPbox.ForeColor = Color.Black;
                        pLPbox.Text = Convert.ToString(setLP);
                    }
                    else 
                    {
                        pLPbox.ForeColor = Color.Red;
                        pLPbox.Text = "Invalid!";
                        Task.Delay(1000).Wait();
                        pLPbox.ForeColor = Color.Black;
                        pLPbox.Text = Convert.ToString(playerLPencrypted ^ lifePointsKey);
                    }
                }
                else
                {
                    pLPbox.ForeColor = Color.Red;
                    pLPbox.Text = "Not In Duel!";
                    Task.Delay(1000).Wait();
                    pLPbox.ForeColor = Color.Black;
                    pLPbox.Text = string.Empty;
                }
            }
        }

        private void oLPset_Click(object sender, EventArgs e)
        {
            if (openProc)
            {
                int duelFlag = m.ReadInt("base+278EF0C");

                if (duelFlag > 0)
                {
                    int lifePointsKey = m.Read2Byte("base+3330280");
                    int opponentLPencrypted = m.ReadInt("base+34989D4");
                    int setLP = 0;
                    bool parse = int.TryParse(oLPbox.Text, out setLP);

                    if (!string.IsNullOrEmpty(oLPbox.Text) && parse && setLP >= 0)
                    {
                        m.WriteMemory("base+34989D4", "int", Convert.ToString(setLP ^ lifePointsKey));
                        m.WriteMemory("base+2793530", "int", Convert.ToString(setLP));
                        m.WriteMemory("base+2793538", "int", Convert.ToString(setLP));
                        oLPbox.ForeColor = Color.Green;
                        oLPbox.Text = "Life Points Set!";
                        Task.Delay(1000).Wait();
                        oLPbox.ForeColor = Color.Black;
                        oLPbox.Text = Convert.ToString(setLP);
                    }
                    else
                    {
                        oLPbox.ForeColor = Color.Red;
                        oLPbox.Text = "Invalid!";
                        Task.Delay(1000).Wait();
                        oLPbox.ForeColor = Color.Black;
                        oLPbox.Text = Convert.ToString(opponentLPencrypted ^ lifePointsKey);
                    }
                }
                else
                {
                    oLPbox.ForeColor = Color.Red;
                    oLPbox.Text = "Not In Duel!";
                    Task.Delay(1000).Wait();
                    oLPbox.ForeColor = Color.Black;
                    oLPbox.Text = string.Empty;
                }
            }
        }

        private void pauseFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (openProc)
            {
                if (pauseFlag.Checked)
                {
                    m.WriteMemory("base+807DD0", "bytes", "C3 90 90 90 90");
                }
                else
                {
                    m.WriteMemory("base+807DD0", "bytes", "48 89 5C 24 08");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            moneyInput.Text = string.Empty;
            shop1Box1.Text = string.Empty;
            shop1Box2.Text = string.Empty;
            shop1Box3.Text = string.Empty;
            shop1Box4.Text = string.Empty;
            shop1Box5.Text = string.Empty;
            shop1Box6.Text = string.Empty;
            shop2Box1.Text = string.Empty;
            shop2Box2.Text = string.Empty;
            shop2Box3.Text = string.Empty;
            shop2Box4.Text = string.Empty;
            shop2Box5.Text = string.Empty;
            shop2Box6.Text = string.Empty;
            shop3Box1.Text = string.Empty;
            shop3Box2.Text = string.Empty;
            shop3Box3.Text = string.Empty;
            shop3Box4.Text = string.Empty;
            shop3Box5.Text = string.Empty;
            shop3Box6.Text = string.Empty;
            shop4Box1.Text = string.Empty;
            shop4Box2.Text = string.Empty;
            shop4Box3.Text = string.Empty;
            shop4Box4.Text = string.Empty;
            shop4Box5.Text = string.Empty;
            shop5Box1.Text = string.Empty;
            shop5Box2.Text = string.Empty;
            shop5Box3.Text = string.Empty;
            shop5Box4.Text = string.Empty;
            shop5Box5.Text = string.Empty;
            shop6Box1.Text = string.Empty;
            shop6Box2.Text = string.Empty;
            shop6Box3.Text = string.Empty;
            shop6Box4.Text = string.Empty;
            shop6Box5.Text = string.Empty;
            addMoney.Checked = false;
            cardCount.Checked = false;
            pauseFlag.Checked = false;
            shopDefault.BackColor = Color.Gainsboro;
            shopFree.BackColor = Color.Gainsboro;
            pLPbox.Text = string.Empty;
            oLPbox.Text = string.Empty;
        }
    }
}
