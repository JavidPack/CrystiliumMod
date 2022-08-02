using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class VortexPortal : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex Portal");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.width = 60; //Set the hitbox width
			Projectile.height = 60; //Set the hitbox height
			Projectile.timeLeft = 110; //The amount of time the projectile is alive for
			Projectile.penetrate = 10; //Tells the game how many enemies it can hit before being destroyed
			Projectile.friendly = false; //Tells the game whether it is friendly to players/friendly npcs or not
			Projectile.hostile = false; //Tells the game whether it is hostile to players or not
			Projectile.light = 0.75f;
			Projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
			Projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
		}

		//How the projectile works
		//AI VALUES: 0 - timer | 1 - unused
		public override void AI()
		{
			float rotationSpeed = (float)Math.PI / 15;
			Projectile.rotation += rotationSpeed;
			if (Projectile.timeLeft == 110 || Projectile.timeLeft <= 1)
			{
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("VortexDust").Type, (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 0);
				}
			}

			if (++Projectile.frameCounter >= 8)
			{
				Projectile.frameCounter = 0;
				Projectile.frame = (Projectile.frame + 1) % 4;
			}

			Projectile.velocity.X = 0;
			Projectile.velocity.Y = 0;
			Projectile.ai[0]++;
			if (Projectile.ai[0] % 6 == 0 && Projectile.timeLeft < 50)
			{
				if (Main.myPlayer == Projectile.owner)
				{
					Projectile.netUpdate = true;
					float dirX = Main.MouseWorld.X - Projectile.position.X;
					float dirY = Main.MouseWorld.Y - Projectile.position.Y;

					float s = 15f;

					float factor = s / (float)Math.Sqrt(Math.Pow(dirX, 2) + Math.Pow(dirY, 2));

					float velX = dirX * factor;
					float velY = dirY * factor;
					SoundEngine.PlaySound(SoundID.Item13, Projectile.position);
					Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, velX, velY, ModContent.ProjectileType<VortexCrystal>(), Projectile.damage + 1, 0, Projectile.owner);
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