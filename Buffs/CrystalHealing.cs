using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using CrystiliumMod.NPCs;

namespace CrystiliumMod.Buffs
{
	public class CrystalHealing : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Crystal Healing";
			Main.buffTip[Type] = "I feel refreshed!";
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff = false;
		}
        
		public override void Update(Player player, ref int buffIndex)
		{
            player.lifeRegen += 16;
		}
	}
}
