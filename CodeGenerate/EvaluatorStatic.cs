using System;

namespace CodeGenerate
{
    /// <summary>   
    /// 本类用来将字符串转为可执行文本并执行   
    /// </summary>   
    public partial class MyEvaluator
    {
        /// <summary>   
        /// 静态方法的执行字符串名称   
        /// </summary>   
        private const string MStaticMethodName = "__foo";

        #region 构造函数

        /// <summary>   
        /// 可执行串的构造函数   
        /// </summary>   
        /// <param name="returnType">返回值类型</param>   
        /// <param name="expression">执行表达式</param>   
        /// <param name="name">执行字符串名称</param>   
        public MyEvaluator(Type returnType, string expression, string name)
        {
            //创建可执行字符串数组   
            EvaluatorItem item = new EvaluatorItem(returnType, expression, name);
            ConstructEvaluator(new[] { item });
        }

        #endregion

        #region 静态成员

        /// <summary>   
        /// 执行表达式并返回整型值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>运算结果</returns>   
        static public int EvaluateToInteger(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(int), code, MStaticMethodName);//生成 Evaluator 类的对像   
            return (int)eval.Evaluate(MStaticMethodName);                        //执行并返回整型数据   
        }

        /// <summary>   
        /// 执行表达式并返回双精度值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>执行结果</returns>   
        static public double EvaluateToDouble(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(double), code, MStaticMethodName);//生成 Evaluator 类的对像   
            return (double)eval.Evaluate(MStaticMethodName);
        }

        /// <summary>   
        /// 执行表达式并返回长整型数值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>执行结果</returns>   
        static public long EvaluateToLong(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(long), code, MStaticMethodName);//生成 Evaluator 类的对像   
            return (long)eval.Evaluate(MStaticMethodName);
        }

        /// <summary>   
        /// 执行表达式并返回十进制数值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>执行结果</returns>   
        static public decimal EvaluateToDecimal(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(decimal), code, MStaticMethodName);//生成 Evaluator 类的对像   
            return (decimal)eval.Evaluate(MStaticMethodName);
        }

        /// <summary>   
        /// 执行表达式并返回字符串型值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>运算结果</returns>   
        static public string EvaluateToString(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(string), code, MStaticMethodName);//生成 Evaluator 类的对像   
            return (string)eval.Evaluate(MStaticMethodName);                     //执行并返回字符串型数据   
        }

        /// <summary>   
        /// 执行表达式并返回布尔型值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>运算结果</returns>   
        static public bool EvaluateToBool(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(bool), code, MStaticMethodName);//生成 Evaluator 类的对像   
            return (bool)eval.Evaluate(MStaticMethodName);                       //执行并返回布尔型数据   
        }

        /// <summary>   
        /// 执行表达式并返回 object 型值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>运算结果</returns>   
        static public object EvaluateToObject(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(object), code, MStaticMethodName);//生成 Evaluator 类的对像   
            return eval.Evaluate(MStaticMethodName);                             //执行并返回 object 型数据   
        }

        #endregion
    }
}
