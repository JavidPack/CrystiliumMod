using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Buffs
{
	public class Twilight : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Twilight");
			Description.SetDefault("+7% damage at night");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (Main.dayTime == false)
			{
				player.thrownDamage *= 1.07f;
				player.meleeDamage *= 1.07f;
				player.magicDamage *= 1.07f;
				player.minionDamage *= 1.07f;
				player.rangedDamage *= 1.07f;
			}
		}
	}
}