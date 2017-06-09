using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
			item.CloneDefaults(ItemID.ThornChakram);
			item.damage = 77;
			item.thrown = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 6;
			item.shoot = mod.ProjectileType<Projectiles.Crystishae>();
		}

		public override bool CanUseItem(Player player)
		{
			//if any projectiles named "Crystishae" exist that are owned by this player, don't use this item
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				if (Main.projectile[i].active && Main.projectile[i].type == item.shoot && Main.projectile[i].owner == player.whoAmI)
					return false;
			}

			//otherwise, use this item
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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