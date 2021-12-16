using Infuller.Items.Magic;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Skills;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrabornLeveling.Perks.Magic.Destruction;

[Skill(typeof(Skills.Destruction))]
public class ViolentMagic : Perk
{
    public ViolentMagic() : base("violentmagic")
    {
    }

    public override void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        if (!Magics.TryGet(item.type, out var record) || !record.EffectType.HasFlag(MagicEffectType.Attack))
            return;

        damage *= DamageMultiplier;
    }

    public static float GetDamageMultiplier(int level)
    {
        return .1f * level;
    }

    public override string GetDescription(int level)
    {
        return $"Attack-type magic does {(int)(GetDamageMultiplier(level) * 100)}% more damage.";
    }

    public override string Name => "Violent Magic";
    public override int MaxLevel => 5;

    public float DamageMultiplier => 1 + GetDamageMultiplier(Level);

    public override IPerkVisualDescriptor Visuals { get; } =
        new AnimatedTypeIconVisualDescriptor(new(.5f, 1), TextureAssets.Projectile, ProjectileID.SpiritFlame, 4, 6);
}