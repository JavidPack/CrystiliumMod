using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = 3;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Magic) += 7;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Items.RadiantPrism>(), 10);
			recipe.AddIngredient(ItemType<Items.ShinyGemstone>(), 10);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.Register();
		}
	}
}