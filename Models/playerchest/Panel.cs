using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenMod.Models.playerchest
{
    public class Panel
    {
        public int Id { get; set; }
        public bool Locked { get; set; }
        public List<Item> InventoryGrid { get; set; }
    }
}
