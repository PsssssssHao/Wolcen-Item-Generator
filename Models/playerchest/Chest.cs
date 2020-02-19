using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenMod.Models.playerchest
{
    public class Chest
    {
        private string[] oneSlotItems = { "Amulet", "Ring", "Belt", "Gem", "Reagent", ""};

        public string Version { get; set; }
        public string InventoryVersion { get; set; }
        public string ItemsVersion { get; set; }
        public List<Panel> Panels { get; set; }


        public List<KeyValuePair<int, int>> GetOccupiedSlots(Panel panel)
        {
            List<KeyValuePair<int, int>> occupied = new List<KeyValuePair<int, int>>();

            foreach (var item in panel.InventoryGrid)
            {
                // Is it a two slot item?
                if(!oneSlotItems.Contains(item.ItemType))
                {
                    occupied.Add(new KeyValuePair<int, int>(item.InventoryX, item.InventoryY));
                    occupied.Add(new KeyValuePair<int, int>(item.InventoryX, item.InventoryY + 1));
                }
                else
                {
                    occupied.Add(new KeyValuePair<int, int>(item.InventoryX, item.InventoryY));
                }
            }

            return occupied;
        }
    }
}
