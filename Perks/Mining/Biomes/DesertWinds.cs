namespace TerrabornLeveling.Perks.Mining.Biomes;

[Parents(typeof(Undergrounder))]
public class DesertWinds : Perk
{
    public DesertWinds() : base("desertwinds")
    {
    }

    public override void OnPreUpdate()
    {
        if (!Owner.Player.ZoneUndergroundDesert)
        {
            return;
        }

        Owner.Player.moveSpeed *= 1.25f;
        Owner.Player.maxRunSpeed *= 1.25f;
        Owner.Player.accRunSpeed *= 1.25f;

        Owner.Player.pickSpeed *= 1.25f;
    }

    public override string GetDescription(int level) => "Increases speed and mining speed while\nin the Underground Desert.";

    public override string Name => "Desert Winds";

    public override IPerkVisualDescriptor Visuals { get; } = new IconTagsPerkVisualDescriptor(new(0.88212925f, 0.7049689f), IconTagsPerkVisualDescriptor.TagsIcon.UndergroundDesert);
}