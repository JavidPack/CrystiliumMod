using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class ThrowingBoostPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwing Boost Potion");
			Tooltip.SetDefault("Increases throwing damage");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 30;
			item.consumable = true;
			item.width = 12;
			item.height = 30;
			item.value = 3000;
			item.rare = 0;
			item.buffType = mod.BuffType<Buffs.ThrowingBoost>();
			item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<CrystalBottleWater>());
			recipe.AddIngredient(mod.ItemType<ShinyGemstone>());
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.Emerald);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}