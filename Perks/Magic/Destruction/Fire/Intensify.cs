using Infuller.Buff;
using Infuller.Items.Magic;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Projectiles;
using Terraria;

namespace TerrabornLeveling.Perks.Magic.Destruction.Fire;

[Parents(typeof(ViolentMagic))]
public class Intensify : Perk
{
    public Intensify() : base("intensify")
    {
    }

    public override void OnProjectileModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit,
        ref int hitDirection)
    {
        var global = projectile.GetGlobalProjectile<TLGlobalProjectileInstanced>();

        if (!Magics.TryGet(global.CreatorItem.type, out var magicRecord) || !magicRecord.IsElement(IMagic.ElementFire))
            return;

        const float increase = .1f;
        float mult = 1;

        for (int i = 0; i < target.buffType.Length; i++)
        {
            if (target.buffTime[i] <= 0)
                continue;

            if (!Buffs.TryGet(target.buffType[i], out var buffRecord) || !buffRecord.Fire)
                continue;

            mult += increase;
        }

        damage = (int) (damage * mult);
    }

    public override string GetDescription(int level)
    {
        return "Fire attacks deal 10% more damage per type of\nfire debuff on the target.";
    }

    public override int GetRequiredSkill(int level)
    {
        return 20;
    }

    public override string Name => "Intensify";

    public override IPerkVisualDescriptor Visuals { get; } = new PerkVisualDescriptor(new(.1f, .8f));
}