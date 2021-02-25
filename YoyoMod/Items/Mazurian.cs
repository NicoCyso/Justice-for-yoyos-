using YoyoMod.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoyoMod.Items
{
	public class Mazurian : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Amazon wants to see your location\nShoots 4 yoyos");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 8;
			item.useTime = 8;
			item.shootSpeed = 34f;
			item.knockBack = 9.5f;
			item.damage = 94;
			item.rare = ItemRarityID.LightRed;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 15);
			item.shoot = ModContent.ProjectileType<MazurianProjectile>();
		}

		// Make sure that your item can even receive these prefixes (check the vanilla wiki on prefixes)
		// These are the ones that reduce damage of a melee weapon
		private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy};

		public override bool AllowPrefix(int pre) {
			// return false to make the game reroll the prefix

			// DON'T DO THIS BY ITSELF:
			// return false;
			// This will get the game stuck because it will try to reroll every time. Instead, make it have a chance to return true

			if (Array.IndexOf(unwantedPrefixes, pre) > -1) {
				// IndexOf returns a positive index of the element you search for. If not found, it's less than 0. Here check the opposite
				// Rolled a prefix we don't want, reroll
				return false;
			}
			// Don't reroll
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Blessar>());
			recipe.AddIngredient(ItemID.Stinger, 10);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 7);
			recipe.AddIngredient(ItemID.JungleSpores, 5);
			recipe.AddIngredient(ItemID.WoodYoyo);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)

     		   {

        		    float spread = 10f * 0.0174f;
        		    float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
        		    double startAngle = Math.Atan2(speedX, speedY) - spread / 2;
         		   double deltaAngle = spread / 40f;
         		   double offsetAngle;
          		  int i;
         		   for (i = 0; i < 4; i++)
          		  {
           		     offsetAngle = startAngle + deltaAngle * i;
            		    Terraria.Projectile.NewProjectile(position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), mod.ProjectileType("MazurianProjectile"), damage, knockBack, item.owner);
           		 }
         		   return false;
       		 }
	}
}
