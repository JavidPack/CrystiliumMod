using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CrystiliumMod.Projectiles;

namespace CrystiliumMod.Items.Weapons
{
	public class Glowstrike : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Glowstrike";
			item.damage = 26;
			item.magic = true;
			item.mana = 12;
			item.width = 40;
			item.height = 40;
			item.toolTip = "Summons a deadly fireball";
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 30000;
			item.rare = 3;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType<CrystalFire>();
			item.shootSpeed = 20f;
		}
	}
}