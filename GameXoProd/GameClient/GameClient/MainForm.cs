using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public partial class MainForm : Form
    {
        ClientManager cm;
        PlayersList pl;
        public MainForm()
        {         
            InitializeComponent();
            cm = new ClientManager();
            pl = new PlayersList();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbLogin.Text == "")
                {
                    MessageBox.Show("Empty username! Enter username, pleasure!");
                }
                if (tbPassword.Text == "")
                {
                    MessageBox.Show("Empty password! Enter password, pleasure!");
                }
                string s = tbLogin.Text;
                if (!(Regex.IsMatch(tbLogin.Text, @"^[a-zA-Z0-9]+$")) || !(Regex.IsMatch(tbPassword.Text, @"^[a-zA-Z0-9]+$")))
                {
                    MessageBox.Show("Incorrect symbols");
                }
                else if (tbLogin.Text.Length > 20)
                {
                    MessageBox.Show("Very long username! Enter username till 20 symbols.");
                }
                else if (tbPassword.Text.Length > 20)
                {
                    MessageBox.Show("Very long password! Enter password till 20 symbols.");
                }
                else
                {
                    cm.Connect(tbLogin.Text, tbPassword.Text, pl, "auth");
                    Thread.Sleep(500);
                    if (!(pl.lb_name.Text == "label1"))
                    {
                        pl.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Invalid Login or pass or you are already in the game");
                }
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbLogin.Text == "")
                {
                    MessageBox.Show("Empty username! Enter username, pleasure!");
                }
                if (tbPassword.Text == "")
                {
                    MessageBox.Show("Empty password! Enter password, pleasure!");
                }
                string s = tbLogin.Text;
                if (!(Regex.IsMatch(tbLogin.Text, @"^[a-zA-Z0-9]+$")) || !(Regex.IsMatch(tbPassword.Text, @"^[a-zA-Z0-9]+$")))
                {
                    MessageBox.Show("Incorrect symbols");
                }
                else if (tbLogin.Text.Length > 20)
                {
                    MessageBox.Show("Very long username! Enter username till 20 symbols.");
                }
                else if (tbPassword.Text.Length > 20)
                {
                    MessageBox.Show("Very long password! Enter password till 20 symbols.");
                }
                else
                {
                    cm.Connect(tbLogin.Text, tbPassword.Text, pl, "reg");
                    Thread.Sleep(500);
                    if (!(pl.lb_name.Text == "label1"))
                    {
                        pl.Show();
                        this.Hide();
                    }
                    else MessageBox.Show("Invalid Login");
                }
            }
            catch { MessageBox.Show("Server not found", "ERROR"); }

        }
    }
}
