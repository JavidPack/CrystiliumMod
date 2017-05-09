using CrystiliumMod.Projectiles;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Buffs
{
	public class QuartzDisease : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Quartz Disease";
			Main.buffTip[Type] = "'Keter.'";
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		private float ticks = 0f;

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (++ticks >= 4f)
			{
				ticks = 0f;
				int random = Main.rand.Next(2);
				if (random == 1)
				{
					Projectile.NewProjectile((npc.Center.X - 100) + Main.rand.Next(200), (npc.Center.Y - 100) + Main.rand.Next(200), 0f, 0f, mod.ProjectileType<QuartzInfectant>(), 24/* this is damage */, 0, Main.myPlayer);
					Projectile.NewProjectile((npc.Center.X - 100) + Main.rand.Next(200), (npc.Center.Y - 100) + Main.rand.Next(200), 0f, 0f, mod.ProjectileType<QuartzInfectant>(), 24/* this is damage */, 0, Main.myPlayer);
					Projectile.NewProjectile((npc.Center.X - 100) + Main.rand.Next(200), (npc.Center.Y - 100) + Main.rand.Next(200), 0f, 0f, mod.ProjectileType<QuartzInfectant>(), 24/* this is damage */, 0, Main.myPlayer);
				}
			}
		}
	}
}