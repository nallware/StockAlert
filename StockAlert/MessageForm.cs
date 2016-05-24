using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockAlert
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }
        private string _message;
        private char _icon;        
        
        public Form refToForm1 { get; set; }
        private void MessageForm_Load(object sender, EventArgs e)
        {
            UpdateMessage();
        }

        public void UpdateMessage()
        {
            tbMessage.Text = InfoMessage;

            switch (IconForMessage)
            {
                case 'e':
                    {
                        panel1.BackColor = Color.Red;
                        tbMessage.BackColor = Color.Red;
                        btnMessage.BackColor = Color.Red;                        
                        pbIcon.Image = Properties.Resources.exclamation;
                        break;
                    }
                case 'i':
                    {

                        panel1.BackColor = Color.Orange;
                        tbMessage.BackColor = Color.Orange;
                        btnMessage.BackColor = Color.Orange;
                        pbIcon.Image = Properties.Resources.info;
                        break;
                    }
                case 'h':
                    {
                        panel1.BackColor = Color.DarkOrange;
                        tbMessage.BackColor = Color.DarkOrange;
                        btnMessage.BackColor = Color.DarkOrange;
                        pbIcon.Image = Properties.Resources.hashtag;
                        break;
                    }
                case 'p':
                    {
                        pbIcon.Image = Properties.Resources.pointer;
                        break;
                    }
                default:
                    break;
            }
        }

        public string InfoMessage
        {
            set { _message = value; }
            get { return _message; }
        }

        public char IconForMessage
        {
            set { _icon = value; }
            get { return _icon; }
        }

        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.refToForm1.Show();
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {            
            this.Hide();            
            this.refToForm1.Show();                        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateMessage();
        }

        private void MessageForm_Shown(object sender, EventArgs e)
        {
            UpdateMessage();
        }

        private void MessageForm_VisibleChanged(object sender, EventArgs e)
        {
            UpdateMessage();
        }
    }
}
