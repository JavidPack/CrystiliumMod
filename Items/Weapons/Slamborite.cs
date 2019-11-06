using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Slamborite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slamborite");
			Tooltip.SetDefault("Drops gemstones");
		}

		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 10;
			item.value = 100000;
			item.rare = 7;

			item.noMelee = true; // Makes sure that the animation when using the item doesn't hurt NPCs.
			item.useStyle = 5; // Set the correct useStyle.
			item.useAnimation = 40; // Determines how long the animation lasts.
			item.useTime = 40; // Determines how fast you can use this weapon (a lower value results in a faster use time).
			item.knockBack = 7.5F;
			item.damage = 85;
			item.noUseGraphic = true; // Do not use the item graphic when using the item (we just want the ball to spawn).
			item.shoot = ProjectileType<Projectiles.SlamboriteProj>();
			item.shootSpeed = 15.1F;
			item.UseSound = SoundID.Item1;
			item.melee = true; // Deals melee damage.
			item.channel = true; // We can keep the left mouse button down when trying to keep using this weapon.
		}
	}
}