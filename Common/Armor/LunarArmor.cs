using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SwapLunarArmor.Common.Armor
{
    public class LunarArmor : ModSystem
    {
        readonly int[] LunarSet = { ItemID.SolarFlareHelmet, ItemID.VortexHelmet, ItemID.NebulaHelmet, ItemID.StardustHelmet };
        public static RecipeGroup LunarHelmets, LunarBreastplates, LunarLeggings;
        public static List<KeyValuePair<string, RecipeGroup>> LunarGroups = new List<KeyValuePair<string, RecipeGroup>>
        {
            new KeyValuePair<string, RecipeGroup>("LunarHelmets", LunarHelmets),
            new KeyValuePair<string, RecipeGroup>("LunarBreastplates", LunarBreastplates),
            new KeyValuePair<string, RecipeGroup>("LunarLeggings", LunarLeggings)
        };
        public override void AddRecipeGroups()
        {
            string legacyText = Language.GetTextValue("LegacyMisc.37");

            for (int i = 0; i < LunarGroups.Count; i++)
            {
                LunarGroups[i] = new KeyValuePair<string, RecipeGroup>(LunarGroups[i].Key, new RecipeGroup(() => $"{legacyText} {Lang.GetItemNameValue(LunarSet[0] + i)}", LunarSet[0] + i, LunarSet[1] + i, LunarSet[2] + i, LunarSet[3] + i));
                RecipeGroup.RegisterGroup(LunarGroups[i].Key, LunarGroups[i].Value);
            }
        }
        private void CreateAndRegisterRecipe(int itemId, RecipeGroup group)
        {
            Recipe recipe = Recipe.Create(itemId, 1);
            recipe.AddRecipeGroup(group, 1);
            // recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
        private RecipeGroup GetRecipeGroup(int index)
        {
            return LunarGroups[index].Value;
        }
        public override void AddRecipes()
        {
            foreach (int LunarSet in LunarSet)
            {
                for (int i = 0; i < 3; i++)
                {
                    CreateAndRegisterRecipe(LunarSet + i, GetRecipeGroup(i));
                }
            }
        }
    }
}