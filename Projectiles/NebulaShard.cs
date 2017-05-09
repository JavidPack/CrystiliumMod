using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class NebulaShard : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Nebula Shard";
			projectile.width = 14;
			projectile.height = 36;
			projectile.friendly = true;
			projectile.magic = true;
            projectile.light = 0.75f;
            projectile.penetrate = 25;
		}
        public override void Kill(int timeLeft)
        {
            for (int I = 0; I < 15; I++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("NebulaDust"), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
            }
        }

        public override void AI()
		{
            float rotationSpeed = (float)Math.PI / 15;
            projectile.rotation += rotationSpeed;
            //Only do thing on the controller's client perspective
            if (Main.myPlayer == projectile.owner) {
				//Do net updatey thing. Syncs this projectile.
				projectile.netUpdate = true;

				float maxVelocity = 6.5f; //maximum velocity projectile can approach cursor
				//only do this stuff if player is actively channeling
				if(Main.player[projectile.owner].channel) {
					Main.player[projectile.owner].itemTime = 2;
					Main.player[projectile.owner].itemAnimation = 2;

					//move towards cursor
					projectile.velocity = projectile.DirectionTo(Main.MouseWorld) * maxVelocity;
					float distToMouse = projectile.Distance(Main.MouseWorld);

					//slows down projectile when getting close to cursor
					if(distToMouse <= maxVelocity * 3) {
						projectile.velocity *= distToMouse / (distToMouse + maxVelocity / 2);
					}
				} else {
                    projectile.Kill(); //kill projectile if no longer channeling
				}
			}
		}
	}
}