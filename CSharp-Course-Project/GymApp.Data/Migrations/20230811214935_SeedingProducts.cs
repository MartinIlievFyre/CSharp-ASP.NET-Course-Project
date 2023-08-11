using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Data.Migrations
{
    public partial class SeedingProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "Benefits", "Description", "ImageUrl", "Manufacturer", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 5, "A modern backpack suitable for all weather conditions, with a capacity of 29 liters, equipped with UA Storm technology that withstands the elements and keeps its contents dry, featuring a durable fabric texture, comfortable to carry, equipped with a breathable ventilated back panel and adjustable shoulder straps, comes with a special water-resistant front pocket for valuables, offers a dedicated shoe storage section, a side pocket for a water bottle, suitable for various sports activities as well as work or university, equipped with an internal 15” laptop pocket, captivates with its modern design and the Under Armour logo.", "The Hustle 5.0 Backpack is a versatile modern backpack, perfect not only for active lifestyle enthusiasts. With a capacity of 29 liters, it provides ample space for all your belongings. Equipped with UA Storm technology, the bag is highly resistant to the elements and will reliably keep its contents dry, making it suitable for various weather conditions. The material features a durable texture that withstands external damage. Meanwhile, it's incredibly comfortable thanks to features like a ventilated back panel and adjustable shoulder straps, allowing you to customize the carrying position to your needs. A special water-resistant front zip pocket ensures your valuables remain safe at all times, ideal for carrying your wallet or smartphone.\r\n\r\nThe backpack is also equipped with various internal pockets. The bottom is separate for storing your shoes or used clothes, protecting the rest of the contents from contact and avoiding unpleasant odors. There are bottle pockets on both sides, making this bag a great choice for activities like cycling, hiking, or going to the gym. However, the bag is highly versatile and can easily serve daily needs - you can take it to work or university, where you'll appreciate its 15-inch laptop pocket that can also store notebooks and more. Visually, the bag captivates with its minimalist design and the prominent Under Armour logo. Overall, this backpack is the perfect choice for anyone seeking an incredibly flexible solution that holds up in any situation.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/b/a/backpack_hustle_5_0_black_under_armour_7_.png", "Under Armour", "Backpack Hustle 5.0 Black", 114.99m, "Accessory" },
                    { 6, "An effective accessory for carrying your daily meals, providing ample storage space for food containers, offering a convenient way to transport your lunch, dinner, and snacks, equipped with various secure zippered pockets, comes with a padded and adjustable shoulder strap, the main compartment features a separator, made with thick thermal insulation to help maintain your food at an optimal temperature, easy to carry wherever you go, helps you streamline your daily activities between work, university, and the gym.", "The meal prep bag offers generous storage space, allowing you to carry your prepared meals with you at all times. It can be carried as a handbag or shoulder bag, thanks to the adjustable padded strap for added comfort. Made from a combination of nylon and polyester, the bag is sturdy and highly durable. It features various pockets secured with reliable zippers, ensuring you won't worry about accidentally spilling your stored food or beverages inside. The core of the storage space is a spacious main compartment equipped with a separator.\r\n\r\nThe bag easily accommodates food containers with your lunch and dinner, as well as additional sides, which can be conveniently accessed through the top or side opening. Moreover, the food bag comes with two side pockets that can hold various healthy foods, allowing you to carry snacks like fruits or bars. Thanks to its thick thermal insulation, the bag reliably keeps its contents dry and at a constant temperature for several hours. It offers the perfect solution for seamlessly connecting your daily activities such as work, university, and fitness, without worrying about your meals. Additionally, the bag is ideal for travel, ensuring you stay on top of your calories and nutrients even during longer journeys. Food containers and gel packs are not included in the packaging of this product and need to be purchased separately.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/m/e/meal_prep_bag__black_white_edition__climaqx_3_.jpg", "Climaqx", "Meal Prep Bag Black", 110.99m, "Accessory" },
                    { 7, "A practical lunch box with a sturdy lid, featuring compartments to separate meal portions, and comes with an included spoon. Made from durable polypropylene, it's suitable for microwave and dishwasher use, making it ideal for preparing your meals on the go, at work, or at university.", "The Fit Prep food container is a practical and essential solution for every food enthusiast and health-conscious individual. With this simple tool, you can ensure that you always have nutritious and delicious food on hand, prepared from high-quality ingredients that you've personally chosen. This way, you can maintain control over your calorie intake, which you'll particularly appreciate when managing your weight or preparing for a competition.\r\n\r\nIt features a convenient snap-on lid that securely seals its contents, so you won't worry about spilling your favorite couscous or meat sauce. If you prefer your dish's components not to mix together, you'll certainly appreciate the movable food divider, which keeps different parts of your meal separate. This allows you to enjoy your meat, side dish, and salad separately. Moreover, you can heat up certain sections in the microwave while leaving others cold. For instance, you can easily remove the section containing your salad and warm up the rest, enabling you to fully savor your meal's taste even when eating from the lunch box. The container also comes with a spoon. You'll surely agree that there's nothing as disappointing as diligently preparing your food only to find that you can't enjoy it the next day.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/f/o/food_container_fit_prep_black_-_gymbeam_1_1.jpg", "GymBeam", "Fit Prep Black", 8.50m, "Accessory" },
                    { 8, "Weightlifting straps designed to enhance grip and reduce tension in wrists and fingers, measuring 60.9 cm in length and 3.8 cm in width, constructed from durable nylon. The package includes two straps for each hand, offering easy usage during pulling exercises like deadlifts. Suitable for bodybuilders and strength athletes.", "LIFT Weightlifting Straps are a practical aid in your workouts, designed to enhance your grip when lifting weights. The straps feature a simple design with a loop on one end. By threading the strap through the loop, you create a space for your hand to pass through, while the remaining portion wraps around the barbell. With a length of 60.9 cm and a width of 3.8 cm, these straps easily wrap around the barbell. This reduces strain on your forearms and fingers during pulling exercises like deadlifts, allowing your performance to be less limited by your grip strength. This should enable you to lift heavier weights and perform more repetitions of a given exercise, ultimately boosting your strength and accelerating muscle growth.\r\n\r\nLIFT Weightlifting Straps are crafted from durable nylon, suitable for crossfitters, powerlifters, and individuals aiming to increase their grip strength.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/l/i/lifting_straps_black___grey_gymbeam_3_.jpg", "GymBeam", "Lifting Straps Black & Grey", 12.99m, "Accessory" },
                    { 9, "You'll be able to develop your grip, which will help you be stronger in other exercises like the deadlift. The forearm muscles will grow.", "The grip training handle is a popular tool for workouts aimed at enhancing hand grip strength. Hand and finger grip are essential for proper grasping of dumbbells, gym equipment, and overall hand strength in daily activities. By increasing resistance, you'll enhance the effectiveness of your workout and prevent potential injuries. You can adjust the resistance according to your needs within the range of 10 - 40 kg.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/h/a/hand-grip_trainer_gymbeam1.jpg", "GymBeam", "Grip training grip", 14.99m, "Accessory" },
                    { 10, "A fitness accessory that engages multiple muscle groups simultaneously, equipped with non-slip handles and a double wheel for enhanced stability, enhancing physical fitness, sculpting the physique, and improving body mobility and stability.", "The Ab Wheel, an abdominal exercise wheel, will help you achieve your fitness goals. By engaging multiple muscle groups simultaneously (back, arms, core, shoulders, and legs), it effectively enhances physical condition and quickly shapes the body. Furthermore, it aids in improving overall body stability and mobility, which can be beneficial for other exercises. Workout comfort is guaranteed by the non-slip handles and the dual wheel design, providing maximum stability! Enhance your fitness and sculpt the body you've always dreamed of.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/1/_/1_2.png", "GymBeam", "Ab Wheel", 18.99m, "Accessory" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "ec7b7e64-fcb4-475a-b04f-96feca2c4047");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "c3a1d5cb-0e86-40ab-88d2-6f5ed633c661");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "7c09c4a7-32ed-44b7-b2de-47c037b3776b", new DateTime(2023, 8, 11, 21, 49, 34, 914, DateTimeKind.Utc).AddTicks(7146), "AQAAAAEAACcQAAAAEKYZs+jEFVAYobzrkNXLZhQ/a3ZNW/7X/Wz1bvhzqvPaBnlNFiNvWQ/ssryRQkLhTw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "cc095c1e-e043-41ed-b867-c130d689405d", new DateTime(2023, 8, 11, 21, 49, 34, 912, DateTimeKind.Utc).AddTicks(4182), "AQAAAAEAACcQAAAAEC7DDHYMpqBFgcGxC2+X2COlmlAiHJCYylYjFcwBc/uh1E/p411hrAfiZDwdV0H7eQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "54632d26-2752-4394-9f52-021329f0e507", new DateTime(2023, 8, 11, 21, 49, 34, 913, DateTimeKind.Utc).AddTicks(5655), "AQAAAAEAACcQAAAAEPNftemYF9/rZa6sn+g99ZZwwVPC4KaDsn62iYxR1c9vrNGdiSA48DDbKd9uE9HgWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "91737648-0364-4c07-a553-fcfdecb8ce44", new DateTime(2023, 8, 11, 21, 49, 34, 911, DateTimeKind.Utc).AddTicks(2404), "AQAAAAEAACcQAAAAEFXQuqetOd/ELR09NV8NaCoXS+fVM5lrEFtP/yNAbDuOXndyiyzaKdoctap5c70u0Q==" });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "Id", "Color", "Description", "Fabric", "ImageUrl", "Name", "Price", "Size", "Type", "WearCategoryId" },
                values: new object[,]
                {
                    { 7, "Maroon White", "The Free Your Strength Maroon White T-shirt will help you conquer even the toughest challenges that await you in the fitness world. Its snug design and high-quality material take care of that - it's made from 100% pre-treated cotton, which is soft to the touch and doesn't cause allergic reactions during sweating. Besides being perfect for fitness, you'll surely fall in love with this T-shirt for your everyday wear as well.", "Cutton", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/f/r/free-your-strength-gymbeam-burgundy-1.jpg", "Free Your Strength Maroon White", 25.99m, "S", "Wear", 1 },
                    { 8, "Pink", "The Athlete Pink women's hoodie is a comfortable hoodie with a hood that will be your partner on the journey to achieving your fitness goals. With the stylish GymBeam logo, you'll express your love for workouts. You'll fall in love with it for workouts due to its high-quality soft material, but you won't be able to resist wearing it in your everyday life as well.", "Cutton", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/l/a/ladies-hoodie-athlete-military-pink-mikina-gymbeam-1.jpg", "Athlete Pink", 52.99m, "S", "Wear", 2 },
                    { 9, "Grey", "The women's Iconic Hero sweatshirt is exceptionally comfortable due to its relaxed fit and soft-touch material that combines gentle cotton and durable polyester, making it highly breathable. The garment is further equipped with a hood and a wide front pocket. The sleeve cuffs and waist area are finished with elastic, ensuring a snug fit to your body.\r\n\r\nThe women's Iconic Hero sweatshirt features a minimalist design adorned with the NEBBIA brand logo on the front. It can be worn during sports activities or casual moments.", "Cutton, Polyester", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/w/o/womens-hoodie-iconic-hero-grey-nebbia_1_.jpg", "Iconic Hero Grey", 175.99m, "S", "Wear", 2 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Benefit", "CategoryId", "Execution", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 12, "The chest fly machine effectively targets the pectoral muscles while providing controlled and isolated movement for improved chest strength and development.", 4, "Sit up tall and relax your neck and shoulders, ensuring your feet are flat on the floor; grasp the handles with palms facing forward, noting that some machines have a foot bar to release the handles; press your arms together in front of your chest with a controlled movement, maintaining a slight bend in the elbows and relaxed wrists; pause for a second with arms fully closed in front of your chest; slowly return arms to the starting position, maintaining strong and upright posture; complete two sets of seven to 10 repetitions, taking a short break between sets.", "https://cdn.shopify.com/s/files/1/1497/9682/files/MicrosoftTeams-image_5_c40117c8-4452-4801-b272-c56dcde1c0f0.jpg?v=1659021798", "Pec Deck" },
                    { 13, "Pull-ups offer benefits such as strengthening the upper body, especially the back, shoulders, and arms, improving grip strength, enhancing overall body coordination, and promoting muscle engagement for a functional and effective exercise.", 5, "To perform a pull-up, hang from a bar with an overhand grip, engage your back and arm muscles, and pull your body upward until your chin is above the bar, then lower yourself back down with controlled movement.", "https://weighttraining.guide/wp-content/uploads/2016/10/pull-up-2-resized.png", "Pull-up" },
                    { 14, "Front planks provide benefits like core strengthening, improved posture, enhanced stability in the abdominal muscles and lower back, and the engagement of various muscle groups for a comprehensive and effective isometric exercise.", 7, "To execute a front plank, start in a push-up position with your forearms resting on the ground, elbows aligned beneath your shoulders, and your body in a straight line from head to heels; engage your core muscles to maintain a neutral spine and avoid sagging or arching; hold the position for a specific duration, focusing on proper alignment and steady breathing.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2021/06/Weighted-front-plank.png?ezimgfmt=ng%3Awebp%2Fngcb4", "Front Plank" },
                    { 15, "Dumbbell lateral raises offer benefits such as targeting the lateral deltoid muscles for broader shoulders, enhancing shoulder stability, improving overall upper body symmetry, and contributing to better posture and functional shoulder strength.", 8, "To execute a dumbbell lateral raise, stand upright holding a dumbbell in each hand at your sides, slightly bending your elbows; keeping your core engaged and maintaining a neutral spine, raise both dumbbells out to your sides until your arms are parallel to the floor; pause briefly at the top of the movement and then slowly lower the dumbbells back down to the starting position while maintaining controlled movement throughout.", "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/dumbbell-lateral-raise-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4", "Dumbbell lateral raise" }
                });

            migrationBuilder.InsertData(
                table: "Supplements",
                columns: new[] { "Id", "Benefits", "Description", "ImageUrl", "Ingredients", "Manufacturer", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 7, "One of the key minerals, it has an essential impact on several biological processes, contributing to proper metabolism crucial for energy production, influencing optimal oxygen transport in the body, aiding in the production of red blood cells and hemoglobin, reducing fatigue and tiredness, positively affecting cognitive functions, supporting the immune system, available in convenient capsule form, suitable for vegans.", "Iron is an essential element crucial for proper bodily function. It is available in vegan-friendly capsules and plays a vital role in producing hemoglobin and red blood cells, facilitating oxygen transport throughout the body. It also helps reduce fatigue and exhaustion, enhances cognitive functions such as memory and attention, and supports the immune system. Adequate iron intake is important for overall health and vitality, especially for individuals with strenuous physical or mental activities. Women experiencing menstrual discomfort and potential lower iron levels should focus on optimizing their iron intake.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/n/e/new_iron_-_gb.png", "Iron fumarate, filler (microcrystalline cellulose), anti-caking agent (magnesium stearate), hydroxypropyl methylcellulose capsule.", "GymBeam", "Iron 120 Capsules", 15.99m, "Supplement" },
                    { 8, "Enriched with Rhodiola rosea extract, containing vitamin C and magnesium, this product contains a full 5g of BCAAs per serving, contributing to muscle growth and maintenance, supporting immune function, and aiding in reducing fatigue and exhaustion.", "Gold Standard BCAA Train Sustain is an original blend of nutrients designed to support muscles, boost immunity, and reduce fatigue. It includes branched-chain amino acids (BCAA), Rhodiola rosea, vitamin C, and magnesium. BCAAs consist of three essential amino acids – leucine, isoleucine, and valine – which the body cannot synthesize on its own, making them necessary through diet or supplements. These amino acids are the building blocks of proteins, contributing to muscle growth and maintenance. Muscles experience breakdown during workouts, making it advisable to replenish essential nutrients post-exercise. Each serving contains a full 5g of BCAAs.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/s/t/straw.kiwi.png", "A blend of branched-chain amino acids (L-leucine, L-isoleucine, L-valine, emulsifier: sunflower lecithin), acids (citric acid, apple acid, L (+) - tartaric acid), flavors, Rhodiola rosea root extract, L-ascorbic acid, anti-caking agents (silicon dioxide, calcium silicate), sodium chloride, magnesium oxide, colorant (red beetroot), potassium chloride, sweetener (sucralose), zinc oxide.", "Optimum Nutrition", "Gold Standard BCAA Train Sustain 226g", 59.99m, "Supplement" },
                    { 9, "A comprehensive pre-workout blend with an effective formula containing ingredients aimed at stimulating muscle blood flow or enhancing performance, possibly delaying the onset of muscle fatigue and improving athletic achievements, featuring nootropics and adaptogens that may assist in facing physically demanding challenges, enriched with B-group vitamins contributing to proper metabolism crucial for energy production, aiding fatigue and exhaustion reduction, offering a refreshing taste, suitable for anyone aiming to serve themselves with maximum efficiency.", "PUMP belongs to the category of pre-workout blends with a comprehensive formula designed for maximum effectiveness. It contains carefully selected amino acids, plant extracts, vitamins, and minerals for athletes. The overall formula primarily includes the non-essential amino acid L-citrulline malate, functioning as a precursor to arginine. The latter serves as a substrate for the production of nitric oxide (NO), which plays a key role in vasodilation, expanding blood vessels. This allows more nutrients and oxygen to reach the muscles, crucial for achieving maximum performance.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/6/3/63da4cf24c412_.png", "Bubblegum flavor: L-citrulline malate, beta-alanine, glycerol monostearate, L-tyrosine, taurine, anti-caking agent silicon dioxide, choline L-bitartrate, Withania somnifera extract (5% withanolides), sodium citrate, Bacopa monnieri extract, anti-caking agent calcium phosphate, flavor, sweeteners sucralose and steviol glycosides, niacinamide, calcium D-pantothenate, thiamine hydrochloride, black pepper extract (95% piperine) - Bioperine®, brilliant color.", "Nutrend", "Pre-Workout PUMP 225g", 35.99m, "Supplement" },
                    { 10, "A comprehensive and effective formula for a pre-workout booster, containing taurine and caffeine to provide energy before a workout, along with beta-alanine, L-citrulline, L-arginine, and creatine; enriched with vitamin B3; enhances performance during intense interval training; contributes to normal muscle function; reduces fatigue and exhaustion; widens blood vessels; comes in powder form and easily dissolves in liquids.", "The pre-workout stimulant \"Concentrated\" is a highly effective powder blend that easily dissolves in water and will provide you with the necessary energy before physical activity. The product contains 192 mg of caffeine to energize you before your workout, as well as creatine, ideal for enhancing physical performance during high-intensity interval training. Another active ingredient in the stimulant is taurine, often found in energy drinks, along with vitamin B3, which influences metabolism, aids muscle function, and delays fatigue and exhaustion.\r\n\r\nLastly, the product is enriched with essential amino acids. Beta-alanine contributes to carnosine production, functioning as a \"cleansing\" agent for your muscles by preventing the buildup of lactic acid and delaying excessive oxygenation. This means it delays muscle fatigue and extends your active time. L-citrulline and L-arginine, also present in the blend, impact nitric oxide production, widening blood vessels to enhance nutrient and oxygen delivery to working muscles. Lastly, but not least, L-tyrosine acts as a precursor to adrenaline, noradrenaline, and dopamine.\r\n\r\nThe ingredients in the \"Concentrated\" pre-workout stimulant make it a highly effective booster suitable for both strength athletes and those engaging in endurance-demanding sports. The blend dissolves well in water and is suitable for vegans.", "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/1/-/1-bodylab-preworkout-apple-375g_1.jpg", "Green Apple flavored blend CPW (creatine monohydrate, beta-alanine, L-arginine AKG, taurine, L-citrulline DL malate, L-tyrosine), dextrin, caffeine, flavor enhancer, sweetener (sucralose), magnesium citrate, vitamin B3 (niacin), acidity regulator (citric acid), potassium chloride, sodium chloride, coloring agent (copper complex of chlorophyllin and beta-carotene), release agent (silicon dioxide), flavor enhancer.", "Bodylab24", "Concentrated Pre Workout 375g", 72.99m, "Supplement" }
                });

            migrationBuilder.InsertData(
                table: "TrainingPlans",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "1# Barbell Squats\r\nSets: 4\r\nReps: 8-10\r\n\r\n2# Leg Press\r\nSets: 3\r\nReps: 10-12\r\n\r\n3# Romanian Deadlifts\r\nSets: 4\r\nReps: 8-10\r\n\r\n4# Lunges (each leg)\r\nSets: 3\r\nReps: 12-15\r\n\r\n5# Leg Extensions\r\nSets: 3\r\nReps: 12-15\r\n\r\n6# Seated Calf Raises\r\nSets: 4\r\nReps: 15-20\r\n\r\n7# Standing Calf Raises\r\nSets: 4\r\nReps: 15-20", "Leg Workout - BEGINNERS 1#" },
                    { 2, 1, "1# Barbell Squats\r\nSets: 4\r\nReps: 8-10\r\n\r\n2# Romanian Deadlifts\r\nSets: 4\r\nReps: 10-12\r\n\r\n3# Leg Press\r\nSets: 3\r\nReps: 12-15\r\n\r\n4# Lunges (each leg)\r\nSets: 3\r\nReps: 10-12\r\n\r\n5# Leg Extensions\r\nSets: 3\r\nReps: 15-20\r\n\r\n6# Hamstring Curls\r\nSets: 3\r\nReps: 12-15\r\n\r\n7# Calf Raises\r\nSets: 4\r\nReps: 15-20", "Leg Workout - BEGINNERS 2#" },
                    { 3, 1, "1# Barbell Hip Thrusts\r\nSets: 4\r\nReps: 8-10\r\n\r\n2# Bulgarian Split Squats\r\nSets: 3\r\nReps: 10-12 (each leg)\r\n\r\n3# Romanian Deadlifts\r\nSets: 4\r\nReps: 8-10\r\n\r\n4# Glute Bridges\r\nSets: 3\r\nReps: 12-15\r\n\r\n5# Cable Kickbacks\r\nSets: 3\r\nReps: 15-20 (each leg)\r\n\r\n6# Sumo Deadlifts\r\nSets: 4\r\nReps: 6-8\r\n\r\n7# Glute-Ham Raises\r\nSets: 3\r\nReps: 10-12", "Workout Routine: Big Glutes" },
                    { 4, 2, "1# Dumbbell Bicep Curls\r\nSets: 3\r\nReps: 12\r\n\r\n2# Hammer Curls\r\nSets: 3\r\nReps: 12\r\n\r\n3# Concentration Curls\r\nSets: 3\r\nReps: 12", "Bicep Workout - BEGINNERS 1#" },
                    { 5, 2, "1# Barbell Bicep Curl\r\nSets: 4\r\nReps: 8-10\r\n\r\n2# Preacher Curl (using an EZ bar)\r\nSets: 4\r\nReps: 10-12\r\n\r\n3# Incline Dumbbell Curl\r\nSets: 3\r\nReps: 12-15\r\n\r\n4# Chin-Up\r\nSets: 3\r\nReps: As many as you can (aim for 6-10 reps)", "BRUTAL Bicep Workout" },
                    { 6, 4, "#1 Bench Press\r\nSets: 4\r\nReps: 8-12\r\n\r\n#2 Incline Dumbbell Press\r\nSets: 4\r\nReps: 8-12\r\n\r\n#3 Vertical Chest Press\r\nSets: 3\r\nReps: 12-15\r\n\r\n#4 Pec Deck\r\nSets: 3\r\nReps: 15-20", "BRUTAL Chest Workout" },
                    { 7, 4, "#1 Incline Dumbbell Press\r\nSets: 4\r\nReps: 8-12\r\n\r\n#2 Bench Press\r\nSets: 3\r\nReps: 8-12\r\n\r\n#3 Dips\r\nSets: 3\r\nReps: 12-15\r\n\r\n#4 Pec Deck\r\nSets: 3\r\nReps: 15-20", "Chest Workout - BEGINNERS #1" },
                    { 8, 5, "#1 Bent Over Barbell Rows\r\nSets: 4\r\nReps: 8-10\r\n\r\n#2 Lat Pulldowns\r\nSets: 3\r\nReps: 10-12\r\n\r\n#3 T-Bar Rows\r\nSets: 3\r\nReps: 8-10\r\n\r\n#4 Seated Cable Rows\r\nSets: 3\r\nReps: 12-15", "Back Workout - BEGINNERS #1" },
                    { 9, 5, "#1 Deadlifts\r\nSets: 4\r\nRepetitions: 6-8\r\n\r\n#2 Pull-Ups\r\nSets: 3\r\nRepetitions: Max (aim for 8-10 reps)\r\n\r\n#3 Barbell Rows\r\nSets: 3\r\nRepetitions: 8-10\r\n\r\n#4 Dumbbell Rows\r\nSets: 3\r\nRepetitions: 10-12", "Back Workout - BEGINNERS #2" },
                    { 10, 6, "#1 Barbell Wrist Curl (Palms Up)\r\nSets: 4\r\nReps: 12-15\r\n\r\n#2 Reverse Barbell Wrist Curl (Palms Down)\r\nSets: 4\r\nReps: 12-15\r\n\r\n#3 Farmer's Walk with Dumbbells\r\nSets: 3\r\nReps: Walk for 30-40 seconds\r\n\r\n#4 Plate Pinch Hold\r\nSets: 3\r\nReps: Hold for 20-30 seconds", "Forearms Workout - BEGINNERS #1" },
                    { 11, 7, "#1 Crunches\r\nSets: 3\r\nReps: 15-20\r\n\r\n#2 Leg Raises\r\nSets: 3\r\nReps: 12-15\r\n\r\n#3 Russian Twists\r\nSets: 3\r\nReps: 20 (10 twists per side)\r\n\r\n#4 Plank\r\nSets: 3\r\nRepetitions: Hold for 30-45 seconds", "Abs Workout - BEGINNERS #1" },
                    { 12, 8, "#1 Military Press (Barbell or Dumbbell)\r\nSets: 4\r\nReps: 6-8\r\n\r\n#2 Dumbbell Lateral Raises\r\nSets: 3\r\nReps: 10-12\r\n\r\nExercise 3 Arnold Press\r\nSets: 3\r\nReps: 8-10\r\n\r\n#4 Bent-Over Dumbbell Rear Delt Raises\r\nSets: 3\r\nReps: 12-15", "Shoulders Workout - BEGINNERS #1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clothes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrainingPlans",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65711ed3-baf2-4084-ab0c-dc0b7af05a45"),
                column: "ConcurrencyStamp",
                value: "e3fd6019-193e-4af3-bcfa-acbf85f1c9d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a12d2cfd-0058-4c64-babd-8c1437001f78"),
                column: "ConcurrencyStamp",
                value: "1eaaad87-67cc-499f-a84c-38278d84793d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "53fa3cc4-91ae-4686-832d-e69a70e437b5", new DateTime(2023, 8, 11, 13, 14, 31, 781, DateTimeKind.Utc).AddTicks(1403), "AQAAAAEAACcQAAAAEJtd8eh37GfS0BS+mdWVEjpVcY2xrq+tUGqC1+vGgMrOteJGN0bMzcaR5FAYLDnB6Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "92a98427-eaf9-4818-9220-e9e2c7e089b8", new DateTime(2023, 8, 11, 13, 14, 31, 778, DateTimeKind.Utc).AddTicks(6851), "AQAAAAEAACcQAAAAEACtYHt107zsqUBGQV8yJ+T7ftPIZA6yYlOTpE7BZlVdy/2JHURzqXc6AxLEJGYTRQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "175c4739-aaa9-4ab9-8690-3e0afb4aec54", new DateTime(2023, 8, 11, 13, 14, 31, 779, DateTimeKind.Utc).AddTicks(8747), "AQAAAAEAACcQAAAAEDGIAsCBDE/MA+bIyPZuFB8EyXkUboA/lmGcAmHHGUgmOr5Zuc1CatK5cWCJwyHQDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "1758e956-e02d-490a-89bd-4e10dcc0d01d", new DateTime(2023, 8, 11, 13, 14, 31, 777, DateTimeKind.Utc).AddTicks(4656), "AQAAAAEAACcQAAAAEI7+WEHV8uy3VhSCmxTHuP0cS47voGDv3SIaomVRv/H1RPwnlnmw7B+G+4mvQmHCtg==" });
        }
    }
}
