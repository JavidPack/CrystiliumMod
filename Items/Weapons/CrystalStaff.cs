using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class CrystalStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Crystal Staff";
			item.damage = 21;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Summons a giant crystal";
			item.useTime = 61;
			item.useAnimation = 61;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType<Projectiles.CrystalBomb>();
			item.shootSpeed = 8f;
		}
	}
}