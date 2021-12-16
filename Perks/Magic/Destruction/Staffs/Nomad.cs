using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;
using Terraria;

namespace TerrabornLeveling.Perks.Magic.Destruction.Staffs;

[Parents(typeof(ViolentMagic))]
public class Nomad : Perk
{
    public Nomad() : base("nomad")
    {
    }

    public static float GetManaCostReduction(int Level)
    {
        return .15f * Level;
    }

    public override void OnModifyManaCost(Item item, ref float reduce, ref float mult)
    {
        if (!Infuller.Items.Magic.Wands.Is(item.type))
            return;

        mult *= ManaCostMultiplier;
    }

    public override string GetDescription(int level)
    {
        return $"Staffs and wands cost {(int) (GetManaCostReduction(level) * 100)}% less mana to use.";
    }

    public override string Name => "Nomad";
    public override int MaxLevel => 2;

    public float ManaCostMultiplier => 1 - GetManaCostReduction(Level);

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.5f, .7f));
}