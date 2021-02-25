using YoyoMod.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoyoMod.Items
{
	public class Teabag : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Get a lot of herbs");
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cobweb, 10);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
