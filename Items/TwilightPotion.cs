using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class TwilightPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight Potion");
			Tooltip.SetDefault("+7% damage boost at night");
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
			Item.buffType = BuffType<Buffs.Twilight>();
			Item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<CrystalBottleWater>());
			recipe.AddIngredient(ItemType<RadiantPrism>());
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}