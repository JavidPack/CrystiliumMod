using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystalSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Spear");
		}

		public override void SetDefaults()
		{
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.thrown = true;
			item.channel = true;
			item.noMelee = true;
			item.consumable = true;
			item.maxStack = 999;
			item.shoot = mod.ProjectileType<Projectiles.CrystalSpear>();
			item.useAnimation = 21;
			item.useTime = 21;
			item.shootSpeed = 8.5f;
			item.damage = 21;
			item.knockBack = 3.5f;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.crit = 12;
			item.rare = 3;
			item.autoReuse = true;
			//item.maxStack = 999;
			//item.consumable = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<RadiantPrism>());
			recipe.AddIngredient(mod.ItemType<ShinyGemstone>());
			recipe.AddIngredient(ItemID.Wood, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}