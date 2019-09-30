using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Lodop;


namespace LodopPrinter
{
    class PrintObject
    {
        public Lodop.LodopX lodop = new Lodop.LodopX();

        /// <summary>
        /// 初始化打印
        /// </summary>
        /// <param name="strPrintTaskName"></param>
        public void print_init(string strPrintTaskName)
        {
            lodop.PRINT_INIT(strPrintTaskName);
        }

        /// <summary>
        /// 设置打印纸张大小
        /// </summary>
        /// <param name="intOrient"></param>
        /// <param name="intPageWidth"></param>
        /// <param name="intPageHeight"></param>
        /// <param name="strPageName"></param>
        public void set_print_pagesize(int intOrient, int intPageWidth, int intPageHeight, int strPageName)
        {
            lodop.SET_PRINT_PAGESIZE(intOrient, intPageWidth, intPageHeight, strPageName);
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void print()
        {
            lodop.PRINT();
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void preview()
        {
            lodop.PREVIEW();
        }

        /// <summary>
        /// 根据单条数据类型打印
        /// </summary>
        /// <param name="strPrintData"></param>
        public void printData(string strPrintData)
        {
            JObject jsonObj = JObject.Parse(strPrintData);
            string printObjType = jsonObj["type"].ToString();

            if (printObjType.CompareTo("htm") == 0)
            {
                printHTM(strPrintData);
            }
            else if (printObjType.CompareTo("1") == 0)//text
            {
                printTEXT(strPrintData);
            }
            else if (printObjType.CompareTo("table") == 0)
            {
                printTABLE(strPrintData);
            }
            else if (printObjType.CompareTo("shape") == 0)
            {
                printSHAPE(strPrintData);
            }
            else
            {
                throw new Exception("获取打印项type错误");
            }
        }

        private void printHTM(string strPrintData)
        {
            JObject jsonObj = JObject.Parse(strPrintData);
            int intTop = (int)Convert.ToSingle(jsonObj["top"].ToString());
            int intLeft = (int)Convert.ToSingle(jsonObj["left"].ToString());
            int intWidth = (int)Convert.ToSingle(jsonObj["width"].ToString());
            int intHeight = (int)Convert.ToSingle(jsonObj["height"].ToString());
            string strHtml = jsonObj["value"].ToString();

            lodop.ADD_PRINT_HTM(intTop, intLeft, intWidth, intHeight, strHtml);
        }

        private void printTEXT(string strPrintData)
        {
            JObject jsonObj = JObject.Parse(strPrintData);
            int intTop = (int)Convert.ToSingle(jsonObj["top"].ToString());
            int intLeft = (int)Convert.ToSingle(jsonObj["left"].ToString());
            int intWidth = (int)Convert.ToSingle(jsonObj["width"].ToString());
            int intHeight = (int)Convert.ToSingle(jsonObj["height"].ToString());
            string strContent = jsonObj["value"].ToString();

            lodop.ADD_PRINT_TEXT(intTop, intLeft, intWidth, intHeight, strContent);
        }

        private void printTABLE(string strPrintData)
        {
            JObject jsonObj = JObject.Parse(strPrintData);
            int intTop = (int)Convert.ToSingle(jsonObj["top"].ToString());
            int intLeft = (int)Convert.ToSingle(jsonObj["left"].ToString());
            int intWidth = (int)Convert.ToSingle(jsonObj["width"].ToString());
            int intHeight = (int)Convert.ToSingle(jsonObj["height"].ToString());
            string strHtml = jsonObj["value"].ToString();

            lodop.ADD_PRINT_TABLE(intTop, intLeft, intWidth, intHeight, strHtml);
        }

        private void printSHAPE(string strPrintData)
        {
            JObject jsonObj = JObject.Parse(strPrintData);
            int intShapeType = int.Parse(jsonObj["intShapeType"].ToString());
            int intTop = (int)Convert.ToSingle(jsonObj["top"].ToString());
            int intLeft = (int)Convert.ToSingle(jsonObj["left"].ToString());
            int intWidth = (int)Convert.ToSingle(jsonObj["width"].ToString());
            int intHeight = (int)Convert.ToSingle(jsonObj["height"].ToString());
            int intLineStyle = (int)Convert.ToSingle(jsonObj["intLineStyle"]);
            int intLineWidth = (int)Convert.ToSingle(jsonObj["intLineWidth"]);
            int intColor = (int)Convert.ToSingle(jsonObj["intColor"]);

            lodop.ADD_PRINT_SHAPE(intShapeType, intTop, intLeft, intWidth, intHeight, intLineStyle, intLineWidth, intColor);
        }
    }
}
