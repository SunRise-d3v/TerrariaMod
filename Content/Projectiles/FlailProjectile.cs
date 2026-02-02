using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ModD.Content.Projectiles
{
    public class FlailProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.height = 38;
            Projectile.width = 38;
            Projectile.scale = 1f;

            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.timeLeft = 120;

            Projectile.damage = 30;
            Projectile.CritChance = 10;
            Projectile.friendly = true;

            Projectile.aiStyle = ProjAIStyleID.Bubble;
            //Projectile.
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position, Projectile.width / 2, Projectile.height / 2, DustID.CursedTorch, 10, 10, 255, Colors.RarityDarkPurple, Projectile.scale);
            Projectile.rotation++;
            Projectile.alpha -= 3;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 1; i < 11; ++i)
                Dust.NewDust(Projectile.position + new Vector2(Main.rand.Next((int)(Projectile.position.X + 5 * i), (int)(Projectile.position.Y + 5 * i))), Projectile.width, Projectile.height, DustID.PurpleTorch, Main.rand.Next(3 * i, 10 * i), Main.rand.Next(3 * i, 10 * i));

            if (timeLeft <= 0 || Projectile.alpha < 1)
                Projectile.active = false;
        }
    }
}
