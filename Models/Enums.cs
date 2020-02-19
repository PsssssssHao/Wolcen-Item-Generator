using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenMod.Models
{
    // Selectable items
    public enum ItemGem
    {
        [StringValue("Shadow_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Shadow,
        [StringValue("Sacred_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Sacred,
        [StringValue("Lightning_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Lightning,
        [StringValue("Umbra_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Aether,
        [StringValue("Frost_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Frost,
        [StringValue("Fire_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Fire,
        [StringValue("Toughness_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Attack_Speed,
        [StringValue("Poison_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Poison,
        [StringValue("Physical_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Physical,
        [StringValue("Rend_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Rend,
        [StringValue("Utility_Gem_Tier_")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(6)]
        Crit_dmg_chance,
    }

    public enum GemTier
    {
        [StringValue("01")]
        Tier_1,
        [StringValue("02")]
        Tier_2,
        [StringValue("03")]
        Tier_3,
        [StringValue("04")]
        Tier_4,
        [StringValue("05")]
        Tier_5,
        [StringValue("06")]
        Tier_6,
        [StringValue("07")]
        Tier_7,
        [StringValue("08")]
        Tier_8,
        [StringValue("09")]
        Tier_9,
        [StringValue("10")]
        Tier_10,
        [StringValue("11")]
        Tier_11,
        [StringValue("12")]
        Tier_12,
    }

    public enum ItemReagent
    {
        [StringValue("Reagent_1")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(10)]
        Entropy_Orb,
        [StringValue("Reagent_1_Legendary")]
        [RarityValue(4)]
        [QualityValue(4)]
        [TypeValue(10)]
        Greater_Entropy_Orb,
        [StringValue("Reagent_2")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(10)]
        Ohms_Echo,
        [StringValue("Reagent_2_Legendary")]
        [RarityValue(4)]
        [QualityValue(4)]
        [TypeValue(10)]
        Greater_Ohms_Echo,
        [StringValue("Reagent_3")]
        [RarityValue(1)]
        [QualityValue(1)]
        [TypeValue(10)]
        Erieban_Tear,
        [StringValue("Reagent_3_Legendary")]
        [RarityValue(4)]
        [QualityValue(4)]
        [TypeValue(10)]
        Greater_Erieban_Tear
    }

    public enum ItemMap
    {
        [StringValue("npc2_consumable_03")]
        [RarityValue(2)]
        [QualityValue(0)]
        [TypeValue(9)]
        Wealth_Omen,
        [StringValue("npc2_consumable_05")]
        [RarityValue(2)]
        [QualityValue(0)]
        [TypeValue(9)]
        Bounty_hunt,
        [StringValue("npc2_consumable_09")]
        [RarityValue(6)]
        [QualityValue(0)]
        [TypeValue(9)]
        Goldroot,
        [StringValue("npc2_consumable_12")]
        [RarityValue(6)]
        [QualityValue(0)]
        [TypeValue(9)]
        Memorys_Echo,
        [StringValue("npc2_consumable_13")]
        [RarityValue(6)]
        [QualityValue(0)]
        [TypeValue(9)]
        Hyperconcentrated_Memorys_Echo,
        [StringValue("npc2_consumable_14")]
        [RarityValue(6)]
        [QualityValue(0)]
        [TypeValue(9)]
        Pure_Memorys_Echo
    }

    public enum Types
    {
        Gem,
        Reagent,
        Map
    }

    public enum ItemType
    {
        ChestArmor,
        FootArmor,
        ArmArmor,
        LegArmor,
        Shoulder,
        Helmet,
        Sword1H,
        Bow,
        Staff,
        Axe1H,
        Axe2H,
        Mace1H,
        Mace2H,
        Trinket,
        Gun,

        Amulet,
        Ring,
        Belt,

        Gem,
        Reagent,
        Map
    }

    public enum Categories
    {
        Gem,
        Reagent,
        NPC2Consumable,
        Armor,
        Weapon
    }
}
