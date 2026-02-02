using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModD.Content.Items.Weapons.Range
{
    public class TripleShootBow : ModItem
    {
        private int shootCount;

        public override void SetDefaults()
        {
            Item.height = 58;
            Item.width = 20;
            Item.scale = 1f;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 11;
            Item.crit = 7;
            Item.knockBack = 9;
            Item.useAmmo = AmmoID.Arrow;
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
            Projectile.NewProjectile(source, new Vector2(position.X, position.Y + 15f), velocity, type, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, new Vector2(position.X, position.Y), velocity, type, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, new Vector2(position.X, position.Y - 15f), velocity, type, damage, knockback, player.whoAmI);
            shootCount += 1;
            return false;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            int proj =Projectile.NewProjectile(
                player.GetSource_ItemUse(player.HeldItem),
                position,
                velocity,
                ProjectileID.DD2BetsyArrow,
                damage,
                knockback,
                player.whoAmI
            );

            if (shootCount >= 5)
                type = proj;
        }
    }
}