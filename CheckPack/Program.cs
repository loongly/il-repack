using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPack
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"E:\Lib\out\out.dll";
            //var path = @"E:\Lib\out\UnityEngine.CoreModule.dll";
            StreamWriter sw = new StreamWriter(@"E:\Lib\out\type.txt", false, Encoding.UTF8);
            ModuleDefinition module = ModuleDefinition.ReadModule(path);
            foreach(var t in module.Types)
            {
                if (!t.IsPublic && !t.IsNestedPublic)
                    continue;

                if (t.IsValueType)
                {
                    sw.WriteLine(t.FullName);
                }

                foreach (var nt in t.NestedTypes)
                {
                    if (!nt.IsPublic && !nt.IsNestedPublic)
                        continue;

                    if (nt.IsValueType)
                        sw.WriteLine(nt.FullName);
                }
            }
            sw.Flush();
            sw.Dispose();

        }

    }
}
