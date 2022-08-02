using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class SapphirePortal : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sapphire Portal");
			Main.projFrames[Projectile.type] = 2;
		}

		public override void SetDefaults()
		{
			Projectile.width = 60; //Set the hitbox width
			Projectile.height = 60; //Set the hitbox height
			Projectile.timeLeft = 1300; //The amount of time the projectile is alive for
			Projectile.penetrate = 10; //Tells the game how many enemies it can hit before being destroyed
			Projectile.light = 0.75f;
			Projectile.friendly = false; //Tells the game whether it is friendly to players/friendly npcs or not
			Projectile.hostile = false; //Tells the game whether it is hostile to players or not
			Projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			Projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
		}

		//How the projectile works
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 15; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("SapphireDust").Type, (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
			}
		}

		public override void AI()
		{
			float rotationSpeed = (float)Math.PI / 15;
			Projectile.rotation += rotationSpeed;
			if (Projectile.timeLeft == 1300)
			{
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("SapphireDust").Type, (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 8)
			{
				Projectile.frameCounter = 0;
				Projectile.frame = (Projectile.frame + 1) % 2;
			}
			Projectile.velocity.X = 0;
			Projectile.velocity.Y = 0;
			if (Main.myPlayer == Projectile.owner)
			{
				//Do net updatey thing. Syncs this projectile.
				Projectile.netUpdate = true;
				if (Main.rand.Next(25) == 0)
				{
					float dirX = Main.MouseWorld.X - Projectile.position.X;
					float dirY = Main.MouseWorld.Y - Projectile.position.Y;

					float s = 15f;

					float factor = s / (float)Math.Sqrt(Math.Pow(dirX, 2) + Math.Pow(dirY, 2));

					float velX = dirX * factor;
					float velY = dirY * factor;
					Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, velX, velY, ProjectileType<SapphireSpike>(), Projectile.damage + 4, 0, Main.myPlayer);
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