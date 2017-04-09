using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class XMLClass
    {
        /// <summary>
        /// 读取XML文档
        /// </summary>
        /// <param name="StrFileName">文件路径</param>
        /// 
        public List<string> ReadXMLByFileName(string StrFileName)
        {
            //DataTable dtResult = new DataTable();
            List<string> list = new List<string>();
            try
            {
                if (!StrFileName.EndsWith(".xml"))
                {
                    Console.WriteLine( "该文件不是xml文件");
                }
                XElement rootE = XElement.Load(StrFileName, LoadOptions.None);
                foreach (var pp in rootE.Elements("product"))
                {
                    string ProductPNo = pp.Attribute("productCode").Value;
                    string ProductName = pp.Attribute("productName").Value;
                     foreach (var sp in pp.Elements("subType"))
                     {
                         string ProductNo = sp.Attribute("typeNo").Value;
                         string PackageSpec = sp.Attribute("packageSpec").Value;
                         string PackUnit = sp.Attribute("packUnit").Value;
                         foreach (var pcs in sp.Elements("resProdCodes"))
                         {
                             foreach (var pc in pcs.Elements("resCode"))
                             {
                                 string codeVersion = pc.Attribute("codeVersion").Value;
                                 string codeLevel = pc.Attribute("codeLevel").Value;
                                 string codeValue = pc.Value;

                                 string ProductRELNo = codeVersion + codeValue;

                                 try
                                 {
                                    
                                     list.Add("ProductPNo：" + ProductPNo + ",ProductName：" + ProductPNo + ",ProductNo:" + ProductNo + ",PackageSpec：" + PackageSpec + ",ProductRELNo：" + PackageSpec + ",codeLevel:" + codeLevel);
                                     //Console.WriteLine("ProductPNo：{0},ProductName：{1},ProductNo：{2},PackageSpec：{3},ProductRELNo：{4},codeLevel：{5},PackUnit:{6}",
                                     //    ProductPNo, ProductName, ProductNo, PackageSpec, ProductRELNo, codeLevel, PackUnit);
                                 }
                                 catch (Exception ex)
                                 {
                                     Console.WriteLine(ex.Message);
                                 }
                             }
                         }
                     }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public string CreateXMLFile(string strPath)
        {

            List<int> list=new List<int>();
            list.AddRange(new int[] {102,123,12334,423});
            //创建文档
            XDocument xmlDoc = new XDocument(new XDeclaration("1.0", "", ""));
           
            //创建根节点
            XElement root= XElement.Parse("<productList xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" version=\"3.0\"></productList>");
            //root.Add(new XElement("Product", new XAttribute("productCode", "1005203")));
            XElement firstElement = new XElement("Product");
            XAttribute xt = new XAttribute("productCode", "1005203");
            

            XElement e=new XElement("Product",
                            new XAttribute("productCode", "1005203"),
                            new XAttribute("productName", "板蓝根颗粒"),
                            new XAttribute("comment", ""),
                            new XElement("subType",
                                new XAttribute("typeNo", "1005203001"),
                                new XAttribute("authorizedNo", "国药准字Z44023408"),
                                new XAttribute("type", ""),
                                new XAttribute("packUnit", ""),
                                new XAttribute("physicDetailType", ""),
                                new XAttribute("spec", "每袋装10g(含糖型)"),
                                new XElement("resProdCodes",
                                    new XElement("resCode",
                                       new XAttribute("codeVersion","86"),
                                       new XAttribute("codeLevel", "2"),
                                       new XAttribute("pkgRatio", "1:50"),10))));
            root.Add(e);
            xmlDoc.Add(root);
            try
            {
                xmlDoc.Save(strPath);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "true";
        }
        
    }
}
