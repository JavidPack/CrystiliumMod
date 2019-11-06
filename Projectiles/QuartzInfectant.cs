using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class QuartzInfectant : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Infectant");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.damage = 38;// Main.rand.Next(1);
			projectile.scale = 1.1f;
			projectile.aiStyle = 24;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.ownerHitCheck = false;
			projectile.melee = true;
			projectile.timeLeft = 25;
			projectile.hide = false;
			projectile.whoAmI = Main.myPlayer;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffType<Buffs.QuartzDisease>(), 500);
		}
	}
}