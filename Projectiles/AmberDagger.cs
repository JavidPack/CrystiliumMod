using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class AmberDagger : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Dagger");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 9;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 7;
			Projectile.height = 14;
			Projectile.aiStyle = 113;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 600;
			Projectile.alpha = 255;
			Projectile.extraUpdates = 1;
			Projectile.light = 0;
			AIType = ProjectileID.ThrowingKnife;
		}

		/* public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		 {
			 target.AddBuff(BuffType<Cut>(), 500);
		 } */

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