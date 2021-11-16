namespace TerrabornLeveling.Perks.Mining.Biomes;

[Parents(typeof(Undergrounder))]
public class Hellevation : Perk
{
    public Hellevation() : base("hellevation")
    {
    }

    public override void OnPreUpdate()
    {
        
    }

    public override string GetDescription(int level) => "Mining straight down with auto cursor on causes you to mine 2 blocks wide.";

    public override string Name => "Hellevation";

    public override IPerkVisualDescriptor Visuals { get; } = new IconTagsPerkVisualDescriptor(new(0.65779465f, 0.6754658f), IconTagsPerkVisualDescriptor.TagsIcon.Hell);
}