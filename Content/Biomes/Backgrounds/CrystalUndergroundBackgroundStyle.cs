using Terraria.ModLoader;

namespace CrystiliumMod.Content.Biomes.Backgrounds
{
	public class CrystalUndergroundBackgroundStyle : ModUndergroundBackgroundStyle
	{
		public override void FillTextureArray(int[] textureSlots)
		{
			textureSlots[0] = BackgroundTextureLoader.GetBackgroundSlot("CrystiliumMod/Content/Biomes/Backgrounds/CrystalBiomeUG0");
			textureSlots[1] = BackgroundTextureLoader.GetBackgroundSlot("CrystiliumMod/Content/Biomes/Backgrounds/CrystalBiomeUG1");
			textureSlots[2] = BackgroundTextureLoader.GetBackgroundSlot("CrystiliumMod/Content/Biomes/Backgrounds/CrystalBiomeUG2");
			textureSlots[3] = BackgroundTextureLoader.GetBackgroundSlot("CrystiliumMod/Content/Biomes/Backgrounds/CrystalBiomeUG3");
		}
	}
}