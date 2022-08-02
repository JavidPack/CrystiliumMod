using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class NebulaShard : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 36;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.light = 0.75f;
			Projectile.penetrate = 25;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 15; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("NebulaDust").Type, (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
			}
		}

		public override void AI()
		{
			float rotationSpeed = (float)Math.PI / 15;
			Projectile.rotation += rotationSpeed;
			//Only do thing on the controller's client perspective
			if (Main.myPlayer == Projectile.owner)
			{
				//Do net updatey thing. Syncs this projectile.
				Projectile.netUpdate = true;

				float maxVelocity = 6.5f; //maximum velocity projectile can approach cursor
										  //only do this stuff if player is actively channeling
				if (Main.player[Projectile.owner].channel)
				{
					Main.player[Projectile.owner].itemTime = 2;
					Main.player[Projectile.owner].itemAnimation = 2;

					//move towards cursor
					Projectile.velocity = Projectile.DirectionTo(Main.MouseWorld) * maxVelocity;
					float distToMouse = Projectile.Distance(Main.MouseWorld);

					//slows down projectile when getting close to cursor
					if (distToMouse <= maxVelocity * 3)
					{
						Projectile.velocity *= distToMouse / (distToMouse + maxVelocity / 2);
					}
				}
				else
				{
					Projectile.Kill(); //kill projectile if no longer channeling
				}
			}
		}
	}
}