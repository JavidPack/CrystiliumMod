using CrystiliumMod.Content.Biomes.Backgrounds;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Biomes
{
    // TODO: Map background image.
    public class CrystalBiome : ModBiome
    {
        // TODO: alt music possibly.
        //var normalMusic = this.GetSoundSlot(SoundType.Music, "Sounds/Music/CrystallineFlows");
        //if(music != normalMusic && Main.rand.NextBool(10))
        public override int Music => MusicLoader.GetMusicSlot("CrystiliumMod/Content/Sounds/Music/CrystallineFlows");

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.GetInstance<CrystalUndergroundBackgroundStyle>();

        public override void OnEnter(Player player)
        {
            player.GetModPlayer<CrystalPlayer>().ZoneCrystal = true;
        }

        public override void OnInBiome(Player player)
        {
            player.GetModPlayer<CrystalPlayer>().ZoneCrystal = true;
        }
        public override void OnLeave(Player player)
        {
            player.GetModPlayer<CrystalPlayer>().ZoneCrystal = false;
        }

        public override bool IsBiomeActive(Player player) {
            return CrystalWorld.CrystalTiles > 400;
        }
    }
}