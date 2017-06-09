using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class CrystalPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Potion");
			Tooltip.SetDefault("Makes shards of crystals damage nearby enemies.");
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
			item.value = 3000;
			item.rare = 0;
			item.buffType = mod.BuffType<Buffs.CrystalLeak>();
			item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<CrystalBottleWater>());
			recipe.AddIngredient(mod.ItemType<ShinyGemstone>());
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}