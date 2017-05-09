using System;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class VortexPortal : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Vortex Portal"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 60; //Set the hitbox width
			projectile.height = 60; //Set the hitbox height
			projectile.timeLeft = 110; //The amount of time the projectile is alive for
			projectile.penetrate = 10; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = false; //Tells the game whether it is friendly to players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to players or not
			projectile.light = 0.75f;
			projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			Main.projFrames[projectile.type] = 4;
		}

		//How the projectile works
		//AI VALUES: 0 - timer | 1 - unused
		public override void AI()
		{
			float rotationSpeed = (float)Math.PI / 15;
			projectile.rotation += rotationSpeed;
			if (projectile.timeLeft == 110 || projectile.timeLeft <= 1)
			{
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("VortexDust"), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}

			if (++projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 4;
			}

			projectile.velocity.X = 0;
			projectile.velocity.Y = 0;
			projectile.ai[0]++;
			if (projectile.ai[0] % 6 == 0 && projectile.timeLeft < 50)
			{
				if (Main.myPlayer == projectile.owner)
				{
					projectile.netUpdate = true;
					float dirX = Main.MouseWorld.X - projectile.position.X;
					float dirY = Main.MouseWorld.Y - projectile.position.Y;

					float s = 15f;

					float factor = s / (float)Math.Sqrt(Math.Pow(dirX, 2) + Math.Pow(dirY, 2));

					float velX = dirX * factor;
					float velY = dirY * factor;
					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 13);
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velX, velY, mod.ProjectileType<VortexCrystal>(), projectile.damage + 1, 0, projectile.owner);
				}
			}
		}

		//public override bool OnTileCollide(Vector2 oldVelocity)
		//{
		//    projectile.velocity.X = 0f;
		//    projectile.velocity.Y = 0f;
		//    return false;
		//}
	}
}