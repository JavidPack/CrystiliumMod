using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
{
	public class Crystishae : ModProjectile
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "CrystiliumMod/Items/Weapons/Crystishae";
			return true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ThornChakram);
			projectile.name = "Crystishae";
		}

		public override bool PreAI()
		{
			if (Main.myPlayer == projectile.owner)
			{
				projectile.netUpdate = true;
			}
			return true;
		}
	}
}