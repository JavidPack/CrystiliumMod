using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles.ShatterGems
{
	public class GemstoneFlailProj : ModProjectile
	{
		public override string Texture => "CrystiliumMod/Content/Projectiles/ShatterGems/GemstoneFlail1";

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Grenade);
			Projectile.penetrate = 1;
			Projectile.alpha = 80;
			AIType = ProjectileID.Grenade;
			Projectile.light = 0.5f;
		}

		//Changes draw texture based on AI value, set at creation. Removes disgusting duplicate projectiles.
		public override bool PreDraw(ref Color lightColor)
		{
			string texName = "CrystiliumMod/Content/Projectiles/ShatterGems/GemstoneFlail" + Projectile.ai[1];
			Texture2D texture = ModContent.Request<Texture2D>(texName).Value;
			Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, new Rectangle(0, 0, texture.Width, texture.Height), lightColor, Projectile.rotation, new Vector2((float)texture.Width / 2, (float)texture.Height / 2), Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
				Projectile.Kill();
			}
			else
			{
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
				SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			}
			return false;
		}
	}
}