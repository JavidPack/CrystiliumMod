using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items
{
	public class CrystalPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Potion");
			// Tooltip.SetDefault("Makes shards of crystals damage nearby enemies.");
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
			Item.value = 3000;
			Item.rare = 0;
			Item.buffType = ModContent.BuffType<Buffs.CrystalLeak>();
			Item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CrystalBottleWater>());
			recipe.AddIngredient(ModContent.ItemType<ShinyGemstone>());
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}