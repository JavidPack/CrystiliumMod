using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

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
			Item.useStyle = 1;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Throwing;
			Item.channel = true;
			Item.noMelee = true;
			Item.consumable = true;
			Item.maxStack = 999;
			Item.shoot = ProjectileType<Projectiles.CrystalSpear>();
			Item.useAnimation = 21;
			Item.useTime = 21;
			Item.shootSpeed = 8.5f;
			Item.damage = 21;
			Item.knockBack = 3.5f;
			Item.value = Item.sellPrice(0, 0, 1, 0);
			Item.crit = 12;
			Item.rare = 3;
			Item.autoReuse = true;
			//item.maxStack = 999;
			//item.consumable = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(10);
			recipe.AddIngredient(ItemType<RadiantPrism>());
			recipe.AddIngredient(ItemType<ShinyGemstone>());
			recipe.AddIngredient(ItemID.Wood, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}