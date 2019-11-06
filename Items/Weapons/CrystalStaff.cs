using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystalStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Staff");
			Tooltip.SetDefault("Summons a giant crystal");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 21;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
			item.useTime = 61;
			item.useAnimation = 61;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<Projectiles.CrystalBomb>();
			item.shootSpeed = 8f;
		}
	}
}