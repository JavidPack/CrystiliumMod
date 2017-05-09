using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using CrystiliumMod.NPCs;

namespace CrystiliumMod.Buffs
{
	public class DragonFury : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Dragon Fury";
			Main.buffTip[Type] = "'RYUUGAWA GA TEKI WO KURAU'";
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.thrownDamage *= 4;
			player.magicDamage *= 4;
			player.minionDamage *= 4;
			player.meleeDamage *= 4;
			player.rangedDamage *= 4;
		}
	}
}
