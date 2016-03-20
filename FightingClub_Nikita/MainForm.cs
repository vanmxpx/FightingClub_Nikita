using System;
using System.Windows.Forms;

namespace FightingClub_Nikita
{
    public partial class MainForm : Form
    {
        public event EventHandler ButHeadClick;
        public event EventHandler ButBodyClick;
        public event EventHandler ButLegClick;

        StartForm start = new StartForm();

        public MainForm()
        {
            InitializeComponent();
            Application.Run(start);
            NamePlayer1 = start.StartName;
        }
        
        public void BlockGame(String _winner)
        {
            lblTitle.Text = _winner + " is winner!";
            butHead.Enabled = false;
            butBody.Enabled = false;
            butLeg.Enabled = false;
        }
        #region Events
        private void butHead_Click(object sender, EventArgs e)
        {
            if (ButHeadClick != null) ButHeadClick(this, EventArgs.Empty);
        }

        private void butBody_Click(object sender, EventArgs e)
        {
            if (ButBodyClick != null) ButBodyClick(this, EventArgs.Empty);
        }

        private void butLeg_Click(object sender, EventArgs e)
        {
            if (ButLegClick != null) ButLegClick(this, EventArgs.Empty);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #endregion

        #region Properties
        public string NamePlayer1
        {
            get
            {
                return lblPlayer1.Text;
            }
            set
            {
                lblPlayer1.Text = value;
            }
        }
        public string NamePlayer2
        {
            get
            {
                return lblPlayer2.Text;
            }
            set
            {
                lblPlayer2.Text = value;
            }
        }
        public int HPPlayer1
        {
            set
            {
                lblHPPlayer1.Text = value.ToString();
                progressBarPlayer1.Value = value;
            }
        }
        public int HPPlayer2
        {
            set
            {
                lblHPPlayer2.Text = value.ToString();
                progressBarPlayer2.Value = value;
            }
        }
        public bool Title
        {
            set
            {
                lblTitle.Text = (value)? "Atack!" : "Block!";
            }
        }
        public int Rounds
        {
            set
            {
                lblRounds.Text = value.ToString();
            }
        }
        public string AddLog
        {
            set
            {
                textBoxLog.Text += value + "\n";
            }
        }
        #endregion
    }
}
