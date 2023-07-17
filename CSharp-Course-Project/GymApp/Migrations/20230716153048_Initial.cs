using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Age = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                    Calories = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Carbs = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Fat = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Protein = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
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
                        name: "FK_ApplicationUsersFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
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
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Legs" },
                    { 2, "Biceps" },
                    { 3, "Triceps" },
                    { 4, "Chest" },
                    { 5, "Back" },
                    { 6, "Forearms" },
                    { 7, "Abs" },
                    { 8, "Shoulders" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Calories", "Carbs", "Fat", "Name", "Protein" },
                values: new object[] { 1, 52, 13.800000000000001, 0.20000000000000001, "Apple", 0.29999999999999999 });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Calories", "Fat", "Name", "Protein" },
                values: new object[] { 2, 153, 3.6000000000000001, "Chicken Fillet", 30.199999999999999 });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Benefit", "CategoryId", "Execution", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "The leg press enables you to exert more force using only your legs, providing a squat-like motion without placing weight on your spine or torso, making it ideal for high-rep sets and drop sets.", 1, "Sit in the leg press seat, and place your feet in the middle of the sled, about shoulder-width apart. Press the sled out of the rack, lower the safety bars, and then slowly lower the sled towards your chest until your thighs break 90 degrees. Press the sled back up but do not lock out your knees. If your lower back or hips lift off the seat as you drive the weight back up, you’re going too far down.", "https://weighttraining.guide/wp-content/uploads/2016/05/Sled-45-degree-Leg-Press-resized.png", "Leg Press" },
                    { 2, "The hack squat, being a machine, offers enhanced stability compared to free-weight squat variations, its predefined path reducing the risk of injury and accommodating pre-existing injuries.", 1, "Your stance on the foot platform will closely mimic that of your back squat stance. You want your feet slightly outside shoulder width with feet angled slightly outward — they should be in line with the knee as it tracks forward during the descent. \r\n\r\nYour torso should be stable with your abdominals engaged and your lower back flat on the back pad. Maintain a neutral head position as you lower your body until the bottoms of your thighs are parallel to the foot platform and drive through your feet to the top.", "https://www.bodybuildingmealplan.com/wp-content/uploads/Hack-Squat-Muscles-Worked.jpg", "Hack Squat" },
                    { 3, "The barbell curl, with its simple and effective mechanics, has a small learning curve, making it ideal for beginners, while still providing benefits to more advanced lifters, allowing them to load their biceps with heavier weights and build stronger biceps more quickly.", 2, "With an underhand grip slightly wider than the shoulders, grab a barbell, pull your shoulders back, and position your elbows under your shoulder joints or slightly in front by your ribs; then, curl the barbell up using your biceps to expose the fronts of your biceps.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/barbell-curl-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4", "Barbell Curl" },
                    { 4, "The hammer curl, with its comfortable neutral wrist position, allows for lifting heavier weights and accumulating more muscle-building volume over time, effectively targeting the inner biceps muscle and forearm to promote denser arms.", 2, "While standing, hold a dumbbell in each hand with wrists facing each other, tuck your arms in at your sides, and flex your elbows to curl the dumbbells up towards your shoulders, then lower them back down with control.", "https://weighttraining.guide/wp-content/uploads/2016/11/Dumbbell-Hammer-Curl-resized.png", "Hammer Curl" },
                    { 5, "This exercise offers versatility with options such as barbells, kettlebells, or dumbbells, making it a versatile triceps exercise that capitalizes on your strength in this position, leading to significant triceps strength gains.", 3, "Begin by lying on a bench with the hands supporting a weight (barbell, dumbbells, or cable attachments) at the top of the bench pressing position, aligning the back and hips as in a bench press; slightly pull the elbows back, pointing them behind you, as you lower the bar handle or loads towards your head, almost touching the forehead, experiencing a stretch on the triceps and partial engagement of the lats, and finally, push the bar back up.", "https://www.fitliferegime.com/wp-content/uploads/2022/03/Barbell-Skull-Crushers.jpg?ezimgfmt=rs:382x215/rscb1/ngcb1/notWebP", "Skullcrusher" },
                    { 6, "This exercise allows for complete isolation of the triceps, providing the ability to feel the muscle contract and achieve a satisfying pump.", 3, "Set the cables or band at a high anchor point, face your body towards it, place your feet together, keep your elbows by your sides, chest up, back flat, and hips angled slightly forward, then grab the handles or band and push them down by fully extending your elbows, ensuring that your elbows are slightly in front of your shoulders.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Triceps-Rope-Pushdown-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4", "Triceps Pushdown" },
                    { 7, "Using two separate dumbbells for pressing exercises allows for easier customization of a comfortable position, particularly beneficial for individuals with shoulder or elbow discomfort, while also promoting enhanced joint and muscle stability; furthermore, the individual effort required by each side helps balance any strength disparities and enables weaker sides of the body to catch up.", 4, "Begin by sitting on a flat bench and hinging forward to pick up each dumbbell, placing them on your knees; after getting set, lean back and drive the dumbbells back towards you using your knees, while simultaneously pressing the weights over your chest, then lower the weights with elbows tucked at a 45-degree angle until they break 90 degrees, followed by driving the dumbbells back up, optionally transitioning to a neutral grip position with palms facing each other for the press.", "https://fitnessvolt.com/wp-content/uploads/2018/04/dumbbell-bench-press.jpg", "Dumbbell Bench Press" },
                    { 8, "The bent-over row can be effectively executed using tools like kettlebells, dumbbells, or a cable machine, allowing for efficient muscle overload as you can handle significant weight in the bent-over row position.", 5, "To perform the barbell bent-over row, set up in a deadlift position with feet shoulder-width apart in front of a loaded barbell, hinge at the hips to achieve a parallel torso to the floor, grip the barbell slightly wider than your typical deadlift grip, lean back to distribute weight on your heels, and initiate the row by pulling with your elbow until the barbell touches around your belly button, ensuring the barbell doesn't touch the floor between repetitions, and considering a wider grip or a more upright torso for individuals with longer arms.", "https://weighttraining.guide/wp-content/uploads/2016/10/Bent-over-barbell-row.png", "Bent-Over Row" },
                    { 9, "Engaging both forearm extensors and flexors, the wrist roller exercise strengthens these muscles while the thick grip enhances grip strength, requiring focused attention on the wrists and forearms, which are typically secondary to the primary movers.", 6, "Begin with a 2.5, five, or 10-pound weight plate, stand with feet hip-width apart, grip the wrist roller with knuckles facing towards you, gradually execute a front raise to elevate the roller to shoulder height, roll the weight up while alternating hands until fully wound, and then slowly reverse the movement.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2022/11/Wrist-roller.png?ezimgfmt=ng%3Awebp%2Fngcb4", "Wrist Roller" },
                    { 10, "By resisting gravity and rotational forces, the L-sit exercise enhances full-body strength, demanding significant isometric strength while stimulating exceptional abdominal strength and stability, making it a valuable core strengthening exercise that prepares lifters and gymnastic athletes for more challenging athletic movements.", 7, "Sit between two dumbbells or kettlebells, placing each hand on a handle, then elevate your body off the floor by extending your legs and maintain an isometric hold, ensuring tension in the middle and upper back.", "https://weighttraining.guide/wp-content/uploads/2021/10/Floor-L-sit-fixed.png", "L-Sit" },
                    { 11, "The dumbbell shoulder press targets and develops muscles in the shoulders, triceps, biceps, and upper back, leading to improvements in overall upper body physique, and as a compound exercise utilizing multiple joints and muscles simultaneously, it is more effective in producing results compared to isolation exercises.", 8, "Begin by grabbing a pair of dumbbells and lifting them to the starting position at your shoulders, lightly brace your core while inhaling, press the dumbbells up to straight arms while exhaling, inhale at the top or during controlled lowering back to your shoulders, and repeat for the desired number of repetitions.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Dumbbell-Shoulder-Press-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4", "Dumbbell Shoulder Press" }
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
                name: "IX_Exercises_CategoryId",
                table: "Exercises",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlans_CategoryId",
                table: "TrainingPlans",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "TrainingPlans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
