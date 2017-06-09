using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CrystalLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Leggings");
			Tooltip.SetDefault("7% increased magic and summon crit chance"
				+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
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
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}