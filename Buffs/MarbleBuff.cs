using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using CrystiliumMod.NPCs;

namespace CrystiliumMod.Buffs
{
	public class MarbleBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Marble Aura";
			Main.buffTip[Type] = "Light as a feather";
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense -= 10;
			player.moveSpeed *= 1.45f;

		}
	}
}
