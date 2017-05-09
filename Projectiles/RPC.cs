using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class RPC : ModProjectile
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "CrystiliumMod/Projectiles/RPC1";
			return true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.RocketI);
			projectile.name = "Rocket Propelled Crystal";
			projectile.width = 14;
			projectile.height = 22;
			projectile.aiStyle = 34;  //rocket AI
			Main.projFrames[projectile.type] = 4; //redundant, since using custom drawing anyway
		}

		//Handles custom drawing for the projectile. Simplifies things a lot. Who needs three separate RPCs anyway?
		//Note: projectile.ai[1] contains the type of projectile. 0=blue, 1=purple, 2=pink
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			if (++projectile.frameCounter % 2 == 0) projectile.frame++;
			if (projectile.frame >= 4) projectile.frame = 0;
			string tex = "Projectiles/RPC" + (int)(projectile.ai[1] + 1);
			spriteBatch.Draw(mod.GetTexture(tex), projectile.Center - Main.screenPosition, new Rectangle(0, projectile.height * projectile.frame, projectile.width, projectile.height), lightColor, projectile.rotation, new Vector2(projectile.width / 2, projectile.height / 2), projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, projectile.Center, 27);

			//Make shards! Twice as many if type 0 (blue).
			int numShards = 15;
			if (projectile.ai[1] == 0) numShards *= 2;
			for (int h = 0; h < numShards; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Shatter" + (1 + Main.rand.Next(0, 3))), projectile.damage - 8, 0, Main.myPlayer);
			}
		}
	}
}