using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class QuartzBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Blade");
			Tooltip.SetDefault("Launches tridents");
		}

		public override void SetDefaults()
		{
			Item.damage = 54;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 80000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<QuartzTrident>();
			Item.shootSpeed = 6f;
			Item.autoReuse = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//create velocity vectors for the two angled projectiles (outwards at PI/6 radians, or 15 degrees)
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / 20);
			Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 20);

			//create three Crystishae projectiles
			Projectile.NewProjectile(player.Center.X, player.Center.Y - 20, speedX, speedY, ProjectileType<QuartzTrident>(), damage, knockBack, Item.playerIndexTheItemIsReservedFor, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y - 20, newVect.X, newVect.Y, ProjectileType<QuartzTrident>(), damage, knockBack, Item.playerIndexTheItemIsReservedFor, 0, 0);
			Projectile.NewProjectile(player.Center.X, player.Center.Y - 20, newVect2.X, newVect2.Y, ProjectileType<QuartzTrident>(), damage, knockBack, Item.playerIndexTheItemIsReservedFor, 0, 0);
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			for (int J = 1; J < 3; J++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				/*		int proj = Projectile.NewProjectile(projectile.Center.X, item.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter"+(1+Main.rand.Next(0,3))), item.damage / 4, 0, Main.myPlayer); */
			}
		}
	}
}