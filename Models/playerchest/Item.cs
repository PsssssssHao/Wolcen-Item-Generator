using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenMod.Models.playerchest
{
    public class Item
    {
        public int InventoryX { get; set; }
        public int InventoryY { get; set; }
        public int Rarity { get; set; }
        public int Quality { get; set; }
        public int Type { get; set; }
        public string ItemType { get; set; }
        public string Value { get; set; }
        public int Level { get; set; }

        public Reagent Reagent { get; set; }
        public Gem Gem { get; set; }
        public NPC2Consumable NPC2Consumable { get; set; }

        public object Armor { get; set; }
        public object Weapon { get; set; }
        public object MagicEffects { get; set; }
    }
}
