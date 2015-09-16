using System;
using System.Collections.Generic;
using System.Linq;

namespace _GZFramework.Demo.Library
{
    public class ModuleFunctionCollection
    {
        public List<ModuleFunction> funs;
        public ModuleFunctionCollection()
        {
            funs = new List<ModuleFunction>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FormType">�Ӵ�����,����̳���frmBaseFunction</param>
        /// <param name="Text">�Ӵ�������</param>
        /// <param name="PNGName">ͼƬ��СΪ64x64</param>
        public void AddFunction(Type FormType, string Text, string PNGName)
        {
            ModuleFunction fun = new ModuleFunction(FormType, Text, PNGName);
            funs.Add(fun);
        }
    }
}
