namespace Db.Models
{
    public static class Gender
    {


        public static readonly string Male = "male";
        public static readonly string Female = "female";
        public static readonly string Other = "other";
        public static readonly string Unknown = "unknown";

        public static List<String> valueList = new List<String>() { Gender.Male, Gender.Female, Gender.Other, Gender.Unknown };

        public static Boolean isValid(String str)
        {
            return valueList.Contains(str);
        }
    }
}
