using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class PrismCast : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prismatic Catalyst");
			Tooltip.SetDefault("'Clense your soul'");
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			Item.damage = 0;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 55;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 77;
			Item.useAnimation = 77;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 30000;
			Item.rare = 3;
			Item.healLife = 10;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
		}
	}
}