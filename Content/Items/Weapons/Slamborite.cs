using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class Slamborite : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Slamborite");
			// Tooltip.SetDefault("Drops gemstones");
		}

		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 10;
			Item.value = 100000;
			Item.rare = 7;

			Item.noMelee = true; // Makes sure that the animation when using the item doesn't hurt NPCs.
			Item.useStyle = 5; // Set the correct useStyle.
			Item.useAnimation = 40; // Determines how long the animation lasts.
			Item.useTime = 40; // Determines how fast you can use this weapon (a lower value results in a faster use time).
			Item.knockBack = 7.5F;
			Item.damage = 85;
			Item.noUseGraphic = true; // Do not use the item graphic when using the item (we just want the ball to spawn).
			Item.shoot = ModContent.ProjectileType<Projectiles.SlamboriteProj>();
			Item.shootSpeed = 15.1F;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */; // Deals melee damage.
			Item.channel = true; // We can keep the left mouse button down when trying to keep using this weapon.
		}
	}
}