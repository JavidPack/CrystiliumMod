using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items
{
	public class MarblePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Marble Potion");
			Tooltip.SetDefault("Lower defense, but faster speed");
		}

		public override void SetDefaults()
		{
			Item.UseSound = SoundID.Item3;
			Item.useStyle = 2;
			Item.useTurn = true;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.width = 12;
			Item.height = 30;
			Item.value = 3000;
			Item.rare = 0;
			Item.buffType = ModContent.BuffType<Buffs.MarbleBuff>();
			Item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CrystalBottleWater>());
			recipe.AddIngredient(ModContent.ItemType<ShinyGemstone>());
			recipe.AddIngredient(ItemID.Marble, 5);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}