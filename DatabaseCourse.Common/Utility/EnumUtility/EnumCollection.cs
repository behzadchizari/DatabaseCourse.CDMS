using System.Collections.ObjectModel;

namespace DatabaseCourse.Common.Utility.EnumUtility
{
    public class EnumItem
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentValue { get; set; }
    }
    public class EnumCollection : Collection<EnumItem>
    {
        public void RemoveByValue(int val)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Value == val)
                {
                    this.RemoveAt(i);
                    return;
                }
            }
        }

    }
}
