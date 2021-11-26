using Infuller.Items.Armors;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;

namespace TerrabornLeveling.Perks.Physical.HeavyArmor;

[Skill(typeof(Skills.HeavyArmor))]
public class TrainingWeights : Perk
{
    private const int ArmorSlots = 3;

    private static readonly Asset<Texture2D> _icon = TerrabornLeveling.Instance.Assets.Request<Texture2D>($"Perks/Physical/HeavyArmor/{nameof(TrainingWeights)}");

    public TrainingWeights() : base("trainingweight")
    {
    }

    public override void OnUpdateEquips()
    {
        if (Level == MaxLevel)
        {
            Owner.HeavyPenalty = false;
        }

        for (int i = 0; i < ArmorSlots; i++)
        {
            var armor = Owner.Player.armor[i];

            if (!Armors.TryGet(armor.type, out var record) || !record.Type.HasFlag(ArmorType.Heavy))
            {
                continue;
            }

            armor.defense = (int) (armor.defense * 1.15f);
        }

        Owner.Player.maxRunSpeed *= .8f;
        Owner.Player.maxFallSpeed *= 1.2f;
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(1, 20, level);

    public override string Name => "Heavy Armor Mastery";
    public override int MaxLevel => 5;

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, 1f), new(36, 36), _icon);
}