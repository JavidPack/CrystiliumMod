using CrystiliumMod.Core.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Buffs
{
	public class Dustbreak : CrystiliumBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dustbreak");
			// Description.SetDefault("+20% critical strike damage");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			LongerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<CrystalPlayer>().critDmgMult += 0.2f;
		}
	}
}