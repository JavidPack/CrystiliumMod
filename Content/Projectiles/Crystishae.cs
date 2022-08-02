using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class Crystishae : ModProjectile
	{
		public override string Texture => "CrystiliumMod/Items/Weapons/Crystishae";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystishae");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ThornChakram);
		}

		public override bool PreAI()
		{
			if (Main.myPlayer == Projectile.owner)
			{
				Projectile.netUpdate = true;
			}
			return true;
		}
	}
}