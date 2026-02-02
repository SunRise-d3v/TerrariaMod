using Microsoft.Xna.Framework;
using ModD.Content.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModD.Content.Items.Weapons.Range
{
    public class TestBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.height = 58;
            Item.width = 20;
            Item.scale = 1f;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 11;
            Item.crit = 7;
            Item.knockBack = 9;
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 8;
            Item.noMelee = true;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 15;
            Item.useTime = 11;
            Item.autoReuse = true;
        }

        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(0, 0);
            return offset;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int offset = 15;
            int projectile = 3;
            Vector2 currentPosition = new Vector2(position.X, position.Y - offset);
            for (int i = 0; i < projectile; i++)
            {
                currentPosition = new Vector2(position.X, position.Y + offset * i);
                Projectile.NewProjectile(source, currentPosition, velocity, ModContent.ProjectileType<FlailProjectile>(), damage, knockback, player.whoAmI);
            }

            return false;
        }

        public override bool CanReforge()
        {
            return false;
        }
    }
}