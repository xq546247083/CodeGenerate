using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;

namespace CodeGenerate
{
    /// <summary>   
    /// 本类用来将字符串转为可执行文本并执行   
    /// </summary>   
    public partial class MyEvaluator
    {
        #region 私有成员

        /// <summary>   
        /// 用于动态引用生成的类，执行其内部包含的可执行字符串   
        /// </summary>   
        private object mCompiled = null;

        #endregion

        #region 构造函数

        /// <summary>   
        /// 可执行串的构造函数   
        /// </summary>   
        /// <param name="items">   
        /// 可执行字符串数组   
        /// </param>   
        public MyEvaluator(EvaluatorItem[] items)
        {
            ConstructEvaluator(items);      //调用解析字符串构造函数进行解析   
        }

        /// <summary>   
        /// 可执行串的构造函数   
        /// </summary>   
        /// <param name="item">可执行字符串项</param>   
        public MyEvaluator(EvaluatorItem item)
        {
            EvaluatorItem[] items = { item };//将可执行字符串项转为可执行字符串项数组   
            ConstructEvaluator(items);      //调用解析字符串构造函数进行解析   
        }

        /// <summary>   
        /// 解析字符串构造函数   
        /// </summary>   
        /// <param name="items">待解析字符串数组</param>   
        private void ConstructEvaluator(EvaluatorItem[] items)
        {
            //创建C#编译器实例
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");

            //编译器的传入参数   
            CompilerParameters cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("system.dll");
            cp.ReferencedAssemblies.Add("system.data.dll");
            cp.ReferencedAssemblies.Add("system.xml.dll");
            cp.GenerateExecutable = false;                          //不生成可执行文件   
            cp.GenerateInMemory = true;                             //在内存中运行   

            StringBuilder code = new StringBuilder();               //创建代码串

            /*  
             *  添加常见且必须的引用字符串  
             */
            code.Append("using System; " + Environment.NewLine);
            code.Append("using System.Data; " + Environment.NewLine);
            code.Append("using System.Data.SqlClient; " + Environment.NewLine);
            code.Append("using System.Data.OleDb; " + Environment.NewLine);
            code.Append("using System.Xml; " + Environment.NewLine);

            code.Append("namespace CodeGenerate { " + Environment.NewLine); 

            code.Append("  public class _Evaluator { " + Environment.NewLine);          //产生 _Evaluator 类，所有可执行代码均在此类中运行   
            foreach (EvaluatorItem item in items)               //遍历每一个可执行字符串项   
            {
                code.AppendFormat("    public {0} {1}() ", item.ReturnType.Name, item.Name);   //函数名称为可执行字符串项中定义的执行字符串名称   
                code.Append("{ ");
                code.AppendFormat("return ({0});", item.Expression);//添加函数体，返回可执行字符串项中定义的表达式的值   
                code.Append("}" + Environment.NewLine);
            }
            code.Append("} }");                                 //添加类结束和命名空间结束括号   

            //得到编译器实例的返回结果   
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, code.ToString());

            if (cr.Errors.HasErrors)                            //如果有错误   
            {
                StringBuilder error = new StringBuilder();          //创建错误信息字符串   
                error.Append("编译有错误的表达式: ");                //添加错误文本   
                foreach (CompilerError err in cr.Errors)            //遍历每一个出现的编译错误   
                {
                    error.AppendFormat("{0}" + Environment.NewLine, err.ErrorText);     //添加进错误文本，每个错误后换行   
                }

                throw new Exception("编译错误: " + error);//抛出异常   
            }

            Assembly a = cr.CompiledAssembly;                       //获取编译器实例的程序集   
            mCompiled = a.CreateInstance("CodeGenerate._Evaluator");     //通过程序集查找并声明 CodeGenerate._Evaluator 的实例   
        }

        #endregion

        #region 公有成员

        /// <summary>   
        /// 执行字符串并返回整型值   
        /// </summary>   
        /// <param name="name">执行字符串名称</param>   
        /// <returns>执行结果</returns>   
        public int EvaluateInt(string name)
        {
            return (int)Evaluate(name);
        }

        /// <summary>   
        /// 执行字符串并返回双精度值   
        /// </summary>   
        /// <param name="name">执行字符串名称</param>   
        /// <returns>执行结果</returns>   
        public double EvaluateDouble(string name)
        {
            return (double)Evaluate(name);
        }

        /// <summary>   
        /// 执行字符串并返回长整型数值   
        /// </summary>   
        /// <param name="name">执行字符串名称</param>   
        /// <returns>执行结果</returns>   
        public long EvaluateLong(string name)
        {
            return (long)Evaluate(name);
        }

        /// <summary>   
        /// 执行字符串并返回十进制数值   
        /// </summary>   
        /// <param name="name">执行字符串名称</param>   
        /// <returns>执行结果</returns>   
        public decimal EvaluateDecimal(string name)
        {
            return (decimal)Evaluate(name);
        }

        /// <summary>   
        /// 执行字符串并返回字符串型值   
        /// </summary>   
        /// <param name="name">执行字符串名称</param>   
        /// <returns>执行结果</returns>   
        public string EvaluateString(string name)
        {
            return (string)Evaluate(name);
        }

        /// <summary>   
        /// 执行字符串并返回布尔型值   
        /// </summary>   
        /// <param name="name">执行字符串名称</param>   
        /// <returns>执行结果</returns>   
        public bool EvaluateBool(string name)
        {
            return (bool)Evaluate(name);
        }

        /// <summary>   
        /// 执行字符串并返 object 型值   
        /// </summary>   
        /// <param name="name">执行字符串名称</param>   
        /// <returns>执行结果</returns>   
        public object Evaluate(string name)
        {
            MethodInfo mi = mCompiled.GetType().GetMethod(name);//获取 mCompiled 所属类型中名称为 name 的方法的引用   
            return mi.Invoke(mCompiled, null);                  //执行 mi 所引用的方法   
        }

        #endregion
    }
}