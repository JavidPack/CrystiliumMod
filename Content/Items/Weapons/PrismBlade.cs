using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class PrismBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Prism Blade");
			// Tooltip.SetDefault("Consumes life.");
		}

		public override void SetDefaults()
		{
			Item.damage = 277;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			for (int J = 1; J < 20; J++)
			{
				player.statLife--;
			}
			if (player.statLife <= 0)
			{
				//Main.player[item.owner].KillMe(9999, 1, true, " sacrificed too much");
			}
			return true;
		}
	}
}