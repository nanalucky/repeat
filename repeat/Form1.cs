using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace repeat
{
    public partial class Form1 : Form
    {
        AllPlayers allPlayers = new AllPlayers();
        
       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            repeatFiddler.doRun();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            repeatFiddler.Init();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            repeatFiddler.doQuit();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            buttonRun.Enabled = false;
            allPlayers.Init();
            allPlayers.Run();
        }

        public void Form1_Init()
        {
            if (AllPlayers.bSetProxy)
                textBoxSetProxy.Text = "true";
            else
                textBoxSetProxy.Text = "false";
            if (AllPlayers.bRepeat)
                textBoxRepeat.Text = "true";
            else
                textBoxRepeat.Text = "false";
            textBoxThreadNum.Text = Convert.ToString(AllPlayers.nThreadNum);
            textBoxStartTime.Text = AllPlayers.dtStartTime.ToShortTimeString();
            textBoxEndTime.Text = AllPlayers.dtEndTime.ToShortTimeString();
            textBoxSazFile.Text = AllPlayers.strSazFile;
        }
        
        
        public delegate void DelegateRichTextBoxStatus_AddString(string strAdd);
        public void richTextBoxStatus_AddString(string strAdd)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new DelegateRichTextBoxStatus_AddString(richTextBoxStatus_AddString), new object[] { strAdd });
                return;
            }
            richTextBoxStatus.Focus();
            //设置光标的位置到文本尾   
            richTextBoxStatus.Select(richTextBoxStatus.TextLength, 0);
            //滚动到控件光标处   
            richTextBoxStatus.ScrollToCaret();
            richTextBoxStatus.AppendText(strAdd);
        }

    }
}
