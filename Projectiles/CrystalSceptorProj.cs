using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class CrystalSceptorProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("GemFire");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(82);
			projectile.hostile = false;
			projectile.magic = true;
			projectile.width = 28;
			projectile.penetrate = 3;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.damage = 10;
			projectile.light = 0.5f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			}
			for (int i = 0; i < 3; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("EtherealFlame"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("EtherealFlame"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
			}
		}

		public override void AI()
		{
			Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("EtherealFlame"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("EtherealFlame"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("EtherealFlame"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}