using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles.TrueGems
{
	public class TerraGemProj : ModProjectile
	{
		public override string Texture => "CrystiliumMod/Content/Projectiles/TrueGems/TrueGem1";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True gem");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(82);
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.friendly = true;
			Projectile.damage = 10;
			Projectile.light = 0.5f;
		}

		//Removes the need for separate projectiles by using custom drawing for all variants
		//public override bool PreDraw (SpriteBatch spriteBatch, Color lightColor)
		//{
		//}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			}
			for (int i = 0; i < 3; i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("CrystalDust").Type, (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
				SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
				for (int i = 0; i < 15; i++)
				{
					Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, Mod.Find<ModDust>("CrystalDust").Type, (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Vector2 drawOrigin = new(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			}

			string texName = "CrystiliumMod/Content/Projectiles/TrueGems/TrueGem" + Projectile.ai[1];
			Texture2D texture = ModContent.Request<Texture2D>(texName).Value;
			Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, new Rectangle(0, 0, texture.Width, texture.Height), lightColor, Projectile.rotation, new Vector2((float)texture.Width / 2, (float)texture.Height / 2), Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}