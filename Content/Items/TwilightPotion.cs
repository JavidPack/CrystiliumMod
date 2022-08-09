using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items
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
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useTurn = true;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.width = 12;
			Item.height = 30;
			Item.value = 3000;
			Item.rare = 0;
			Item.buffType = ModContent.BuffType<Buffs.Twilight>();
			Item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CrystalBottleWater>());
			recipe.AddIngredient(ModContent.ItemType<RadiantPrism>());
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}