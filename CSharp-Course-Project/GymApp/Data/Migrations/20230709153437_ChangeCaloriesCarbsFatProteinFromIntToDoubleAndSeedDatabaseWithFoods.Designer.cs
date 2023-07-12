﻿// <auto-generated />
using System;
using GymApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymApp.Data.Migrations
{
    [DbContext(typeof(GymAppDbContext))]
    [Migration("20230709153437_ChangeCaloriesCarbsFatProteinFromIntToDoubleAndSeedDatabaseWithFoods")]
    partial class ChangeCaloriesCarbsFatProteinFromIntToDoubleAndSeedDatabaseWithFoods
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GymApp.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Legs"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Biceps"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Triceps"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Chest"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Back"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Forearms"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Abs"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Shoulders"
                        });
                });

            modelBuilder.Entity("GymApp.Data.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Benefit")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Execution")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Benefit = "The leg press enables you to exert more force using only your legs, providing a squat-like motion without placing weight on your spine or torso, making it ideal for high-rep sets and drop sets.",
                            CategoryId = 1,
                            Execution = "Sit in the leg press seat, and place your feet in the middle of the sled, about shoulder-width apart. Press the sled out of the rack, lower the safety bars, and then slowly lower the sled towards your chest until your thighs break 90 degrees. Press the sled back up but do not lock out your knees. If your lower back or hips lift off the seat as you drive the weight back up, you’re going too far down.",
                            ImageUrl = "https://weighttraining.guide/wp-content/uploads/2016/05/Sled-45-degree-Leg-Press-resized.png",
                            Name = "Leg Press"
                        },
                        new
                        {
                            Id = 2,
                            Benefit = "The hack squat, being a machine, offers enhanced stability compared to free-weight squat variations, its predefined path reducing the risk of injury and accommodating pre-existing injuries.",
                            CategoryId = 1,
                            Execution = "Your stance on the foot platform will closely mimic that of your back squat stance. You want your feet slightly outside shoulder width with feet angled slightly outward — they should be in line with the knee as it tracks forward during the descent. \r\n\r\nYour torso should be stable with your abdominals engaged and your lower back flat on the back pad. Maintain a neutral head position as you lower your body until the bottoms of your thighs are parallel to the foot platform and drive through your feet to the top.",
                            ImageUrl = "https://www.bodybuildingmealplan.com/wp-content/uploads/Hack-Squat-Muscles-Worked.jpg",
                            Name = "Hack Squat"
                        },
                        new
                        {
                            Id = 3,
                            Benefit = "The barbell curl, with its simple and effective mechanics, has a small learning curve, making it ideal for beginners, while still providing benefits to more advanced lifters, allowing them to load their biceps with heavier weights and build stronger biceps more quickly.",
                            CategoryId = 2,
                            Execution = "With an underhand grip slightly wider than the shoulders, grab a barbell, pull your shoulders back, and position your elbows under your shoulder joints or slightly in front by your ribs; then, curl the barbell up using your biceps to expose the fronts of your biceps.",
                            ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/barbell-curl-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                            Name = "Barbell Curl"
                        },
                        new
                        {
                            Id = 4,
                            Benefit = "The hammer curl, with its comfortable neutral wrist position, allows for lifting heavier weights and accumulating more muscle-building volume over time, effectively targeting the inner biceps muscle and forearm to promote denser arms.",
                            CategoryId = 2,
                            Execution = "While standing, hold a dumbbell in each hand with wrists facing each other, tuck your arms in at your sides, and flex your elbows to curl the dumbbells up towards your shoulders, then lower them back down with control.",
                            ImageUrl = "https://weighttraining.guide/wp-content/uploads/2016/11/Dumbbell-Hammer-Curl-resized.png",
                            Name = "Hammer Curl"
                        },
                        new
                        {
                            Id = 5,
                            Benefit = "This exercise offers versatility with options such as barbells, kettlebells, or dumbbells, making it a versatile triceps exercise that capitalizes on your strength in this position, leading to significant triceps strength gains.",
                            CategoryId = 3,
                            Execution = "Begin by lying on a bench with the hands supporting a weight (barbell, dumbbells, or cable attachments) at the top of the bench pressing position, aligning the back and hips as in a bench press; slightly pull the elbows back, pointing them behind you, as you lower the bar handle or loads towards your head, almost touching the forehead, experiencing a stretch on the triceps and partial engagement of the lats, and finally, push the bar back up.",
                            ImageUrl = "https://www.fitliferegime.com/wp-content/uploads/2022/03/Barbell-Skull-Crushers.jpg?ezimgfmt=rs:382x215/rscb1/ngcb1/notWebP",
                            Name = "Skullcrusher"
                        },
                        new
                        {
                            Id = 6,
                            Benefit = "This exercise allows for complete isolation of the triceps, providing the ability to feel the muscle contract and achieve a satisfying pump.",
                            CategoryId = 3,
                            Execution = "Set the cables or band at a high anchor point, face your body towards it, place your feet together, keep your elbows by your sides, chest up, back flat, and hips angled slightly forward, then grab the handles or band and push them down by fully extending your elbows, ensuring that your elbows are slightly in front of your shoulders.",
                            ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Triceps-Rope-Pushdown-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                            Name = "Triceps Pushdown"
                        },
                        new
                        {
                            Id = 7,
                            Benefit = "Using two separate dumbbells for pressing exercises allows for easier customization of a comfortable position, particularly beneficial for individuals with shoulder or elbow discomfort, while also promoting enhanced joint and muscle stability; furthermore, the individual effort required by each side helps balance any strength disparities and enables weaker sides of the body to catch up.",
                            CategoryId = 4,
                            Execution = "Begin by sitting on a flat bench and hinging forward to pick up each dumbbell, placing them on your knees; after getting set, lean back and drive the dumbbells back towards you using your knees, while simultaneously pressing the weights over your chest, then lower the weights with elbows tucked at a 45-degree angle until they break 90 degrees, followed by driving the dumbbells back up, optionally transitioning to a neutral grip position with palms facing each other for the press.",
                            ImageUrl = "https://fitnessvolt.com/wp-content/uploads/2018/04/dumbbell-bench-press.jpg",
                            Name = "Dumbbell Bench Press"
                        },
                        new
                        {
                            Id = 8,
                            Benefit = "The bent-over row can be effectively executed using tools like kettlebells, dumbbells, or a cable machine, allowing for efficient muscle overload as you can handle significant weight in the bent-over row position.",
                            CategoryId = 5,
                            Execution = "To perform the barbell bent-over row, set up in a deadlift position with feet shoulder-width apart in front of a loaded barbell, hinge at the hips to achieve a parallel torso to the floor, grip the barbell slightly wider than your typical deadlift grip, lean back to distribute weight on your heels, and initiate the row by pulling with your elbow until the barbell touches around your belly button, ensuring the barbell doesn't touch the floor between repetitions, and considering a wider grip or a more upright torso for individuals with longer arms.",
                            ImageUrl = "https://weighttraining.guide/wp-content/uploads/2016/10/Bent-over-barbell-row.png",
                            Name = "Bent-Over Row"
                        },
                        new
                        {
                            Id = 9,
                            Benefit = "Engaging both forearm extensors and flexors, the wrist roller exercise strengthens these muscles while the thick grip enhances grip strength, requiring focused attention on the wrists and forearms, which are typically secondary to the primary movers.",
                            CategoryId = 6,
                            Execution = "Begin with a 2.5, five, or 10-pound weight plate, stand with feet hip-width apart, grip the wrist roller with knuckles facing towards you, gradually execute a front raise to elevate the roller to shoulder height, roll the weight up while alternating hands until fully wound, and then slowly reverse the movement.",
                            ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2022/11/Wrist-roller.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                            Name = "Wrist Roller"
                        },
                        new
                        {
                            Id = 10,
                            Benefit = "By resisting gravity and rotational forces, the L-sit exercise enhances full-body strength, demanding significant isometric strength while stimulating exceptional abdominal strength and stability, making it a valuable core strengthening exercise that prepares lifters and gymnastic athletes for more challenging athletic movements.",
                            CategoryId = 7,
                            Execution = "Sit between two dumbbells or kettlebells, placing each hand on a handle, then elevate your body off the floor by extending your legs and maintain an isometric hold, ensuring tension in the middle and upper back.",
                            ImageUrl = "https://weighttraining.guide/wp-content/uploads/2021/10/Floor-L-sit-fixed.png",
                            Name = "L-Sit"
                        },
                        new
                        {
                            Id = 11,
                            Benefit = "The dumbbell shoulder press targets and develops muscles in the shoulders, triceps, biceps, and upper back, leading to improvements in overall upper body physique, and as a compound exercise utilizing multiple joints and muscles simultaneously, it is more effective in producing results compared to isolation exercises.",
                            CategoryId = 8,
                            Execution = "Begin by grabbing a pair of dumbbells and lifting them to the starting position at your shoulders, lightly brace your core while inhaling, press the dumbbells up to straight arms while exhaling, inhale at the top or during controlled lowering back to your shoulders, and repeat for the desired number of repetitions.",
                            ImageUrl = "https://cdn-0.weighttraining.guide/wp-content/uploads/2016/05/Dumbbell-Shoulder-Press-resized.png?ezimgfmt=ng%3Awebp%2Fngcb4",
                            Name = "Dumbbell Shoulder Press"
                        });
                });

            modelBuilder.Entity("GymApp.Data.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Calories")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("Carbs")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("Fat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Protein")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.HasKey("Id");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Calories = 52.0,
                            Carbs = 13.800000000000001,
                            Fat = 0.20000000000000001,
                            Name = "Apple",
                            Protein = 0.29999999999999999
                        },
                        new
                        {
                            Id = 2,
                            Calories = 153.0,
                            Carbs = 0.0,
                            Fat = 3.6000000000000001,
                            Name = "Chicken Fillet",
                            Protein = 30.199999999999999
                        });
                });

            modelBuilder.Entity("GymApp.Data.Models.IdentityUserExercise", b =>
                {
                    b.Property<string>("TrainingGuyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.HasKey("TrainingGuyId", "ExerciseId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("IdentityUsersExercises");
                });

            modelBuilder.Entity("GymApp.Data.Models.IdentityUserFood", b =>
                {
                    b.Property<string>("TrainingGuyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.HasKey("TrainingGuyId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("IdentityUsersFoods");
                });

            modelBuilder.Entity("GymApp.Data.Models.IdentityUserTrainingPlan", b =>
                {
                    b.Property<string>("TrainingGuyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TrainingPlanId")
                        .HasColumnType("int");

                    b.HasKey("TrainingGuyId", "TrainingPlanId");

                    b.HasIndex("TrainingPlanId");

                    b.ToTable("IdentityUserTrainingPlan");
                });

            modelBuilder.Entity("GymApp.Data.Models.TrainingPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("TrainingPlans");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GymApp.Data.Models.Exercise", b =>
                {
                    b.HasOne("GymApp.Data.Models.Category", "Category")
                        .WithMany("Exercises")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GymApp.Data.Models.IdentityUserExercise", b =>
                {
                    b.HasOne("GymApp.Data.Models.Exercise", "Exercise")
                        .WithMany("UsersExercises")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "TrainingGuy")
                        .WithMany()
                        .HasForeignKey("TrainingGuyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("TrainingGuy");
                });

            modelBuilder.Entity("GymApp.Data.Models.IdentityUserFood", b =>
                {
                    b.HasOne("GymApp.Data.Models.Food", "Food")
                        .WithMany("UsersFood")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "TrainingGuy")
                        .WithMany()
                        .HasForeignKey("TrainingGuyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("TrainingGuy");
                });

            modelBuilder.Entity("GymApp.Data.Models.IdentityUserTrainingPlan", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "TrainingGuy")
                        .WithMany()
                        .HasForeignKey("TrainingGuyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymApp.Data.Models.TrainingPlan", "TrainingPlan")
                        .WithMany("UsersTrainingPlan")
                        .HasForeignKey("TrainingPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingGuy");

                    b.Navigation("TrainingPlan");
                });

            modelBuilder.Entity("GymApp.Data.Models.TrainingPlan", b =>
                {
                    b.HasOne("GymApp.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymApp.Data.Models.Category", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("GymApp.Data.Models.Exercise", b =>
                {
                    b.Navigation("UsersExercises");
                });

            modelBuilder.Entity("GymApp.Data.Models.Food", b =>
                {
                    b.Navigation("UsersFood");
                });

            modelBuilder.Entity("GymApp.Data.Models.TrainingPlan", b =>
                {
                    b.Navigation("UsersTrainingPlan");
                });
#pragma warning restore 612, 618
        }
    }
}
