using Assignment.DAL.Entities;
using System.Reflection;

namespace Assignment.Extensions
{
    public static class ContentExtension
    {
        public static string SetContent<T>(this HtmlTemplate template, T data)
        {
            string content = null;

            PropertyInfo[] properties = typeof(T).GetProperties();

            if (template != null && template.Content != null)
            {
                content = template.Content;
                for(int i=1; i<properties.Length-1; i++)
                {
                    var propValue = properties[i].GetValue(data);
                    content = content.Replace("{{" + properties[i].Name + "}}", Convert.ToString(propValue));
                }

                //foreach (var property in properties)
                //{
                //    var propValue = property.GetValue(data);
                //    content = content.Replace("{{" + property.Name + "}}", Convert.ToString(propValue));
                //}
            }
            return content;
        }
    }
}
