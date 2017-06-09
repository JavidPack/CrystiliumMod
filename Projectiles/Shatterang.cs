using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class ShatterangProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shatterang");
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.magic = false;
			projectile.penetrate = 10;
			projectile.timeLeft = 600;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int h = 0; h < 22; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter" + (1 + Main.rand.Next(0, 3))), projectile.damage / 3, 0, Main.myPlayer);
			}
		}
	}
}