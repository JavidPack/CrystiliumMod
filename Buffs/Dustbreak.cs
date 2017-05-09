using System;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using CrystiliumMod.NPCs;

namespace CrystiliumMod.Buffs
{
    public class Dustbreak : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Dustbreak";
            Main.buffTip[Type] = "+20% critical strike damage";
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            longerExpertDebuff = false;
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<CrystalPlayer>(mod).critDmgMult += 0.2f;
		}
    }
}
