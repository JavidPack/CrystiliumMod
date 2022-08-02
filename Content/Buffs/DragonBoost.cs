using CrystiliumMod.Core.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Buffs
{
	public class DragonFury : CrystiliumBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Fury");
			Description.SetDefault("'RYUUGAWA GA TEKI WO KURAU'");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			LongerExpertDebuff = false;
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