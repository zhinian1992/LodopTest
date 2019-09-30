using System;
using System.Collections.Generic;
using System.Text;
using Lodop;

namespace LodopPrinter
{
    public class PrintManager
    {
        PrintObject printObject = new PrintObject();

        /// <summary>
        /// 初始化打印机
        /// </summary>
        /// <param name="strPrintTaskName">设置打印任务名称</param>
        /// <returns></returns>
        public void print_init(string strPrintTaskName)
        {
            printObject = new PrintObject();
            printObject.print_init(strPrintTaskName);
        }

        /// <summary>
        /// 设置打印纸张大小
        /// </summary>
        /// <param name="intOrient">纸张朝向</param>
        /// <param name="intPageWidth">纸张宽度</param>
        /// <param name="intPageHeight">纸张高度</param>
        /// <param name="strPageName"></param>
        public void set_print_pagesize(int intOrient, int intPageWidth, int intPageHeight, int strPageName)
        {
            printObject.set_print_pagesize(intOrient, intPageWidth, intPageHeight, strPageName);
        }

        /// <summary>
        /// 直接打印接口
        /// </summary>
        /// <param name="strPrintData">待打印数据字符串(含数据内容及报表格式)</param>
        /// <param name="strErrorInfo">异常信息(返回参数)</param>
        /// <returns>打印成功标识</returns>
        public bool print(string strPrintData,ref string strErrorInfo)
        {
            try
            {
                printData(strPrintData);

                printObject.print();
                return true;
            }
            catch(Exception e)
            {
                strErrorInfo = e.ToString();
                return false;
            }
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="strPrintData">待打印数据字符串(含数据内容及报表格式)</param>
        /// <param name="strErrorInfo">异常信息(返回参数)</param>
        /// <returns></returns>
        public bool preview(string strPrintData,ref string strErrorInfo)
        {
            try
            {
                printData(strPrintData);

                printObject.preview();
                return true;
            }
            catch(Exception e)
            {
                strErrorInfo = e.ToString();
                return false;
            }
        }

        /// <summary>
        /// 逐条设置打印数据
        /// </summary>
        /// <param name="strPrintData">待打印数据字符串</param>
        private void printData(string strPrintData)
        {
            /* 解析待打印数据 生成*/
            DataParser parser = new DataParser();
            List<String> printObjects = parser.parseData(strPrintData);

            /* 逐条打印 */
            printObjects.ForEach(delegate (String data)
            {
                printObject.printData(data);
            });
        }
    }
}
