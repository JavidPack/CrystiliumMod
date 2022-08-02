using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Buffs
{
	public class ThrowingBoost : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Throwing Boost");
			Description.SetDefault("+10% throwing damage");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Throwing) *= 1.1f;
		}
	}
}