using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TerrabornLeveling.Perks;
using TerrabornLeveling.Skills;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using WebmilioCommons.Extensions;

namespace TerrabornLeveling.UI
{
    public class SkillElement : UIPanel
    {
        public const float SizeWidth = 600;

        private UIProgressBar _skillExpBar;
        private List<PerkElement> _perks;

        public SkillElement(ISkill skill)
        {
            Skill = skill;

            VAlign = 0.5f;
            HAlign = 0.5f;
            Width = new(SizeWidth, 0);
            Height = new(0, 0.8f);

            BackgroundColor = BorderColor = Color.Transparent;

            Append(MakeSkillPanel());
            AddSkillInfoPanel();
        }

        private UIPanel MakeSkillPanel()
        {
            UIPanel panel = new()
            {
                Width = StyleDimension.Fill,
                Height = new(0, 0.80f),

                BackgroundColor = Color.Transparent,
                BorderColor = Color.Transparent
            };

            _perks = new(Skill.Perks.Count);
            Skill.Perks.Do(delegate (IPerk perk)
            {
                PerkElement perkElement = new(perk)
                {
                    HAlign = perk.Visuals.Position.X,
                    VAlign = perk.Visuals.Position.Y
                };

                _perks.Add(perkElement);
                panel.Append(perkElement);
            });

            _perks.Do(p =>
            {
                p.ParentPerks = new PerkElement[p.Perk.Parents.Count];

                p.Perk.Parents.Do((child, i) =>
                {
                    p.ParentPerks[i] = GetPerkElement(child);
                });
            });

            return panel;
        }

        private void AddSkillInfoPanel()
        {
            UIPanel skillInfoPanel = new()
            {
                Width = StyleDimension.Fill,
                Height = new(0, .15f),

                VAlign = 1f,

                BackgroundColor = Color.Transparent,
                BorderColor = Color.Transparent
            };

            Append(skillInfoPanel);

            UIText nameDisplayText = new($"{Skill.Name} {Skill.Level}", 0.8f, true)
            {
                VAlign = 0.1f,
                HAlign = .5f
            };

            skillInfoPanel.Append(nameDisplayText);

            _skillExpBar = new()
            {
                HAlign = 0.5f,
                VAlign = 0.9f,
                Width = new(0, 0.8f),
                Height = new(24, 0)
            };

            skillInfoPanel.Append(_skillExpBar);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            _perks.Do(p => p.DrawConstellationLines(spriteBatch));
            base.Draw(spriteBatch);

            _perks.Do(p => p.DrawPerk(spriteBatch));
            _perks.Do(p => p.DrawHoverText(spriteBatch));
        }

        public override void OnActivate()
        {
            base.OnActivate();

            _skillExpBar.SetProgress(Skill.Experience / Skill.ExperienceForLevel);
        }

        public PerkElement GetPerkElement(IPerk perk)
        {
            return _perks.Find(p => p.Perk == perk);
        }

        public ISkill Skill { get; set; }
    }
}
