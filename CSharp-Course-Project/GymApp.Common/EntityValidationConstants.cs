using System.ComponentModel.DataAnnotations;

namespace GymApp.Common
{
    public class EntityValidationConstants
    {
        public static class Exercise
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int ExecutionMinLength = 20;
            public const int ExecutionMaxLength = 1000;

            public const int BenefitMinLength = 20;
            public const int BenefitMaxLength = 1000;

            public const int ImageUrlMaxLength = 2048;
        }

        public static class TrainingPlan
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 0;
            public const int DescriptionMaxLength = 5000;
        }

        public static class Food
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int DefaultGrams = 100;
        }

        public static class Wear
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const string PriceMin = "1";
            public const string PriceMax = "10000";

            public const int ImageUrMaxlLength = 2048;

            public const int SizeMinLength = 1;
            public const int SizeMaxLength = 3;

            public const int FabricMinLength = 2;
            public const int FabricMaxLength = 50;

            public const int DescriptionMinLength = 0;
            public const int DescriptionMaxLength = 5000;

            public const int ColorMinLength = 0; 
            public const int ColorMaxLength = 30; 
        }

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class WearCategory
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class ApplicationUser
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int BioMinLength = 2;
            public const int BioMaxLength = 300;

            public const int CityNameMinLength = 2;
            public const int CityNameMaxLength = 85;
        }
    }
}
