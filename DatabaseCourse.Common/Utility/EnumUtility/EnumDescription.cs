namespace DatabaseCourse.Common.Utility.EnumUtility
{
    public class EnumDescription : System.Attribute
    {
        public string Text;

        public EnumDescription(string text)
        {
            this.Text = text;
        }

    }
}
