using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using CrystiliumMod.NPCs;

namespace CrystiliumMod.Buffs
{
	public class ThrowingBoost : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Throwing Boost";
			Main.buffTip[Type] = "+10% throwing damage";
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.thrownDamage *= 1.1f;
		}
	}
}
