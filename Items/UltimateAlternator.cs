using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZenithItems.Items
{

	public class UltimateAlternator : ModItem
	{

	
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("The last bow you'll ever need");
		}

		public override void SetDefaults()
		{
			item.height = 12;
			item.width = 20;
			item.damage = 150;
			item.ranged = true;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 6;
			item.useTime = 45;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 750000;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item39;
			item.autoReuse = true;
			item.useTurn = false;
			item.useAmmo = 40;
			item.reuseDelay = 20;
			item.shootSpeed = 16f;
			item.crit = 10;
			item.channel = true;
			item.noUseGraphic = false;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			}



		int stageCounter = 0;
		

	

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{

			
			if (stageCounter == 8)
			{
				// Stage 9 | Luminite tracers

				float arrowGapAmount = 0.25f;
				int projectileCount = 3;
				Vector2 direction = new Vector2(speedX, speedY);
				direction.Normalize();
				direction *= 50f;
				Vector2 originalCoordinates = new Vector2(0, 0);
				bool lineofSight = Collision.CanHit(originalCoordinates, 0, 0, originalCoordinates + direction, 0, 0);


		    for (int i = 0; i < projectileCount; i++)
				{
					float stepCounter = (float)i - ((float)projectileCount - 1f) / 2f;
					double rotationAmount = (double)(arrowGapAmount * stepCounter);
					Vector2 rotatableCoordinates = default(Vector2);
					Vector2 updatedDirection = direction.RotatedBy(rotationAmount, rotatableCoordinates);
					if (!lineofSight)
					{
						updatedDirection -= direction;
					}
					int projectileRef = Projectile.NewProjectile(position.X + updatedDirection.X, position.Y + updatedDirection.Y, speedX, speedY, ProjectileID.MoonlordArrowTrail, damage * 13, knockBack * 3, player.whoAmI);
					Main.projectile[projectileRef].noDropItem = true;
					Main.projectile[projectileRef].friendly = true;
				}

				stageCounter++;
			}
			if (stageCounter == 7)
			{
				// Stage 8 | Hellfire Arrows

				float arrowGapAmount = 0.25f;
				int projectileCount = 3;
				Vector2 direction = new Vector2(speedX, speedY);
				direction.Normalize();
				direction *= 50f;
				Vector2 originalCoordinates = new Vector2(0, 0);
				bool lineofSight = Collision.CanHit(originalCoordinates, 0, 0, originalCoordinates + direction, 0, 0);

				for (int i = 0; i < projectileCount; i++)
				{
					float stepCounter = (float)i - ((float)projectileCount - 1f) / 2f;
					double rotationAmount = (double)(arrowGapAmount * stepCounter);
					Vector2 rotatableCoordinates = default(Vector2);
					Vector2 updatedDirection = direction.RotatedBy(rotationAmount, rotatableCoordinates);
					if (!lineofSight)
					{
						updatedDirection -= direction;
					}
					int projectileRef = Projectile.NewProjectile(position.X + updatedDirection.X, position.Y + updatedDirection.Y, speedX, speedY, ProjectileID.HellfireArrow, damage * 13, knockBack * 3, player.whoAmI);
					Main.projectile[projectileRef].noDropItem = true;
					Main.projectile[projectileRef].friendly = true;
				}

				stageCounter++;
			}
			if (stageCounter == 6)
			{
				// Stage 7 | Shadowflame Arrows

				float arrowGapAmount = 0.25f;
				int projectileCount = 3;
				Vector2 direction = new Vector2(speedX, speedY);
				direction.Normalize();
				direction *= 50f;
				Vector2 originalCoordinates = new Vector2(0, 0);
				bool lineofSight = Collision.CanHit(originalCoordinates, 0, 0, originalCoordinates + direction, 0, 0);

				for (int i = 0; i < projectileCount; i++)
				{
					float stepCounter = (float)i - ((float)projectileCount - 1f) / 2f;
					double rotationAmount = (double)(arrowGapAmount * stepCounter);
					Vector2 rotatableCoordinates = default(Vector2);
					Vector2 updatedDirection = direction.RotatedBy(rotationAmount, rotatableCoordinates);
					if (!lineofSight)
					{
						updatedDirection -= direction;
					}
					int projectileRef = Projectile.NewProjectile(position.X + updatedDirection.X, position.Y + updatedDirection.Y, speedX, speedY, ProjectileID.ShadowFlameArrow, damage * 13, knockBack * 3, player.whoAmI);
					Main.projectile[projectileRef].noDropItem = true;
					Main.projectile[projectileRef].friendly = true;
				}

				stageCounter++;
			}
			if (stageCounter == 5)
			{
				// Stage 6 | Holy Daedeulus Arrows


				int projectileCount = 3;
				for (int i = 0; i < projectileCount; ++i)
				{
					Vector2 adjustment = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(100) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //This defines the projectile width, direction and position.
					adjustment.X = (float)(((double)adjustment.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-100, 100);
					adjustment.Y -= (float)(100 * i);
					float adjustedXValue = (float)Main.mouseX + Main.screenPosition.X - adjustment.X;
					float adjustedYValue = (float)Main.mouseY + Main.screenPosition.Y - adjustment.Y;
					if ((double)adjustedYValue < 0.0) adjustedYValue *= -1f;
					if ((double)adjustedYValue < 20.0) adjustedYValue = 20f;
					float squareRootofValues = (float)Math.Sqrt((double)adjustedXValue * (double)adjustedXValue + (double)adjustedYValue * (double)adjustedYValue);
					float speedFactor = item.shootSpeed / squareRootofValues;
					float speedXAdjustment = adjustedXValue * speedFactor;
					float speedYAdjustment = adjustedYValue * speedFactor;
					float SpeedX = speedXAdjustment;
					float SpeedY = speedYAdjustment;
					int projectileRef = Projectile.NewProjectile(adjustment.X, adjustment.Y, SpeedX, SpeedY, ProjectileID.HolyArrow, damage * 13, knockBack * 3, player.whoAmI);
					Main.projectile[projectileRef].noDropItem = true;
					Main.projectile[projectileRef].friendly = true;

				}

				stageCounter++;
			}
			if (stageCounter == 4)
			{
				// Stage 5 | Flaming Arrows

				float arrowGapAmount = 0.25f;
				int projectileCount = 3;
				Vector2 direction = new Vector2(speedX, speedY);
				direction.Normalize();
				direction *= 50f;
				Vector2 originalCoordinates = new Vector2(0, 0);
				bool lineofSight = Collision.CanHit(originalCoordinates, 0, 0, originalCoordinates + direction, 0, 0);

				for (int i = 0; i < projectileCount; i++)
				{
					float stepCounter = (float)i - ((float)projectileCount - 1f) / 2f;
					double rotationAmount = (double)(arrowGapAmount * stepCounter);
					Vector2 rotatableCoordinates = default(Vector2);
					Vector2 updatedDirection = direction.RotatedBy(rotationAmount, rotatableCoordinates);
					if (!lineofSight)
					{
						updatedDirection -= direction;
					}
					int projectileRef = Projectile.NewProjectile(position.X + updatedDirection.X, position.Y + updatedDirection.Y, speedX, speedY, ProjectileID.FlamingArrow, damage * 13, knockBack * 3, player.whoAmI);
					Main.projectile[projectileRef].noDropItem = true;
					Main.projectile[projectileRef].friendly = true;
				}

				stageCounter++;
			}
			if (stageCounter == 3)
			{
				// Stage 4 | Bee Arrows

				float arrowGapAmount = 0.25f;
				int projectileCount = 3;
				Vector2 direction = new Vector2(speedX, speedY);
				direction.Normalize();
				direction *= 50f;
				Vector2 originalCoordinates = new Vector2(0, 0);
				bool lineofSight = Collision.CanHit(originalCoordinates, 0, 0, originalCoordinates + direction, 0, 0);

				for (int i = 0; i < projectileCount; i++)
				{
					float stepCounter = (float)i - ((float)projectileCount - 1f) / 2f;
					double rotationAmount = (double)(arrowGapAmount * stepCounter);
					Vector2 rotatableCoordinates = default(Vector2);
					Vector2 updatedDirection = direction.RotatedBy(rotationAmount, rotatableCoordinates);
					if (!lineofSight)
					{
						updatedDirection -= direction;
					}
					int projectileRef = Projectile.NewProjectile(position.X + updatedDirection.X, position.Y + updatedDirection.Y, speedX, speedY, ProjectileID.BeeArrow, damage * 13, knockBack * 3, player.whoAmI);
					Main.projectile[projectileRef].noDropItem = true;
					Main.projectile[projectileRef].friendly = true;
				}

				stageCounter++;
			}
			if (stageCounter == 2)
			{
				// Stage 3 | Bat Arrows

				float arrowGapAmount = 0.25f;
				int projectileCount = 3;
				Vector2 direction = new Vector2(speedX, speedY);
				direction.Normalize();
				direction *= 50f;
				Vector2 originalCoordinates = new Vector2(0, 0);
				bool lineofSight = Collision.CanHit(originalCoordinates, 0, 0, originalCoordinates + direction, 0, 0);

				for (int i = 0; i < projectileCount; i++)
				{
					float stepCounter = (float)i - ((float)projectileCount - 1f) / 2f;
					double rotationAmount = (double)(arrowGapAmount * stepCounter);
					Vector2 rotatableCoordinates = default(Vector2);
					Vector2 updatedDirection = direction.RotatedBy(rotationAmount, rotatableCoordinates);
					if (!lineofSight)
					{
						updatedDirection -= direction;
					}
					int projectileRef = Projectile.NewProjectile(position.X + updatedDirection.X, position.Y + updatedDirection.Y, speedX, speedY, ProjectileID.Bat, damage * 13, knockBack * 3, player.whoAmI);
					Main.projectile[projectileRef].noDropItem = true;
					Main.projectile[projectileRef].friendly = true;
				}

				stageCounter++;
			}
			if (stageCounter == 1)
			{
				// Stage 2 | Cursed or Ichor Arrows

				float arrowGapAmount = 0.25f;
				int projectileCount = 3;
				Vector2 direction = new Vector2(speedX, speedY);
				direction.Normalize();
				direction *= 50f;
				Vector2 originalCoordinates = new Vector2(0, 0);
				bool lineofSight = Collision.CanHit(originalCoordinates, 0, 0, originalCoordinates + direction, 0, 0);

				for (int i = 0; i < projectileCount; i++)
				{
					float stepCounter = (float)i - ((float)projectileCount - 1f) / 2f;
					double rotationAmount = (double)(arrowGapAmount * stepCounter);
					Vector2 rotatableCoordinates = default(Vector2);
					Vector2 updatedDirection = direction.RotatedBy(rotationAmount, rotatableCoordinates);
					if (!lineofSight)
					{
						updatedDirection -= direction;
					}

					int choice = Main.rand.Next(0, 1);
					if (choice == 0)
					{
						int projectileRef = Projectile.NewProjectile(position.X + updatedDirection.X, position.Y + updatedDirection.Y, speedX, speedY, ProjectileID.CursedArrow, damage * 13, knockBack * 3, player.whoAmI);
						Main.projectile[projectileRef].noDropItem = true;
						Main.projectile[projectileRef].friendly = true;
					}
					else
					{
						int projectileRef = Projectile.NewProjectile(position.X + updatedDirection.X, position.Y + updatedDirection.Y, speedX, speedY, ProjectileID.IchorArrow, damage * 13, knockBack * 3, player.whoAmI);
						Main.projectile[projectileRef].noDropItem = true;
						Main.projectile[projectileRef].friendly = true;
					}
				}

				stageCounter++;
			}
			if (stageCounter == 0)
			{
				// Stage 1 | Wooden Arrows

				float arrowGapAmount = 0.25f;
				int projectileCount = 3;
				Vector2 direction = new Vector2(speedX, speedY);
				direction.Normalize();
				direction *= 50f;
				Vector2 originalCoordinates = new Vector2(0, 0);
				bool lineofSight = Collision.CanHit(originalCoordinates, 0, 0, originalCoordinates + direction, 0, 0);

				for (int i = 0; i < projectileCount; i++)
				{
					float stepCounter = (float)i - ((float)projectileCount - 1f) / 2f;
					double rotationAmount = (double)(arrowGapAmount * stepCounter);
					Vector2 rotatableCoordinates = default(Vector2);
					Vector2 updatedDirection = direction.RotatedBy(rotationAmount, rotatableCoordinates);
					if (!lineofSight)
					{
						updatedDirection -= direction;
					}
					int projectileRef = Projectile.NewProjectile(position.X + updatedDirection.X, position.Y + updatedDirection.Y, speedX, speedY, ProjectileID.WoodenArrowFriendly, damage * 13, knockBack * 3, player.whoAmI);
					Main.projectile[projectileRef].noDropItem = true;
					Main.projectile[projectileRef].friendly = true;
				}

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
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ItemID.WoodenBow, 1);
			recipe1.AddIngredient(ItemID.DemonBow, 1);
			recipe1.AddIngredient(ItemID.HellwingBow, 1);
			recipe1.AddIngredient(ItemID.BeesKnees, 1);
			recipe1.AddIngredient(ItemID.MoltenFury, 1);
			recipe1.AddIngredient(ItemID.DaedalusStormbow, 1);
			recipe1.AddIngredient(ItemID.ShadowFlameBow, 1);	
			recipe1.AddIngredient(ItemID.Tsunami, 1);
			recipe1.AddIngredient(ItemID.Phantasm, 1);
			recipe1.AddTile(TileID.Anvils);
			recipe1.SetResult(this);
			recipe1.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.WoodenBow, 1);
			recipe2.AddIngredient(ItemID.TendonBow, 1);
			recipe2.AddIngredient(ItemID.HellwingBow, 1);
			recipe2.AddIngredient(ItemID.BeesKnees, 1);
			recipe2.AddIngredient(ItemID.MoltenFury, 1);
			recipe2.AddIngredient(ItemID.DaedalusStormbow, 1);
			recipe2.AddIngredient(ItemID.ShadowFlameBow, 1);
			recipe2.AddIngredient(ItemID.Tsunami, 1);
			recipe2.AddIngredient(ItemID.Phantasm, 1);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
 
}