using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class QuartzInfectant : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Infectant");
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.damage = 38;// Main.rand.Next(1);
			Projectile.scale = 1.1f;
			Projectile.aiStyle = 24;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = true;
			Projectile.penetrate = 1;
			Projectile.ownerHitCheck = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 25;
			Projectile.hide = false;
			Projectile.whoAmI = Main.myPlayer;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<Buffs.QuartzDisease>(), 500);
		}
	}
}