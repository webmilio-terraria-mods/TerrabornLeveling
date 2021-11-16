namespace TerrabornLeveling.Perks.Mining.Biomes;

[Parents(typeof(CaveDweller))]
public class Undergrounder : Perk
{
    public Undergrounder() : base("undergrounder")
    {
    }

    public override void OnPreUpdate()
    {
        if (!Owner.Player.ZoneRockLayerHeight)
        {
            return;
        }

        Owner.Player.statDefense += 4;
        Owner.Player.pickSpeed += .15f;
    }

    public override void OnUpdateLifeRegen()
    {
        if (!Owner.Player.ZoneRockLayerHeight)
        {
            return;
        }

        Owner.Player.lifeRegen += 2 * 2;
    }

    public override string GetDescription(int level)
    {
        return "Increases defense, health regeneration and\n" +
               "mining speed when underground";
    }

    public override string Name => "Undergrounder";

    public override IPerkVisualDescriptor Visuals { get; } = new IconTagsPerkVisualDescriptor(new(0.6368821f, 0.9736025f), IconTagsPerkVisualDescriptor.TagsIcon.Underground);
}