using CrystiliumMod.Core.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Buffs
{
	public class ThrowingBoost : CrystiliumBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Throwing Boost");
			// Description.SetDefault("+10% throwing damage");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			LongerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Throwing) *= 1.1f;
		}
	}
}