using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class AmberBlade : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Blade");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.tileCollide = false;
			projectile.penetrate = 600;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.damage = 12;
			projectile.timeLeft = 120;
			projectile.extraUpdates = 1;
			projectile.light = 1;
		}

		/* public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		 {
			 target.AddBuff(BuffType<Cut>(), 500);
		 } */

		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
				projectile.rotation += 0.3f;
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
			}
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}

		//public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		//{
		//	 Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
		//	 for (int k = 0; k < projectile.oldPos.Length; k++)
		//	 {
		//		  Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
		//		  Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
		//		  spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
		//	 }
		//	 return true;
		//}
	}
}