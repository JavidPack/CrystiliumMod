using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
	public class PrismSlug : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism Bolt");
			Main.projFrames[Projectile.type] = 7;
		}

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 48;
			Projectile.timeLeft = 600; //The amount of time the projectile is alive for
			Projectile.penetrate = 4; //Tells the game how many enemies it can hit before being destroyed
			Projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			Projectile.hostile = false; //Tells the game whether it is hostile to players or not
			Projectile.light = 0.75f;
			Projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				for (int k = 0; k < 6; k++)
				{
					Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("CrystalDust").Type, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
				}
			}
			else
			{
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}
			return false;
		}

		//How the projectile works
		public override void AI()
		{
			Projectile.rotation = Projectile.velocity.ToRotation() + 1.57f;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 8)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("CrystalDust").Type, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("CrystalDust").Type, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
				Projectile.frameCounter = 0;
				Projectile.frame = (Projectile.frame + 1) % 7;
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