using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YoyoMod.Projectiles
{
	public class StarProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star");
		}

		public override void SetDefaults()
		{
			projectile.arrow = false;
			projectile.width = 7;
			projectile.height = 6;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 3;
			projectile.scale = 2f;
			aiType = ProjectileID.JestersArrow;
		}
		public override void PostAI() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 272);
				dust.noGravity = false;
				dust.scale = 1.1f;
			}
		}
	}
}