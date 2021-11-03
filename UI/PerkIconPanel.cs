using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using TerrabornLeveling.Perks;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace TerrabornLeveling.UI;

public class PerkIconPanel : UIPanel
{
    public const float SizePadding = 1.1f;
    private Action<UIMouseEvent, PerkIconPanel> _clickCallback;

    public PerkIconPanel(IPerk perk, float width, float height, Action<UIMouseEvent, PerkIconPanel> clickCallback)
    {
        Perk = perk;

        Width = new(width, 0);
        Height = new(height, 0);

        BackgroundColor = BorderColor = Color.Transparent;
        _clickCallback = clickCallback;
    }

    public void DrawHover(SpriteBatch spriteBatch)
    {
        if (IsMouseHovering)
        {
            StringBuilder sb = new();

            if (Perk.Unlocked)
                sb.AppendLine($"Current: {Perk.GetDescription(Perk.Level)}");

            if (Perk.Unlocked && Perk.Level < Perk.MaxLevel)
                sb.AppendLine();

            if (Perk.Level < Perk.MaxLevel)
                sb.AppendLine($"Next: {Perk.GetDescription(Perk.Level + 1)}");

            var str = sb.ToString();
            var txtDims = FontAssets.MouseText.Value.MeasureString(str);

            spriteBatch.DrawString(FontAssets.MouseText.Value, str, Main.MouseScreen + new Vector2(-txtDims.X / 2 - 2, 12 - 2), Color.Black);
            spriteBatch.DrawString(FontAssets.MouseText.Value, str, Main.MouseScreen + new Vector2(-txtDims.X / 2 + 2, 12 + 2), Color.Black);
            spriteBatch.DrawString(FontAssets.MouseText.Value, str, Main.MouseScreen + new Vector2(-txtDims.X / 2, 12), Color.White);
        }
    }

    public override void Click(UIMouseEvent evt)
    {
        Main.NewText($"Perk '{Perk.Name}' was left clicked");
        _clickCallback?.Invoke(evt, this);
    }

    public IPerk Perk { get; }
}