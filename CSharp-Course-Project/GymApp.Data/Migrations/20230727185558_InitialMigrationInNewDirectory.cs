using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class InitialMigrationInNewDirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsModerator",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessoryCartItems",
                columns: table => new
                {
                    AccessoryId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryCartItems", x => new { x.CartId, x.AccessoryId });
                    table.ForeignKey(
                        name: "FK_AccessoryCartItems_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessoryCartItems_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: true),
                    City = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplementCartItems",
                columns: table => new
                {
                    SupplementId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplementCartItems", x => new { x.CartId, x.SupplementId });
                    table.ForeignKey(
                        name: "FK_SupplementCartItems_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplementCartItems_Supplements_SupplementId",
                        column: x => x.SupplementId,
                        principalTable: "Supplements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WearCartItems",
                columns: table => new
                {
                    WearId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WearCartItems", x => new { x.CartId, x.WearId });
                    table.ForeignKey(
                        name: "FK_WearCartItems_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WearCartItems_Clothes_WearId",
                        column: x => x.WearId,
                        principalTable: "Clothes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "The 4-layer leather belt with an adjustable section provides stability and durabilitywhile //ensuring comfort, offering support during weightlifting and is suitable for individuals engaging inheavy/ /lifting.", "The LEVER weightlifting belt is a practical device designed for individuals engaged in /strength training, aiming to increase the weights they lift; it helps stabilize the core and lower back muscles, /boosting your confidence and enabling you to lift heavier weights. Made from 4-layered material /- 2inner layers /of cowhide and suede covered with 2 outer layers of buffalo suede - it ensures stability/ anddurability while /fitting perfectly to your body; the belt also features an adjustable section to /accommodateyour waist size, /eliminating concerns about it being too large or small. If you want to /enhance the weightslifted during squats or/ deadlifts, this high-quality leather belt should undoubtedly /be part of your fitnessarsenal.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/w/e//weightlifting-belt-lever-gymbeam_5_.jpg" });

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "The Ronnie fitness gloves protect hands from injuries, calluses, and abrasions, providinga //secure grip during workouts with fitness equipment, bars, or weights; they are perfect for strength training, have/ an ergonomic shape for long-lasting durability, and fit hands comfortably without /squeezingfingers.", "The Ronnie fitness gloves are high-quality exercise gloves made of split leather witha //rubber-padded cowhide interior for an ideal fit and intense workout protection for every athlete; they /are reinforced with a double lining in the palm area for durability and resistance against wear, designed/ for professional athletes seeking superior hand protection during training, guarding against scratches, /calluses,and /impacts while providing a secure grip on workout equipment, but they should not be machine /washed.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/r/u//rukavice_2j_1.jpg" });

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "This 700ml shaker, made of high-quality polypropylene PP, is perfect for mixing allsoluble //dietary supplements, featuring a leak-proof screw-on lid, a cone-shaped filter to prevent lumps, milliliter (ml) /and ounce (oz) markings, break-resistant, dishwasher, microwave, and fridge safe, BPA and/ DEHPfree, and compliant/ with food regulations.", "The green shaker is a classic 700ml shaker with a traditional closure and filter,perfect //for mixing your favorite proteins, pre-workout stimulants, and creatine; made of non-toxic plasticand /free from /BPA and DEHP.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/s/h//shaker_yellow_green.jpg" });

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "Made of 100% cotton, this towel has anti-static and antibacterial properties, driesquickly, //absorbs efficiently, feels soft and pleasant to touch, and boasts a long lifespan.", "This gray fitness and workout towel, made of 100% soft and pleasant-to-touch cotton, stands /out with its excellent absorption, high durability, and anti-static, antibacterial properties. With /dimensions of 50x90 cm, this towel possesses these qualities naturally, without the use of any chemical compounds,/ making it suitable for individuals with sensitive skin or allergies, as it does not cause /allergicreactions. /Every athlete recognizes the significance of a workout towel, an essential accessory /in the gym, no only to wipe /away sweat from the face but also to provide a clean surface for various /exercises, such as forabdominal /workouts, seating, or under the feet during exercises. Not having a /workout towel in the gym is apure faux pas /(embarrassing mistake) and can easily be avoided to prevent /someone from asking, \"Where is yourtowel?\"", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/g/r//grey_fitness_towel_gymbeam_1_.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great rangeof  //motion to get you through your workout in total comfort.");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great rangeof  //motion to get you through your workout in total comfort.", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-/white-510x510.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range o  //motion to get you through your workout in total comfort.", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg?width=800&height=800&hash=1600" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range ofmotion  //to get you through your workout in total comfort.", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeatt- //shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion/ to get you through your workout in total comfort.", "https://www.hard-wear.com/media/catalog/product/cacheb8bf61042c9b806ea0edf19101a0211e/1/0/100-//hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion/ to get you through your workout in total comfort.", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-HardcoreSportswear-//Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "The leg press enables you to exert more force using only your legs, providing a squat-like motion/ without placing weight on your spine or torso, making it ideal for high-rep sets and drop sets.", "Sit in the leg press seat, and place your feet in the middle of the sled, about shoulder-width /apart. Press the sled out of the rack, lower the safety bars, and then slowly lower the sled towardsyour //chest until your thighs break 90 degrees. Press the sled back up but do not lock out your knees. If your lower back /or hips lift off the seat as you drive the weight back up, you’re going too far down.", "https://weighttraining.guide/wp-content/uploads/2016/05/Sled-45-degree-Leg-Pressresized.png" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "The hack squat, being a machine, offers enhanced stability compared to free-weight squat /variations, its predefined path reducing the risk of injury and accommodating pre-existing injuries.", "Your stance on the foot platform will closely mimic that of your back squat stance. Youwant //your feet slightly outside shoulder width with feet angled slightly outward — they should be in linewith /the knee /as it tracks forward during the descent. \r\n\r\nYour torso should be stable with yourabdominals/ engaged and your /lower back flat on the back pad. Maintain a neutral head position as you lower you body/ until the bottoms of your /thighs are parallel to the foot platform and drive through your feet to the top." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "The barbell curl, with its simple and effective mechanics, has a small learning curve,making /it /ideal for beginners, while still providing benefits to more advanced lifters, allowing them to loadtheir /biceps/ with heavier weights and build stronger biceps more quickly.", "With an underhand grip slightly wider than the shoulders, grab a barbell, pull yourshoulders //back, and position your elbows under your shoulder joints or slightly in front by your ribs; then,curl /the barbell /up using your biceps to expose the fronts of your biceps.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/barbell-curl-resized.png?/ezimgfmt=ng%3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "The hammer curl, with its comfortable neutral wrist position, allows for lifting heavier weights /and accumulating more muscle-building volume over time, effectively targeting the inner biceps muscleand //forearm to promote denser arms.", "While standing, hold a dumbbell in each hand with wrists facing each other, tuck your arm in //at your sides, and flex your elbows to curl the dumbbells up towards your shoulders, then lower them back down with /control." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "This exercise offers versatility with options such as barbells, kettlebells, or dumbbells, making/ it a versatile triceps exercise that capitalizes on your strength in this position, leading to significant /triceps strength gains.", "Begin by lying on a bench with the hands supporting a weight (barbell, dumbbells, orcable //attachments) at the top of the bench pressing position, aligning the back and hips as in a bench press; slightly /pull the elbows back, pointing them behind you, as you lower the bar handle or loads towards your/head, almost /touching the forehead, experiencing a stretch on the triceps and partial engagement of the /lats,and finally, push /the bar back up.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2018/06/decline-ez-bar-skullcrusher-//resized.png?ezimgfmt=ng%3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "This exercise allows for complete isolation of the triceps, providing the ability to feelthe //muscle contract and achieve a satisfying pump.", "Set the cables or band at a high anchor point, face your body towards it, place yourfeet //together, keep your elbows by your sides, chest up, back flat, and hips angled slightly forward, thengrab/ the /handles or band and push them down by fully extending your elbows, ensuring that your elbows are slightly in front /of your shoulders.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Triceps-Rope-Pushdown-resized.png?/ezimgfmt=ng%3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "Using two separate dumbbells for pressing exercises allows for easier customization of a /comfortable position, particularly beneficial for individuals with shoulder or elbow discomfort, while /also promoting enhanced joint and muscle stability; furthermore, the individual effort required by each /side helps balance any strength disparities and enables weaker sides of the body to catch up.", "Begin by sitting on a flat bench and hinging forward to pick up each dumbbell, placingthem /on /your knees; after getting set, lean back and drive the dumbbells back towards you using your knees,while //simultaneously pressing the weights over your chest, then lower the weights with elbows tucked at a 45-degree angle /until they break 90 degrees, followed by driving the dumbbells back up, optionally /transitioningto a neutral grip /position with palms facing each other for the press." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "The bent-over row can be effectively executed using tools like kettlebells, dumbbells, ora /cable/ machine, allowing for efficient muscle overload as you can handle significant weight in the bent-overrow/ /position.", "To perform the barbell bent-over row, set up in a deadlift position with feet shoulderwidth //apart in front of a loaded barbell, hinge at the hips to achieve a parallel torso to the floor, gripthe /barbell /slightly wider than your typical deadlift grip, lean back to distribute weight on your heels, and initiate the row /by pulling with your elbow until the barbell touches around your belly button, ensuring /thebarbell doesn't touch /the floor between repetitions, and considering a wider grip or a more upright /torso forindividuals with longer /arms." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "Engaging both forearm extensors and flexors, the wrist roller exercise strengthens these muscles /while the thick grip enhances grip strength, requiring focused attention on the wrists and forearms,which/ /are typically secondary to the primary movers.", "Begin with a 2.5, five, or 10-pound weight plate, stand with feet hip-width apart, gripthe //wrist roller with knuckles facing towards you, gradually execute a front raise to elevate the roller to shoulder /height, roll the weight up while alternating hands until fully wound, and then slowly reverse the/movement.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2022/11/Wrist-roller.png?ezimgfmt=ng%/3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "By resisting gravity and rotational forces, the L-sit exercise enhances full-bodystrength, //demanding significant isometric strength while stimulating exceptional abdominal strength andstability, /making it a/ valuable core strengthening exercise that prepares lifters and gymnastic athletes formore /challenging athletic /movements.", "Sit between two dumbbells or kettlebells, placing each hand on a handle, then elevateyour /body/ off the floor by extending your legs and maintain an isometric hold, ensuring tension in the middleand /upper /back." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "The dumbbell shoulder press targets and develops muscles in the shoulders, triceps, biceps,and //upper back, leading to improvements in overall upper body physique, and as a compound exercise utilizing multiple /joints and muscles simultaneously, it is more effective in producing results compared to /isolationexercises.", "Begin by grabbing a pair of dumbbells and lifting them to the starting position at your /shoulders, lightly brace your core while inhaling, press the dumbbells up to straight arms while exhaling,/inhale at/ the top or during controlled lowering back to your shoulders, and repeat for the desired number/ ofrepetitions.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Dumbbell-Shoulder-Press-/resized.png?ezimgfmt=ng%3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "The most biologically accessible form of calcium, enriched with vitamin D2, magnesium, copper,/ zinc, and manganese, ensures the health of muscles, bones, and teeth, participates in blood clotting, /supports proper neurotransmission, guarantees immune function, and promotes the well-being of hair, /nails, andskin,/ conveniently available in tablet form and suitable for vegetarians and vegans.", "Calcium citrate, in tablet form, is the most biologically accessible form ofcalcium, //ensuring optimal health for muscles, bones, and teeth, while also participating in blood clottingand /supporting /proper neurotransmission. Additionally, it is enriched with other beneficial electrolytes /suchas vitamin D2, /magnesium, copper, manganese, and zinc, which play crucial roles in bone metabolism,/ reducefatigue, support immune /and nervous system health, promote healthy hair, nails, and skin, and /protect cellsfrom oxidative stress, making /the product suitable for vegans and vegetarians.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/u/n//untitled_design_-_2020-04-03t164935.609.png", "Hydroxypropyl cellulose, vegetable coating, croscarmellose sodium, silicondioxide, //magnesium stearate (vegetable source), and stearic acid (vegetable source)." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "500 mg of Ashwagandha (Withania somnifera) extract, containing 5% of active compounds called /withanolides, classified as adaptogens, may help enhance the body's resilience and aid in betterstress //management, available in convenient capsule form.", "Ashwagandha or Indian Ginseng (Withania somnifera) is a plant classified among adaptogens, /compounds known for their beneficial effects on the body, particularly in increasing itsresilience /and /improving the adaptation process to stress. Similar to how our muscles become stronger and growwhen we //exercise, adaptogens can enhance the body's resistance to stress and aid in better stress management. It's no wonder/ that Ashwagandha is popular among individuals experiencing daily stress at work, school, /or intheir personal /lives. However, its benefits don't end there; this plant is still being researched /by scientifi institutions for /its potential positive effects in reducing anxiety, fatigue, lowering the/ stress hormonecortisol, and enhancing /athletic performance, strength, and sleep. Additionally, it may /support our mentalwell-being and aid in /relaxation.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/a/s//ashwagandha_90_caps.png", "Ashwagandha extract (Withania somnifera) (5% withanolides), anti-caking agent(calcium //phosphate, magnesium stearate), gelatin capsule." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "This dietary supplement, containing this essential mineral, participates in hundredsof //biological processes, supporting proper carbohydrate metabolism, bone health, protein synthesis, maintaining normal /testosterone levels, enhancing fertility and reproductive function, promoting healthy/ skin,hair, and nails, /supporting good vision, boosting the immune system, influencing proper /metabolism of fattyacids, aiding in DNA /synthesis, maintaining cognitive functions, affecting the /metabolism of vitamin A,protecting cells against /oxidative stress, and suitable for vegans, making it /ideal for anyone striving tomaintain optimal health.", "Zinc is an essential mineral found in many food supplements, vital for hundreds of /biological processes in the body, supporting proper metabolism of macronutrients like carbohydrates, /crucialfor /energy supply to athletes and active individuals. It also aids in maintaining bone health, /proteinsynthesis for /muscle growth, and has a positive impact on testosterone levels in men. Zinc plays/ a vital rolein various bodily /processes, positively affecting muscle size and strength, fertility, and/ reproductivefunction, benefiting skin, /hair, and nails for women, and supporting vision for those /spending time in front o screens. Additionally, as an /antioxidant, zinc protects cells against /oxidative stress, boosts the immunesystem, aids in fat metabolism, DNA /synthesis, cognitive functions, /and vitamin A metabolism, making it anideal supplement for overall health and /suitable for vegans.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/z/i//zinc_100_tabs_gymbeam.png", "Filler (microcrystalline cellulose, calcium hydrogen phosphate), zinc oxide,coating //(stearic acid), anti-caking agent (magnesium stearate)." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "This supplement contains 1000 mg of ascorbic acid (Vitamin C), offered in easy-toswallow //tablets, supporting the proper functioning of the immune and nervous systems, promoting mentalbalance, /reducing /fatigue, maintaining energy metabolism, bone and cartilage health, collagen production,skin, /gum, and teeth /function, protecting cells from oxidative stress, enhancing iron absorption, and supporting cardiovascular health, /enriched with rosehip extract, promoting overall health and /vitality.", "Vitamin C 1000 mg, also known as L-ascorbic acid, is an essential vitamin found ineasy-/to-/swallow tablets and commonly present in various fruits and vegetables. It participates in numerous biological /processes, making it one of the most popular supplements supporting overall health and /vitality.Vitamin C /contributes to the proper functioning of the immune and nervous systems, supports /immunity during an after intense /physical activity, promotes mental balance, reduces fatigue, and aids /in energy metabolism fordaily activities and /sports. Additionally, it maintains bone and cartilage /health, collagen production, and th health of skin, gums, and/ teeth. Moreover, Vitamin C acts as an /antioxidant, protects cells from oxidativestress, enhances iron absorption, /and supports cardiovascular/ health. The supplement is enriched with rosehipextract (Rosa canina), offering a wide /range of /beneficial effects.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/n/e//new_vitamin_c.png", "Vitamin C (L-ascorbic acid), rosehip extract (Rosa canina), filler(microcrystalline //cellulose), anti-caking agent (magnesium stearate)." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "A multi-component whey protein powder, derived from the milk of free-range cows,containing /a /combination of whey concentrate, isolate, and hydrolysate, boasting an impressive 74.8% proteincontent,/ /providing 22.4g of protein per serving, including all essential amino acids and BCAAs, making it an ideal choice to /meet protein intake needs, supporting muscle growth and preservation, with high /bioavailabilit and easy /digestibility, enriched with selected vitamins and minerals, promoting muscle /function and bonehealth, positively /impacting optimal testosterone levels, aiding in reducing fatigue /and tiredness, supportingproper immune function, /offering a delightful taste and easy solubility, /containing only natural flavors andcolors, a great way to enrich /cereals and other dishes with high-/quality protein, suitable for athletes and al active individuals, perfect for /post-workout or anytime /during the day.", "Just Whey Protein is a multi-component whey protein powder that effectivelysupports //protein intake after workouts or at any other time of the day, containing a unique combination ofwhey /protein /concentrate, isolate, and hydrolysate, ensuring high absorbability and bioavailability for the body, providing 18% /EPA and 12% DHA, supporting cardiovascular functions, brain functions, and good /vision,enriched with vitamin E, /respecting nature and produced from the milk of free-range cows, with /added enzymesfor better nutrient absorption, /containing 74.8% protein content, supporting muscle growth/ and maintenance,beneficial for athletes, active /individuals, and those on a weight loss or recovery /journey, enriched withvitamins and minerals like B6, magnesium,/ and zinc, easily consumed in various /ways and delicious flavors,suitable for a healthy lifestyle.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/j/u//just_whey_unflavored_1_kg_gymbeam_1.png", "Whey protein concentrate powder, whey protein isolate powder, protein hydrolysate, minerals/ (magnesium citrate, zinc oxide), vitamins (vitamin E - tocopheryl acetate, vitamin B6 - pyridoxine /hydrochloride), DigeZyme® - a complex of digestive enzymes, bromelain." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "100% Creatine monohydrate, a highly researched nutritional supplement, enhancesphysical //performance during short bursts of intense exercises, making it suitable for strength athletes andteam /sport /enthusiasts; it comes in a soluble powder form that can be easily mixed with water, juice, or /postworkout protein /shakes.", "100% Creatine monohydrate is a popular supplement known for enhancing physical performance /in short, intense exercises, making it highly favored by athletes, including strength trainers,team //sport enthusiasts, and HIIT practitioners. It is a naturally occurring substance in the body, and supplementing with/ creatine powder ensures easy intake of the recommended daily dose of at least 3 /grams,supporting improved exercise/ performance without the need for cycling or time-limited usage.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/c/r//creatinemonohydrate_500_1.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoryCartItems_AccessoryId",
                table: "AccessoryCartItems",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplementCartItems_SupplementId",
                table: "SupplementCartItems",
                column: "SupplementId");

            migrationBuilder.CreateIndex(
                name: "IX_WearCartItems_WearId",
                table: "WearCartItems",
                column: "WearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryCartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SupplementCartItems");

            migrationBuilder.DropTable(
                name: "WearCartItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsModerator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "AspNetUsers",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "The 4-layer leather belt with an adjustable section provides stability and durability while ensuring comfort, offering support during weightlifting and is suitable for individuals engaging in heavy lifting.", "The LEVER weightlifting belt is a practical device designed for individuals engaged in strength training, aiming to increase the weights they lift; it helps stabilize the core and lower back muscles, boosting your confidence and enabling you to lift heavier weights. Made from 4-layered material - 2 inner layers of cowhide and suede covered with 2 outer layers of buffalo suede - it ensures stability and durability while fitting perfectly to your body; the belt also features an adjustable section to accommodate your waist size, eliminating concerns about it being too large or small. If you want to enhance the weights lifted during squats or deadlifts, this high-quality leather belt should undoubtedly be part of your fitness arsenal.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/w/e/weightlifting-belt-lever-gymbeam_5_.jpg" });

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "The Ronnie fitness gloves protect hands from injuries, calluses, and abrasions, providing a secure grip during workouts with fitness equipment, bars, or weights; they are perfect for strength training, have an ergonomic shape for long-lasting durability, and fit hands comfortably without squeezing fingers.", "The Ronnie fitness gloves are high-quality exercise gloves made of split leather with a rubber-padded cowhide interior for an ideal fit and intense workout protection for every athlete; they are reinforced with a double lining in the palm area for durability and resistance against wear, designed for professional athletes seeking superior hand protection during training, guarding against scratches, calluses, and impacts while providing a secure grip on workout equipment, but they should not be machine washed.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/r/u/rukavice_2j_1.jpg" });

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "This 700ml shaker, made of high-quality polypropylene PP, is perfect for mixing all soluble dietary supplements, featuring a leak-proof screw-on lid, a cone-shaped filter to prevent lumps, milliliter (ml) and ounce (oz) markings, break-resistant, dishwasher, microwave, and fridge safe, BPA and DEHP-free, and compliant with food regulations.", "The green shaker is a classic 700ml shaker with a traditional closure and filter, perfect for mixing your favorite proteins, pre-workout stimulants, and creatine; made of non-toxic plastic and free from BPA and DEHP.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/s/h/shaker_yellow_green.jpg" });

            migrationBuilder.UpdateData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "Made of 100% cotton, this towel has anti-static and antibacterial properties, dries quickly, absorbs efficiently, feels soft and pleasant to touch, and boasts a long lifespan.", "This gray fitness and workout towel, made of 100% soft and pleasant-to-touch cotton, stands out with its excellent absorption, high durability, and anti-static, antibacterial properties. With dimensions of 50x90 cm, this towel possesses these qualities naturally, without the use of any chemical compounds, making it suitable for individuals with sensitive skin or allergies, as it does not cause allergic reactions. Every athlete recognizes the significance of a workout towel, an essential accessory in the gym, not only to wipe away sweat from the face but also to provide a clean surface for various exercises, such as for abdominal workouts, seating, or under the feet during exercises. Not having a workout towel in the gym is a pure faux pas (embarrassing mistake) and can easily be avoided to prevent someone from asking, \"Where is your towel?\"", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/g/r/grey_fitness_towel_gymbeam_1_.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.", "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.", "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.", "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg" });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.", "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "The leg press enables you to exert more force using only your legs, providing a squat-like motion without placing weight on your spine or torso, making it ideal for high-rep sets and drop sets.", "Sit in the leg press seat, and place your feet in the middle of the sled, about shoulder-width apart. Press the sled out of the rack, lower the safety bars, and then slowly lower the sled towards your chest until your thighs break 90 degrees. Press the sled back up but do not lock out your knees. If your lower back or hips lift off the seat as you drive the weight back up, you’re going too far down.", "https://weighttraining.guide/wp-content/uploads/2016/05/Sled-45-degree-Leg-Press-resized.png" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "The hack squat, being a machine, offers enhanced stability compared to free-weight squat variations, its predefined path reducing the risk of injury and accommodating pre-existing injuries.", "Your stance on the foot platform will closely mimic that of your back squat stance. You want your feet slightly outside shoulder width with feet angled slightly outward — they should be in line with the knee as it tracks forward during the descent. \r\n\r\nYour torso should be stable with your abdominals engaged and your lower back flat on the back pad. Maintain a neutral head position as you lower your body until the bottoms of your thighs are parallel to the foot platform and drive through your feet to the top." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "The barbell curl, with its simple and effective mechanics, has a small learning curve, making it ideal for beginners, while still providing benefits to more advanced lifters, allowing them to load their biceps with heavier weights and build stronger biceps more quickly.", "With an underhand grip slightly wider than the shoulders, grab a barbell, pull your shoulders back, and position your elbows under your shoulder joints or slightly in front by your ribs; then, curl the barbell up using your biceps to expose the fronts of your biceps.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/barbell-curl-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "The hammer curl, with its comfortable neutral wrist position, allows for lifting heavier weights and accumulating more muscle-building volume over time, effectively targeting the inner biceps muscle and forearm to promote denser arms.", "While standing, hold a dumbbell in each hand with wrists facing each other, tuck your arms in at your sides, and flex your elbows to curl the dumbbells up towards your shoulders, then lower them back down with control." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "This exercise offers versatility with options such as barbells, kettlebells, or dumbbells, making it a versatile triceps exercise that capitalizes on your strength in this position, leading to significant triceps strength gains.", "Begin by lying on a bench with the hands supporting a weight (barbell, dumbbells, or cable attachments) at the top of the bench pressing position, aligning the back and hips as in a bench press; slightly pull the elbows back, pointing them behind you, as you lower the bar handle or loads towards your head, almost touching the forehead, experiencing a stretch on the triceps and partial engagement of the lats, and finally, push the bar back up.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2018/06/decline-ez-bar-skull-crusher-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "This exercise allows for complete isolation of the triceps, providing the ability to feel the muscle contract and achieve a satisfying pump.", "Set the cables or band at a high anchor point, face your body towards it, place your feet together, keep your elbows by your sides, chest up, back flat, and hips angled slightly forward, then grab the handles or band and push them down by fully extending your elbows, ensuring that your elbows are slightly in front of your shoulders.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Triceps-Rope-Pushdown-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "Using two separate dumbbells for pressing exercises allows for easier customization of a comfortable position, particularly beneficial for individuals with shoulder or elbow discomfort, while also promoting enhanced joint and muscle stability; furthermore, the individual effort required by each side helps balance any strength disparities and enables weaker sides of the body to catch up.", "Begin by sitting on a flat bench and hinging forward to pick up each dumbbell, placing them on your knees; after getting set, lean back and drive the dumbbells back towards you using your knees, while simultaneously pressing the weights over your chest, then lower the weights with elbows tucked at a 45-degree angle until they break 90 degrees, followed by driving the dumbbells back up, optionally transitioning to a neutral grip position with palms facing each other for the press." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "The bent-over row can be effectively executed using tools like kettlebells, dumbbells, or a cable machine, allowing for efficient muscle overload as you can handle significant weight in the bent-over row position.", "To perform the barbell bent-over row, set up in a deadlift position with feet shoulder-width apart in front of a loaded barbell, hinge at the hips to achieve a parallel torso to the floor, grip the barbell slightly wider than your typical deadlift grip, lean back to distribute weight on your heels, and initiate the row by pulling with your elbow until the barbell touches around your belly button, ensuring the barbell doesn't touch the floor between repetitions, and considering a wider grip or a more upright torso for individuals with longer arms." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "Engaging both forearm extensors and flexors, the wrist roller exercise strengthens these muscles while the thick grip enhances grip strength, requiring focused attention on the wrists and forearms, which are typically secondary to the primary movers.", "Begin with a 2.5, five, or 10-pound weight plate, stand with feet hip-width apart, grip the wrist roller with knuckles facing towards you, gradually execute a front raise to elevate the roller to shoulder height, roll the weight up while alternating hands until fully wound, and then slowly reverse the movement.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2022/11/Wrist-roller.png?ezimgfmt=ng%3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Benefit", "Execution" },
                values: new object[] { "By resisting gravity and rotational forces, the L-sit exercise enhances full-body strength, demanding significant isometric strength while stimulating exceptional abdominal strength and stability, making it a valuable core strengthening exercise that prepares lifters and gymnastic athletes for more challenging athletic movements.", "Sit between two dumbbells or kettlebells, placing each hand on a handle, then elevate your body off the floor by extending your legs and maintain an isometric hold, ensuring tension in the middle and upper back." });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Benefit", "Execution", "ImageUrl" },
                values: new object[] { "The dumbbell shoulder press targets and develops muscles in the shoulders, triceps, biceps, and upper back, leading to improvements in overall upper body physique, and as a compound exercise utilizing multiple joints and muscles simultaneously, it is more effective in producing results compared to isolation exercises.", "Begin by grabbing a pair of dumbbells and lifting them to the starting position at your shoulders, lightly brace your core while inhaling, press the dumbbells up to straight arms while exhaling, inhale at the top or during controlled lowering back to your shoulders, and repeat for the desired number of repetitions.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Dumbbell-Shoulder-Press-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4" });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "The most biologically accessible form of calcium, enriched with vitamin D2, magnesium, copper, zinc, and manganese, ensures the health of muscles, bones, and teeth, participates in blood clotting, supports proper neurotransmission, guarantees immune function, and promotes the well-being of hair, nails, and skin, conveniently available in tablet form and suitable for vegetarians and vegans.", "Calcium citrate, in tablet form, is the most biologically accessible form of calcium, ensuring optimal health for muscles, bones, and teeth, while also participating in blood clotting and supporting proper neurotransmission. Additionally, it is enriched with other beneficial electrolytes such as vitamin D2, magnesium, copper, manganese, and zinc, which play crucial roles in bone metabolism, reduce fatigue, support immune and nervous system health, promote healthy hair, nails, and skin, and protect cells from oxidative stress, making the product suitable for vegans and vegetarians.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/u/n/untitled_design_-_2020-04-03t164935.609.png", "Hydroxypropyl cellulose, vegetable coating, croscarmellose sodium, silicon dioxide, magnesium stearate (vegetable source), and stearic acid (vegetable source)." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "500 mg of Ashwagandha (Withania somnifera) extract, containing 5% of active compounds called withanolides, classified as adaptogens, may help enhance the body's resilience and aid in better stress management, available in convenient capsule form.", "Ashwagandha or Indian Ginseng (Withania somnifera) is a plant classified among adaptogens, compounds known for their beneficial effects on the body, particularly in increasing its resilience and improving the adaptation process to stress. Similar to how our muscles become stronger and grow when we exercise, adaptogens can enhance the body's resistance to stress and aid in better stress management. It's no wonder that Ashwagandha is popular among individuals experiencing daily stress at work, school, or in their personal lives. However, its benefits don't end there; this plant is still being researched by scientific institutions for its potential positive effects in reducing anxiety, fatigue, lowering the stress hormone cortisol, and enhancing athletic performance, strength, and sleep. Additionally, it may support our mental well-being and aid in relaxation.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/a/s/ashwagandha_90_caps.png", "Ashwagandha extract (Withania somnifera) (5% withanolides), anti-caking agent (calcium phosphate, magnesium stearate), gelatin capsule." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "This dietary supplement, containing this essential mineral, participates in hundreds of biological processes, supporting proper carbohydrate metabolism, bone health, protein synthesis, maintaining normal testosterone levels, enhancing fertility and reproductive function, promoting healthy skin, hair, and nails, supporting good vision, boosting the immune system, influencing proper metabolism of fatty acids, aiding in DNA synthesis, maintaining cognitive functions, affecting the metabolism of vitamin A, protecting cells against oxidative stress, and suitable for vegans, making it ideal for anyone striving to maintain optimal health.", "Zinc is an essential mineral found in many food supplements, vital for hundreds of biological processes in the body, supporting proper metabolism of macronutrients like carbohydrates, crucial for energy supply to athletes and active individuals. It also aids in maintaining bone health, protein synthesis for muscle growth, and has a positive impact on testosterone levels in men. Zinc plays a vital role in various bodily processes, positively affecting muscle size and strength, fertility, and reproductive function, benefiting skin, hair, and nails for women, and supporting vision for those spending time in front of screens. Additionally, as an antioxidant, zinc protects cells against oxidative stress, boosts the immune system, aids in fat metabolism, DNA synthesis, cognitive functions, and vitamin A metabolism, making it an ideal supplement for overall health and suitable for vegans.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/z/i/zinc_100_tabs_gymbeam.png", "Filler (microcrystalline cellulose, calcium hydrogen phosphate), zinc oxide, coating (stearic acid), anti-caking agent (magnesium stearate)." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "This supplement contains 1000 mg of ascorbic acid (Vitamin C), offered in easy-to-swallow tablets, supporting the proper functioning of the immune and nervous systems, promoting mental balance, reducing fatigue, maintaining energy metabolism, bone and cartilage health, collagen production, skin, gum, and teeth function, protecting cells from oxidative stress, enhancing iron absorption, and supporting cardiovascular health, enriched with rosehip extract, promoting overall health and vitality.", "Vitamin C 1000 mg, also known as L-ascorbic acid, is an essential vitamin found in easy-to-swallow tablets and commonly present in various fruits and vegetables. It participates in numerous biological processes, making it one of the most popular supplements supporting overall health and vitality. Vitamin C contributes to the proper functioning of the immune and nervous systems, supports immunity during and after intense physical activity, promotes mental balance, reduces fatigue, and aids in energy metabolism for daily activities and sports. Additionally, it maintains bone and cartilage health, collagen production, and the health of skin, gums, and teeth. Moreover, Vitamin C acts as an antioxidant, protects cells from oxidative stress, enhances iron absorption, and supports cardiovascular health. The supplement is enriched with rosehip extract (Rosa canina), offering a wide range of beneficial effects.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/n/e/new_vitamin_c.png", "Vitamin C (L-ascorbic acid), rosehip extract (Rosa canina), filler (microcrystalline cellulose), anti-caking agent (magnesium stearate)." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Benefits", "Description", "ImageUrl", "Ingredients" },
                values: new object[] { "A multi-component whey protein powder, derived from the milk of free-range cows, containing a combination of whey concentrate, isolate, and hydrolysate, boasting an impressive 74.8% protein content, providing 22.4g of protein per serving, including all essential amino acids and BCAAs, making it an ideal choice to meet protein intake needs, supporting muscle growth and preservation, with high bioavailability and easy digestibility, enriched with selected vitamins and minerals, promoting muscle function and bone health, positively impacting optimal testosterone levels, aiding in reducing fatigue and tiredness, supporting proper immune function, offering a delightful taste and easy solubility, containing only natural flavors and colors, a great way to enrich cereals and other dishes with high-quality protein, suitable for athletes and all active individuals, perfect for post-workout or anytime during the day.", "Just Whey Protein is a multi-component whey protein powder that effectively supports protein intake after workouts or at any other time of the day, containing a unique combination of whey protein concentrate, isolate, and hydrolysate, ensuring high absorbability and bioavailability for the body, providing 18% EPA and 12% DHA, supporting cardiovascular functions, brain functions, and good vision, enriched with vitamin E, respecting nature and produced from the milk of free-range cows, with added enzymes for better nutrient absorption, containing 74.8% protein content, supporting muscle growth and maintenance, beneficial for athletes, active individuals, and those on a weight loss or recovery journey, enriched with vitamins and minerals like B6, magnesium, and zinc, easily consumed in various ways and delicious flavors, suitable for a healthy lifestyle.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/j/u/just_whey_unflavored_1_kg_gymbeam_1.png", "Whey protein concentrate powder, whey protein isolate powder, protein hydrolysate, minerals (magnesium citrate, zinc oxide), vitamins (vitamin E - tocopheryl acetate, vitamin B6 - pyridoxine hydrochloride), DigeZyme® - a complex of digestive enzymes, bromelain." });

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Benefits", "Description", "ImageUrl" },
                values: new object[] { "100% Creatine monohydrate, a highly researched nutritional supplement, enhances physical performance during short bursts of intense exercises, making it suitable for strength athletes and team sport enthusiasts; it comes in a soluble powder form that can be easily mixed with water, juice, or post-workout protein shakes.", "100% Creatine monohydrate is a popular supplement known for enhancing physical performance in short, intense exercises, making it highly favored by athletes, including strength trainers, team sport enthusiasts, and HIIT practitioners. It is a naturally occurring substance in the body, and supplementing with creatine powder ensures easy intake of the recommended daily dose of at least 3 grams, supporting improved exercise performance without the need for cycling or time-limited usage.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/c/r/creatinemonohydrate_500_1.jpg" });
        }
    }
}
