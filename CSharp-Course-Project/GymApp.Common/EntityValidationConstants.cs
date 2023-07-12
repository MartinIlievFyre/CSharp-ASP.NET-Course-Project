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
        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }
        public static class Note 
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
        }
    }
}
