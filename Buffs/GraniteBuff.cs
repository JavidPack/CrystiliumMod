using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Buffs
{
	public class GraniteBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Granite Skin");
			Description.SetDefault("Hard as a rock");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 12;
			player.moveSpeed *= 0.55f;
		}
	}
}