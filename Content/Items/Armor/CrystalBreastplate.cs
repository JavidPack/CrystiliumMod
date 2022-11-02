using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class CrystalBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Breastplate");
			// Tooltip.SetDefault("10% increased magic and summon damage"
			// 	+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 20000;
			Item.rare = 3;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) *= 1.10f;
			player.GetDamage(DamageClass.Summon) *= 1.10f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.RadiantPrism>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Items.ShinyGemstone>(), 25);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.Register();
		}
	}
}