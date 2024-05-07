using System;
using System.CodeDom.Compiler;
using System.Web.Mvc;

public class ExampleController : Controller
{
    public void Run(string message)
    {
        const string code = @"
            using System;
            public class MyClass
            {
                public void MyMethod()
                {
                    Console.WriteLine(""" + message + @""");
                }
            }
        ";

        var provider = CodeDomProvider.CreateProvider("CSharp");
        var compilerParameters = new CompilerParameters { ReferencedAssemblies = { "System.dll", "System.Runtime.dll" } };
        var compilerResults = provider.CompileAssemblyFromSource(compilerParameters, code);
        object myInstance = compilerResults.CompiledAssembly.CreateInstance("MyClass");
        myInstance.GetType().GetMethod("MyMethod").Invoke(myInstance, new object[0]);
    }
}
