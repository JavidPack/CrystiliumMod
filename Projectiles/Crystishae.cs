using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Projectiles
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
			projectile.CloneDefaults(ProjectileID.ThornChakram);
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