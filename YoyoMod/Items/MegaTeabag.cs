using YoyoMod.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoyoMod.Items
{
	public class MegaTeabag : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("You actually got a lot of herbs!");
		}
		public override void SetDefaults() {
			item.rare = ItemRarityID.LightRed;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Teabag>());
			recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddIngredient(ItemID.Daybloom);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.Fireblossom);
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddIngredient(ItemID.Shiverthorn);
			recipe.AddIngredient(ItemID.Waterleaf);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
