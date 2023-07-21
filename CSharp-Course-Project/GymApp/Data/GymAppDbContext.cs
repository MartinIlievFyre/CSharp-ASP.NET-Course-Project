using GymApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace GymApp.Data
{
    public class GymAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public GymAppDbContext(DbContextOptions<GymAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; } = null!;

        public DbSet<TrainingPlan> TrainingPlans { get; set; } = null!;

        public DbSet<Food> Foods { get; set; } = null!;

        public DbSet<UserFood> UsersFoods { get; set; } = null!;

        public DbSet<Wear> Clothes { get; set; } = null!;

        public DbSet<Supplement> Supplements { get; set; } = null!;

        public DbSet<Accessory> Accessories { get; set; } = null!;

        public DbSet<WearCategory> WearCategories { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<ApplicationUserExercise> ApplicationUsersExercises { get; set; } = null!;

        public DbSet<ApplicationUserFood> ApplicationUsersFoods { get; set; } = null!;

        public DbSet<ApplicationUserTrainingPlan> ApplicationUsersTrainingPlans { get; set; } = null!;

        public DbSet<ApplicationUserWear> ApplicationUsersClothes { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Seeding exercise categories
            builder
                .Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Name = "Legs"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Biceps"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Triceps"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Chest"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Back"
                },
                new Category()
                {
                    Id = 6,
                    Name = "Forearms"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Abs"
                },
                new Category()
                {
                    Id = 8,
                    Name = "Shoulders"
                });



            //Seeding clothes categories
            builder
                .Entity<WearCategory>()
                .HasData(new WearCategory()
                {
                    Id = 1,
                    Name = "T-Shirts"
                },
                 new WearCategory()
                 {
                     Id = 2,
                     Name = "Hoodies"
                 });

            //Seeding exercises
            builder
               .Entity<Exercise>()
               .HasData(new Exercise()
               {
                   Id = 1,
                   Name = "Leg Press",

                   Execution = "Sit in the leg press seat, and place your feet in the middle of the sled, about shoulder-width apart. Press the sled out of the rack, lower the safety bars, and then slowly lower the sled towards your chest until your thighs break 90 degrees. Press the sled back up but do not lock out your knees. If your lower back or hips lift off the seat as you drive the weight back up, you’re going too far down.",

                   Benefit = "The leg press enables you to exert more force using only your legs, providing a squat-like motion without placing weight on your spine or torso, making it ideal for high-rep sets and drop sets.",

                   ImageUrl = "https://weighttraining.guide/wp-content/uploads/2016/05/Sled-45-degree-Leg-Press-resized.png",
                   CategoryId = 1
               },
               new Exercise()
               {
                   Id = 2,
                   Name = "Hack Squat",
                   Execution = "Your stance on the foot platform will closely mimic that of your back squat stance. You want your feet slightly outside shoulder width with feet angled slightly outward — they should be in line with the knee as it tracks forward during the descent. \r\n\r\nYour torso should be stable with your abdominals engaged and your lower back flat on the back pad. Maintain a neutral head position as you lower your body until the bottoms of your thighs are parallel to the foot platform and drive through your feet to the top.",

                   Benefit = "The hack squat, being a machine, offers enhanced stability compared to free-weight squat variations, its predefined path reducing the risk of injury and accommodating pre-existing injuries.",

                   ImageUrl = "https://www.bodybuildingmealplan.com/wp-content/uploads/Hack-Squat-Muscles-Worked.jpg",
                   CategoryId = 1
               },
               new Exercise()
               {
                   Id = 3,
                   Name = "Barbell Curl",
                   Execution = "With an underhand grip slightly wider than the shoulders, grab a barbell, pull your shoulders back, and position your elbows under your shoulder joints or slightly in front by your ribs; then, curl the barbell up using your biceps to expose the fronts of your biceps.",

                   Benefit = "The barbell curl, with its simple and effective mechanics, has a small learning curve, making it ideal for beginners, while still providing benefits to more advanced lifters, allowing them to load their biceps with heavier weights and build stronger biceps more quickly.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/barbell-curl-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 2
               },
               new Exercise()
               {
                   Id = 4,
                   Name = "Hammer Curl",
                   Execution = "While standing, hold a dumbbell in each hand with wrists facing each other, tuck your arms in at your sides, and flex your elbows to curl the dumbbells up towards your shoulders, then lower them back down with control.",

                   Benefit = "The hammer curl, with its comfortable neutral wrist position, allows for lifting heavier weights and accumulating more muscle-building volume over time, effectively targeting the inner biceps muscle and forearm to promote denser arms.",

                   ImageUrl = "https://weighttraining.guide/wp-content/uploads/2016/11/Dumbbell-Hammer-Curl-resized.png",
                   CategoryId = 2
               },
               new Exercise()
               {
                   Id = 5,
                   Name = "Skullcrusher",
                   Execution = "Begin by lying on a bench with the hands supporting a weight (barbell, dumbbells, or cable attachments) at the top of the bench pressing position, aligning the back and hips as in a bench press; slightly pull the elbows back, pointing them behind you, as you lower the bar handle or loads towards your head, almost touching the forehead, experiencing a stretch on the triceps and partial engagement of the lats, and finally, push the bar back up.",

                   Benefit = "This exercise offers versatility with options such as barbells, kettlebells, or dumbbells, making it a versatile triceps exercise that capitalizes on your strength in this position, leading to significant triceps strength gains.",

                   ImageUrl = "https://adventurefitness.club/wp-content/uploads/2022/11/lying-triceps-extension-vs-skullcrusher.jpeg",
                   CategoryId = 3
               },
               new Exercise()
               {
                   Id = 6,
                   Name = "Triceps Pushdown",
                   Execution = "Set the cables or band at a high anchor point, face your body towards it, place your feet together, keep your elbows by your sides, chest up, back flat, and hips angled slightly forward, then grab the handles or band and push them down by fully extending your elbows, ensuring that your elbows are slightly in front of your shoulders.",

                   Benefit = "This exercise allows for complete isolation of the triceps, providing the ability to feel the muscle contract and achieve a satisfying pump.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Triceps-Rope-Pushdown-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 3
               },
               new Exercise()
               {
                   Id = 7,
                   Name = "Dumbbell Bench Press",
                   Execution = "Begin by sitting on a flat bench and hinging forward to pick up each dumbbell, placing them on your knees; after getting set, lean back and drive the dumbbells back towards you using your knees, while simultaneously pressing the weights over your chest, then lower the weights with elbows tucked at a 45-degree angle until they break 90 degrees, followed by driving the dumbbells back up, optionally transitioning to a neutral grip position with palms facing each other for the press.",

                   Benefit = "Using two separate dumbbells for pressing exercises allows for easier customization of a comfortable position, particularly beneficial for individuals with shoulder or elbow discomfort, while also promoting enhanced joint and muscle stability; furthermore, the individual effort required by each side helps balance any strength disparities and enables weaker sides of the body to catch up.",

                   ImageUrl = "https://fitnessvolt.com/wp-content/uploads/2018/04/dumbbell-bench-press.jpg",
                   CategoryId = 4
               },
               new Exercise()
               {
                   Id = 8,
                   Name = "Bent-Over Row",
                   Execution = "To perform the barbell bent-over row, set up in a deadlift position with feet shoulder-width apart in front of a loaded barbell, hinge at the hips to achieve a parallel torso to the floor, grip the barbell slightly wider than your typical deadlift grip, lean back to distribute weight on your heels, and initiate the row by pulling with your elbow until the barbell touches around your belly button, ensuring the barbell doesn't touch the floor between repetitions, and considering a wider grip or a more upright torso for individuals with longer arms.",

                   Benefit = "The bent-over row can be effectively executed using tools like kettlebells, dumbbells, or a cable machine, allowing for efficient muscle overload as you can handle significant weight in the bent-over row position.",

                   ImageUrl = "https://weighttraining.guide/wp-content/uploads/2016/10/Bent-over-barbell-row.png",
                   CategoryId = 5
               },
               new Exercise()
               {
                   Id = 9,
                   Name = "Wrist Roller",
                   Execution = "Begin with a 2.5, five, or 10-pound weight plate, stand with feet hip-width apart, grip the wrist roller with knuckles facing towards you, gradually execute a front raise to elevate the roller to shoulder height, roll the weight up while alternating hands until fully wound, and then slowly reverse the movement.",

                   Benefit = "Engaging both forearm extensors and flexors, the wrist roller exercise strengthens these muscles while the thick grip enhances grip strength, requiring focused attention on the wrists and forearms, which are typically secondary to the primary movers.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2022/11/Wrist-roller.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 6
               },
               new Exercise()
               {
                   Id = 10,
                   Name = "L-Sit",
                   Execution = "Sit between two dumbbells or kettlebells, placing each hand on a handle, then elevate your body off the floor by extending your legs and maintain an isometric hold, ensuring tension in the middle and upper back.",

                   Benefit = "By resisting gravity and rotational forces, the L-sit exercise enhances full-body strength, demanding significant isometric strength while stimulating exceptional abdominal strength and stability, making it a valuable core strengthening exercise that prepares lifters and gymnastic athletes for more challenging athletic movements.",

                   ImageUrl = "https://weighttraining.guide/wp-content/uploads/2021/10/Floor-L-sit-fixed.png",
                   CategoryId = 7
               },
               new Exercise()
               {
                   Id = 11,
                   Name = "Dumbbell Shoulder Press",
                   Execution = "Begin by grabbing a pair of dumbbells and lifting them to the starting position at your shoulders, lightly brace your core while inhaling, press the dumbbells up to straight arms while exhaling, inhale at the top or during controlled lowering back to your shoulders, and repeat for the desired number of repetitions.",

                   Benefit = "The dumbbell shoulder press targets and develops muscles in the shoulders, triceps, biceps, and upper back, leading to improvements in overall upper body physique, and as a compound exercise utilizing multiple joints and muscles simultaneously, it is more effective in producing results compared to isolation exercises.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Dumbbell-Shoulder-Press-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 8
               });

            //Seeding food
            builder
                 .Entity<Supplement>()
                 .HasData(new Supplement()
                 {
                     Id = 1,
                     Name = "Calcium Citrate 100 Tablets",
                     Manufacturer = "NOW",
                     Description = "Calcium citrate, in tablet form, is the most biologically accessible form of calcium, ensuring optimal health for muscles, bones, and teeth, while also participating in blood clotting and supporting proper neurotransmission. Additionally, it is enriched with other beneficial electrolytes such as vitamin D2, magnesium, copper, manganese, and zinc, which play crucial roles in bone metabolism, reduce fatigue, support immune and nervous system health, promote healthy hair, nails, and skin, and protect cells from oxidative stress, making the product suitable for vegans and vegetarians.",
                     Benefits = "The most biologically accessible form of calcium, enriched with vitamin D2, magnesium, copper, zinc, and manganese, ensures the health of muscles, bones, and teeth, participates in blood clotting, supports proper neurotransmission, guarantees immune function, and promotes the well-being of hair, nails, and skin, conveniently available in tablet form and suitable for vegetarians and vegans.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/u/n/untitled_design_-_2020-04-03t164935.609.png",
                     Ingredients = "Hydroxypropyl cellulose, vegetable coating, croscarmellose sodium, silicon dioxide, magnesium stearate (vegetable source), and stearic acid (vegetable source).",
                     Price = 29.99m
                 },
                 new Supplement()
                 {
                     Id = 2,
                     Name = "Ashwagandha 90 Capsules",
                     Manufacturer = "GymBeam",
                     Description = "Ashwagandha or Indian Ginseng (Withania somnifera) is a plant classified among adaptogens, compounds known for their beneficial effects on the body, particularly in increasing its resilience and improving the adaptation process to stress. Similar to how our muscles become stronger and grow when we exercise, adaptogens can enhance the body's resistance to stress and aid in better stress management. It's no wonder that Ashwagandha is popular among individuals experiencing daily stress at work, school, or in their personal lives. However, its benefits don't end there; this plant is still being researched by scientific institutions for its potential positive effects in reducing anxiety, fatigue, lowering the stress hormone cortisol, and enhancing athletic performance, strength, and sleep. Additionally, it may support our mental well-being and aid in relaxation.",
                     Benefits = "500 mg of Ashwagandha (Withania somnifera) extract, containing 5% of active compounds called withanolides, classified as adaptogens, may help enhance the body's resilience and aid in better stress management, available in convenient capsule form.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/a/s/ashwagandha_90_caps.png",
                     Ingredients = "Ashwagandha extract (Withania somnifera) (5% withanolides), anti-caking agent (calcium phosphate, magnesium stearate), gelatin capsule.",
                     Price = 19.99m
                 },
                 new Supplement()
                 {
                     Id = 3,
                     Name = "Zinc 100 Tablets",
                     Manufacturer = "GymBeam",
                     Description = "Zinc is an essential mineral found in many food supplements, vital for hundreds of biological processes in the body, supporting proper metabolism of macronutrients like carbohydrates, crucial for energy supply to athletes and active individuals. It also aids in maintaining bone health, protein synthesis for muscle growth, and has a positive impact on testosterone levels in men. Zinc plays a vital role in various bodily processes, positively affecting muscle size and strength, fertility, and reproductive function, benefiting skin, hair, and nails for women, and supporting vision for those spending time in front of screens. Additionally, as an antioxidant, zinc protects cells against oxidative stress, boosts the immune system, aids in fat metabolism, DNA synthesis, cognitive functions, and vitamin A metabolism, making it an ideal supplement for overall health and suitable for vegans.",
                     Benefits = "This dietary supplement, containing this essential mineral, participates in hundreds of biological processes, supporting proper carbohydrate metabolism, bone health, protein synthesis, maintaining normal testosterone levels, enhancing fertility and reproductive function, promoting healthy skin, hair, and nails, supporting good vision, boosting the immune system, influencing proper metabolism of fatty acids, aiding in DNA synthesis, maintaining cognitive functions, affecting the metabolism of vitamin A, protecting cells against oxidative stress, and suitable for vegans, making it ideal for anyone striving to maintain optimal health.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/z/i/zinc_100_tabs_gymbeam.png",
                     Ingredients = "Filler (microcrystalline cellulose, calcium hydrogen phosphate), zinc oxide, coating (stearic acid), anti-caking agent (magnesium stearate).",
                     Price = 10.99m
                 },
                 new Supplement()
                 {
                     Id = 4,
                     Name = "Vitamin C 1000mg 180 Tablets",
                     Manufacturer = "GymBeam",
                     Description = "Vitamin C 1000 mg, also known as L-ascorbic acid, is an essential vitamin found in easy-to-swallow tablets and commonly present in various fruits and vegetables. It participates in numerous biological processes, making it one of the most popular supplements supporting overall health and vitality. Vitamin C contributes to the proper functioning of the immune and nervous systems, supports immunity during and after intense physical activity, promotes mental balance, reduces fatigue, and aids in energy metabolism for daily activities and sports. Additionally, it maintains bone and cartilage health, collagen production, and the health of skin, gums, and teeth. Moreover, Vitamin C acts as an antioxidant, protects cells from oxidative stress, enhances iron absorption, and supports cardiovascular health. The supplement is enriched with rosehip extract (Rosa canina), offering a wide range of beneficial effects.",
                     Benefits = "This supplement contains 1000 mg of ascorbic acid (Vitamin C), offered in easy-to-swallow tablets, supporting the proper functioning of the immune and nervous systems, promoting mental balance, reducing fatigue, maintaining energy metabolism, bone and cartilage health, collagen production, skin, gum, and teeth function, protecting cells from oxidative stress, enhancing iron absorption, and supporting cardiovascular health, enriched with rosehip extract, promoting overall health and vitality.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/n/e/new_vitamin_c.png",
                     Ingredients = "Vitamin C (L-ascorbic acid), rosehip extract (Rosa canina), filler (microcrystalline cellulose), anti-caking agent (magnesium stearate).",
                     Price = 35.99m
                 },
                 new Supplement()
                 {
                     Id = 5,
                     Name = "Just Whey 1kg",
                     Manufacturer = "GymBeam",
                     Description = "Just Whey Protein is a multi-component whey protein powder that effectively supports protein intake after workouts or at any other time of the day, containing a unique combination of whey protein concentrate, isolate, and hydrolysate, ensuring high absorbability and bioavailability for the body, providing 18% EPA and 12% DHA, supporting cardiovascular functions, brain functions, and good vision, enriched with vitamin E, respecting nature and produced from the milk of free-range cows, with added enzymes for better nutrient absorption, containing 74.8% protein content, supporting muscle growth and maintenance, beneficial for athletes, active individuals, and those on a weight loss or recovery journey, enriched with vitamins and minerals like B6, magnesium, and zinc, easily consumed in various ways and delicious flavors, suitable for a healthy lifestyle.",
                     Benefits = "A multi-component whey protein powder, derived from the milk of free-range cows, containing a combination of whey concentrate, isolate, and hydrolysate, boasting an impressive 74.8% protein content, providing 22.4g of protein per serving, including all essential amino acids and BCAAs, making it an ideal choice to meet protein intake needs, supporting muscle growth and preservation, with high bioavailability and easy digestibility, enriched with selected vitamins and minerals, promoting muscle function and bone health, positively impacting optimal testosterone levels, aiding in reducing fatigue and tiredness, supporting proper immune function, offering a delightful taste and easy solubility, containing only natural flavors and colors, a great way to enrich cereals and other dishes with high-quality protein, suitable for athletes and all active individuals, perfect for post-workout or anytime during the day.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/j/u/just_whey_unflavored_1_kg_gymbeam_1.png",
                     Ingredients = "Whey protein concentrate powder, whey protein isolate powder, protein hydrolysate, minerals (magnesium citrate, zinc oxide), vitamins (vitamin E - tocopheryl acetate, vitamin B6 - pyridoxine hydrochloride), DigeZyme® - a complex of digestive enzymes, bromelain.",
                     Price = 99.99m
                 },
                 new Supplement()
                 {
                     Id = 6,
                     Name = "Creatine Monohydrate 500g",
                     Manufacturer = "GymBeam",
                     Description = "100% Creatine monohydrate is a popular supplement known for enhancing physical performance in short, intense exercises, making it highly favored by athletes, including strength trainers, team sport enthusiasts, and HIIT practitioners. It is a naturally occurring substance in the body, and supplementing with creatine powder ensures easy intake of the recommended daily dose of at least 3 grams, supporting improved exercise performance without the need for cycling or time-limited usage.",
                     Benefits = "100% Creatine monohydrate, a highly researched nutritional supplement, enhances physical performance during short bursts of intense exercises, making it suitable for strength athletes and team sport enthusiasts; it comes in a soluble powder form that can be easily mixed with water, juice, or post-workout protein shakes.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/c/r/creatinemonohydrate_500_1.jpg",
                     Ingredients = "Unflavored: Creatine monohydrate",
                     Price = 39.99m
                 });


            //Seeding accessories
            builder
                .Entity<Accessory>()
                .HasData(new Accessory()
                {
                    Id = 1,
                    Name = "Weight belt LEVER Black",
                    Manufacturer = "GymBeam",
                    Description = "The LEVER weightlifting belt is a practical device designed for individuals engaged in strength training, aiming to increase the weights they lift; it helps stabilize the core and lower back muscles, boosting your confidence and enabling you to lift heavier weights. Made from 4-layered material - 2 inner layers of cowhide and suede covered with 2 outer layers of buffalo suede - it ensures stability and durability while fitting perfectly to your body; the belt also features an adjustable section to accommodate your waist size, eliminating concerns about it being too large or small. If you want to enhance the weights lifted during squats or deadlifts, this high-quality leather belt should undoubtedly be part of your fitness arsenal.",
                    Benefits = "The 4-layer leather belt with an adjustable section provides stability and durability while ensuring comfort, offering support during weightlifting and is suitable for individuals engaging in heavy lifting.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/w/e/weightlifting-belt-lever-gymbeam_5_.jpg",
                    Price = 99.99m
                },
                new Accessory()
                {
                    Id = 2,
                    Name = "Fitness gloves Ronnie",
                    Manufacturer = "GymBeam",
                    Description = "The Ronnie fitness gloves are high-quality exercise gloves made of split leather with a rubber-padded cowhide interior for an ideal fit and intense workout protection for every athlete; they are reinforced with a double lining in the palm area for durability and resistance against wear, designed for professional athletes seeking superior hand protection during training, guarding against scratches, calluses, and impacts while providing a secure grip on workout equipment, but they should not be machine washed.",
                    Benefits = "The Ronnie fitness gloves protect hands from injuries, calluses, and abrasions, providing a secure grip during workouts with fitness equipment, bars, or weights; they are perfect for strength training, have an ergonomic shape for long-lasting durability, and fit hands comfortably without squeezing fingers.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/r/u/rukavice_2j_1.jpg",
                    Price = 19.99m
                },
                new Accessory()
                {
                    Id = 3,
                    Name = "Green shaker 700ml",
                    Manufacturer = "GymBeam",
                    Description = "The green shaker is a classic 700ml shaker with a traditional closure and filter, perfect for mixing your favorite proteins, pre-workout stimulants, and creatine; made of non-toxic plastic and free from BPA and DEHP.",
                    Benefits = "This 700ml shaker, made of high-quality polypropylene PP, is perfect for mixing all soluble dietary supplements, featuring a leak-proof screw-on lid, a cone-shaped filter to prevent lumps, milliliter (ml) and ounce (oz) markings, break-resistant, dishwasher, microwave, and fridge safe, BPA and DEHP-free, and compliant with food regulations.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/s/h/shaker_yellow_green.jpg",
                    Price = 7.99m
                },
                new Accessory()
                {
                    Id = 4,
                    Name = "Towel for fitness",
                    Manufacturer = "GymBeam",
                    Description = "This gray fitness and workout towel, made of 100% soft and pleasant-to-touch cotton, stands out with its excellent absorption, high durability, and anti-static, antibacterial properties. With dimensions of 50x90 cm, this towel possesses these qualities naturally, without the use of any chemical compounds, making it suitable for individuals with sensitive skin or allergies, as it does not cause allergic reactions. Every athlete recognizes the significance of a workout towel, an essential accessory in the gym, not only to wipe away sweat from the face but also to provide a clean surface for various exercises, such as for abdominal workouts, seating, or under the feet during exercises. Not having a workout towel in the gym is a pure faux pas (embarrassing mistake) and can easily be avoided to prevent someone from asking, \"Where is your towel?\"",
                    Benefits = "Made of 100% cotton, this towel has anti-static and antibacterial properties, dries quickly, absorbs efficiently, feels soft and pleasant to touch, and boasts a long lifespan.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/g/r/grey_fitness_towel_gymbeam_1_.jpg",
                    Price = 14.99m
                });

           //Seeding food
           builder
                 .Entity<UserFood>()
                 .HasData(new UserFood()
                 {
                     Id = 1,
                     Name = "Apple",
                     Calories = 52,
                     Carbs = 13.8,
                     Fat = 0.2,
                     Protein = 0.3
                 });



            //Seeding clothes
            builder
            .Entity<Wear>()
            .HasData(new Wear()
            {
                Id = 1,
                Name = "Hardcore T-shirt Black",
                Price = 29.99m,
                ImageUrl = "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-black.jpg",
                Description = "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.",
                Color = "Black",
                Size = "S",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 2,
                Name = "Hardcore T-shirt Black",
                Price = 29.99m,
                ImageUrl = "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-black.jpg",
                Description = "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.",
                Color = "Black",
                Size = "M",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 3,
                Name = "Hardcore T-shirt Black",
                Price = 29.99m,
                ImageUrl = "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-black.jpg",
                Description = "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.",
                Color = "Black",
                Size = "L",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 4,
                Name = "Hardcore T-shirt White",
                Price = 29.99m,
                ImageUrl = "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg",
                Description = "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.",
                Color = "White",
                Size = "S",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 5,
                Name = "Hardcore T-shirt White",
                Price = 29.99m,
                ImageUrl = "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg",
                Description = "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.",
                Color = "White",
                Size = "M",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 6,
                Name = "Hardcore T-shirt White",
                Price = 29.99m,
                ImageUrl = "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white-510x510.jpg",
                Description = "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great range of  motion to get you through your workout in total comfort.",
                Color = "White",
                Size = "L",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 7,
                Name = "Gym Warrior T-shirt Black",
                Price = 29.99m,
                ImageUrl = "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600",
                Description = "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.",
                Color = "Black",
                Size = "S",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 8,
                Name = "Gym Warrior T-shirt Black",
                Price = 29.99m,
                ImageUrl = "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600",
                Description = "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.",
                Color = "Black",
                Size = "M",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 9,
                Name = "Gym Warrior T-shirt Black",
                Price = 29.99m,
                ImageUrl = "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg? width=800&height=800&hash=1600",
                Description = "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range /o  motion to get you through your workout in total comfort.",
                Color = "Black",
                Size = "L",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 10,
                Name = "The Cicle T-shirt Black",
                Price = 29.99m,
                ImageUrl = "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit",
                Description = "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.",
                Color = "Black",
                Size = "S",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 11,
                Name = "The Cicle T-shirt Black",
                Price = 29.99m,
                ImageUrl = "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit",
                Description = "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.",
                Color = "Black",
                Size = "M",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 12,
                Name = "The Cicle T-shirt Black",
                Price = 29.99m,
                ImageUrl = "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeat-t- shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit",
                Description = "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range of motion  to get you through your workout in total comfort.",
                Color = "Black",
                Size = "L",
                Fabric = "Cutton",
                WearCategoryId = 1
            },
            new Wear()
            {
                Id = 13,
                Name = "Hardcore Hoodie Black",
                Price = 49.99m,
                ImageUrl = "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg",
                Description = "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.",
                Color = "Black",
                Size = "S",
                Fabric = "Cutton",
                WearCategoryId = 2
            },
            new Wear()
            {
                Id = 14,
                Name = "Hardcore Hoodie Black",
                Price = 49.99m,
                ImageUrl = "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg",
                Description = "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.",
                Color = "Black",
                Size = "M",
                Fabric = "Cutton",
                WearCategoryId = 2
            },
            new Wear()
            {
                Id = 15,
                Name = "Hardcore Hoodie Black",
                Price = 49.99m,
                ImageUrl = "https://www.hard-wear.com/media/catalog/product/cache/b8bf61042c9b806ea0edf19101a0211e/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg",
                Description = "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.",
                Color = "Black",
                Size = "L",
                Fabric = "Cutton",
                WearCategoryId = 2
            },
            new Wear()
            {
                Id = 16,
                Name = "Hardcore Hoodie White",
                Price = 49.99m,
                ImageUrl = "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg",
                Description = "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.",
                Color = "White",
                Size = "S",
                Fabric = "Cutton",
                WearCategoryId = 2
            },
            new Wear()
            {
                Id = 17,
                Name = "Hardcore Hoodie White",
                Price = 49.99m,
                ImageUrl = "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg",
                Description = "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.",
                Color = "White",
                Size = "M",
                Fabric = "Cutton",
                WearCategoryId = 2
            },
            new Wear()
            {
                Id = 18,
                Name = "Hardcore Hoodie White",
                Price = 49.99m,
                ImageUrl = "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-Hardcore-Sportswear-Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg",
                Description = "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.",
                Color = "White",
                Size = "L",
                Fabric = "Cutton",
                WearCategoryId = 2
            });
            


            builder.Entity<ApplicationUserExercise>().HasKey(aue => new { aue.TrainingGuyId, aue.ExerciseId });
            builder.Entity<ApplicationUserFood>().HasKey(auf => new { auf.TrainingGuyId, auf.FoodId });
            builder.Entity<ApplicationUserTrainingPlan>().HasKey(autp => new { autp.TrainingGuyId, autp.TrainingPlanId });
            builder.Entity<ApplicationUserWear>().HasKey(auw => new { auw.TrainingGuyId, auw.WearId });

            builder.Entity<UserFood>().Property("Calories").HasDefaultValue(0);
            builder.Entity<UserFood>().Property("Carbs").HasDefaultValue(0);
            builder.Entity<UserFood>().Property("Fat").HasDefaultValue(0);
            builder.Entity<UserFood>().Property("Protein").HasDefaultValue(0);

            base.OnModelCreating(builder);

        }
    }
}