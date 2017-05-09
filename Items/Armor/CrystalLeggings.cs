using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	public class CrystalLeggings : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Legs);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Crystal Leggings";
			item.width = 18;
			item.height = 18;
			item.toolTip = "7% increased magic and summon crit chance";
			item.toolTip2 = "Increases maximum minions";
			item.value = 10000;
			item.rare = 3;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicCrit += 7;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.RadiantPrism>(), 10);
			recipe.AddIngredient(mod.ItemType<Items.ShinyGemstone>(), 10);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}