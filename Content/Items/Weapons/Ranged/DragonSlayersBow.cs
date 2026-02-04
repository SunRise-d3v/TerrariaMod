using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModD.Content.Items.Weapons.Ranged
{
    public class DragonSlayersBow : ModItem
    {
        private int count = 0;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.DD2BetsyBow;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 66;
            Item.scale = 1f;

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 21;
            Item.useTime = 21;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 20;
            Item.crit = 15;
            Item.knockBack = 5;

            Item.shootSpeed = 20f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useAmmo = AmmoID.Arrow;

            Item.value = 10000;

            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item5;
            Item.noMelee = false;
        }

        public override Vector2? HoldoutOffset()
        {
            Vector2? offset = new Vector2(-7, 0);
            return offset;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (count == 1)
            {
                int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.FireArrow, damage, knockback, player.whoAmI);
                Main.projectile[proj].friendly = true;
            }
            else
            {
                int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.BoneArrow, damage, knockback, player.whoAmI);
                Main.projectile[proj].friendly = true;

                count = 0;
            }

            count++;
            return false;
        }
    }
}