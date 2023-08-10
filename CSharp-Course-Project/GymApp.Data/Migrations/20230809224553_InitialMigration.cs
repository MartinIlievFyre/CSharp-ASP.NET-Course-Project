using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsModerator = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Carbs = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Carbs = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Fat = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Protein = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Grams = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WearCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WearCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Execution = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Benefit = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlans_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsersFoods",
                columns: table => new
                {
                    TrainingGuyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersFoods", x => new { x.TrainingGuyId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersFoods_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersFoods_UsersFoods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "UsersFoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Fabric = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WearCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clothes_WearCategories_WearCategoryId",
                        column: x => x.WearCategoryId,
                        principalTable: "WearCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsersExercises",
                columns: table => new
                {
                    TrainingGuyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersExercises", x => new { x.TrainingGuyId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersExercises_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsersTrainingPlans",
                columns: table => new
                {
                    TrainingGuyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsersTrainingPlans", x => new { x.TrainingGuyId, x.TrainingPlanId });
                    table.ForeignKey(
                        name: "FK_ApplicationUsersTrainingPlans_AspNetUsers_TrainingGuyId",
                        column: x => x.TrainingGuyId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsersTrainingPlans_TrainingPlans_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "Benefits", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "The 4-layer leather belt with an adjustable section provides stability and durabilitywhile //ensuring comfort, offering support during weightlifting and is suitable for individuals engaging inheavy/ /lifting.", "The LEVER weightlifting belt is a practical device designed for individuals engaged in /strength training, aiming to increase the weights they lift; it helps stabilize the core and lower back muscles, /boosting your confidence and enabling you to lift heavier weights. Made from 4-layered material /- 2inner layers /of cowhide and suede covered with 2 outer layers of buffalo suede - it ensures stability/ anddurability while /fitting perfectly to your body; the belt also features an adjustable section to /accommodateyour waist size, /eliminating concerns about it being too large or small. If you want to /enhance the weightslifted during squats or/ deadlifts, this high-quality leather belt should undoubtedly /be part of your fitnessarsenal.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/w/e//weightlifting-belt-lever-gymbeam_5_.jpg", "GymBeam", "Weight belt LEVER Black", 99.99m, "Accessory" },
                    { 2, "The Ronnie fitness gloves protect hands from injuries, calluses, and abrasions, providinga //secure grip during workouts with fitness equipment, bars, or weights; they are perfect for strength training, have/ an ergonomic shape for long-lasting durability, and fit hands comfortably without /squeezingfingers.", "The Ronnie fitness gloves are high-quality exercise gloves made of split leather witha //rubber-padded cowhide interior for an ideal fit and intense workout protection for every athlete; they /are reinforced with a double lining in the palm area for durability and resistance against wear, designed/ for professional athletes seeking superior hand protection during training, guarding against scratches, /calluses,and /impacts while providing a secure grip on workout equipment, but they should not be machine /washed.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/r/u//rukavice_2j_1.jpg", "GymBeam", "Fitness gloves Ronnie", 19.99m, "Accessory" },
                    { 3, "This 700ml shaker, made of high-quality polypropylene PP, is perfect for mixing allsoluble //dietary supplements, featuring a leak-proof screw-on lid, a cone-shaped filter to prevent lumps, milliliter (ml) /and ounce (oz) markings, break-resistant, dishwasher, microwave, and fridge safe, BPA and/ DEHPfree, and compliant/ with food regulations.", "The green shaker is a classic 700ml shaker with a traditional closure and filter,perfect //for mixing your favorite proteins, pre-workout stimulants, and creatine; made of non-toxic plasticand /free from /BPA and DEHP.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/s/h//shaker_yellow_green.jpg", "GymBeam", "Green shaker 700ml", 7.99m, "Accessory" },
                    { 4, "Made of 100% cotton, this towel has anti-static and antibacterial properties, driesquickly, //absorbs efficiently, feels soft and pleasant to touch, and boasts a long lifespan.", "This gray fitness and workout towel, made of 100% soft and pleasant-to-touch cotton, stands /out with its excellent absorption, high durability, and anti-static, antibacterial properties. With /dimensions of 50x90 cm, this towel possesses these qualities naturally, without the use of any chemical compounds,/ making it suitable for individuals with sensitive skin or allergies, as it does not cause /allergicreactions. /Every athlete recognizes the significance of a workout towel, an essential accessory /in the gym, no only to wipe /away sweat from the face but also to provide a clean surface for various /exercises, such as forabdominal /workouts, seating, or under the feet during exercises. Not having a /workout towel in the gym is apure faux pas /(embarrassing mistake) and can easily be avoided to prevent /someone from asking, \"Where is yourtowel?\"", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/g/r//grey_fitness_towel_gymbeam_1_.jpg", "GymBeam", "Towel for fitness", 14.99m, "Accessory" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"), "e757b8e3-9c52-4650-b0af-9c2b65b67e02", "Admin", "ADMIN" },
                    { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), "c10bf1ca-7130-45c4-bb69-336e404b17d6", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "IsDeleted", "IsModerator", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"), 0, "ce360d2d-704f-4d87-9fa2-76b82dfa762f", new DateTime(2023, 8, 9, 22, 45, 53, 31, DateTimeKind.Utc).AddTicks(6077), "admin@abv.com", false, false, false, false, null, null, null, "admin", "AQAAAAEAACcQAAAAEKXsLMIZHDryQH5M6uIX6wr1a06kB3oNnfe2lX3L/KGxp3ZaIu+O9D7ixgzDRjQPoA==", null, false, null, "SecurityStamp04", false, "admin" },
                    { new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"), 0, "549bf90e-fa20-4c0f-89d6-7731b3910be8", new DateTime(2023, 8, 9, 22, 45, 53, 28, DateTimeKind.Utc).AddTicks(3541), "monika02@abv.com", false, false, false, false, null, null, null, "MONIKA-02", "AQAAAAEAACcQAAAAEFmx1tvovOSQ8QysYvPGWn/QC8E/ALxFuJy9Dl0+GjbGhQJZaU6cxV0ERy56k5kXbQ==", null, false, null, "SecurityStamp02", false, "Monika-02" },
                    { new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"), 0, "4f7b1511-256f-454e-89dd-4ab91f37f0bb", new DateTime(2023, 8, 9, 22, 45, 53, 30, DateTimeKind.Utc).AddTicks(253), "presko-03@abv.com", false, false, false, false, null, null, null, "PRESLAV-03", "AQAAAAEAACcQAAAAEC0/DhELSk3QZ9Iy8k9su1uwuAvoFpuvqazUzzEzEN9a3FeP0cYwqmz0ikVPvjG3tw==", null, false, null, "SecurityStamp03", false, "Preslav-03" },
                    { new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"), 0, "77824c96-2511-4d36-bf65-94fa0b7d2917", new DateTime(2023, 8, 9, 22, 45, 53, 26, DateTimeKind.Utc).AddTicks(7724), "vlado01@abv.com", false, false, false, false, null, null, null, "VLADO-01", "AQAAAAEAACcQAAAAEKSYTeyytNYCrZBIU005a/DfqTjzU7bbpWEnoAyr8lQajgdblaSz20++Fgzq3bswnw==", null, false, null, "SecurityStamp01", false, "Vlado-01" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Legs" },
                    { 2, false, "Biceps" },
                    { 3, false, "Triceps" },
                    { 4, false, "Chest" },
                    { 5, false, "Back" },
                    { 6, false, "Forearms" },
                    { 7, false, "Abs" },
                    { 8, false, "Shoulders" }
                });

            migrationBuilder.InsertData(
                table: "Supplements",
                columns: new[] { "Id", "Benefits", "Description", "ImageUrl", "Ingredients", "Manufacturer", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "The most biologically accessible form of calcium, enriched with vitamin D2, magnesium, copper,/ zinc, and manganese, ensures the health of muscles, bones, and teeth, participates in blood clotting, /supports proper neurotransmission, guarantees immune function, and promotes the well-being of hair, /nails, andskin,/ conveniently available in tablet form and suitable for vegetarians and vegans.", "Calcium citrate, in tablet form, is the most biologically accessible form ofcalcium, //ensuring optimal health for muscles, bones, and teeth, while also participating in blood clottingand /supporting /proper neurotransmission. Additionally, it is enriched with other beneficial electrolytes /suchas vitamin D2, /magnesium, copper, manganese, and zinc, which play crucial roles in bone metabolism,/ reducefatigue, support immune /and nervous system health, promote healthy hair, nails, and skin, and /protect cellsfrom oxidative stress, making /the product suitable for vegans and vegetarians.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/u/n//untitled_design_-_2020-04-03t164935.609.png", "Hydroxypropyl cellulose, vegetable coating, croscarmellose sodium, silicondioxide, //magnesium stearate (vegetable source), and stearic acid (vegetable source).", "NOW", "Calcium Citrate 100 Tablets", 29.99m, "Supplement" },
                    { 2, "500 mg of Ashwagandha (Withania somnifera) extract, containing 5% of active compounds called /withanolides, classified as adaptogens, may help enhance the body's resilience and aid in betterstress //management, available in convenient capsule form.", "Ashwagandha or Indian Ginseng (Withania somnifera) is a plant classified among adaptogens, /compounds known for their beneficial effects on the body, particularly in increasing itsresilience /and /improving the adaptation process to stress. Similar to how our muscles become stronger and growwhen we //exercise, adaptogens can enhance the body's resistance to stress and aid in better stress management. It's no wonder/ that Ashwagandha is popular among individuals experiencing daily stress at work, school, /or intheir personal /lives. However, its benefits don't end there; this plant is still being researched /by scientifi institutions for /its potential positive effects in reducing anxiety, fatigue, lowering the/ stress hormonecortisol, and enhancing /athletic performance, strength, and sleep. Additionally, it may /support our mentalwell-being and aid in /relaxation.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/a/s//ashwagandha_90_caps.png", "Ashwagandha extract (Withania somnifera) (5% withanolides), anti-caking agent(calcium //phosphate, magnesium stearate), gelatin capsule.", "GymBeam", "Ashwagandha 90 Capsules", 19.99m, "Supplement" },
                    { 3, "This dietary supplement, containing this essential mineral, participates in hundredsof //biological processes, supporting proper carbohydrate metabolism, bone health, protein synthesis, maintaining normal /testosterone levels, enhancing fertility and reproductive function, promoting healthy/ skin,hair, and nails, /supporting good vision, boosting the immune system, influencing proper /metabolism of fattyacids, aiding in DNA /synthesis, maintaining cognitive functions, affecting the /metabolism of vitamin A,protecting cells against /oxidative stress, and suitable for vegans, making it /ideal for anyone striving tomaintain optimal health.", "Zinc is an essential mineral found in many food supplements, vital for hundreds of /biological processes in the body, supporting proper metabolism of macronutrients like carbohydrates, /crucialfor /energy supply to athletes and active individuals. It also aids in maintaining bone health, /proteinsynthesis for /muscle growth, and has a positive impact on testosterone levels in men. Zinc plays/ a vital rolein various bodily /processes, positively affecting muscle size and strength, fertility, and/ reproductivefunction, benefiting skin, /hair, and nails for women, and supporting vision for those /spending time in front o screens. Additionally, as an /antioxidant, zinc protects cells against /oxidative stress, boosts the immunesystem, aids in fat metabolism, DNA /synthesis, cognitive functions, /and vitamin A metabolism, making it anideal supplement for overall health and /suitable for vegans.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/z/i//zinc_100_tabs_gymbeam.png", "Filler (microcrystalline cellulose, calcium hydrogen phosphate), zinc oxide,coating //(stearic acid), anti-caking agent (magnesium stearate).", "GymBeam", "Zinc 100 Tablets", 10.99m, "Supplement" },
                    { 4, "This supplement contains 1000 mg of ascorbic acid (Vitamin C), offered in easy-toswallow //tablets, supporting the proper functioning of the immune and nervous systems, promoting mentalbalance, /reducing /fatigue, maintaining energy metabolism, bone and cartilage health, collagen production,skin, /gum, and teeth /function, protecting cells from oxidative stress, enhancing iron absorption, and supporting cardiovascular health, /enriched with rosehip extract, promoting overall health and /vitality.", "Vitamin C 1000 mg, also known as L-ascorbic acid, is an essential vitamin found ineasy-/to-/swallow tablets and commonly present in various fruits and vegetables. It participates in numerous biological /processes, making it one of the most popular supplements supporting overall health and /vitality.Vitamin C /contributes to the proper functioning of the immune and nervous systems, supports /immunity during an after intense /physical activity, promotes mental balance, reduces fatigue, and aids /in energy metabolism fordaily activities and /sports. Additionally, it maintains bone and cartilage /health, collagen production, and th health of skin, gums, and/ teeth. Moreover, Vitamin C acts as an /antioxidant, protects cells from oxidativestress, enhances iron absorption, /and supports cardiovascular/ health. The supplement is enriched with rosehipextract (Rosa canina), offering a wide /range of /beneficial effects.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/n/e//new_vitamin_c.png", "Vitamin C (L-ascorbic acid), rosehip extract (Rosa canina), filler(microcrystalline //cellulose), anti-caking agent (magnesium stearate).", "GymBeam", "Vitamin C 1000mg 180 Tablets", 35.99m, "Supplement" },
                    { 5, "A multi-component whey protein powder, derived from the milk of free-range cows,containing /a /combination of whey concentrate, isolate, and hydrolysate, boasting an impressive 74.8% proteincontent,/ /providing 22.4g of protein per serving, including all essential amino acids and BCAAs, making it an ideal choice to /meet protein intake needs, supporting muscle growth and preservation, with high /bioavailabilit and easy /digestibility, enriched with selected vitamins and minerals, promoting muscle /function and bonehealth, positively /impacting optimal testosterone levels, aiding in reducing fatigue /and tiredness, supportingproper immune function, /offering a delightful taste and easy solubility, /containing only natural flavors andcolors, a great way to enrich /cereals and other dishes with high-/quality protein, suitable for athletes and al active individuals, perfect for /post-workout or anytime /during the day.", "Just Whey Protein is a multi-component whey protein powder that effectivelysupports //protein intake after workouts or at any other time of the day, containing a unique combination ofwhey /protein /concentrate, isolate, and hydrolysate, ensuring high absorbability and bioavailability for the body, providing 18% /EPA and 12% DHA, supporting cardiovascular functions, brain functions, and good /vision,enriched with vitamin E, /respecting nature and produced from the milk of free-range cows, with /added enzymesfor better nutrient absorption, /containing 74.8% protein content, supporting muscle growth/ and maintenance,beneficial for athletes, active /individuals, and those on a weight loss or recovery /journey, enriched withvitamins and minerals like B6, magnesium,/ and zinc, easily consumed in various /ways and delicious flavors,suitable for a healthy lifestyle.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/j/u//just_whey_unflavored_1_kg_gymbeam_1.png", "Whey protein concentrate powder, whey protein isolate powder, protein hydrolysate, minerals/ (magnesium citrate, zinc oxide), vitamins (vitamin E - tocopheryl acetate, vitamin B6 - pyridoxine /hydrochloride), DigeZyme® - a complex of digestive enzymes, bromelain.", "GymBeam", "Just Whey 1kg", 99.99m, "Supplement" },
                    { 6, "100% Creatine monohydrate, a highly researched nutritional supplement, enhancesphysical //performance during short bursts of intense exercises, making it suitable for strength athletes andteam /sport /enthusiasts; it comes in a soluble powder form that can be easily mixed with water, juice, or /postworkout protein /shakes.", "100% Creatine monohydrate is a popular supplement known for enhancing physical performance /in short, intense exercises, making it highly favored by athletes, including strength trainers,team //sport enthusiasts, and HIIT practitioners. It is a naturally occurring substance in the body, and supplementing with/ creatine powder ensures easy intake of the recommended daily dose of at least 3 /grams,supporting improved exercise/ performance without the need for cycling or time-limited usage.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/c/r//creatinemonohydrate_500_1.jpg", "Unflavored: Creatine monohydrate", "GymBeam", "Creatine Monohydrate 500g", 39.99m, "Supplement" }
                });

            migrationBuilder.InsertData(
                table: "WearCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "T-Shirts" },
                    { 2, "Hoodies" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"), new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2") },
                    { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff") },
                    { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554") },
                    { new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"), new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9") }
                });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "Color", "Description", "Fabric", "ImageUrl", "Name", "Price", "Size", "Type", "WearCategoryId" },
                values: new object[,]
                {
                    { 1, "Black", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great rangeof  //motion to get you through your workout in total comfort.", "Cutton", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-black.jpg", "Hardcore T-shirt Black", 29.99m, "S", "Wear", 1 },
                    { 2, "White", "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great rangeof  //motion to get you through your workout in total comfort.", "Cutton", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white.jpg", "Hardcore T-shirt White", 29.99m, "S", "Wear", 1 },
                    { 3, "Black", "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range o  //motion to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg?width=800&height=800&hash=1600", "Gym Warrior T-shirt Black", 29.99m, "S", "Wear", 1 },
                    { 4, "Black", "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range ofmotion  //to get you through your workout in total comfort.", "Cutton", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeatt- //shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit", "The Cicle T-shirt Black", 29.99m, "S", "Wear", 1 },
                    { 5, "Black", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion/ to get you through your workout in total comfort.", "Cutton", "https://www.hard-wear.com/media/catalog/product/cache/74aab73cb060cf90b1e98012d0101b9a/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg", "Hardcore Hoodie Black", 49.99m, "S", "Wear", 2 },
                    { 6, "White", "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion/ to get you through your workout in total comfort.", "Cutton", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-HardcoreSportswear-//Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg", "Hardcore Hoodie White", 49.99m, "S", "Wear", 2 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Benefit", "CategoryId", "Execution", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "The leg press enables you to exert more force using only your legs, providing a squat-like motion/ without placing weight on your spine or torso, making it ideal for high-rep sets and drop sets.", 1, "Sit in the leg press seat, and place your feet in the middle of the sled, about shoulder-width /apart. Press the sled out of the rack, lower the safety bars, and then slowly lower the sled towardsyour //chest until your thighs break 90 degrees. Press the sled back up but do not lock out your knees. If your lower back /or hips lift off the seat as you drive the weight back up, you’re going too far down.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Sled-45-degree-Leg-Press-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4", "Leg Press" },
                    { 2, "The hack squat, being a machine, offers enhanced stability compared to free-weight squat /variations, its predefined path reducing the risk of injury and accommodating pre-existing injuries.", 1, "Your stance on the foot platform will closely mimic that of your back squat stance. Youwant //your feet slightly outside shoulder width with feet angled slightly outward — they should be in linewith /the knee /as it tracks forward during the descent. \r\n\r\nYour torso should be stable with yourabdominals/ engaged and your /lower back flat on the back pad. Maintain a neutral head position as you lower you body/ until the bottoms of your /thighs are parallel to the foot platform and drive through your feet to the top.", "https://www.bodybuildingmealplan.com/wp-content/uploads/Hack-Squat-Muscles-Worked.jpg", "Hack Squat" },
                    { 3, "The barbell curl, with its simple and effective mechanics, has a small learning curve,making /it /ideal for beginners, while still providing benefits to more advanced lifters, allowing them to loadtheir /biceps/ with heavier weights and build stronger biceps more quickly.", 2, "With an underhand grip slightly wider than the shoulders, grab a barbell, pull yourshoulders //back, and position your elbows under your shoulder joints or slightly in front by your ribs; then,curl /the barbell /up using your biceps to expose the fronts of your biceps.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/barbell-curl-resized.png?/ezimgfmt=ng%3Awebp%2Fngcb4", "Barbell Curl" },
                    { 4, "The hammer curl, with its comfortable neutral wrist position, allows for lifting heavier weights /and accumulating more muscle-building volume over time, effectively targeting the inner biceps muscleand //forearm to promote denser arms.", 2, "While standing, hold a dumbbell in each hand with wrists facing each other, tuck your arm in //at your sides, and flex your elbows to curl the dumbbells up towards your shoulders, then lower them back down with /control.", "https://weighttraining.guide/wp-content/uploads/2016/11/Dumbbell-Hammer-Curl-resized.png", "Hammer Curl" },
                    { 5, "This exercise offers versatility with options such as barbells, kettlebells, or dumbbells, making/ it a versatile triceps exercise that capitalizes on your strength in this position, leading to significant /triceps strength gains.", 3, "Begin by lying on a bench with the hands supporting a weight (barbell, dumbbells, orcable //attachments) at the top of the bench pressing position, aligning the back and hips as in a bench press; slightly /pull the elbows back, pointing them behind you, as you lower the bar handle or loads towards your/head, almost /touching the forehead, experiencing a stretch on the triceps and partial engagement of the /lats,and finally, push /the bar back up.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/12/Decline-Skull-crusher-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4", "Skullcrusher" },
                    { 6, "This exercise allows for complete isolation of the triceps, providing the ability to feelthe //muscle contract and achieve a satisfying pump.", 3, "Set the cables or band at a high anchor point, face your body towards it, place yourfeet //together, keep your elbows by your sides, chest up, back flat, and hips angled slightly forward, thengrab/ the /handles or band and push them down by fully extending your elbows, ensuring that your elbows are slightly in front /of your shoulders.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Triceps-Rope-Pushdown-resized.png?/ezimgfmt=ng%3Awebp%2Fngcb4", "Triceps Pushdown" },
                    { 7, "Using two separate dumbbells for pressing exercises allows for easier customization of a /comfortable position, particularly beneficial for individuals with shoulder or elbow discomfort, while /also promoting enhanced joint and muscle stability; furthermore, the individual effort required by each /side helps balance any strength disparities and enables weaker sides of the body to catch up.", 4, "Begin by sitting on a flat bench and hinging forward to pick up each dumbbell, placingthem /on /your knees; after getting set, lean back and drive the dumbbells back towards you using your knees,while //simultaneously pressing the weights over your chest, then lower the weights with elbows tucked at a 45-degree angle /until they break 90 degrees, followed by driving the dumbbells back up, optionally /transitioningto a neutral grip /position with palms facing each other for the press.", "https://fitnessvolt.com/wp-content/uploads/2018/04/dumbbell-bench-press.jpg", "Dumbbell Bench Press" },
                    { 8, "The bent-over row can be effectively executed using tools like kettlebells, dumbbells, ora /cable/ machine, allowing for efficient muscle overload as you can handle significant weight in the bent-overrow/ /position.", 5, "To perform the barbell bent-over row, set up in a deadlift position with feet shoulderwidth //apart in front of a loaded barbell, hinge at the hips to achieve a parallel torso to the floor, gripthe /barbell /slightly wider than your typical deadlift grip, lean back to distribute weight on your heels, and initiate the row /by pulling with your elbow until the barbell touches around your belly button, ensuring /thebarbell doesn't touch /the floor between repetitions, and considering a wider grip or a more upright /torso forindividuals with longer /arms.", "https://weighttraining.guide/wp-content/uploads/2016/10/Bent-over-barbell-row.png", "Bent-Over Row" },
                    { 9, "Engaging both forearm extensors and flexors, the wrist roller exercise strengthens these muscles /while the thick grip enhances grip strength, requiring focused attention on the wrists and forearms,which/ /are typically secondary to the primary movers.", 6, "Begin with a 2.5, five, or 10-pound weight plate, stand with feet hip-width apart, gripthe //wrist roller with knuckles facing towards you, gradually execute a front raise to elevate the roller to shoulder /height, roll the weight up while alternating hands until fully wound, and then slowly reverse the/movement.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2022/11/Wrist-roller.png?ezimgfmt=ng%/3Awebp%2Fngcb4", "Wrist Roller" },
                    { 10, "By resisting gravity and rotational forces, the L-sit exercise enhances full-bodystrength, //demanding significant isometric strength while stimulating exceptional abdominal strength andstability, /making it a/ valuable core strengthening exercise that prepares lifters and gymnastic athletes formore /challenging athletic /movements.", 7, "Sit between two dumbbells or kettlebells, placing each hand on a handle, then elevateyour /body/ off the floor by extending your legs and maintain an isometric hold, ensuring tension in the middleand /upper /back.", "https://weighttraining.guide/wp-content/uploads/2021/10/Floor-L-sit-fixed.png", "L-Sit" },
                    { 11, "The dumbbell shoulder press targets and develops muscles in the shoulders, triceps, biceps,and //upper back, leading to improvements in overall upper body physique, and as a compound exercise utilizing multiple /joints and muscles simultaneously, it is more effective in producing results compared to /isolationexercises.", 8, "Begin by grabbing a pair of dumbbells and lifting them to the starting position at your /shoulders, lightly brace your core while inhaling, press the dumbbells up to straight arms while exhaling,/inhale at/ the top or during controlled lowering back to your shoulders, and repeat for the desired number/ ofrepetitions.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Dumbbell-Shoulder-Press-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4", "Dumbbell Shoulder Press" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersExercises_ExerciseId",
                table: "ApplicationUsersExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersFoods_FoodId",
                table: "ApplicationUsersFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsersTrainingPlans_TrainingPlanId",
                table: "ApplicationUsersTrainingPlans",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_WearCategoryId",
                table: "Clothes",
                column: "WearCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CategoryId",
                table: "Exercises",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_UserId",
                table: "ShoppingCart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_CategoryId",
                table: "TrainingPlans",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "ApplicationUsersExercises");

            migrationBuilder.DropTable(
                name: "ApplicationUsersFoods");

            migrationBuilder.DropTable(
                name: "ApplicationUsersTrainingPlans");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "Supplements");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "UsersFoods");

            migrationBuilder.DropTable(
                name: "TrainingPlans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "WearCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
