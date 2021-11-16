namespace TerrabornLeveling.Perks.Mining.Biomes;

public abstract class BiomePerk : Perk
{
    protected BiomePerk(string identifier) : base(identifier)
    {
    }

    public bool IsInRange => Owner.Player.ZoneDirtLayerHeight || Owner.Player.ZoneRockLayerHeight;
}