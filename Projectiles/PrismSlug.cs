using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class PrismSlug : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Prism Bolt"; //Name of the projectile, only shows this if you get killed by it
			projectile.width = 8;
			projectile.height = 48;
			projectile.timeLeft = 600; //The amount of time the projectile is alive for
			projectile.penetrate = 4; //Tells the game how many enemies it can hit before being destroyed
			projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			projectile.hostile = false; //Tells the game whether it is hostile to players or not
			projectile.light = 0.75f;
			projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
			Main.projFrames[projectile.type] = 7;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				for (int k = 0; k < 6; k++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CrystalDust"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				}
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			}
			return false;
		}

		//How the projectile works
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CrystalDust"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CrystalDust"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 7;
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