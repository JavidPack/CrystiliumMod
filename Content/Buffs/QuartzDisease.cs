using CrystiliumMod.Content.Projectiles;
using CrystiliumMod.Core.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Buffs
{
	public class QuartzDisease : CrystiliumBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quartz Disease");
			Description.SetDefault("'Keter.'");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			LongerExpertDebuff = true;
		}

		private float ticks = 0f;

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (++ticks >= 4f)
			{
				ticks = 0f;
				if (!Main.rand.NextBool(2)) return;
				Projectile.NewProjectile(npc.GetSource_Buff(buffIndex), (npc.Center.X - 100) + Main.rand.Next(200), (npc.Center.Y - 100) + Main.rand.Next(200), 0f, 0f, ModContent.ProjectileType<QuartzInfectant>(), 24/* this is damage */, 0, Main.myPlayer);
				Projectile.NewProjectile(npc.GetSource_Buff(buffIndex), (npc.Center.X - 100) + Main.rand.Next(200), (npc.Center.Y - 100) + Main.rand.Next(200), 0f, 0f, ModContent.ProjectileType<QuartzInfectant>(), 24/* this is damage */, 0, Main.myPlayer);
				Projectile.NewProjectile(npc.GetSource_Buff(buffIndex), (npc.Center.X - 100) + Main.rand.Next(200), (npc.Center.Y - 100) + Main.rand.Next(200), 0f, 0f, ModContent.ProjectileType<QuartzInfectant>(), 24/* this is damage */, 0, Main.myPlayer);
			}
		}
	}
}