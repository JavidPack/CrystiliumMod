using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod
{
	public class CrystiliumMod : Mod
	{
		public CrystiliumMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CrystalBottle");
			recipe.needWater = true;
			recipe.SetResult("CrystalBottleWater", 1);
		}

		public override void UpdateMusic(ref int music)
		{
			Player player = Main.player[Main.myPlayer];

			//Don't override the songs in this list!
			int[] NoOverride = {MusicID.Boss1, MusicID.Boss2, MusicID.Boss3, MusicID.Boss4, MusicID.Boss5,
				MusicID.LunarBoss, MusicID.PumpkinMoon, MusicID.TheTowers, MusicID.FrostMoon, MusicID.GoblinInvasion,
				MusicID.PirateInvasion, GetSoundSlot(SoundType.Music, "Sounds/Music/CrystalKing")};

			bool playMusic = true;
			foreach(int n in NoOverride) {
				if(music == n) playMusic = false;
			}

			if(player.active && player.GetModPlayer<CrystalPlayer>(this).ZoneCrystal && !Main.gameMenu && playMusic) {
					music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows");
			}
		}
	}
}