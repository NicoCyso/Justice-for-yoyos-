using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoyoMod.Projectiles
{
	public class SawProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Saw");
		}

		public override void SetDefaults()
		{
			projectile.arrow = false;
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			aiType = ProjectileID.JestersArrow;
		}
	}
}