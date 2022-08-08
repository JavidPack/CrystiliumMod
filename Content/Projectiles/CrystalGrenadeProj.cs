using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Projectiles
{
	public class CrystalGrenadeProj : ModProjectile
	{
		public override string Texture => "CrystiliumMod/Content/Items/Weapons/CrystalGrenade";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Grenade");
		}
		private int oldDamage = 0;
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Grenade);
			Projectile.timeLeft = 120;
			Projectile.width = 26;
            Projectile.height = 28;
		}

        public override void OnSpawn(IEntitySource source)
        {
			oldDamage = Projectile.damage;
		}

        public override bool PreAI()
        {
			Projectile.damage = oldDamage;
			return true;
        }

        public override void Kill(int timeLeft)
		{
			Projectile.hostile = true;
			Projectile.friendly = true;
			SoundEngine.PlaySound(SoundID.Item27, Projectile.position);
			for (int h = 0; h < 25; h++)
			{
				Vector2 vel = new(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 5f;
				int proj = Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.Center.X, Projectile.Center.Y + 20, vel.X, vel.Y, Mod.Find<ModProjectile>("Shatter" + (1 + Main.rand.Next(0, 3))).Type, (int)(oldDamage * .425), 0, Main.myPlayer);
				Main.projectile[proj].friendly = true;
				Main.projectile[proj].hostile = true;
			}
			Main.NewText(oldDamage);
		}
	}
}