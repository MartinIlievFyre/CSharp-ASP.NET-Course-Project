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

        public DbSet<WearCategory> WearCategories { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<ApplicationUserExercise> ApplicationUsersExercises { get; set; } = null!;

        public DbSet<ApplicationUserFood> ApplicationUsersFoods { get; set; } = null!;

        public DbSet<ApplicationUserTrainingPlan> ApplicationUsersTrainingPlans { get; set; } = null!;

        public DbSet<ApplicationUserWear> ApplicationUsersClothes { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
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
                Price = 29.99m,
                ImageUrl = "https://100procenthardcore.com/wp-content/uploads/2023/05/100-Hardcore-Hooded-Logo-/Gabber-4Life- Black-301-S14-050-1.jpg",
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
                Price = 29.99m,
                ImageUrl = "https://100procenthardcore.com/wp-content/uploads/2023/05/100-Hardcore-Hooded-Logo-/Gabber-4Life- Black-301-S14-050-1.jpg",
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
                Price = 29.99m,
                ImageUrl = "https://100procenthardcore.com/wp-content/uploads/2023/05/100-Hardcore-Hooded-Logo-/Gabber-4Life- Black-301-S14-050-1.jpg",
                Description = "The Hardcore Hoodie delivers a soft feel, sweat-wicking performance and a great range / ofmotion to get you through your workout in total comfort.",
                Color = "Black",
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