using Terraria.ID;
using Terraria.ModLoader;

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
			item.buffType = mod.BuffType<Buffs.Twilight>();
			item.buffTime = 10000;
			return;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<CrystalBottleWater>());
			recipe.AddIngredient(mod.ItemType<RadiantPrism>());
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}