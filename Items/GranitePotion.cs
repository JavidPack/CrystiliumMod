using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class GranitePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Potion");
			Tooltip.SetDefault("More defense, but slower speed");
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
			Item.buffType = BuffType<Buffs.GraniteBuff>();
			Item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<CrystalBottleWater>());
			recipe.AddIngredient(ItemType<ShinyGemstone>());
			recipe.AddIngredient(ItemID.Granite, 5);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}