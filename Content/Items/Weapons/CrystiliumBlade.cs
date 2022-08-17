using CrystiliumMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class CrystiliumBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystilium Cleaver");
			// Tooltip.SetDefault("Launches crystal embers");
		}

		public override void SetDefaults()
		{
			Item.damage = 138;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 80000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ModContent.ProjectileType<CrystiliumBladeProj>();
			Item.shootSpeed = 6f;
			Item.autoReuse = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//create velocity vectors for the projectiles
			float speedX = velocity.X;
			float speedY = velocity.Y;
			Vector2 newVect = velocity.RotatedBy(System.Math.PI / Main.rand.Next(18, 22));
			Vector2 newVect2 = velocity.RotatedBy(-System.Math.PI / Main.rand.Next(18, 22));
			Vector2 newVect3 = velocity.RotatedBy(System.Math.PI / Main.rand.Next(8, 12));
			Vector2 newVect4 = velocity.RotatedBy(-System.Math.PI / Main.rand.Next(8, 12));

			//create projectiles
			Projectile.NewProjectile(source, position.X, position.Y - 20, speedX + ((float)Main.rand.Next(-300, 300) / 100), speedY + ((float)Main.rand.Next(-300, 300) / 100), ModContent.ProjectileType<CrystiliumBladeProj>(), damage / 3, knockback, player.whoAmI, 0, 0);
			Projectile.NewProjectile(source, position.X, position.Y - 20, newVect.X + ((float)Main.rand.Next(-300, 300) / 100), newVect.Y + ((float)Main.rand.Next(-300, 300) / 100), ModContent.ProjectileType<CrystiliumBladeProj>(), damage / 3, knockback, player.whoAmI, 0, 0);
			Projectile.NewProjectile(source, position.X, position.Y - 20, newVect2.X + ((float)Main.rand.Next(-300, 300) / 100), newVect2.Y + ((float)Main.rand.Next(-300, 300) / 100), ModContent.ProjectileType<CrystiliumBladeProj>(), damage / 3, knockback, player.whoAmI, 0, 0);
			Projectile.NewProjectile(source, position.X, position.Y - 20, newVect3.X + ((float)Main.rand.Next(-300, 300) / 100), newVect3.Y + ((float)Main.rand.Next(-300, 300) / 100), ModContent.ProjectileType<CrystiliumBladeProj>(), damage / 3, knockback, player.whoAmI, 0, 0);
			Projectile.NewProjectile(source, position.X, position.Y - 20, newVect4.X + ((float)Main.rand.Next(-300, 300) / 100), newVect4.Y + ((float)Main.rand.Next(-300, 300) / 100), ModContent.ProjectileType<CrystiliumBladeProj>(), damage / 3, knockback, player.whoAmI, 0, 0);
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			for (int J = 1; J < 3; J++)
			{
				Vector2 vel = new(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				/*		int proj = Projectile.NewProjectile(projectile.Center.X, item.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter"+(1+Main.rand.Next(0,3))), item.damage / 4, 0, Main.myPlayer); */
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<CrystiliumBar>(), 19);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}