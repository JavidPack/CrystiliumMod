using CrystiliumMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class Callandor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Callandor");
			Tooltip.SetDefault("'I DID get this off of a Schmo'");
		}

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 36;
			Item.useAnimation = 25;
			Item.useTime = 15;
			Item.useStyle = 5;
			Item.noUseGraphic = true;
			Item.channel = true;
			Item.noMelee = true;
			Item.damage = 166;
			Item.knockBack = 4f;
			Item.autoReuse = false;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.shoot = ModContent.ProjectileType<CallandorSlice>();
			Item.shootSpeed = 15f;
			Item.value = 100000;
			Item.rare = 7;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int p = Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<CallandorSlice>(), damage, knockback, player.whoAmI);
			Main.projectile[p].scale = 1f;
			return false;
		}
	}
}