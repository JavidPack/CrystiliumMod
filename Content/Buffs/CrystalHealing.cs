using CrystiliumMod.Core.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Buffs
{
	public class CrystalHealing : CrystiliumBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Healing");
			// Description.SetDefault("I feel refreshed!");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			LongerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen += 16;
		}
	}
}