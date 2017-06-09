using Terraria.ID;
using Terraria.ModLoader;

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
			item.buffType = mod.BuffType<Buffs.GraniteBuff>();
			item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<CrystalBottleWater>());
			recipe.AddIngredient(mod.ItemType<ShinyGemstone>());
			recipe.AddIngredient(ItemID.Granite, 5);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}