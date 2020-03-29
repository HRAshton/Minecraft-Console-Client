﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinecraftClient.Inventory;

namespace MinecraftClient.Commands
{
    class GetInventory : Command
    {
        public override string CMDName { get { return "inventory"; } }
        public override string CMDDesc { get { return "inventory: Show your inventory."; } }

        public override string Run(McTcpClient handler, string command, Dictionary<string, object> localVars)
        {
            List<string> response = new List<string>();

            response.Add("Inventory slots:");

            foreach (KeyValuePair<int, Item> item in handler.GetPlayerInventory().Items)
            {
                response.Add(String.Format(" #{0}: {1} x{2}", item.Key, item.Value.Type, item.Value.Count));
            }

            return String.Join("\n", response.ToArray());
        }
    }
}
