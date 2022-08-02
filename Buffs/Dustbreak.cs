using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Buffs
{
	public class Dustbreak : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dustbreak");
			Description.SetDefault("+20% critical strike damage");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<CrystalPlayer>().critDmgMult += 0.2f;
		}
	}
}