using Infuller.Items.Magic;
using Terraria;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Magic;

public abstract class ManaEfficiencyPerk : Perk
{
    public const float
        RangeReduction = .25f,
        LowerReduction = .10f;

    public static readonly string Description = $"Reduces the mana cost of spells between tiers {{0}} and {{1}} by {RangeReduction * 100}%\nand of spells under {{0}} tier by {LowerReduction * 100}%.";

    protected ManaEfficiencyPerk(string identifier, int lowerRarity, int upperRarity) : base(identifier)
    {
        LowerRarity = lowerRarity;
        UpperRarity = upperRarity;
    }

    public override void OnModifyManaCost(Item item, ref float reduce, ref float mult)
    {
        if (item.mana <= 0 || item.OriginalRarity > UpperRarity || 
            !Magics.TryGet(item.type, out var magicRecord) || !magicRecord.EffectType.HasFlag(MagicEffectType.Attack))
            return;

        if (item.rare < LowerRarity)
        {
            mult *= 1 - LowerReduction;
            return;
        }

        if (item.rare >= LowerRarity && item.rare <= UpperRarity)
        {
            mult *= 1 - RangeReduction;
            return;
        }
    }

    public virtual int LowerRarity { get; }
    public virtual int UpperRarity { get; }
}