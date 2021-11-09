﻿using static Terraria.ID.PrefixID;

namespace TerrabornLeveling.Perks.Smithing.Melee;

[Parents(typeof(CheapSteel))]
public class TeenageWisdom : MeleePerk
{
    public TeenageWisdom() : base("teenagewisdom")
    {
    }

    public override string Name => "Teenage Wisdom";

    protected override int RequiredSkill => 30;

    protected override int[] Unlocks { get; } = { Dull, Small, Large, Sharp };
    protected override string[] UnlockNames { get; } = { nameof(Dull), nameof(Small), nameof(Large), nameof(Sharp) };

    public override IPerkVisualDescriptor Visuals { get; } = new StandardPerkVisualDescriptor(new(XPosition, YPosition - YOffset * 3));
}