using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class CrystalBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Breastplate");
			Tooltip.SetDefault("10% increased magic and summon damage"
				+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 20000;
			item.rare = 3;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage *= 1.10f;
			player.minionDamage *= 1.10f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Items.RadiantPrism>(), 15);
			recipe.AddIngredient(ItemType<Items.ShinyGemstone>(), 25);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}