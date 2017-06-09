using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Buffs
{
	public class MarbleBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Marble Aura");
			Description.SetDefault("Light as a feather");
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