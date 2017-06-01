
namespace CodeGenerate
{
    /// <summary>   
    /// 本类用来将字符串转为可执行文本并执行   
    /// </summary>   
    public partial class MyEvaluator
    {
        #region 静态成员

        /// <summary>   
        /// 执行表达式并返回整型值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>运算结果</returns>   
        static public int EvaluateToInteger(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(int), code, staticMethodName);//生成 Evaluator 类的对像   
            return (int)eval.Evaluate(staticMethodName);                        //执行并返回整型数据   
        }

        /// <summary>   
        /// 执行表达式并返回双精度值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>执行结果</returns>   
        static public double EvaluateToDouble(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(double), code, staticMethodName);//生成 Evaluator 类的对像   
            return (double)eval.Evaluate(staticMethodName);
        }

        /// <summary>   
        /// 执行表达式并返回长整型数值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>执行结果</returns>   
        static public long EvaluateToLong(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(long), code, staticMethodName);//生成 Evaluator 类的对像   
            return (long)eval.Evaluate(staticMethodName);
        }

        /// <summary>   
        /// 执行表达式并返回十进制数值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>执行结果</returns>   
        static public decimal EvaluateToDecimal(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(decimal), code, staticMethodName);//生成 Evaluator 类的对像   
            return (decimal)eval.Evaluate(staticMethodName);
        }

        /// <summary>   
        /// 执行表达式并返回字符串型值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>运算结果</returns>   
        static public string EvaluateToString(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(string), code, staticMethodName);//生成 Evaluator 类的对像   
            return (string)eval.Evaluate(staticMethodName);                     //执行并返回字符串型数据   
        }

        /// <summary>   
        /// 执行表达式并返回布尔型值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>运算结果</returns>   
        static public bool EvaluateToBool(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(bool), code, staticMethodName);//生成 Evaluator 类的对像   
            return (bool)eval.Evaluate(staticMethodName);                       //执行并返回布尔型数据   
        }

        /// <summary>   
        /// 执行表达式并返回 object 型值   
        /// </summary>   
        /// <param name="code">要执行的表达式</param>   
        /// <returns>运算结果</returns>   
        static public object EvaluateToObject(string code)
        {
            MyEvaluator eval = new MyEvaluator(typeof(object), code, staticMethodName);//生成 Evaluator 类的对像   
            return eval.Evaluate(staticMethodName);                             //执行并返回 object 型数据   
        }

        #endregion
    }
}
