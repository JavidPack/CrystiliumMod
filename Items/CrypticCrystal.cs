using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class CrypticCrystal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryptic Crystal");
			Tooltip.SetDefault("Use at the heart of the Crystal"
				+ "\n'Boast of thy Treasures, and Dragons will come...'");
		}

		public override void SetDefaults()
		{
			item.consumable = true;
			item.rare = 7;
		}

		public override bool CanUseItem(Player player)
		{
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.CrystalShard, 10);
			recipe.AddIngredient(mod.ItemType<EnchantedGeode>(), 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}