using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
    public class CrystiliumGreaves : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Crystilium Greaves";
            item.width = 18;
            item.height = 18; 
			item.toolTip = "+9% magic crit chance";
            item.value = 100000;
            item.rare = 8;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
           player.magicCrit += 9;
        }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CrystiliumBar"), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}