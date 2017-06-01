using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerate
{
    class Program
    {
        static void Main(string[] args)
        {

            //静态方法，在方法内构造对象，返回值
            Console.WriteLine("Test0: {0}", MyEvaluator.EvaluateToInteger("(30 + 4) * 2"));

            //构造要执行的items
            EvaluatorItem[] items = 
            {  
                new EvaluatorItem(typeof(int), "(30 + 4) * 2", "GetNumber"),  
                new EvaluatorItem(typeof(string), "\"Hello\"+\"There\"", "GetString"),  
                new EvaluatorItem(typeof(bool), "30 == 40", "GetBool"),  
                new EvaluatorItem(typeof(object), "new DataSet()", "GetDataSet") 
            };  
            
            //构造对象，执行items
            MyEvaluator eval = new MyEvaluator(items);  
            Console.WriteLine("TestStatic0: {0}", eval.EvaluateInt("GetNumber"));  
            Console.WriteLine("TestStatic1: {0}", eval.EvaluateString("GetString"));  
            Console.WriteLine("TestStatic2: {0}", eval.EvaluateBool("GetBool"));  
            Console.WriteLine("TestStatic3: {0}", eval.Evaluate("GetDataSet"));  
            Console.ReadLine();  
        }
    }
}
