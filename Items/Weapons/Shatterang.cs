using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Shatterang : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shatterang");
		}

		public override void SetDefaults()
		{
			Item.damage = 90;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.noUseGraphic = true;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 80000;
			Item.rare = 8;
			Item.shootSpeed = 16f;
			Item.shoot = ProjectileType<Projectiles.ShatterangProj>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool CanUseItem(Player player)		 //this make that you can shoot only 1 boomerang at once
		{
			for (int i = 0; i < 1000; ++i)
			{
				if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot)
				{
					return false;
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<CrystiliumBar>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}