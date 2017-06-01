using System;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class SapphirePortal : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Sapphire Portal"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 60; //Set the hitbox width
			projectile.height = 60; //Set the hitbox height
			projectile.timeLeft = 1300; //The amount of time the projectile is alive for
			projectile.penetrate = 10; //Tells the game how many enemies it can hit before being destroyed
			projectile.light = 0.75f;
			projectile.friendly = false; //Tells the game whether it is friendly to players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to players or not
			projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			Main.projFrames[projectile.type] = 2;
		}

		//How the projectile works
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 15; i++)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("SapphireDust"), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
			}
		}

		public override void AI()
		{
			float rotationSpeed = (float)Math.PI / 15;
			projectile.rotation += rotationSpeed;
			if (projectile.timeLeft == 1300)
			{
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("SapphireDust"), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 2;
			}
			projectile.velocity.X = 0;
			projectile.velocity.Y = 0;
			if (Main.myPlayer == projectile.owner)
			{
				//Do net updatey thing. Syncs this projectile.
				projectile.netUpdate = true;
				if (Main.rand.Next(25) == 0)
				{
					float dirX = Main.MouseWorld.X - projectile.position.X;
					float dirY = Main.MouseWorld.Y - projectile.position.Y;

					float s = 15f;

					float factor = s / (float)Math.Sqrt(Math.Pow(dirX, 2) + Math.Pow(dirY, 2));

					float velX = dirX * factor;
					float velY = dirY * factor;
					Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, velX, velY, mod.ProjectileType<SapphireSpike>(), projectile.damage + 4, 0, Main.myPlayer);
				}
			}
		}

		//public override bool OnTileCollide(Vector2 oldVelocity)
		//{
		//	 projectile.velocity.X = 0f;
		//	 projectile.velocity.Y = 0f;
		//	 return false;
		//}
	}
}