using System;
using System.Reflection;

namespace DatabaseCourse.Common.Utility.EnumUtility
{
    public class EnumUtility
    {

        public static EnumCollection List(Type type)
        {
            EnumCollection result = new EnumCollection();
            try
            {
                if (type.IsEnum)
                {
                    Array enValues = Enum.GetValues(type);

                    MemberInfo[] mis = type.GetMembers();
                    foreach (MemberInfo mi in mis)
                    {
                        object[] attribs = mi.GetCustomAttributes(typeof(EnumDescription), false);
                        object[] attribs_parent = mi.GetCustomAttributes(typeof(EnumParentValue), false);
                        if (attribs != null && attribs.Length != 0)
                        {
                            EnumItem item = new EnumItem();
                            item.Name = mi.Name;
                            item.Value = (int)Enum.Parse(type, mi.Name);
                            item.Description = ((EnumDescription)attribs[0]).Text;
                            if (attribs_parent != null && attribs_parent.Length != 0)
                            {
                                item.ParentValue = ((EnumParentValue)attribs_parent[0]).Value;
                            }

                            result.Add(item);
                        }

                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return new EnumCollection();
            }
        }
        public static string GetEnumDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length != 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (attrs != null && attrs.Length != 0)
                {
                    return ((EnumDescription)attrs[0]).Text;
                }
            }
            return en.ToString();
        }
        public static int GetEnumValue(Enum en)
        {
            try
            {
                return Convert.ToInt16(en);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static T ConvertStringToEnum<T>(string inputStr, T defaultValue)
        {
            try
            {
                var type = typeof(T);

                if (!type.IsEnum ||
                    String.IsNullOrEmpty(inputStr) ||
                    String.IsNullOrWhiteSpace(inputStr))
                    return defaultValue;

                var valueList = Enum.GetValues(type);
                var nameList = Enum.GetNames(type);

                for (int i = 0; i < nameList.Length; i++)
                {
                    var name = nameList[i];
                    var value = valueList.GetValue(i);
                    if (inputStr.ToLower() == name.ToLower())
                        return (T)Enum.Parse(type, name);
                }

                return defaultValue;
            }
            catch (Exception ex)
            {
                return defaultValue;
            }
        }
    }
}
