using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class PrismBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prism Blade");
			Tooltip.SetDefault("Consumes life.");
		}

		public override void SetDefaults()
		{
			item.damage = 277;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool UseItem(Player player)
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