using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod
{
	public class CrystiliumMod : Mod
	{
		internal static CrystiliumMod instance;

		public CrystiliumMod()
		{
			instance = this;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemType<Items.CrystalBottle>());
			recipe.needWater = true;
			recipe.SetResult(ItemType<Items.CrystalBottleWater>());
		}

		public override void UpdateMusic(ref int music)
		{
			Player player = Main.LocalPlayer;

			//Don't override the songs in this list!
			int[] NoOverride = {MusicID.Boss1, MusicID.Boss2, MusicID.Boss3, MusicID.Boss4, MusicID.Boss5,
				MusicID.LunarBoss, MusicID.PumpkinMoon, MusicID.TheTowers, MusicID.FrostMoon, MusicID.GoblinInvasion,
				MusicID.PirateInvasion, GetSoundSlot(SoundType.Music, "Sounds/Music/CrystalKing")};

			bool playMusic = true;
			foreach (int n in NoOverride)
			{
				if (music == n) playMusic = false;
			}

			if (player.active && player.GetModPlayer<CrystalPlayer>(this).ZoneCrystal && !Main.gameMenu && playMusic)
			{
				music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows");
			}
		}
	}
}