using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class Crystishae : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystoshet");
			Tooltip.SetDefault("'The powers of three do not set out alone'");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ThornChakram);
			Item.damage = 77;
			Item.DamageType = DamageClass.Throwing;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = 6;
			Item.shoot = ProjectileType<Projectiles.Crystishae>();
		}

		public override bool CanUseItem(Player player)
		{
			//if any projectiles named "Crystishae" exist that are owned by this player, don't use this item
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].type == Item.shoot && Main.projectile[i].owner == player.whoAmI)
					return false;
			}

			//otherwise, use this item
			return true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			//create velocity vectors for the two angled projectiles (outwards at PI/15 radians)
			Vector2 origVect = new Vector2(speedX, speedY);
			Vector2 newVect = origVect.RotatedBy(System.Math.PI / 15);
			Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 15);

			//create three Crystishae projectiles
			//Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockBack, player.whoAmI);
			return true; //will shoot original projectile
		}
	}
}