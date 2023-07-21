using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    public partial class AddingTablesForSupplementsAndAccessories : Migration
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "Benefits", "Description", "ImageUrl", "Manufacturer", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "The 4-layer leather belt with an adjustable section provides stability and durability while ensuring comfort, offering support during weightlifting and is suitable for individuals engaging in heavy lifting.", "The LEVER weightlifting belt is a practical device designed for individuals engaged in strength training, aiming to increase the weights they lift; it helps stabilize the core and lower back muscles, boosting your confidence and enabling you to lift heavier weights. Made from 4-layered material - 2 inner layers of cowhide and suede covered with 2 outer layers of buffalo suede - it ensures stability and durability while fitting perfectly to your body; the belt also features an adjustable section to accommodate your waist size, eliminating concerns about it being too large or small. If you want to enhance the weights lifted during squats or deadlifts, this high-quality leather belt should undoubtedly be part of your fitness arsenal.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/w/e/weightlifting-belt-lever-gymbeam_5_.jpg", "GymBeam", "Weight belt LEVER Black", 99.99m },
                    { 2, "The Ronnie fitness gloves protect hands from injuries, calluses, and abrasions, providing a secure grip during workouts with fitness equipment, bars, or weights; they are perfect for strength training, have an ergonomic shape for long-lasting durability, and fit hands comfortably without squeezing fingers.", "The Ronnie fitness gloves are high-quality exercise gloves made of split leather with a rubber-padded cowhide interior for an ideal fit and intense workout protection for every athlete; they are reinforced with a double lining in the palm area for durability and resistance against wear, designed for professional athletes seeking superior hand protection during training, guarding against scratches, calluses, and impacts while providing a secure grip on workout equipment, but they should not be machine washed.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/r/u/rukavice_2j_1.jpg", "GymBeam", "Fitness gloves Ronnie", 19.99m },
                    { 3, "This 700ml shaker, made of high-quality polypropylene PP, is perfect for mixing all soluble dietary supplements, featuring a leak-proof screw-on lid, a cone-shaped filter to prevent lumps, milliliter (ml) and ounce (oz) markings, break-resistant, dishwasher, microwave, and fridge safe, BPA and DEHP-free, and compliant with food regulations.", "The green shaker is a classic 700ml shaker with a traditional closure and filter, perfect for mixing your favorite proteins, pre-workout stimulants, and creatine; made of non-toxic plastic and free from BPA and DEHP.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/s/h/shaker_yellow_green.jpg", "GymBeam", "Green shaker 700ml", 7.99m },
                    { 4, "Made of 100% cotton, this towel has anti-static and antibacterial properties, dries quickly, absorbs efficiently, feels soft and pleasant to touch, and boasts a long lifespan.", "This gray fitness and workout towel, made of 100% soft and pleasant-to-touch cotton, stands out with its excellent absorption, high durability, and anti-static, antibacterial properties. With dimensions of 50x90 cm, this towel possesses these qualities naturally, without the use of any chemical compounds, making it suitable for individuals with sensitive skin or allergies, as it does not cause allergic reactions. Every athlete recognizes the significance of a workout towel, an essential accessory in the gym, not only to wipe away sweat from the face but also to provide a clean surface for various exercises, such as for abdominal workouts, seating, or under the feet during exercises. Not having a workout towel in the gym is a pure faux pas (embarrassing mistake) and can easily be avoided to prevent someone from asking, \"Where is your towel?\"", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/g/r/grey_fitness_towel_gymbeam_1_.jpg", "GymBeam", "Towel for fitness", 14.99m }
                });

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Price",
                value: 49.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Price",
                value: 49.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Price",
                value: 49.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 16,
                column: "Price",
                value: 49.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 17,
                column: "Price",
                value: 49.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 18,
                column: "Price",
                value: 49.99m);

            migrationBuilder.InsertData(
                table: "Supplements",
                columns: new[] { "Id", "Benefits", "Description", "ImageUrl", "Ingredients", "Manufacturer", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "The most biologically accessible form of calcium, enriched with vitamin D2, magnesium, copper, zinc, and manganese, ensures the health of muscles, bones, and teeth, participates in blood clotting, supports proper neurotransmission, guarantees immune function, and promotes the well-being of hair, nails, and skin, conveniently available in tablet form and suitable for vegetarians and vegans.", "Calcium citrate, in tablet form, is the most biologically accessible form of calcium, ensuring optimal health for muscles, bones, and teeth, while also participating in blood clotting and supporting proper neurotransmission. Additionally, it is enriched with other beneficial electrolytes such as vitamin D2, magnesium, copper, manganese, and zinc, which play crucial roles in bone metabolism, reduce fatigue, support immune and nervous system health, promote healthy hair, nails, and skin, and protect cells from oxidative stress, making the product suitable for vegans and vegetarians.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/u/n/untitled_design_-_2020-04-03t164935.609.png", "Hydroxypropyl cellulose, vegetable coating, croscarmellose sodium, silicon dioxide, magnesium stearate (vegetable source), and stearic acid (vegetable source).", "NOW", "Calcium Citrate 100 Tablets", 29.99m },
                    { 2, "500 mg of Ashwagandha (Withania somnifera) extract, containing 5% of active compounds called withanolides, classified as adaptogens, may help enhance the body's resilience and aid in better stress management, available in convenient capsule form.", "Ashwagandha or Indian Ginseng (Withania somnifera) is a plant classified among adaptogens, compounds known for their beneficial effects on the body, particularly in increasing its resilience and improving the adaptation process to stress. Similar to how our muscles become stronger and grow when we exercise, adaptogens can enhance the body's resistance to stress and aid in better stress management. It's no wonder that Ashwagandha is popular among individuals experiencing daily stress at work, school, or in their personal lives. However, its benefits don't end there; this plant is still being researched by scientific institutions for its potential positive effects in reducing anxiety, fatigue, lowering the stress hormone cortisol, and enhancing athletic performance, strength, and sleep. Additionally, it may support our mental well-being and aid in relaxation.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/a/s/ashwagandha_90_caps.png", "Ashwagandha extract (Withania somnifera) (5% withanolides), anti-caking agent (calcium phosphate, magnesium stearate), gelatin capsule.", "GymBeam", "Ashwagandha 90 Capsules", 19.99m },
                    { 3, "This dietary supplement, containing this essential mineral, participates in hundreds of biological processes, supporting proper carbohydrate metabolism, bone health, protein synthesis, maintaining normal testosterone levels, enhancing fertility and reproductive function, promoting healthy skin, hair, and nails, supporting good vision, boosting the immune system, influencing proper metabolism of fatty acids, aiding in DNA synthesis, maintaining cognitive functions, affecting the metabolism of vitamin A, protecting cells against oxidative stress, and suitable for vegans, making it ideal for anyone striving to maintain optimal health.", "Zinc is an essential mineral found in many food supplements, vital for hundreds of biological processes in the body, supporting proper metabolism of macronutrients like carbohydrates, crucial for energy supply to athletes and active individuals. It also aids in maintaining bone health, protein synthesis for muscle growth, and has a positive impact on testosterone levels in men. Zinc plays a vital role in various bodily processes, positively affecting muscle size and strength, fertility, and reproductive function, benefiting skin, hair, and nails for women, and supporting vision for those spending time in front of screens. Additionally, as an antioxidant, zinc protects cells against oxidative stress, boosts the immune system, aids in fat metabolism, DNA synthesis, cognitive functions, and vitamin A metabolism, making it an ideal supplement for overall health and suitable for vegans.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/z/i/zinc_100_tabs_gymbeam.png", "Filler (microcrystalline cellulose, calcium hydrogen phosphate), zinc oxide, coating (stearic acid), anti-caking agent (magnesium stearate).", "GymBeam", "Zinc 100 Tablets", 10.99m },
                    { 4, "This supplement contains 1000 mg of ascorbic acid (Vitamin C), offered in easy-to-swallow tablets, supporting the proper functioning of the immune and nervous systems, promoting mental balance, reducing fatigue, maintaining energy metabolism, bone and cartilage health, collagen production, skin, gum, and teeth function, protecting cells from oxidative stress, enhancing iron absorption, and supporting cardiovascular health, enriched with rosehip extract, promoting overall health and vitality.", "Vitamin C 1000 mg, also known as L-ascorbic acid, is an essential vitamin found in easy-to-swallow tablets and commonly present in various fruits and vegetables. It participates in numerous biological processes, making it one of the most popular supplements supporting overall health and vitality. Vitamin C contributes to the proper functioning of the immune and nervous systems, supports immunity during and after intense physical activity, promotes mental balance, reduces fatigue, and aids in energy metabolism for daily activities and sports. Additionally, it maintains bone and cartilage health, collagen production, and the health of skin, gums, and teeth. Moreover, Vitamin C acts as an antioxidant, protects cells from oxidative stress, enhances iron absorption, and supports cardiovascular health. The supplement is enriched with rosehip extract (Rosa canina), offering a wide range of beneficial effects.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/n/e/new_vitamin_c.png", "Vitamin C (L-ascorbic acid), rosehip extract (Rosa canina), filler (microcrystalline cellulose), anti-caking agent (magnesium stearate).", "GymBeam", "Vitamin C 1000mg 180 Tablets", 35.99m },
                    { 5, "A multi-component whey protein powder, derived from the milk of free-range cows, containing a combination of whey concentrate, isolate, and hydrolysate, boasting an impressive 74.8% protein content, providing 22.4g of protein per serving, including all essential amino acids and BCAAs, making it an ideal choice to meet protein intake needs, supporting muscle growth and preservation, with high bioavailability and easy digestibility, enriched with selected vitamins and minerals, promoting muscle function and bone health, positively impacting optimal testosterone levels, aiding in reducing fatigue and tiredness, supporting proper immune function, offering a delightful taste and easy solubility, containing only natural flavors and colors, a great way to enrich cereals and other dishes with high-quality protein, suitable for athletes and all active individuals, perfect for post-workout or anytime during the day.", "Just Whey Protein is a multi-component whey protein powder that effectively supports protein intake after workouts or at any other time of the day, containing a unique combination of whey protein concentrate, isolate, and hydrolysate, ensuring high absorbability and bioavailability for the body, providing 18% EPA and 12% DHA, supporting cardiovascular functions, brain functions, and good vision, enriched with vitamin E, respecting nature and produced from the milk of free-range cows, with added enzymes for better nutrient absorption, containing 74.8% protein content, supporting muscle growth and maintenance, beneficial for athletes, active individuals, and those on a weight loss or recovery journey, enriched with vitamins and minerals like B6, magnesium, and zinc, easily consumed in various ways and delicious flavors, suitable for a healthy lifestyle.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/j/u/just_whey_unflavored_1_kg_gymbeam_1.png", "Whey protein concentrate powder, whey protein isolate powder, protein hydrolysate, minerals (magnesium citrate, zinc oxide), vitamins (vitamin E - tocopheryl acetate, vitamin B6 - pyridoxine hydrochloride), DigeZyme® - a complex of digestive enzymes, bromelain.", "GymBeam", "Just Whey 1kg", 9.99m },
                    { 6, "100% Creatine monohydrate, a highly researched nutritional supplement, enhances physical performance during short bursts of intense exercises, making it suitable for strength athletes and team sport enthusiasts; it comes in a soluble powder form that can be easily mixed with water, juice, or post-workout protein shakes.", "100% Creatine monohydrate is a popular supplement known for enhancing physical performance in short, intense exercises, making it highly favored by athletes, including strength trainers, team sport enthusiasts, and HIIT practitioners. It is a naturally occurring substance in the body, and supplementing with creatine powder ensures easy intake of the recommended daily dose of at least 3 grams, supporting improved exercise performance without the need for cycling or time-limited usage.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/c/r/creatinemonohydrate_500_1.jpg", "Unflavored: Creatine monohydrate", "GymBeam", "Creatine Monohydrate 500g", 9.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Supplements");

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 13,
                column: "Price",
                value: 29.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 14,
                column: "Price",
                value: 29.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 15,
                column: "Price",
                value: 29.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 16,
                column: "Price",
                value: 29.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 17,
                column: "Price",
                value: 29.99m);

            migrationBuilder.UpdateData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 18,
                column: "Price",
                value: 29.99m);
        }
    }
}
