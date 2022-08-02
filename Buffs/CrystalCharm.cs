using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Buffs
{
	public class CrystalCharm : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Resonance");
			Description.SetDefault("+1% magic damage");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			//Increase magic damage based on current stacks
			player.GetDamage(DamageClass.Magic) *= (float)(1 + (player.GetModPlayer<CrystalPlayer>().crystalCharmStacks * .01));
		}

		public override void ModifyBuffTip(ref string tip, ref int rare)
		{
			//Use of myPlayer is OK, as buff tips are not visible by other players
			tip = "+" + Main.LocalPlayer.GetModPlayer<CrystalPlayer>().crystalCharmStacks + "% magic damage";
		}
	}
}