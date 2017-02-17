﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    class Games
    {
        CommandManager commandManager;
        List<IGame> gameList;
        public Games(CommandManager commandManager)
        {
            gameList = new List<IGame>();
            this.commandManager = commandManager;
        }
        public void SetCommand(string command)
        {
            string[] msg = command.Split(',');
            switch (msg[1])
            {
                case "ask":
                    if(AskRequest(msg[2], commandManager.connectionList.GetClient(msg[3]), commandManager.connectionList.GetClient(msg[4]), msg[5]))
                    {
                        switch (msg[5])
                        {
                            case "XO":
                                gameList.Add(new XO(commandManager.connectionList.GetClient(msg[3]), commandManager.connectionList.GetClient(msg[4])));
                                break;
                        }
                    }
                    break;
                case "gamexo":
                    for (int i = 0; i < gameList.Count; i++)
                    {
                        if (gameList[i].ContainsPlayer(commandManager.connectionList.GetClient(msg[2])))
                        {
                            if (gameList[i].Action(commandManager.connectionList.GetClient(msg[2]), msg[3]))
                                gameList.Remove(gameList[i]);
                        }
                    }
                    break;
            }
        }

        private bool AskRequest(string ask, Client player1, Client player2, string gameid)
        {
            if (ask == "No")
            {
                return false;
            }

            StreamWriter writer = new StreamWriter(player1.user.GetStream());
            writer.WriteLine("ask" + "," + "XO");
            writer.Flush();
            StreamWriter sw = new StreamWriter(player2.user.GetStream());
            sw.WriteLine("ask" + "," + "XO");
            sw.Flush();
            return true;
        }    
    }
}