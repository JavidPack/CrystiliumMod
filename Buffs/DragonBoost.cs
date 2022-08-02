using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Buffs
{
	public class DragonFury : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Fury");
			Description.SetDefault("'RYUUGAWA GA TEKI WO KURAU'");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetDamage(DamageClass.Throwing) *= 4;
			player.GetDamage(DamageClass.Magic) *= 4;
			player.GetDamage(DamageClass.Summon) *= 4;
			player.GetDamage(DamageClass.Melee) *= 4;
			player.GetDamage(DamageClass.Ranged) *= 4;
		}
	}
}