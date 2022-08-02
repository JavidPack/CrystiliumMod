using CrystiliumMod.Core.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Buffs
{
	public class Twilight : CrystiliumBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight");
			Description.SetDefault("+7% damage at night");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			LongerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (Main.dayTime == false)
			{
				player.GetDamage(DamageClass.Throwing) *= 1.07f;
				player.GetDamage(DamageClass.Melee) *= 1.07f;
				player.GetDamage(DamageClass.Magic) *= 1.07f;
				player.GetDamage(DamageClass.Summon) *= 1.07f;
				player.GetDamage(DamageClass.Ranged) *= 1.07f;
			}
		}
	}
}