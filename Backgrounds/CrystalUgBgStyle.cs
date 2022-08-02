using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Backgrounds
{
	public class CrystalUgBgStyle : ModUndergroundBackgroundStyle
	{
		public override bool ChooseBgStyle()/* tModPorter Note: Removed. Create a ModBiome (or ModSceneEffect) class and override UndergroundBackgroundStyle property to return this object through Mod/ModContent.Find, then move this code into IsBiomeActive (or IsSceneEffectActive) */
		{
			return Main.LocalPlayer.GetModPlayer<CrystalPlayer>().ZoneCrystal;
		}

		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/CrystalBiomeUG0");
			textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/CrystalBiomeUG1");
			textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/CrystalBiomeUG2");
			textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot(Mod, "Backgrounds/CrystalBiomeUG3");
		}
	}
}