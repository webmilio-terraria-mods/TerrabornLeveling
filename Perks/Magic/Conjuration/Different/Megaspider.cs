using System;
using TerrabornLeveling.Perks.Visualisers;
using Terraria.GameContent;
using Terraria.ID;

namespace TerrabornLeveling.Perks.Magic.Conjuration.Different;

[Parents(typeof(Arachnophilia))]
public class Megaspider : Perk
{
    public Megaspider() : base("megaspider")
    {
    }

    public override string GetDescription(int level)
    {
        return "";
    }

    public override string Name => "Megaspider";

    public override IPerkVisualDescriptor Visuals { get; } = new AnimatedTypeIconVisualDescriptor(new(0.117870726f, 0.38471502f),
        TextureAssets.Npc, NPCID.BlackRecluseWall, 4, 10)
    {
        Rotation = MathF.PI / -4,
        Scale= .7f
    };
}