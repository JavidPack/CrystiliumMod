using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class CrystProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryst");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 9;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.penetrate = 600;
			Projectile.tileCollide = false;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.timeLeft = 1400;
			Projectile.damage = 13;
			Projectile.extraUpdates = 1;
			Projectile.light = 2;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			for (int k = 0; k < 15; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustType<Dusts.Sparkle>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
			}
		}

		public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustType<Dusts.Sparkle>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
			}
			Projectile.rotation += 0.1f;
			//Making player variable "p" set as the projectile's owner
			Player player = Main.player[Projectile.owner];

			//Factors for calculations
			double deg = (double)Projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
			double rad = deg * (Math.PI / 180); //Convert degrees to radians
			double dist = 140; //Distance away from the player

			/*Position the projectile based on where the player is, the Sin/Cos of the angle times the /
	 		/distance for the desired distance away from the player minus the projectile's width	/
	 		/and height divided by two so the center of the projectile is at the right place.	  */
			Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
			Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;

			//Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
			Projectile.ai[1] += 2f;
		}
	}
}