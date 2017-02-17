﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameClient
{
    public partial class PlayersList : Form
    {
        public string name;
        public NetworkStream stream;
        public delegate void listDel(string[] ps);
        public PlayersList()
        {
            InitializeComponent();
            cbGame.SelectedIndex = 0;
        }
        

        public void AddList(string[] items)
        {
            lbPlayers.Invoke(new Action(() => { lbPlayers.Items.Clear(); }));
            for (int i = 1; i < items.Length; i++)
            {
                lbPlayers.Invoke(new Action(() => { lbPlayers.Items.Add(items[i]); }));
            }
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            if (lbPlayers.SelectedItem != null)
            {
                SendInvite(name, lbPlayers.SelectedItem.ToString(), cbGame.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please choose player firstly");
            }
        }      

        public void SendInvite(string player1, string player2, string gameid)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("lobby,invite" + "," + player1 + "," + player2 + "," + gameid);
            sw.Flush();
        }

        private void PlayersList_FormClosed(object sender, FormClosedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine("lobby,exit" + "," + lb_name.Text);
            sw.Flush();
            Environment.Exit(0);         
        }
    }
}