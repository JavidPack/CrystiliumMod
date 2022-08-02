using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class RPC : ModProjectile
	{
		public override string Texture => "CrystiliumMod/Projectiles/RPC1";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rocket Propelled Crystal");
			Main.projFrames[Projectile.type] = 4; //redundant, since using custom drawing anyway
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.RocketI);
			Projectile.width = 14;
			Projectile.height = 22;
			Projectile.aiStyle = 34;  //rocket AI
		}

		//Handles custom drawing for the projectile. Simplifies things a lot. Who needs three separate RPCs anyway?
		//Note: projectile.ai[1] contains the type of projectile. 0=blue, 1=purple, 2=pink
		public override bool PreDraw(ref Color lightColor)
		{
			if (++Projectile.frameCounter % 2 == 0) Projectile.frame++;
			if (Projectile.frame >= 4) Projectile.frame = 0;
			string tex = "Projectiles/RPC" + (int)(Projectile.ai[1] + 1);
			spriteBatch.Draw(Mod.GetTexture(tex), Projectile.Center - Main.screenPosition, new Rectangle(0, Projectile.height * Projectile.frame, Projectile.width, Projectile.height), lightColor, Projectile.rotation, new Vector2(Projectile.width / 2, Projectile.height / 2), Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item27, Projectile.Center);

			//Make shards! Twice as many if type 0 (blue).
			int numShards = 15;
			if (Projectile.ai[1] == 0) numShards *= 2;
			for (int h = 0; h < numShards; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y + 20, vel.X, vel.Y, Mod.Find<ModProjectile>("Shatter" + (1 + Main.rand.Next(0, 3))).Type, Projectile.damage - 8, 0, Main.myPlayer);
			}
		}
	}
}