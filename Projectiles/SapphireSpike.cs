using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Projectiles
{
	public class SapphireSpike : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Staff Spike");
		}

		public override void SetDefaults()
		{
			Projectile.width = 18; //Set the hitbox width
			Projectile.height = 18; //Set the hitbox height
			Projectile.aiStyle = 45;
			Projectile.damage = 5;
			Projectile.timeLeft = 600; //The amount of time the projectile is alive for
			Projectile.penetrate = 1; //Tells the game how many enemies it can hit before being destroyed
			Projectile.friendly = true; //Tells the game whether it is friendly to players/friendly npcs or not
			Projectile.hostile = false; //Tells the game whether it is hostile to players or not
			Projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
			Projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
		}

		//How the projectile works
		public override void AI()
		{
			Projectile.AngleTo(Main.MouseWorld);
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 6; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 33, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
			}
		}

		/*	public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
			{
				target.AddBuff(Terraria.ID.BuffID.Chilled, 300);
			}*/
	}
}