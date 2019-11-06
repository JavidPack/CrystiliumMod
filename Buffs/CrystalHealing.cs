using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Buffs
{
	public class CrystalHealing : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Crystal Healing");
			Description.SetDefault("I feel refreshed!");
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