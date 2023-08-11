namespace GymApp.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    using GymApp.Data.Models;

    using static GymApp.Common.GeneralApplicationConstants;
    using GymApp.Data.Configuration;

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
        public DbSet<Product> ShoppingCart { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var roleConfiguration = new CreateRolesConfiguration();
            var userConfiguration = new SeedUsersConfiguration();

            builder.ApplyConfiguration<IdentityRole<Guid>>(roleConfiguration);

            //Configure the users and add roles to them
            builder.ApplyConfiguration<ApplicationUser>(userConfiguration);
            builder.ApplyConfiguration<IdentityUserRole<Guid>>(userConfiguration); ;

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

                   Execution = "Sit in the leg press seat, and place your feet in the middle of the sled, about shoulder-width /apart. Press the sled out of the rack, lower the safety bars, and then slowly lower the sled towardsyour //chest until your thighs break 90 degrees. Press the sled back up but do not lock out your knees. If your lower back /or hips lift off the seat as you drive the weight back up, you’re going too far down.",

                   Benefit = "The leg press enables you to exert more force using only your legs, providing a squat-like motion/ without placing weight on your spine or torso, making it ideal for high-rep sets and drop sets.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Sled-45-degree-Leg-Press-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 1
               },
               new Exercise()
               {
                   Id = 2,
                   Name = "Hack Squat",
                   Execution = "Your stance on the foot platform will closely mimic that of your back squat stance. Youwant //your feet slightly outside shoulder width with feet angled slightly outward — they should be in linewith /the knee /as it tracks forward during the descent. \r\n\r\nYour torso should be stable with yourabdominals/ engaged and your /lower back flat on the back pad. Maintain a neutral head position as you lower you body/ until the bottoms of your /thighs are parallel to the foot platform and drive through your feet to the top.",

                   Benefit = "The hack squat, being a machine, offers enhanced stability compared to free-weight squat /variations, its predefined path reducing the risk of injury and accommodating pre-existing injuries.",

                   ImageUrl = "https://www.bodybuildingmealplan.com/wp-content/uploads/Hack-Squat-Muscles-Worked.jpg",
                   CategoryId = 1
               },
               new Exercise()
               {
                   Id = 3,
                   Name = "Barbell Curl",
                   Execution = "With an underhand grip slightly wider than the shoulders, grab a barbell, pull yourshoulders //back, and position your elbows under your shoulder joints or slightly in front by your ribs; then,curl /the barbell /up using your biceps to expose the fronts of your biceps.",

                   Benefit = "The barbell curl, with its simple and effective mechanics, has a small learning curve,making /it /ideal for beginners, while still providing benefits to more advanced lifters, allowing them to loadtheir /biceps/ with heavier weights and build stronger biceps more quickly.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/barbell-curl-resized.png?/ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 2
               },
               new Exercise()
               {
                   Id = 4,
                   Name = "Hammer Curl",
                   Execution = "While standing, hold a dumbbell in each hand with wrists facing each other, tuck your arm in //at your sides, and flex your elbows to curl the dumbbells up towards your shoulders, then lower them back down with /control.",

                   Benefit = "The hammer curl, with its comfortable neutral wrist position, allows for lifting heavier weights /and accumulating more muscle-building volume over time, effectively targeting the inner biceps muscleand //forearm to promote denser arms.",

                   ImageUrl = "https://weighttraining.guide/wp-content/uploads/2016/11/Dumbbell-Hammer-Curl-resized.png",
                   CategoryId = 2
               },
               new Exercise()
               {
                   Id = 5,
                   Name = "Skullcrusher",
                   Execution = "Begin by lying on a bench with the hands supporting a weight (barbell, dumbbells, orcable //attachments) at the top of the bench pressing position, aligning the back and hips as in a bench press; slightly /pull the elbows back, pointing them behind you, as you lower the bar handle or loads towards your/head, almost /touching the forehead, experiencing a stretch on the triceps and partial engagement of the /lats,and finally, push /the bar back up.",

                   Benefit = "This exercise offers versatility with options such as barbells, kettlebells, or dumbbells, making/ it a versatile triceps exercise that capitalizes on your strength in this position, leading to significant /triceps strength gains.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/12/Decline-Skull-crusher-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 3
               },
               new Exercise()
               {
                   Id = 6,
                   Name = "Triceps Pushdown",
                   Execution = "Set the cables or band at a high anchor point, face your body towards it, place yourfeet //together, keep your elbows by your sides, chest up, back flat, and hips angled slightly forward, thengrab/ the /handles or band and push them down by fully extending your elbows, ensuring that your elbows are slightly in front /of your shoulders.",

                   Benefit = "This exercise allows for complete isolation of the triceps, providing the ability to feelthe //muscle contract and achieve a satisfying pump.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Triceps-Rope-Pushdown-resized.png?/ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 3
               },
               new Exercise()
               {
                   Id = 7,
                   Name = "Dumbbell Bench Press",
                   Execution = "Begin by sitting on a flat bench and hinging forward to pick up each dumbbell, placingthem /on /your knees; after getting set, lean back and drive the dumbbells back towards you using your knees,while //simultaneously pressing the weights over your chest, then lower the weights with elbows tucked at a 45-degree angle /until they break 90 degrees, followed by driving the dumbbells back up, optionally /transitioningto a neutral grip /position with palms facing each other for the press.",

                   Benefit = "Using two separate dumbbells for pressing exercises allows for easier customization of a /comfortable position, particularly beneficial for individuals with shoulder or elbow discomfort, while /also promoting enhanced joint and muscle stability; furthermore, the individual effort required by each /side helps balance any strength disparities and enables weaker sides of the body to catch up.",

                   ImageUrl = "https://fitnessvolt.com/wp-content/uploads/2018/04/dumbbell-bench-press.jpg",
                   CategoryId = 4
               },
               new Exercise()
               {
                   Id = 8,
                   Name = "Bent-Over Row",
                   Execution = "To perform the barbell bent-over row, set up in a deadlift position with feet shoulderwidth //apart in front of a loaded barbell, hinge at the hips to achieve a parallel torso to the floor, gripthe /barbell /slightly wider than your typical deadlift grip, lean back to distribute weight on your heels, and initiate the row /by pulling with your elbow until the barbell touches around your belly button, ensuring /thebarbell doesn't touch /the floor between repetitions, and considering a wider grip or a more upright /torso forindividuals with longer /arms.",

                   Benefit = "The bent-over row can be effectively executed using tools like kettlebells, dumbbells, ora /cable/ machine, allowing for efficient muscle overload as you can handle significant weight in the bent-overrow/ /position.",

                   ImageUrl = "https://weighttraining.guide/wp-content/uploads/2016/10/Bent-over-barbell-row.png",
                   CategoryId = 5
               },
               new Exercise()
               {
                   Id = 9,
                   Name = "Wrist Roller",
                   Execution = "Begin with a 2.5, five, or 10-pound weight plate, stand with feet hip-width apart, gripthe //wrist roller with knuckles facing towards you, gradually execute a front raise to elevate the roller to shoulder /height, roll the weight up while alternating hands until fully wound, and then slowly reverse the/movement.",

                   Benefit = "Engaging both forearm extensors and flexors, the wrist roller exercise strengthens these muscles /while the thick grip enhances grip strength, requiring focused attention on the wrists and forearms,which/ /are typically secondary to the primary movers.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2022/11/Wrist-roller.png?ezimgfmt=ng%/3Awebp%2Fngcb4",
                   CategoryId = 6
               },
               new Exercise()
               {
                   Id = 10,
                   Name = "L-Sit",
                   Execution = "Sit between two dumbbells or kettlebells, placing each hand on a handle, then elevateyour /body/ off the floor by extending your legs and maintain an isometric hold, ensuring tension in the middleand /upper /back.",

                   Benefit = "By resisting gravity and rotational forces, the L-sit exercise enhances full-bodystrength, //demanding significant isometric strength while stimulating exceptional abdominal strength andstability, /making it a/ valuable core strengthening exercise that prepares lifters and gymnastic athletes formore /challenging athletic /movements.",

                   ImageUrl = "https://weighttraining.guide/wp-content/uploads/2021/10/Floor-L-sit-fixed.png",
                   CategoryId = 7
               },
               new Exercise()
               {
                   Id = 11,
                   Name = "Dumbbell Shoulder Press",
                   Execution = "Begin by grabbing a pair of dumbbells and lifting them to the starting position at your /shoulders, lightly brace your core while inhaling, press the dumbbells up to straight arms while exhaling,/inhale at/ the top or during controlled lowering back to your shoulders, and repeat for the desired number/ ofrepetitions.",

                   Benefit = "The dumbbell shoulder press targets and develops muscles in the shoulders, triceps, biceps,and //upper back, leading to improvements in overall upper body physique, and as a compound exercise utilizing multiple /joints and muscles simultaneously, it is more effective in producing results compared to /isolationexercises.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Dumbbell-Shoulder-Press-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 8
               },
               new Exercise()
               {
                   Id = 12,
                   Name = "Pec Deck",
                   Execution = "Sit up tall and relax your neck and shoulders, ensuring your feet are flat on the floor; grasp the handles with palms facing forward, noting that some machines have a foot bar to release the handles; press your arms together in front of your chest with a controlled movement, maintaining a slight bend in the elbows and relaxed wrists; pause for a second with arms fully closed in front of your chest; slowly return arms to the starting position, maintaining strong and upright posture; complete two sets of seven to 10 repetitions, taking a short break between sets.",

                   Benefit = "The chest fly machine effectively targets the pectoral muscles while providing controlled and isolated movement for improved chest strength and development.",

                   ImageUrl = "https://cdn.shopify.com/s/files/1/1497/9682/files/MicrosoftTeams-image_5_c40117c8-4452-4801-b272-c56dcde1c0f0.jpg?v=1659021798",
                   CategoryId = 4
               },
               new Exercise()
               {
                   Id = 13,
                   Name = "Pull-up",
                   Execution = "To perform a pull-up, hang from a bar with an overhand grip, engage your back and arm muscles, and pull your body upward until your chin is above the bar, then lower yourself back down with controlled movement.",

                   Benefit = "Pull-ups offer benefits such as strengthening the upper body, especially the back, shoulders, and arms, improving grip strength, enhancing overall body coordination, and promoting muscle engagement for a functional and effective exercise.",

                   ImageUrl = "https://weighttraining.guide/wp-content/uploads/2016/10/pull-up-2-resized.png",
                   CategoryId = 5
               },
               new Exercise()
               {
                   Id = 14,
                   Name = "Front Plank",
                   Execution = "To execute a front plank, start in a push-up position with your forearms resting on the ground, elbows aligned beneath your shoulders, and your body in a straight line from head to heels; engage your core muscles to maintain a neutral spine and avoid sagging or arching; hold the position for a specific duration, focusing on proper alignment and steady breathing.",

                   Benefit = "Front planks provide benefits like core strengthening, improved posture, enhanced stability in the abdominal muscles and lower back, and the engagement of various muscle groups for a comprehensive and effective isometric exercise.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2021/06/Weighted-front-plank.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 7
               },
               new Exercise()
               {
                   Id = 15,
                   Name = "Dumbbell lateral raise",
                   Execution = "To execute a dumbbell lateral raise, stand upright holding a dumbbell in each hand at your sides, slightly bending your elbows; keeping your core engaged and maintaining a neutral spine, raise both dumbbells out to your sides until your arms are parallel to the floor; pause briefly at the top of the movement and then slowly lower the dumbbells back down to the starting position while maintaining controlled movement throughout.",

                   Benefit = "Dumbbell lateral raises offer benefits such as targeting the lateral deltoid muscles for broader shoulders, enhancing shoulder stability, improving overall upper body symmetry, and contributing to better posture and functional shoulder strength.",

                   ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/dumbbell-lateral-raise-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                   CategoryId = 8
               });

            //Seeding Training plans
            builder
              .Entity<TrainingPlan>()
              .HasData(new TrainingPlan()
              {
                  Id = 1,
                  Name = "Leg Workout - BEGINNERS 1#",

                  Description = "1# Barbell Squats\r\nSets: 4\r\nReps: 8-10\r\n\r\n2# Leg Press\r\nSets: 3\r\nReps: 10-12\r\n\r\n3# Romanian Deadlifts\r\nSets: 4\r\nReps: 8-10\r\n\r\n4# Lunges (each leg)\r\nSets: 3\r\nReps: 12-15\r\n\r\n5# Leg Extensions\r\nSets: 3\r\nReps: 12-15\r\n\r\n6# Seated Calf Raises\r\nSets: 4\r\nReps: 15-20\r\n\r\n7# Standing Calf Raises\r\nSets: 4\r\nReps: 15-20",

                  CategoryId = 1
              },
              new TrainingPlan()
              {
                  Id = 2,
                  Name = "Leg Workout - BEGINNERS 2#",

                  Description = "1# Barbell Squats\r\nSets: 4\r\nReps: 8-10\r\n\r\n2# Romanian Deadlifts\r\nSets: 4\r\nReps: 10-12\r\n\r\n3# Leg Press\r\nSets: 3\r\nReps: 12-15\r\n\r\n4# Lunges (each leg)\r\nSets: 3\r\nReps: 10-12\r\n\r\n5# Leg Extensions\r\nSets: 3\r\nReps: 15-20\r\n\r\n6# Hamstring Curls\r\nSets: 3\r\nReps: 12-15\r\n\r\n7# Calf Raises\r\nSets: 4\r\nReps: 15-20",

                  CategoryId = 1
              },
              new TrainingPlan()
              {
                  Id = 3,
                  Name = "Workout Routine: Big Glutes",

                  Description = "1# Barbell Hip Thrusts\r\nSets: 4\r\nReps: 8-10\r\n\r\n2# Bulgarian Split Squats\r\nSets: 3\r\nReps: 10-12 (each leg)\r\n\r\n3# Romanian Deadlifts\r\nSets: 4\r\nReps: 8-10\r\n\r\n4# Glute Bridges\r\nSets: 3\r\nReps: 12-15\r\n\r\n5# Cable Kickbacks\r\nSets: 3\r\nReps: 15-20 (each leg)\r\n\r\n6# Sumo Deadlifts\r\nSets: 4\r\nReps: 6-8\r\n\r\n7# Glute-Ham Raises\r\nSets: 3\r\nReps: 10-12",

                  CategoryId = 1
              },
              new TrainingPlan()
              {
                  Id = 4,
                  Name = "Bicep Workout - BEGINNERS 1#",

                  Description = "1# Dumbbell Bicep Curls\r\nSets: 3\r\nReps: 12\r\n\r\n2# Hammer Curls\r\nSets: 3\r\nReps: 12\r\n\r\n3# Concentration Curls\r\nSets: 3\r\nReps: 12",

                  CategoryId = 2
              },
              new TrainingPlan()
              {
                  Id = 5,
                  Name = "BRUTAL Bicep Workout",

                  Description = "1# Barbell Bicep Curl\r\nSets: 4\r\nReps: 8-10\r\n\r\n2# Preacher Curl (using an EZ bar)\r\nSets: 4\r\nReps: 10-12\r\n\r\n3# Incline Dumbbell Curl\r\nSets: 3\r\nReps: 12-15\r\n\r\n4# Chin-Up\r\nSets: 3\r\nReps: As many as you can (aim for 6-10 reps)",

                  CategoryId = 2
              },
              new TrainingPlan()
              {
                  Id = 6,
                  Name = "BRUTAL Chest Workout",

                  Description = "#1 Bench Press\r\nSets: 4\r\nReps: 8-12\r\n\r\n#2 Incline Dumbbell Press\r\nSets: 4\r\nReps: 8-12\r\n\r\n#3 Vertical Chest Press\r\nSets: 3\r\nReps: 12-15\r\n\r\n#4 Pec Deck\r\nSets: 3\r\nReps: 15-20",

                  CategoryId = 4
              },
              new TrainingPlan()
              {
                  Id = 7,
                  Name = "Chest Workout - BEGINNERS #1",

                  Description = "#1 Incline Dumbbell Press\r\nSets: 4\r\nReps: 8-12\r\n\r\n#2 Bench Press\r\nSets: 3\r\nReps: 8-12\r\n\r\n#3 Dips\r\nSets: 3\r\nReps: 12-15\r\n\r\n#4 Pec Deck\r\nSets: 3\r\nReps: 15-20",

                  CategoryId = 4
              },
              new TrainingPlan()
              {
                  Id = 8,
                  Name = "Back Workout - BEGINNERS #1",

                  Description = "#1 Bent Over Barbell Rows\r\nSets: 4\r\nReps: 8-10\r\n\r\n#2 Lat Pulldowns\r\nSets: 3\r\nReps: 10-12\r\n\r\n#3 T-Bar Rows\r\nSets: 3\r\nReps: 8-10\r\n\r\n#4 Seated Cable Rows\r\nSets: 3\r\nReps: 12-15",

                  CategoryId = 5
              },
              new TrainingPlan()
              {
                  Id = 9,
                  Name = "Back Workout - BEGINNERS #2",

                  Description = "#1 Deadlifts\r\nSets: 4\r\nRepetitions: 6-8\r\n\r\n#2 Pull-Ups\r\nSets: 3\r\nRepetitions: Max (aim for 8-10 reps)\r\n\r\n#3 Barbell Rows\r\nSets: 3\r\nRepetitions: 8-10\r\n\r\n#4 Dumbbell Rows\r\nSets: 3\r\nRepetitions: 10-12",

                  CategoryId = 5
              },
              new TrainingPlan()
              {
                  Id = 10,
                  Name = "Forearms Workout - BEGINNERS #1",

                  Description = "#1 Barbell Wrist Curl (Palms Up)\r\nSets: 4\r\nReps: 12-15\r\n\r\n#2 Reverse Barbell Wrist Curl (Palms Down)\r\nSets: 4\r\nReps: 12-15\r\n\r\n#3 Farmer's Walk with Dumbbells\r\nSets: 3\r\nReps: Walk for 30-40 seconds\r\n\r\n#4 Plate Pinch Hold\r\nSets: 3\r\nReps: Hold for 20-30 seconds",

                  CategoryId = 6
              },
              new TrainingPlan()
              {
                  Id = 11,
                  Name = "Abs Workout - BEGINNERS #1",

                  Description = "#1 Crunches\r\nSets: 3\r\nReps: 15-20\r\n\r\n#2 Leg Raises\r\nSets: 3\r\nReps: 12-15\r\n\r\n#3 Russian Twists\r\nSets: 3\r\nReps: 20 (10 twists per side)\r\n\r\n#4 Plank\r\nSets: 3\r\nRepetitions: Hold for 30-45 seconds",

                  CategoryId = 7
              },
              new TrainingPlan()
              {
                  Id = 12,
                  Name = "Shoulders Workout - BEGINNERS #1",

                  Description = "#1 Military Press (Barbell or Dumbbell)\r\nSets: 4\r\nReps: 6-8\r\n\r\n#2 Dumbbell Lateral Raises\r\nSets: 3\r\nReps: 10-12\r\n\r\nExercise 3 Arnold Press\r\nSets: 3\r\nReps: 8-10\r\n\r\n#4 Bent-Over Dumbbell Rear Delt Raises\r\nSets: 3\r\nReps: 12-15",

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
                     Description = "Calcium citrate, in tablet form, is the most biologically accessible form ofcalcium, //ensuring optimal health for muscles, bones, and teeth, while also participating in blood clottingand /supporting /proper neurotransmission. Additionally, it is enriched with other beneficial electrolytes /suchas vitamin D2, /magnesium, copper, manganese, and zinc, which play crucial roles in bone metabolism,/ reducefatigue, support immune /and nervous system health, promote healthy hair, nails, and skin, and /protect cellsfrom oxidative stress, making /the product suitable for vegans and vegetarians.",
                     Benefits = "The most biologically accessible form of calcium, enriched with vitamin D2, magnesium, copper,/ zinc, and manganese, ensures the health of muscles, bones, and teeth, participates in blood clotting, /supports proper neurotransmission, guarantees immune function, and promotes the well-being of hair, /nails, andskin,/ conveniently available in tablet form and suitable for vegetarians and vegans.",
                     Type = TypeProductSupplement,
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/u/n//untitled_design_-_2020-04-03t164935.609.png",
                     Ingredients = "Hydroxypropyl cellulose, vegetable coating, croscarmellose sodium, silicondioxide, //magnesium stearate (vegetable source), and stearic acid (vegetable source).",
                     Price = 29.99m
                 },
                 new Supplement()
                 {
                     Id = 2,
                     Name = "Ashwagandha 90 Capsules",
                     Manufacturer = "GymBeam",
                     Description = "Ashwagandha or Indian Ginseng (Withania somnifera) is a plant classified among adaptogens, /compounds known for their beneficial effects on the body, particularly in increasing itsresilience /and /improving the adaptation process to stress. Similar to how our muscles become stronger and growwhen we //exercise, adaptogens can enhance the body's resistance to stress and aid in better stress management. It's no wonder/ that Ashwagandha is popular among individuals experiencing daily stress at work, school, /or intheir personal /lives. However, its benefits don't end there; this plant is still being researched /by scientifi institutions for /its potential positive effects in reducing anxiety, fatigue, lowering the/ stress hormonecortisol, and enhancing /athletic performance, strength, and sleep. Additionally, it may /support our mentalwell-being and aid in /relaxation.",
                     Benefits = "500 mg of Ashwagandha (Withania somnifera) extract, containing 5% of active compounds called /withanolides, classified as adaptogens, may help enhance the body's resilience and aid in betterstress //management, available in convenient capsule form.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/a/s//ashwagandha_90_caps.png",
                     Type = TypeProductSupplement,
                     Ingredients = "Ashwagandha extract (Withania somnifera) (5% withanolides), anti-caking agent(calcium //phosphate, magnesium stearate), gelatin capsule.",
                     Price = 19.99m
                 },
                 new Supplement()
                 {
                     Id = 3,
                     Name = "Zinc 100 Tablets",
                     Manufacturer = "GymBeam",
                     Description = "Zinc is an essential mineral found in many food supplements, vital for hundreds of /biological processes in the body, supporting proper metabolism of macronutrients like carbohydrates, /crucialfor /energy supply to athletes and active individuals. It also aids in maintaining bone health, /proteinsynthesis for /muscle growth, and has a positive impact on testosterone levels in men. Zinc plays/ a vital rolein various bodily /processes, positively affecting muscle size and strength, fertility, and/ reproductivefunction, benefiting skin, /hair, and nails for women, and supporting vision for those /spending time in front o screens. Additionally, as an /antioxidant, zinc protects cells against /oxidative stress, boosts the immunesystem, aids in fat metabolism, DNA /synthesis, cognitive functions, /and vitamin A metabolism, making it anideal supplement for overall health and /suitable for vegans.",
                     Benefits = "This dietary supplement, containing this essential mineral, participates in hundredsof //biological processes, supporting proper carbohydrate metabolism, bone health, protein synthesis, maintaining normal /testosterone levels, enhancing fertility and reproductive function, promoting healthy/ skin,hair, and nails, /supporting good vision, boosting the immune system, influencing proper /metabolism of fattyacids, aiding in DNA /synthesis, maintaining cognitive functions, affecting the /metabolism of vitamin A,protecting cells against /oxidative stress, and suitable for vegans, making it /ideal for anyone striving tomaintain optimal health.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/z/i//zinc_100_tabs_gymbeam.png",
                     Type = TypeProductSupplement,
                     Ingredients = "Filler (microcrystalline cellulose, calcium hydrogen phosphate), zinc oxide,coating //(stearic acid), anti-caking agent (magnesium stearate).",
                     Price = 10.99m
                 },
                 new Supplement()
                 {
                     Id = 4,
                     Name = "Vitamin C 1000mg 180 Tablets",
                     Manufacturer = "GymBeam",
                     Description = "Vitamin C 1000 mg, also known as L-ascorbic acid, is an essential vitamin found ineasy-/to-/swallow tablets and commonly present in various fruits and vegetables. It participates in numerous biological /processes, making it one of the most popular supplements supporting overall health and /vitality.Vitamin C /contributes to the proper functioning of the immune and nervous systems, supports /immunity during an after intense /physical activity, promotes mental balance, reduces fatigue, and aids /in energy metabolism fordaily activities and /sports. Additionally, it maintains bone and cartilage /health, collagen production, and th health of skin, gums, and/ teeth. Moreover, Vitamin C acts as an /antioxidant, protects cells from oxidativestress, enhances iron absorption, /and supports cardiovascular/ health. The supplement is enriched with rosehipextract (Rosa canina), offering a wide /range of /beneficial effects.",
                     Benefits = "This supplement contains 1000 mg of ascorbic acid (Vitamin C), offered in easy-toswallow //tablets, supporting the proper functioning of the immune and nervous systems, promoting mentalbalance, /reducing /fatigue, maintaining energy metabolism, bone and cartilage health, collagen production,skin, /gum, and teeth /function, protecting cells from oxidative stress, enhancing iron absorption, and supporting cardiovascular health, /enriched with rosehip extract, promoting overall health and /vitality.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/n/e//new_vitamin_c.png",
                     Type = TypeProductSupplement,
                     Ingredients = "Vitamin C (L-ascorbic acid), rosehip extract (Rosa canina), filler(microcrystalline //cellulose), anti-caking agent (magnesium stearate).",
                     Price = 35.99m
                 },
                 new Supplement()
                 {
                     Id = 5,
                     Name = "Just Whey 1kg",
                     Manufacturer = "GymBeam",
                     Description = "Just Whey Protein is a multi-component whey protein powder that effectivelysupports //protein intake after workouts or at any other time of the day, containing a unique combination ofwhey /protein /concentrate, isolate, and hydrolysate, ensuring high absorbability and bioavailability for the body, providing 18% /EPA and 12% DHA, supporting cardiovascular functions, brain functions, and good /vision,enriched with vitamin E, /respecting nature and produced from the milk of free-range cows, with /added enzymesfor better nutrient absorption, /containing 74.8% protein content, supporting muscle growth/ and maintenance,beneficial for athletes, active /individuals, and those on a weight loss or recovery /journey, enriched withvitamins and minerals like B6, magnesium,/ and zinc, easily consumed in various /ways and delicious flavors,suitable for a healthy lifestyle.",
                     Benefits = "A multi-component whey protein powder, derived from the milk of free-range cows,containing /a /combination of whey concentrate, isolate, and hydrolysate, boasting an impressive 74.8% proteincontent,/ /providing 22.4g of protein per serving, including all essential amino acids and BCAAs, making it an ideal choice to /meet protein intake needs, supporting muscle growth and preservation, with high /bioavailabilit and easy /digestibility, enriched with selected vitamins and minerals, promoting muscle /function and bonehealth, positively /impacting optimal testosterone levels, aiding in reducing fatigue /and tiredness, supportingproper immune function, /offering a delightful taste and easy solubility, /containing only natural flavors andcolors, a great way to enrich /cereals and other dishes with high-/quality protein, suitable for athletes and al active individuals, perfect for /post-workout or anytime /during the day.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/j/u//just_whey_unflavored_1_kg_gymbeam_1.png",
                     Type = TypeProductSupplement,
                     Ingredients = "Whey protein concentrate powder, whey protein isolate powder, protein hydrolysate, minerals/ (magnesium citrate, zinc oxide), vitamins (vitamin E - tocopheryl acetate, vitamin B6 - pyridoxine /hydrochloride), DigeZyme® - a complex of digestive enzymes, bromelain.",
                     Price = 99.99m
                 },
                 new Supplement()
                 {
                     Id = 6,
                     Name = "Creatine Monohydrate 500g",
                     Manufacturer = "GymBeam",
                     Description = "100% Creatine monohydrate is a popular supplement known for enhancing physical performance /in short, intense exercises, making it highly favored by athletes, including strength trainers,team //sport enthusiasts, and HIIT practitioners. It is a naturally occurring substance in the body, and supplementing with/ creatine powder ensures easy intake of the recommended daily dose of at least 3 /grams,supporting improved exercise/ performance without the need for cycling or time-limited usage.",
                     Benefits = "100% Creatine monohydrate, a highly researched nutritional supplement, enhancesphysical //performance during short bursts of intense exercises, making it suitable for strength athletes andteam /sport /enthusiasts; it comes in a soluble powder form that can be easily mixed with water, juice, or /postworkout protein /shakes.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/c/r//creatinemonohydrate_500_1.jpg",
                     Type = TypeProductSupplement,
                     Ingredients = "Unflavored: Creatine monohydrate",
                     Price = 39.99m
                 }, 
                 new Supplement()
                 {
                     Id = 7,
                     Name = "Iron 120 Capsules",
                     Manufacturer = "GymBeam",
                     Description = "Iron is an essential element crucial for proper bodily function. It is available in vegan-friendly capsules and plays a vital role in producing hemoglobin and red blood cells, facilitating oxygen transport throughout the body. It also helps reduce fatigue and exhaustion, enhances cognitive functions such as memory and attention, and supports the immune system. Adequate iron intake is important for overall health and vitality, especially for individuals with strenuous physical or mental activities. Women experiencing menstrual discomfort and potential lower iron levels should focus on optimizing their iron intake.",
                     Benefits = "One of the key minerals, it has an essential impact on several biological processes, contributing to proper metabolism crucial for energy production, influencing optimal oxygen transport in the body, aiding in the production of red blood cells and hemoglobin, reducing fatigue and tiredness, positively affecting cognitive functions, supporting the immune system, available in convenient capsule form, suitable for vegans.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/n/e/new_iron_-_gb.png",
                     Type = TypeProductSupplement,
                     Ingredients = "Iron fumarate, filler (microcrystalline cellulose), anti-caking agent (magnesium stearate), hydroxypropyl methylcellulose capsule.",
                     Price = 15.99m
                 },
                 new Supplement()
                 {
                     Id = 8,
                     Name = "Gold Standard BCAA Train Sustain 226g",
                     Manufacturer = "Optimum Nutrition",
                     Description = "Gold Standard BCAA Train Sustain is an original blend of nutrients designed to support muscles, boost immunity, and reduce fatigue. It includes branched-chain amino acids (BCAA), Rhodiola rosea, vitamin C, and magnesium. BCAAs consist of three essential amino acids – leucine, isoleucine, and valine – which the body cannot synthesize on its own, making them necessary through diet or supplements. These amino acids are the building blocks of proteins, contributing to muscle growth and maintenance. Muscles experience breakdown during workouts, making it advisable to replenish essential nutrients post-exercise. Each serving contains a full 5g of BCAAs.",
                     Benefits = "Enriched with Rhodiola rosea extract, containing vitamin C and magnesium, this product contains a full 5g of BCAAs per serving, contributing to muscle growth and maintenance, supporting immune function, and aiding in reducing fatigue and exhaustion.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/s/t/straw.kiwi.png",
                     Type = TypeProductSupplement,
                     Ingredients = "A blend of branched-chain amino acids (L-leucine, L-isoleucine, L-valine, emulsifier: sunflower lecithin), acids (citric acid, apple acid, L (+) - tartaric acid), flavors, Rhodiola rosea root extract, L-ascorbic acid, anti-caking agents (silicon dioxide, calcium silicate), sodium chloride, magnesium oxide, colorant (red beetroot), potassium chloride, sweetener (sucralose), zinc oxide.",
                     Price = 59.99m
                 },
                 new Supplement()
                 {
                     Id = 9,
                     Name = "Pre-Workout PUMP 225g",
                     Manufacturer = "Nutrend",
                     Description = "PUMP belongs to the category of pre-workout blends with a comprehensive formula designed for maximum effectiveness. It contains carefully selected amino acids, plant extracts, vitamins, and minerals for athletes. The overall formula primarily includes the non-essential amino acid L-citrulline malate, functioning as a precursor to arginine. The latter serves as a substrate for the production of nitric oxide (NO), which plays a key role in vasodilation, expanding blood vessels. This allows more nutrients and oxygen to reach the muscles, crucial for achieving maximum performance.",
                     Benefits = "A comprehensive pre-workout blend with an effective formula containing ingredients aimed at stimulating muscle blood flow or enhancing performance, possibly delaying the onset of muscle fatigue and improving athletic achievements, featuring nootropics and adaptogens that may assist in facing physically demanding challenges, enriched with B-group vitamins contributing to proper metabolism crucial for energy production, aiding fatigue and exhaustion reduction, offering a refreshing taste, suitable for anyone aiming to serve themselves with maximum efficiency.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/6/3/63da4cf24c412_.png",
                     Type = TypeProductSupplement,
                     Ingredients = "Bubblegum flavor: L-citrulline malate, beta-alanine, glycerol monostearate, L-tyrosine, taurine, anti-caking agent silicon dioxide, choline L-bitartrate, Withania somnifera extract (5% withanolides), sodium citrate, Bacopa monnieri extract, anti-caking agent calcium phosphate, flavor, sweeteners sucralose and steviol glycosides, niacinamide, calcium D-pantothenate, thiamine hydrochloride, black pepper extract (95% piperine) - Bioperine®, brilliant color.",
                     Price = 35.99m
                 },
                 new Supplement()
                 {
                     Id = 10,
                     Name = "Concentrated Pre Workout 375g",
                     Manufacturer = "Bodylab24",
                     Description = "The pre-workout stimulant \"Concentrated\" is a highly effective powder blend that easily dissolves in water and will provide you with the necessary energy before physical activity. The product contains 192 mg of caffeine to energize you before your workout, as well as creatine, ideal for enhancing physical performance during high-intensity interval training. Another active ingredient in the stimulant is taurine, often found in energy drinks, along with vitamin B3, which influences metabolism, aids muscle function, and delays fatigue and exhaustion.\r\n\r\nLastly, the product is enriched with essential amino acids. Beta-alanine contributes to carnosine production, functioning as a \"cleansing\" agent for your muscles by preventing the buildup of lactic acid and delaying excessive oxygenation. This means it delays muscle fatigue and extends your active time. L-citrulline and L-arginine, also present in the blend, impact nitric oxide production, widening blood vessels to enhance nutrient and oxygen delivery to working muscles. Lastly, but not least, L-tyrosine acts as a precursor to adrenaline, noradrenaline, and dopamine.\r\n\r\nThe ingredients in the \"Concentrated\" pre-workout stimulant make it a highly effective booster suitable for both strength athletes and those engaging in endurance-demanding sports. The blend dissolves well in water and is suitable for vegans.",
                     Benefits = "A comprehensive and effective formula for a pre-workout booster, containing taurine and caffeine to provide energy before a workout, along with beta-alanine, L-citrulline, L-arginine, and creatine; enriched with vitamin B3; enhances performance during intense interval training; contributes to normal muscle function; reduces fatigue and exhaustion; widens blood vessels; comes in powder form and easily dissolves in liquids.",
                     ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/1/-/1-bodylab-preworkout-apple-375g_1.jpg",
                     Type = TypeProductSupplement,
                     Ingredients = "Green Apple flavored blend CPW (creatine monohydrate, beta-alanine, L-arginine AKG, taurine, L-citrulline DL malate, L-tyrosine), dextrin, caffeine, flavor enhancer, sweetener (sucralose), magnesium citrate, vitamin B3 (niacin), acidity regulator (citric acid), potassium chloride, sodium chloride, coloring agent (copper complex of chlorophyllin and beta-carotene), release agent (silicon dioxide), flavor enhancer.",
                     Price = 72.99m
                 });


            //Seeding accessories
            builder
                .Entity<Accessory>()
                .HasData(new Accessory()
                {
                    Id = 1,
                    Name = "Weight belt LEVER Black",
                    Manufacturer = "GymBeam",
                    Description = "The LEVER weightlifting belt is a practical device designed for individuals engaged in /strength training, aiming to increase the weights they lift; it helps stabilize the core and lower back muscles, /boosting your confidence and enabling you to lift heavier weights. Made from 4-layered material /- 2inner layers /of cowhide and suede covered with 2 outer layers of buffalo suede - it ensures stability/ anddurability while /fitting perfectly to your body; the belt also features an adjustable section to /accommodateyour waist size, /eliminating concerns about it being too large or small. If you want to /enhance the weightslifted during squats or/ deadlifts, this high-quality leather belt should undoubtedly /be part of your fitnessarsenal.",
                    Benefits = "The 4-layer leather belt with an adjustable section provides stability and durabilitywhile //ensuring comfort, offering support during weightlifting and is suitable for individuals engaging inheavy/ /lifting.",
                    Type = TypeProductAccessory,
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/w/e//weightlifting-belt-lever-gymbeam_5_.jpg",
                    Price = 99.99m
                },
                new Accessory()
                {
                    Id = 2,
                    Name = "Fitness gloves Ronnie",
                    Manufacturer = "GymBeam",
                    Description = "The Ronnie fitness gloves are high-quality exercise gloves made of split leather witha //rubber-padded cowhide interior for an ideal fit and intense workout protection for every athlete; they /are reinforced with a double lining in the palm area for durability and resistance against wear, designed/ for professional athletes seeking superior hand protection during training, guarding against scratches, /calluses,and /impacts while providing a secure grip on workout equipment, but they should not be machine /washed.",
                    Benefits = "The Ronnie fitness gloves protect hands from injuries, calluses, and abrasions, providinga //secure grip during workouts with fitness equipment, bars, or weights; they are perfect for strength training, have/ an ergonomic shape for long-lasting durability, and fit hands comfortably without /squeezingfingers.",
                    Type = TypeProductAccessory,
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/r/u//rukavice_2j_1.jpg",
                    Price = 19.99m
                },
                new Accessory()
                {
                    Id = 3,
                    Name = "Green shaker 700ml",
                    Manufacturer = "GymBeam",
                    Description = "The green shaker is a classic 700ml shaker with a traditional closure and filter,perfect //for mixing your favorite proteins, pre-workout stimulants, and creatine; made of non-toxic plasticand /free from /BPA and DEHP.",
                    Benefits = "This 700ml shaker, made of high-quality polypropylene PP, is perfect for mixing allsoluble //dietary supplements, featuring a leak-proof screw-on lid, a cone-shaped filter to prevent lumps, milliliter (ml) /and ounce (oz) markings, break-resistant, dishwasher, microwave, and fridge safe, BPA and/ DEHPfree, and compliant/ with food regulations.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/s/h//shaker_yellow_green.jpg",
                    Type = TypeProductAccessory,
                    Price = 7.99m
                },
                new Accessory()
                {
                    Id = 4,
                    Name = "Towel for fitness",
                    Manufacturer = "GymBeam",
                    Description = "This gray fitness and workout towel, made of 100% soft and pleasant-to-touch cotton, stands /out with its excellent absorption, high durability, and anti-static, antibacterial properties. With /dimensions of 50x90 cm, this towel possesses these qualities naturally, without the use of any chemical compounds,/ making it suitable for individuals with sensitive skin or allergies, as it does not cause /allergicreactions. /Every athlete recognizes the significance of a workout towel, an essential accessory /in the gym, no only to wipe /away sweat from the face but also to provide a clean surface for various /exercises, such as forabdominal /workouts, seating, or under the feet during exercises. Not having a /workout towel in the gym is apure faux pas /(embarrassing mistake) and can easily be avoided to prevent /someone from asking, \"Where is yourtowel?\"",
                    Benefits = "Made of 100% cotton, this towel has anti-static and antibacterial properties, driesquickly, //absorbs efficiently, feels soft and pleasant to touch, and boasts a long lifespan.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/g/r//grey_fitness_towel_gymbeam_1_.jpg",
                    Type = TypeProductAccessory,
                    Price = 14.99m
                },
                new Accessory()
                {
                    Id = 5,
                    Name = "Backpack Hustle 5.0 Black",
                    Manufacturer = "Under Armour",
                    Description = "The Hustle 5.0 Backpack is a versatile modern backpack, perfect not only for active lifestyle enthusiasts. With a capacity of 29 liters, it provides ample space for all your belongings. Equipped with UA Storm technology, the bag is highly resistant to the elements and will reliably keep its contents dry, making it suitable for various weather conditions. The material features a durable texture that withstands external damage. Meanwhile, it's incredibly comfortable thanks to features like a ventilated back panel and adjustable shoulder straps, allowing you to customize the carrying position to your needs. A special water-resistant front zip pocket ensures your valuables remain safe at all times, ideal for carrying your wallet or smartphone.\r\n\r\nThe backpack is also equipped with various internal pockets. The bottom is separate for storing your shoes or used clothes, protecting the rest of the contents from contact and avoiding unpleasant odors. There are bottle pockets on both sides, making this bag a great choice for activities like cycling, hiking, or going to the gym. However, the bag is highly versatile and can easily serve daily needs - you can take it to work or university, where you'll appreciate its 15-inch laptop pocket that can also store notebooks and more. Visually, the bag captivates with its minimalist design and the prominent Under Armour logo. Overall, this backpack is the perfect choice for anyone seeking an incredibly flexible solution that holds up in any situation.",
                    Benefits = "A modern backpack suitable for all weather conditions, with a capacity of 29 liters, equipped with UA Storm technology that withstands the elements and keeps its contents dry, featuring a durable fabric texture, comfortable to carry, equipped with a breathable ventilated back panel and adjustable shoulder straps, comes with a special water-resistant front pocket for valuables, offers a dedicated shoe storage section, a side pocket for a water bottle, suitable for various sports activities as well as work or university, equipped with an internal 15” laptop pocket, captivates with its modern design and the Under Armour logo.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/b/a/backpack_hustle_5_0_black_under_armour_7_.png",
                    Type = TypeProductAccessory,
                    Price = 114.99m
                },
                new Accessory()
                {
                    Id = 6,
                    Name = "Meal Prep Bag Black",
                    Manufacturer = "Climaqx",
                    Description = "The meal prep bag offers generous storage space, allowing you to carry your prepared meals with you at all times. It can be carried as a handbag or shoulder bag, thanks to the adjustable padded strap for added comfort. Made from a combination of nylon and polyester, the bag is sturdy and highly durable. It features various pockets secured with reliable zippers, ensuring you won't worry about accidentally spilling your stored food or beverages inside. The core of the storage space is a spacious main compartment equipped with a separator.\r\n\r\nThe bag easily accommodates food containers with your lunch and dinner, as well as additional sides, which can be conveniently accessed through the top or side opening. Moreover, the food bag comes with two side pockets that can hold various healthy foods, allowing you to carry snacks like fruits or bars. Thanks to its thick thermal insulation, the bag reliably keeps its contents dry and at a constant temperature for several hours. It offers the perfect solution for seamlessly connecting your daily activities such as work, university, and fitness, without worrying about your meals. Additionally, the bag is ideal for travel, ensuring you stay on top of your calories and nutrients even during longer journeys. Food containers and gel packs are not included in the packaging of this product and need to be purchased separately.",
                    Benefits = "An effective accessory for carrying your daily meals, providing ample storage space for food containers, offering a convenient way to transport your lunch, dinner, and snacks, equipped with various secure zippered pockets, comes with a padded and adjustable shoulder strap, the main compartment features a separator, made with thick thermal insulation to help maintain your food at an optimal temperature, easy to carry wherever you go, helps you streamline your daily activities between work, university, and the gym.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/m/e/meal_prep_bag__black_white_edition__climaqx_3_.jpg",
                    Type = TypeProductAccessory,
                    Price = 110.99m
                },
                new Accessory()
                {
                    Id = 7,
                    Name = "Fit Prep Black",
                    Manufacturer = "GymBeam",
                    Description = "The Fit Prep food container is a practical and essential solution for every food enthusiast and health-conscious individual. With this simple tool, you can ensure that you always have nutritious and delicious food on hand, prepared from high-quality ingredients that you've personally chosen. This way, you can maintain control over your calorie intake, which you'll particularly appreciate when managing your weight or preparing for a competition.\r\n\r\nIt features a convenient snap-on lid that securely seals its contents, so you won't worry about spilling your favorite couscous or meat sauce. If you prefer your dish's components not to mix together, you'll certainly appreciate the movable food divider, which keeps different parts of your meal separate. This allows you to enjoy your meat, side dish, and salad separately. Moreover, you can heat up certain sections in the microwave while leaving others cold. For instance, you can easily remove the section containing your salad and warm up the rest, enabling you to fully savor your meal's taste even when eating from the lunch box. The container also comes with a spoon. You'll surely agree that there's nothing as disappointing as diligently preparing your food only to find that you can't enjoy it the next day.",
                    Benefits = "A practical lunch box with a sturdy lid, featuring compartments to separate meal portions, and comes with an included spoon. Made from durable polypropylene, it's suitable for microwave and dishwasher use, making it ideal for preparing your meals on the go, at work, or at university.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/f/o/food_container_fit_prep_black_-_gymbeam_1_1.jpg",
                    Type = TypeProductAccessory,
                    Price = 8.50m
                },
                new Accessory()
                {
                    Id = 8,
                    Name = "Lifting Straps Black & Grey",
                    Manufacturer = "GymBeam",
                    Description = "LIFT Weightlifting Straps are a practical aid in your workouts, designed to enhance your grip when lifting weights. The straps feature a simple design with a loop on one end. By threading the strap through the loop, you create a space for your hand to pass through, while the remaining portion wraps around the barbell. With a length of 60.9 cm and a width of 3.8 cm, these straps easily wrap around the barbell. This reduces strain on your forearms and fingers during pulling exercises like deadlifts, allowing your performance to be less limited by your grip strength. This should enable you to lift heavier weights and perform more repetitions of a given exercise, ultimately boosting your strength and accelerating muscle growth.\r\n\r\nLIFT Weightlifting Straps are crafted from durable nylon, suitable for crossfitters, powerlifters, and individuals aiming to increase their grip strength.",
                    Benefits = "Weightlifting straps designed to enhance grip and reduce tension in wrists and fingers, measuring 60.9 cm in length and 3.8 cm in width, constructed from durable nylon. The package includes two straps for each hand, offering easy usage during pulling exercises like deadlifts. Suitable for bodybuilders and strength athletes.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/l/i/lifting_straps_black___grey_gymbeam_3_.jpg",
                    Type = TypeProductAccessory,
                    Price = 12.99m
                },
                new Accessory()
                {
                    Id = 9,
                    Name = "Grip training grip",
                    Manufacturer = "GymBeam",
                    Description = "The grip training handle is a popular tool for workouts aimed at enhancing hand grip strength. Hand and finger grip are essential for proper grasping of dumbbells, gym equipment, and overall hand strength in daily activities. By increasing resistance, you'll enhance the effectiveness of your workout and prevent potential injuries. You can adjust the resistance according to your needs within the range of 10 - 40 kg.",
                    Benefits = "You'll be able to develop your grip, which will help you be stronger in other exercises like the deadlift. The forearm muscles will grow.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/h/a/hand-grip_trainer_gymbeam1.jpg",
                    Type = TypeProductAccessory,
                    Price = 14.99m
                },
                new Accessory()
                {
                    Id = 10,
                    Name = "Ab Wheel",
                    Manufacturer = "GymBeam",
                    Description = "The Ab Wheel, an abdominal exercise wheel, will help you achieve your fitness goals. By engaging multiple muscle groups simultaneously (back, arms, core, shoulders, and legs), it effectively enhances physical condition and quickly shapes the body. Furthermore, it aids in improving overall body stability and mobility, which can be beneficial for other exercises. Workout comfort is guaranteed by the non-slip handles and the dual wheel design, providing maximum stability! Enhance your fitness and sculpt the body you've always dreamed of.",
                    Benefits = "A fitness accessory that engages multiple muscle groups simultaneously, equipped with non-slip handles and a double wheel for enhanced stability, enhancing physical fitness, sculpting the physique, and improving body mobility and stability.",
                    ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/1/_/1_2.png",
                    Type = TypeProductAccessory,
                    Price = 18.99m
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
                  Description = "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great rangeof  //motion to get you through your workout in total comfort.",
                  Color = "Black",
                  Size = "S",
                  Fabric = "Cutton",
                  Type = TypeProductWear,
                  WearCategoryId = 1
              },
              new Wear()
              {
                  Id = 2,
                  Name = "Hardcore T-shirt White",
                  Price = 29.99m,
                  ImageUrl = "https://gymtier.com/wp-content/uploads/2021/01/menstshirt-empty-motivation-hardcore-white.jpg",
                  Description = "The Hardcore T-Shirt delivers a soft feel, sweat-wicking performance and a great rangeof  //motion to get you through your workout in total comfort.",
                  Color = "White",
                  Size = "S",
                  Fabric = "Cutton",
                  Type = TypeProductWear,
                  WearCategoryId = 1
              },
              new Wear()
              {
                  Id = 3,
                  Name = "Gym Warrior T-shirt Black",
                  Price = 29.99m,
                  ImageUrl = "https://ae01.alicdn.com/kf/S9bbb3f96fb6f4a8e95055daca201ef81K.jpg?width=800&height=800&hash=1600",
                  Description = "The Gym Warrior T-Shirt delivers a soft feel, sweat-wicking performance and a great range o  //motion to get you through your workout in total comfort.",
                  Color = "Black",
                  Size = "S",
                  Fabric = "Cutton",
                  Type = TypeProductWear,
                  WearCategoryId = 1
              },
              new Wear()
              {
                  Id = 4,
                  Name = "The Cicle T-shirt Black",
                  Price = 29.99m,
                  ImageUrl = "https://media.boohoo.com/i/boohoo/bmm18988_black_xl/male-black-man-active-oversized-repeatt- //shirt/?w=900&qlt=default&fmt.jp2.qlt=70&fmt=auto&sm=fit",
                  Description = "The Cicle T-Shirt delivers a soft feel, sweat-wicking performance and a great range ofmotion  //to get you through your workout in total comfort.",
                  Color = "Black",
                  Size = "S",
                  Fabric = "Cutton",
                  Type = TypeProductWear,
                  WearCategoryId = 1
              },
              new Wear()
              {
                  Id = 5,
                  Name = "Hardcore Hoodie Black",
                  Price = 49.99m,
                  ImageUrl = "https://www.hard-wear.com/media/catalog/product/cache/74aab73cb060cf90b1e98012d0101b9a/1/0/100-hardcore-hooded-logo-gabber-4-life-black-301-s14-050-1.jpeg",
                  Description = "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion/ to get you through your workout in total comfort.",
                  Color = "Black",
                  Size = "S",
                  Fabric = "Cutton",
                  Type = TypeProductWear,
                  WearCategoryId = 2
              },
              new Wear()
              {
                  Id = 6,
                  Name = "Hardcore Hoodie White",
                  Price = 49.99m,
                  ImageUrl = "https://ae01.alicdn.com/kf/Hef62f5408d324ff684905fb5829dac8dX/Europe-Size-XXL-HardcoreSportswear-//Men-Fashion-Hardcore-Harajuku-Hoodies-Cool-Fun-Hardcore-Hoodie-Jacket-Camisetas.jpg",
                  Description = "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion/ to get you through your workout in total comfort.",
                  Color = "White",
                  Size = "S",
                  Fabric = "Cutton",
                  Type = TypeProductWear,
                  WearCategoryId = 2
              },
              new Wear()
              {
                  Id = 7,
                  Name = "Free Your Strength Maroon White",
                  Price = 25.99m,
                  ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/f/r/free-your-strength-gymbeam-burgundy-1.jpg",
                  Description = "The Free Your Strength Maroon White T-shirt will help you conquer even the toughest challenges that await you in the fitness world. Its snug design and high-quality material take care of that - it's made from 100% pre-treated cotton, which is soft to the touch and doesn't cause allergic reactions during sweating. Besides being perfect for fitness, you'll surely fall in love with this T-shirt for your everyday wear as well.",
                  Color = "Maroon White",
                  Size = "S",
                  Fabric = "Cutton",
                  Type = TypeProductWear,
                  WearCategoryId = 1
              },
              new Wear()
              {
                  Id = 8,
                  Name = "Athlete Pink",
                  Price = 52.99m,
                  ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/l/a/ladies-hoodie-athlete-military-pink-mikina-gymbeam-1.jpg",
                  Description = "The Athlete Pink women's hoodie is a comfortable hoodie with a hood that will be your partner on the journey to achieving your fitness goals. With the stylish GymBeam logo, you'll express your love for workouts. You'll fall in love with it for workouts due to its high-quality soft material, but you won't be able to resist wearing it in your everyday life as well.",
                  Color = "Pink",
                  Size = "S",
                  Fabric = "Cutton",
                  Type = TypeProductWear,
                  WearCategoryId = 2
              },
              new Wear()
              {
                  Id = 9,
                  Name = "Iconic Hero Grey",
                  Price = 175.99m,
                  ImageUrl = "https://gymbeam.bg/media/catalog/product/cache/70f742f66feec18cb83790f14444a3d1/w/o/womens-hoodie-iconic-hero-grey-nebbia_1_.jpg",
                  Description = "The women's Iconic Hero sweatshirt is exceptionally comfortable due to its relaxed fit and soft-touch material that combines gentle cotton and durable polyester, making it highly breathable. The garment is further equipped with a hood and a wide front pocket. The sleeve cuffs and waist area are finished with elastic, ensuring a snug fit to your body.\r\n\r\nThe women's Iconic Hero sweatshirt features a minimalist design adorned with the NEBBIA brand logo on the front. It can be worn during sports activities or casual moments.",
                  Color = "Grey",
                  Size = "S",
                  Fabric = "Cutton, Polyester",
                  Type = TypeProductWear,
                  WearCategoryId = 2
              });



            builder.Entity<ApplicationUserExercise>().HasKey(aue => new { aue.TrainingGuyId, aue.ExerciseId });
            builder.Entity<ApplicationUserFood>().HasKey(auf => new { auf.TrainingGuyId, auf.FoodId });
            builder.Entity<ApplicationUserTrainingPlan>().HasKey(autp => new { autp.TrainingGuyId, autp.TrainingPlanId });

            builder.Entity<UserFood>().Property("Calories").HasDefaultValue(0);
            builder.Entity<UserFood>().Property("Carbs").HasDefaultValue(0);
            builder.Entity<UserFood>().Property("Fat").HasDefaultValue(0);
            builder.Entity<UserFood>().Property("Protein").HasDefaultValue(0);

            base.OnModelCreating(builder);

        }
    }
}