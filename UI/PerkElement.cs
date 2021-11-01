using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TerrabornLeveling.Perks;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;
using WebmilioCommons.Extensions;
using Color = Microsoft.Xna.Framework.Color;

namespace TerrabornLeveling.UI;

public class PerkElement : UIPanel
{
    private int _lastLevelUpdate = -1;

    public PerkElement(IPerk perk)
    {
        const float padding = 1.1f;
        Perk = perk;

        float iconPanelHeight = perk.Visuals.Size.Y * padding;

        IconPanel = new(perk, perk.Visuals.Size.X * padding, iconPanelHeight, 
            (evt, panel) => ClickPerkIcon(evt, panel, perk));
        Append(IconPanel);

        LevelPanel = new("")
        {
            Top = new StyleDimension(iconPanelHeight / 1.5f, 0),
            Width = StyleDimension.Fill,

            HAlign = 0.5f
        };
        Append(LevelPanel);

        var textDimensions = LevelPanel.GetDimensions();

        Width.Set(Math.Max(IconPanel.Width.Pixels * padding, textDimensions.Width), 0);
        Height.Set(Math.Max(iconPanelHeight, textDimensions.Height), 0);

        BackgroundColor = BorderColor = Color.Transparent;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (Perk.MaxLevel > 1 && Perk.Level != _lastLevelUpdate)
        {
            LevelPanel.SetText($"{Perk.Level}/{Perk.MaxLevel}");
            _lastLevelUpdate = Perk.Level;
        }
    }

    public void ClickPerkIcon(UIMouseEvent evt, PerkIconPanel icon, IPerk perk)
    {
        if (perk.TryLevel(Main.LocalPlayer))
        {
            SoundEngine.PlaySound(SoundID.Lavafall);
        }
    }

    public void DrawConstellationLines(SpriteBatch spriteBatch)
    {
        var dimensions = GetDimensions();

        for (int i = 0; i < Children.Length; i++)
        {
            spriteBatch.DrawLine(2, dimensions.Center(), Children[i].IconPanel.GetDimensions().Center(), Perk.Level == Perk.MaxLevel ? Color.White : Color.Gray);
        }
    }

    public void DrawPerk(SpriteBatch spriteBatch)
    {
        Perk.Visuals.DrawIcon(Perk, spriteBatch, IconPanel);
    }

    public IPerk Perk { get; }

    /// <summary>Provided for the sake of optimisation, removes the need to constantly fetch the children of the perk being drawn. Must be fed by the creator of this element.</summary>
    public PerkElement[] Children { get; set; }

    public PerkIconPanel IconPanel { get; }
    public UIText LevelPanel { get; }
}