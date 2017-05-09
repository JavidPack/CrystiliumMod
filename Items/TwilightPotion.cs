using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class TwilightPotion : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Twilight Potion";
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 17;
			item.useTime = 17;
			item.maxStack = 30;
			item.consumable = true;
			item.width = 12;
			item.height = 30;
			item.toolTip = "+7% damage boost at night";
			item.value = 3000;
			item.rare = 0;
			item.buffType = mod.BuffType<Buffs.Twilight>();
			item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CrystalBottleWater", 1);
			recipe.AddIngredient(null, "RadiantPrism", 1);
			recipe.AddIngredient(ItemID.Moonglow, 1);
			recipe.AddIngredient(ItemID.Sapphire, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}