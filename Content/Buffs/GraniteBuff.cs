using CrystiliumMod.Core.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Buffs
{
	public class GraniteBuff : CrystiliumBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Skin");
			Description.SetDefault("Hard as a rock");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			LongerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += 12;
			player.moveSpeed *= 0.55f;
		}
	}
}