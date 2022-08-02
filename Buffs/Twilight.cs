using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Buffs
{
	public class Twilight : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Twilight");
			Description.SetDefault("+7% damage at night");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
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