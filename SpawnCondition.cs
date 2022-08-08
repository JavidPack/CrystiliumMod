using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using ReLogic.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrystiliumMod
{
    public class CrystaliumSpawnCondition : IFilterInfoProvider, IProvideSearchFilterString, IBestiaryInfoElement, IBestiaryBackgroundImagePathAndColorProvider, IBestiaryPrioritizedElement
    {
        public string name = "Crystal biome";
        public Color color = Color.AliceBlue;
        public float OrderPriority => 1f;
        public Color? GetBackgroundColor() => color;
        public Asset<Texture2D> GetBackgroundImage() => ModContent.Request<Texture2D>("CrystiliumMod/Content/Biomes/Backgrounds/CrystalBiomeUG1");

        public string GetDisplayNameKey() => name;
        public UIElement GetFilterImage()
        {
            Asset<Texture2D> asset = null;//Terraria.GameContent.TextureAssets.BlackTile;
            return new UIImageFramed(asset, new Rectangle(0, 0, asset.Width(), asset.Height()))
            {
                HAlign = 0.5f,
                VAlign = 0.5f
            };
            
        }

        public string GetSearchString(ref BestiaryUICollectionInfo info) => info.UnlockState == BestiaryEntryUnlockState.NotKnownAtAll_0 ? null : name;
        public UIElement ProvideUIElement(BestiaryUICollectionInfo info)
        {
            if (info.UnlockState == BestiaryEntryUnlockState.NotKnownAtAll_0)
                return null;

            UIElement uIElement = new UIPanel(Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Stat_Panel"), null, 12, 7)
            {
                Width = new StyleDimension(-14f, 1f),
                Height = new StyleDimension(34f, 0f),
                BackgroundColor = new Color(43, 56, 101),
                BorderColor = Color.Transparent,
                Left = new StyleDimension(5f, 0f)
            };
            uIElement.SetPadding(0f);
            uIElement.PaddingRight = 5f;
            UIElement filterImage = GetFilterImage();
            filterImage.HAlign = 0f;
            filterImage.Left = new StyleDimension(5f, 0f);
            UIText element = new UIText(GetDisplayNameKey(), 0.8f)
            {
                HAlign = 0f,
                Left = new StyleDimension(38f, 0f),
                TextOriginX = 0f,
                TextOriginY = 0f,
                VAlign = 0.5f,
                DynamicallyScaleDownToWidth = true
            };
            if (filterImage != null)
            {
                uIElement.Append(filterImage);
            }

            uIElement.Append(element);
            uIElement.OnUpdate += delegate (UIElement e)
            {
                if (e.IsMouseHovering)
                {
                    string textValue = GetDisplayNameKey();
                    Main.instance.MouseText(textValue, 0, 0);
                };
            };
            return uIElement;
        }
    }
}
