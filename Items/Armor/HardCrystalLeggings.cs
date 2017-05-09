using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
    public class HardCrystalLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Hard Crystal Leggings";
            item.width = 18;
            item.height = 18; 
			item.toolTip = "Increases maximum minions by 2";
            item.value = 30000;
            item.rare = 5;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 2;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 15);
            recipe.AddIngredient(mod.ItemType("EnchantedGeode"), 10);
            recipe.AddTile(Terraria.ID.TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}