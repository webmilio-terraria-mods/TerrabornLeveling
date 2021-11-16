using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Mining.Biomes;

[Parents(typeof(Undergrounder))]
public class FrigidResolve : BiomePerk
{
    public FrigidResolve() : base("frigidresolve")
    {
    }

    public override void OnPreUpdate()
    {
        if (!IsInRange || !Owner.Player.ZoneSnow)
        {
            return;
        }

        Owner.Player.endurance = (1 - Owner.Player.endurance) * .25f + Owner.Player.endurance;
    }

    public override string GetDescription(int level) => "Increases damage resistance by 25% while\nin the Underground Tundra.";

    public override string Name => "Frigid Resolve";

    public override IPerkVisualDescriptor Visuals { get; } = new IconTagsPerkVisualDescriptor(new(0.9448669f, 0.82763976f), IconTagsPerkVisualDescriptor.TagsIcon.UndergroundTundra);
}