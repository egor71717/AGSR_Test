namespace Db.Models
{
    public static class Active
    {
        public static readonly string True = "true";
        public static readonly string False = "false";
        public static List<String> valueList = new List<String>() { Active.True, Active.False };
        public static Boolean isValid(String str)
        {
            return valueList.Contains(str);
        }


    }
}
