using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            if (tbLogin.Text == "")
            {
                MessageBox.Show("Empty username! Enter username, pleasure!");
            }
            else if (tbLogin.Text.Length > 25)
            {
                MessageBox.Show("Very long username! Enter username till 25 symbols.");
            }
            else
            {
                cm.Connect(tbLogin.Text, pl);
                pl.Show();
                this.Hide();
            }
        }
    }
}
