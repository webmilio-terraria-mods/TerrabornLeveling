using System.Text;
using Infuller.Items.Magic;
using TerrabornLeveling.Perks.Visualisers;
using TerrabornLeveling.Projectiles;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using WebmilioCommons;

namespace TerrabornLeveling.Perks.Magic.Destruction.Fire;

[Parents(typeof(Intensify))]
public class DarkPyromancy : Perk
{
    private static readonly int[] _buffs = { BuffID.OnFire3, BuffID.Frostburn, BuffID.ShadowFlame, BuffID.CursedInferno };
    private static readonly string[] _buffNames = { "Hellfire", "Frostburn", "Shadowflame", "Cursed Inferno" };

    public DarkPyromancy() : base("darkpyromancy")
    {
    }

    public override void OnProjectileHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
    {
        var global = projectile.GetGlobalProjectile<TLGlobalProjectileInstanced>();

        if (!Magics.TryGet(global.CreatorItem.type, out var magicRecord) || !magicRecord.IsElement(IMagic.ElementFire))
            return;

        // TODO Add check so that not every magic type inflicts fire debuffs
        for (int i = 0; i < Level; i++)
        {
            target.AddBuff(_buffs[i], Constants.TicksPerSecond * 3);
        }
    }

    public override string GetDescription(int level)
    {
        StringBuilder sb = new("Fire attacks inflict the following for 3 seconds:\n");

        for (int i = 0; i < level && i < _buffNames.Length; i++)
        {
            sb.Append(_buffNames[i]);

            if (i + 1 < level)
                sb.Append(", ");
        }

        return sb.ToString();
    }

    public override int GetRequiredSkill(int level)
    {
        return 50;
    }

    public override string Name => "Dark Pyromancy";
    public override int MaxLevel => _buffs.Length;

    public override IPerkVisualDescriptor Visuals { get; } = new TypeIconVisualDescriptor(new(.1f, .5f), TextureAssets.Item, ItemID.LivingDemonFireBlock);
}