using System;
using Microsoft.Xna.Framework;
using TerrabornLeveling.Perks;
using Terraria;
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

        BackgroundColor = BorderColor = Color.Red;
        _clickCallback = clickCallback;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Click(UIMouseEvent evt)
    {
        Main.NewText($"Perk '{Perk.Name}' was left clicked");
        _clickCallback?.Invoke(evt, this);
    }

    public IPerk Perk { get; }
}