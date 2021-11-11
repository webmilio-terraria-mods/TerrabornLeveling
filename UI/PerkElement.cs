using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TerrabornLeveling.Perks;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;
using WebmilioCommons.Extensions;
using Color = Microsoft.Xna.Framework.Color;

namespace TerrabornLeveling.UI;

public class PerkElement : UIPanel
{
    private int _lastLevelUpdate = -1;
    private UIElement _tooltip;

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

    private bool _dragging;
    private bool _mouseRight;

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (_dragging)
        {
            if (!_mouseRight && Main.mouseRight && !IconPanel.IsMouseHovering) // Just making sure you can drop if not hovering cause it happens...
            {
                _dragging = false;
            }

            _mouseRight = false;

            var dimensions = Parent.GetDimensions();
            var rectangle = dimensions.ToRectangle();
            var mouse = Main.MouseScreen;

            float xPerc = Math.Clamp((mouse.X - rectangle.X) / (float)rectangle.Width, 0, 1);
            float yPerc = Math.Clamp((mouse.Y - rectangle.Y) / (float)rectangle.Height, 0, 1);

            HAlign = xPerc;
            VAlign = yPerc;

            Perk.Visuals.Position = new(xPerc, yPerc);
            Recalculate();
        }

        if (Perk.MaxLevel > 1 && Perk.Level != _lastLevelUpdate)
        {
            LevelPanel.SetText($"{Perk.Level}/{Perk.MaxLevel}");
            _lastLevelUpdate = Perk.Level;
        }
    }

    public override void RightClick(UIMouseEvent evt)
    {
        if (DragAndDrop)
        {
            _dragging = !_dragging;
            _mouseRight = true;
        }
    }

    public void ClickPerkIcon(UIMouseEvent evt, PerkIconPanel icon, IPerk perk)
    {
        if (perk.TryLevel())
        {
            SoundEngine.PlaySound(SoundID.Lavafall);
        }
    }

    public override void MouseOver(UIMouseEvent evt)
    {
        if (_tooltip == null && !_dragging)
        {
            BuildTooltip();
        }
    }

    public override void MouseOut(UIMouseEvent evt)
    {
        if (_tooltip != null)
        {
            TooltipContainer.RemoveChild(_tooltip);
            _tooltip = null;
        }
    }

    private void BuildTooltip()
    {
        float height = 0;

        _tooltip = new UIPanel()
        {
            Left = new(Main.MouseScreen.X, 0),
            Top = new(Main.MouseScreen.Y, 0)
        };

        UIText description;

        {
            StringBuilder sb = new();

            if (Perk.Unlocked)
                sb.AppendLine($"Current: {Perk.GetDescription(Perk.Level)}");

            if (Perk.Unlocked && !Perk.Maxed) sb.AppendLine();

            if (Perk.Level < Perk.MaxLevel)
                sb.AppendLine($"Next: {Perk.GetDescription(Perk.Level + 1)}");

            var str = sb.ToString();
            var dim = FontAssets.MouseText.Value.MeasureString(str);

            height += dim.Y;

            description = new UIText(str)
            {
                Width = new(dim.X, 0),
                Height = new(dim.Y, 0)
            };

            _tooltip.Append(description);
        }

        UIText requirements = null;

        if (!Perk.Maxed)
        {
            var str = $"Requires Level {Perk.RequiredSkillForNext}";
            var dims = FontAssets.MouseText.Value.MeasureString(str);

            height += dims.Y;

            requirements = new UIText(str)
            {
                Width = new(dims.X, 0),
                Top = new(description.Height.Pixels - dims.Y / 2, 0),

                TextColor = Perk.Skill.Level >= Perk.RequiredSkillForNext ? Color.Green : Color.Red
            };

            _tooltip.Append(requirements);
        }

        ((UIPanel)_tooltip).BackgroundColor.A = 200;

        const int padding = 15;

        _tooltip.SetPadding(15);
        _tooltip.Width = requirements == null ? new(description.Width.Pixels, 0) :
            new(Math.Max(description.Width.Pixels, requirements.Width.Pixels) + padding * 2, 0);
        _tooltip.Height = new(height, 0);

        TooltipContainer.Append(_tooltip);
    }

    public void DrawConstellationLines(SpriteBatch spriteBatch)
    {
        var dimensions = GetDimensions();

        for (int i = 0; i < ParentPerks.Length; i++)
        {
            var parentElement = ParentPerks[i];
            var parent = parentElement.Perk;

            var progressiveGray = 0.5f + (float) Perk.Level / Perk.MaxLevel * 0.5f;
            spriteBatch.DrawLine(2, dimensions.Center(), parentElement.IconPanel.GetDimensions().Center(), 
                parent.Unlocked ? new Color(progressiveGray, progressiveGray, progressiveGray) : Color.Gray);
        }
    }

    public void DrawPerk(SpriteBatch spriteBatch)
    {
        Perk.Visuals.DrawIcon(Perk, spriteBatch, IconPanel);
    }

    public void DrawHoverText(SpriteBatch spriteBatch)
    {
        if (_dragging) return;

        IconPanel.DrawHover(spriteBatch);
    }

    public IPerk Perk { get; }

    /// <summary>Provided for the sake of optimisation, removes the need to constantly fetch the children of the perk being drawn. Must be fed by the creator of this element.</summary>
    public PerkElement[] ParentPerks { get; set; }

    public PerkIconPanel IconPanel { get; }
    public UIText LevelPanel { get; }

    private UIElement TooltipContainer => Parent.Parent.Parent;

    public static bool DragAndDrop => TerrabornLeveling.Development;
}