using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZenithItems.Items
{
	public class Gathering : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Line them all up and knock them all down");
		}

		public override void SetDefaults()
		{
			item.height = 40;
			item.width = 40;
			item.damage = 145;
			item.magic = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 6;
			item.useTime = 6;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 750000;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.channel = true;
			item.mana = 100;
			item.shoot = ProjectileID.StarWrath;
		}


		int stageCounter = 0;

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (stageCounter == 8)
			{
				// Stage 9 | Last Prism (but not)

				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.StarWrath, damage * 10, knockBack, player.whoAmI);
				//	Main.projectile[projectileRef].extraUpdates = 2;

				stageCounter++;
			}
			if (stageCounter == 7)
			{
				// Stage 8 | Nebula Blaze

				int projectileRef = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.NebulaBlaze1, damage * 10, knockBack, player.whoAmI);
				stageCounter++;
			}
			if (stageCounter == 6)
			{
				// Stage 6 | Razorblade Typhoon

				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Typhoon, damage * 10, knockBack, player.whoAmI);
				stageCounter++;
			}
			if (stageCounter == 5)
			{
				// Stage 6 | Laser Machinegun

				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.ScutlixLaser, damage * 10, knockBack, player.whoAmI);

				stageCounter++;
			}
			if (stageCounter == 4)
			{
				// Stage 5 | Sky Fracture

				Projectile.NewProjectile(position.X, position.Y, speedX *10, speedY *10, ProjectileID.SkyFracture, damage * 10, knockBack, player.whoAmI);


				stageCounter++;
			}
			if (stageCounter == 3)
			{
				// Stage 4 | Meteor Staff
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Meteor1, damage * 10, knockBack, player.whoAmI);


				stageCounter++;
			}
			if (stageCounter == 2)
			{
				// Stage 3 | Crystal Storm

				Projectile.NewProjectile(position.X, position.Y, speedX *3, speedY *3, ProjectileID.CrystalStorm, damage * 10, knockBack, player.whoAmI);

				stageCounter++;
			}
			if (stageCounter == 1)
			{
				// Stage 2 | Water Bolt
				Projectile.NewProjectile(position.X, position.Y, speedX *3, speedY *3, ProjectileID.WaterBolt, damage * 10, knockBack, player.whoAmI);

				stageCounter++;
			}
			if (stageCounter == 0)
			{
				// Stage 1 | Space Gun

				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.GreenLaser, damage * 10, knockBack, player.whoAmI);


				stageCounter++;
			}
			if (stageCounter == 9)
			{
				stageCounter = 0;
			}
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpaceGun, 1);
			recipe.AddIngredient(ItemID.WaterBolt, 1);
			recipe.AddIngredient(ItemID.CrystalStorm, 1);
			recipe.AddIngredient(ItemID.MeteorStaff, 1);
			recipe.AddIngredient(ItemID.SkyFracture, 1);
			recipe.AddIngredient(ItemID.LaserMachinegun, 1);
			recipe.AddIngredient(ItemID.RazorbladeTyphoon, 1);
			recipe.AddIngredient(ItemID.NebulaBlaze, 1);
			recipe.AddIngredient(ItemID.LastPrism, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}