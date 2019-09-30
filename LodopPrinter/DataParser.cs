using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LodopPrinter
{
    class DataParser
    {
        /// <summary>
        /// 提取JSON数据中待打印数组
        /// </summary>
        /// <param name="strData">待打印数据</param>
        /// <returns></returns>
        public List<String> parseData(string strData)
        {
            List<String> printObjects = new List<String>();

            JArray jlist = JArray.Parse(strData);
            for (int i = 0; i < jlist.Count; i++)
            {
                printObjects.Add(jlist[i].ToString());
            }
            return printObjects;
        }
    }
}
