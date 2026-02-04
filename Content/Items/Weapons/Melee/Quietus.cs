using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModD.Content.Items.Weapons.Melee
{
    public class Quietus : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.NightsEdge;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 68;
            Item.height = 68;
            Item.scale = 1f;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 35;
            Item.crit = 11;
            Item.knockBack = 7;

            Item.value = 10000;

            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item45;
            Item.noMelee = false;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3))
                target.AddBuff(BuffID.OnFire, 180);
        }
    }
}