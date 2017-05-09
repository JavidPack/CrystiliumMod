using CrystiliumMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class Callandor : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Callandor";
			item.width = 36;
			item.height = 36;
			item.useAnimation = 25;
			item.useTime = 15;
			item.useStyle = 5;
			item.toolTip = "'I DID get this off of a Schmo'";
			item.noUseGraphic = true;
			item.channel = true;
			item.noMelee = true;
			item.damage = 166;
			item.knockBack = 4f;
			item.autoReuse = false;
			item.noMelee = true;
			item.melee = true;
			item.shoot = mod.ProjectileType<CallandorSlice>();
			item.shootSpeed = 15f;
			item.value = 100000;
			item.rare = 7;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType<CallandorSlice>(), damage, knockBack, player.whoAmI);
			Main.projectile[p].scale = 1f;
			return false;
		}
	}
}