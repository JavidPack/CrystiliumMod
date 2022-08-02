using CrystiliumMod.Core.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Buffs
{
	public class CrystalLeak : CrystiliumBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Leak");
			Description.SetDefault("Creates dangerous crystals");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			LongerExpertDebuff = false;
		}

		private float ticks = 0f;

		public override void Update(Player player, ref int buffIndex)
		{
			if (++ticks >= 6f)
			{
				ticks = 0f;
				Projectile.NewProjectile(player.GetSource_Buff(buffIndex), (player.Center.X - 125) + Main.rand.Next(250), (player.Center.Y - 125) + Main.rand.Next(250), 0f, 0f, Mod.Find<ModProjectile>("Shatter" + (1 + Main.rand.Next(0, 3))).Type, 14, 0, Main.myPlayer);
			}
		}
	}
}