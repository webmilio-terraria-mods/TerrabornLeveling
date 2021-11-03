using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TerrabornLeveling;

public partial class TLHooks
{
    private void Main_OnCraftItem(On.Terraria.Main.orig_CraftItem orig, Recipe r)
    {
        int stack = MouseItem.stack;

        MouseItem = r.createItem.Clone();
        MouseItem.stack += stack;
        if (stack <= 0)
            MouseItem.Prefix(-1);

        MouseItem.position.X = Main.LocalPlayer.position.X + Main.LocalPlayer.width / 2 - MouseItem.width / 2;
        MouseItem.position.Y = Main.LocalPlayer.position.Y + Main.LocalPlayer.height / 2 - MouseItem.height / 2;
        
        PopupText.NewText(PopupTextContext.ItemCraft, MouseItem, r.createItem.stack);
        r.Create();

        if (MouseItem.type > 0 || r.createItem.type > 0)
        {
            ItemLoader.OnCreate(MouseItem, new RecipeCreationContext { recipe = r });
            RecipeLoader.OnCraft(MouseItem, r);

            SoundEngine.PlaySound(7);
        }
	}

    public Item MouseItem
    {
        get => Main.mouseItem;
        set => Main.mouseItem = value;
    }
}
