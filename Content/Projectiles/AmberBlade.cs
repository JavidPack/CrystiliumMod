using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class AmberBlade : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Blade");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 9;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.tileCollide = false;
			Projectile.penetrate = 600;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.damage = 12;
			Projectile.timeLeft = 120;
			Projectile.extraUpdates = 1;
			Projectile.light = 1;
		}

		/* public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		 {
			 target.AddBuff(BuffType<Cut>(), 500);
		 } */

		public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
				Projectile.rotation += 0.3f;
			}
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			}
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
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