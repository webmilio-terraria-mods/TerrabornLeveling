using System;
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
        const float padding = 1.25f;
        Perk = perk;

        SetPadding(0);

        IconPanel = new(perk, perk.Visuals.Size.X * padding, perk.Visuals.Size.Y * padding, 
            (evt, panel) => ClickPerkIcon(evt, panel, perk));
        Append(IconPanel);

        UIText name = new(perk.Name)
        {
            Top = new(IconPanel.Height.Pixels, 0),
            Width = StyleDimension.Fill,

            HAlign = .5f
        };
        Append(name);

        LevelPanel = new("")
        {
            Top = new(IconPanel.Height.Pixels + 20, 0),
            Width = StyleDimension.Fill,

            HAlign = .5f
        };
        Append(LevelPanel);

        var textDimensions = LevelPanel.GetDimensions();

        Width.Set(Math.Max(IconPanel.Width.Pixels, textDimensions.Width), 0);
        Height.Set(Math.Max(IconPanel.Height.Pixels, textDimensions.Height), 0);

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

        for (int i = 0; i < ParentPerks.Length; i++)
        {
            var parentElement = ParentPerks[i];
            var parent = parentElement.Perk;

            var progressiveGray = 0.5f + (float) Perk.Level / Perk.MaxLevel * 0.5f;
            spriteBatch.DrawLine(2, dimensions.Center(), parentElement.IconPanel.GetDimensions().Center(), parent.Unlocked ? new Color(progressiveGray, progressiveGray, progressiveGray) : Color.Gray);
        }
    }

    public void DrawPerk(SpriteBatch spriteBatch)
    {
        Perk.Visuals.DrawIcon(Perk, spriteBatch, IconPanel);
    }

    public void DrawHoverText(SpriteBatch spriteBatch)
    {
        IconPanel.DrawHover(spriteBatch);
    }

    public IPerk Perk { get; }

    /// <summary>Provided for the sake of optimisation, removes the need to constantly fetch the children of the perk being drawn. Must be fed by the creator of this element.</summary>
    public PerkElement[] ParentPerks { get; set; }

    public PerkIconPanel IconPanel { get; }
    public UIText LevelPanel { get; }
}