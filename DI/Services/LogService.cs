using DI.Attributes;
using System.Diagnostics;
using System.Reflection;

namespace DI.Services
{
    [MyCustom]          // using an attribute for a class
    public class LogService
    {
        public LogService()
        {
            Console.WriteLine("LogService ctor");
        }

        [Obsolete("This is obsolete")]          // using a built-in atrtibute
        
        public void Write(string message)
        {
            
            Console.WriteLine(message);
        }

        
        // this method shows how to get the data from the class's attribute
        public void Write2(string message)
        {
            var attr = typeof(LogService).GetCustomAttributes();
            foreach (var attribute in attr)
            {
                if (attribute is MyCustomAttribute)
                {
                    var attrVar = attribute as MyCustomAttribute;
                    Console.WriteLine($"Write2 {attrVar?.secret}");
                }
            }
            Console.WriteLine(message);
        }

        [MyCustom]      // using an attribute for a method
        public void Write3(string message) {

            // shows how to get the data from this method's attribute
            MethodBase? method = MethodBase.GetCurrentMethod();
            MyCustomAttribute? attribute = (MyCustomAttribute?)method?.GetCustomAttribute(typeof(MyCustomAttribute));
            Console.WriteLine($"Write3 {attribute?.secret}");
            Console.WriteLine(message);
        }
    }
}
