using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;

namespace TerrabornLeveling.Perks.Visualisers;

public class IconTagsPerkVisualDescriptor : PerkVisualDescriptor
{
    private const int
        FrameX = 16,
        FrameY = 5,

        FullWidth = 480,
        FullHeight = 150,

        Width = FullWidth / FrameX,
        Height = FullHeight / FrameY;

    private static readonly Vector2 _size = new(Width, Height);
    private static readonly Vector2 _origin = new(Width / 2, Height / 2);

    private static readonly Asset<Texture2D> _texture = Main.Assets.Request<Texture2D>("Images/UI/Bestiary/Icon_Tags_Shadow");

    private readonly Rectangle _sourceRectangle;

    public IconTagsPerkVisualDescriptor(Vector2 position, TagsIcon icon) : base(position, _size, _texture)
    {
        TagIcon = icon;

        _sourceRectangle = new(((int)icon % FrameX) * Width, ((int)icon / FrameX) * Height, Width, Height);
    }

    protected override void DrawIcon(SpriteBatch spriteBatch, Asset<Texture2D> icon, Vector2 location, Color color, float scale)
    {
        spriteBatch.Draw(icon.Value, location, _sourceRectangle, color, Rotation, _origin, scale, SpriteEffects.None, 0);
    }

    public TagsIcon TagIcon { get; }

    public enum TagsIcon
    {
        Forest,
        Cavern,
        Underground,
        
        Desert,
        UndergroundDesert,
        
        SnowBiome,
        UndergroundTundra,

        // Corrupted
        Corruption,
        UndergroundCorruption,

        CorruptedDesert,
        UndergroundCorruptedDesert,

        UndergroundCorruptedTundra,

        // Crimson
        Crimson,
        UndergroundCrimson,

        CrimsonDesert,
        UndergroundCrimsonDesert,

        UndergroundCrimsonTundra,

        // Hallow
        Hallow,
        UndergroundHallow,

        HallowedDesert,
        UndergroundHallowedDesert,

        UndergroundHallowTundra,

        // Jungle
        Jungle,
        UndergroundJungle,

        MushroomBiome,
        UndergroundMushroomBiome,

        SkyIsland,
        Oasis,
        Ocean,

        MarbleBiome,
        GraniteBiome,

        Temple,
        Dungeon,

        Hell,

        SpiderBiome,
        GraveyardBiome,

        // Sun & Moon
        Sun,
        Moon,
        Bloodmoon,
        Eclipse,

        // Weather
        Storm,
        Windy,
        Blizzard,
        Sandstorm,

        Meteor,
        
        Pumpkin,
        Present,

        SlimeRain,

        Party,

        // Invasions
        Goblin,
        PirateFlag,

        // Events
        PumpkinMoon,
        FrostMoon,
        MartianMadness,
        FrostLegion,
        OldOnesArmy,

        // Pillars
        SolarPillar,
        VortexPillar,
        NebulaPillar,
        StardustPillar,

        SwirlingSouls,
        
        // Others
        MoneyBag, 
        Lock,
        Boss,

        QuestionMark,
        QuestionMark2
    }
}