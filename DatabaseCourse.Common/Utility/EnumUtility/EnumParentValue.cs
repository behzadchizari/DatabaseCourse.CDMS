namespace DatabaseCourse.Common.Utility.EnumUtility
{
    public class EnumParentValue : System.Attribute
    {
        public int Value;

        public EnumParentValue(int Value)
        {
            this.Value = Value;
        }
    }
}
