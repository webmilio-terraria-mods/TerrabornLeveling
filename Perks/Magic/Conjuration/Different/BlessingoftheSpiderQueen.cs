using TerrabornLeveling.Perks.Visualisers;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;
using WebmilioCommons.Tinq;

namespace TerrabornLeveling.Perks.Magic.Conjuration.Different;

[Parents(typeof(OtherworldAttunement))]
public class BlessingoftheSpiderQueen : Perk
{
    public BlessingoftheSpiderQueen() : base("blessingofthespiderqueen")
    {
    }

    public override void OnPreUpdate()
    {
        var x = Owner.Player.ownedProjectileCounts;

        /*Owner.Player.ownedProjectileCounts.Do(delegate(int type)
        {
            var projectile = Main.projectile[type];

            if (projectile.owner == Owner.Player.whoAmI && projectile.minion)
            {
                
            }
        });*/
    }

    public override void OnModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        Main.projectile
            .WhereActive(delegate(Projectile p)
            {
                return p.owner == Owner.Player.whoAmI && p.minion;
            })
            .Do(delegate(Projectile p)
            {
                p.damage += (int)GetDamageMultiplier(Level, (Owner.Player.ownedProjectileCounts[p.type] - 1));
                p.damage += 1000;
            });
    }

    public float GetDamageMultiplier(int level) => level * .04f;
    public float GetDamageMultiplier(int level, int count) => GetDamageMultiplier(level) * count;

    public override string GetDescription(int level)
    {
        return "";
    }

    public override int GetRequiredSkill(int level) => StepRequiredLevel(10, 20, level);

    public override string Name => "Blessing of the Spider Queen";
    public override int MaxLevel => 3;

    public override IPerkVisualDescriptor Visuals { get; } = new StaticTypeIconVisualDescriptor(new(0.41825095f, 0.7279793f), 
        TextureAssets.Projectile, ProjectileID.SpiderHiver, 9, 4);
}