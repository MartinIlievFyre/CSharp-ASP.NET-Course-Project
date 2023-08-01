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

            public const string CaloriesMin = "0";
            public const string CaloriesMax = "2147483647";

            public const string ProteinMin = "0";
            public const string ProteinMax = "2147483647";

            public const string CarbsMin = "0";
            public const string CarbsMax = "2147483647";

            public const string FatMin = "0";
            public const string FatMax = "2147483647";
        }

        public static class Wear
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const string PriceMin = "1";
            public const string PriceMax = "10000";

            public const int ImageUrlMaxlLength = 2048;

            public const int SizeMinLength = 1;
            public const int SizeMaxLength = 3;

            public const int FabricMinLength = 2;
            public const int FabricMaxLength = 50;

            public const int DescriptionMinLength = 0;
            public const int DescriptionMaxLength = 5000;

            public const int TypeMinLength = 2;
            public const int TypeMaxLength = 20;

            public const int ColorMinLength = 0; 
            public const int ColorMaxLength = 30; 
        }
        public static class Supplement
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
           
            public const int ManufacturerNameMinLength = 2;
            public const int ManufacturerNameMaxLength = 50;

            public const int DescriptionMinLength = 0;
            public const int DescriptionMaxLength = 5000;


            public const int ImageUrlMaxlLength = 2048;

            public const int BenefitsMinLength = 20;
            public const int BenefitsMaxLength = 1000;

            public const int TypeMinLength = 2;
            public const int TypeMaxLength = 20;

            public const int IngredientsMinLength = 20;
            public const int IngredientsMaxLength = 1000;

            public const string PriceMin = "1";
            public const string PriceMax = "10000";
        }
        public static class Accessory
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int ManufacturerNameMinLength = 2;
            public const int ManufacturerNameMaxLength = 50;

            public const int DescriptionMinLength = 0;
            public const int DescriptionMaxLength = 5000;

            public const int BenefitsMinLength = 20;
            public const int BenefitsMaxLength = 1000;

            public const int ImageUrlMaxlLength = 2048;

            public const int TypeMinLength = 2;
            public const int TypeMaxLength = 20;

            public const string PriceMin = "1";
            public const string PriceMax = "10000";
        }
        public static class Product 
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int SizeMinLength = 1;
            public const int SizeMaxLength = 3;

            public const int ImageUrlMaxlLength = 2048;

            public const int TypeMinLength = 2;
            public const int TypeMaxLength = 20;

            public const string QuantityMinValue = "1";
            public const string QuantityMaxValue = "1000";

            public const string TotalPriceMinValue = "0";
            public const string TotalPriceMaxValue = "100000";

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "100000";


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
        }

        public static class Register
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

            public const int PasswordMinLength = 4;
            public const int PasswordMaxLength = 20;

        }
        public static class Order
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 50;

            public const int EmailMinLength = 2;
            public const int EmailMaxLength = 320;

            public const int CityNameMinLength = 2;
            public const int CityNameMaxLength = 85;

            public const int CountryNameMinLength = 2;
            public const int CountryNameMaxLength = 56;

            public const int AddressMinLength = 2;
            public const int AddressMaxLength = 200;

            public const int DescriptionMinLength = 0;
            public const int DescriptionMaxLength = 5000;

            public const int PhoneLength = 10;
        }
    }
}
