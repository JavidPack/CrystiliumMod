using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class GeodePickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Geode Pickaxe";
			item.damage = 30;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 13;
			item.useAnimation = 13;
			item.pick = 150;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 20000;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EnchantedGeode", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}