using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace wpf_xpath_demo
{
    class Program
    {
        static XmlElement class23 = null;
        static void Main(string[] args)
        {
            XmlDocument xmldoc = new XmlDocument();
            var School = xmldoc.AppendChild(xmldoc.CreateElement("School")) as XmlElement;
            School.SetAttribute("id","school");
            var grade1 = AddChildOnParent("Grade", "grade1", School);
            {
                var class1 = AddChildOnParent("Class", "class11", grade1);
                var class2 = AddChildOnParent("Class", "class12", grade1);
                var class3 = AddChildOnParent("Class", "class13", grade1);
                var class4 = AddChildOnParent("Class", "class14", grade1);
            }
            var grade2 = AddChildOnParent("Grade", "grade2", School);
            {
                var class1 = AddChildOnParent("Class", "class21", grade2);
                var class2 = AddChildOnParent("Class", "class22", grade2);
                var class3 = class23 = AddChildOnParent("Class", "class23", grade2);
                var class4 = AddChildOnParent("Class", "class24", grade2);
                var class5 = AddChildOnParent("Class", "class25", grade2);
            }
            var grade3 = AddChildOnParent("Grade", "grade3", School);
            {
                var class1 = AddChildOnParent("Class", "class31", grade3);
                var class2 = AddChildOnParent("Class", "class32", grade3);
                var class3 = AddChildOnParent("Class", "class33", grade3);
                var group331 = AddChildOnParent("Group", "group331", class3);
                var group332 = AddChildOnParent("Group", "group332", class3);
                var group333 = AddChildOnParent("Group", "group333", class3);
                var class4 = AddChildOnParent("Class", "class34", grade3);
            }
            var grade4 = AddChildOnParent("Grade", "grade4", School);
            {
                var class1 = AddChildOnParent("Class", "class41", grade4);
                var class2 = AddChildOnParent("Class", "class42", grade4);
                var class3 = AddChildOnParent("Class", "class43", grade4);
                var class4 = AddChildOnParent("Class", "class44", grade4);
            }
            var grade5 = AddChildOnParent("Grade", "grade5", School);
            {
                var class1 = AddChildOnParent("Class", "class51", grade5);
                var class2 = AddChildOnParent("Class", "class52", grade5);
                var class3 = AddChildOnParent("Class", "class53", grade5);
                var class4 = AddChildOnParent("Class", "class54", grade5);
            }
            var grade6 = AddChildOnParent("Grade", "grade6", School);
            {
                var class1 = AddChildOnParent("Class", "class61", grade6);
                var class2 = AddChildOnParent("Class", "class62", grade6);
                var class3 = AddChildOnParent("Class", "class63", grade6);
                var class4 = AddChildOnParent("Class", "class64", grade6);
            }
            //xmldoc.Save(@"d:\1.xml");
            //Console.Write(xmldoc.OuterXml);
            /*
             * 由此可见：
             * 1. * 与 ./*相同,皆代表子节点 （皆不包含自己）
             * 2. //* 代表所有节点，无论当前节点是什么。
             * 3. .//* 代表所有后代节点。
             */
            var cmd = "childs";
            if (cmd == "cur") //获取当前节点方法
            {
                //第1种：直接访问
                Console.WriteLine("Method 1: "+class23.GetAttribute("id"));

                //第2种：XPath 访问
                var x = class23.SelectSingleNode(".") as XmlElement;
                Console.WriteLine("Method 2: " + x.GetAttribute("id"));

                //第3种：XPath Axes 访问
                var y = class23.SelectSingleNode("self::*") as XmlElement;
                Console.WriteLine("Method 3: " + y.GetAttribute("id"));
            }
            else if (cmd == "parent") //父节点访问
            {
                //第1种：ParentNode访问
                Console.WriteLine((class23.ParentNode as XmlElement).GetAttribute("id"));

                //第2种：XPath访问
                var x = class23.SelectSingleNode("..") as XmlElement;
                Console.WriteLine(x.GetAttribute("id"));

                //第3种：XPath Axes访问
                var y = class23.SelectSingleNode("parent::*") as XmlElement;
                Console.WriteLine(y.GetAttribute("id"));
            }
            else if (cmd == "lastchild") //访问最后节点
            {
                //第1种：ChildNodes直接访问
                Console.WriteLine((class23.ParentNode.ChildNodes[class23.ParentNode.ChildNodes.Count - 1] as XmlElement).GetAttribute("id"));

                //第2种：XPath访问
                var x = class23.SelectSingleNode("../*[last()]") as XmlElement;
                Console.WriteLine(x.GetAttribute("id"));

                //第3种：ParentNode.LastChild访问
                var z = class23.ParentNode.LastChild as XmlElement;
                Console.WriteLine(z.GetAttribute("id"));
            }
            else if (cmd == "firsthild") //首节点访问
            {
                //第1种：ChildNodes访问
                Console.WriteLine((class23.ParentNode.ChildNodes[0] as XmlElement).GetAttribute("id"));

                //第2种：XPath访问
                var x = class23.SelectSingleNode("../*[1]") as XmlElement;
                Console.WriteLine(x.GetAttribute("id"));

                //第3种：LastChild访问
                var z = class23.ParentNode.LastChild as XmlElement;
                Console.WriteLine(z.GetAttribute("id"));
            }
            else if (cmd == "previousChild") //前一节点访问
            {
                //第1种：PreviousSibling访问
                Console.WriteLine((class23.PreviousSibling as XmlElement).GetAttribute("id"));

                //第2种：XPath Axes访问
                var x = class23.SelectSingleNode("preceding-sibling::*[1]") as XmlElement;
                Console.WriteLine(x.GetAttribute("id"));
            }
            else if (cmd == "lastChild") //后一节点访问
            {
                //第1种：NextSibling访问
                Console.WriteLine((class23.NextSibling as XmlElement).GetAttribute("id"));

                //第2种：XPath Axes访问
                var x = class23.SelectSingleNode("following-sibling::*[1]") as XmlElement;
                Console.WriteLine(x.GetAttribute("id"));
            }
            else if (cmd == "root") //访问根节点
            {
                //第1种：XPath访问
                var x = class23.SelectSingleNode("/*") as XmlElement;
                Console.WriteLine(x.GetAttribute("id"));

                //第2种：DocumentElement访问
                var y = class23.OwnerDocument.DocumentElement;
                Console.WriteLine(y.GetAttribute("id"));

                //第3种：循环访问
                var z = class23;
                while (z as XmlElement != class23.OwnerDocument.DocumentElement) z = z.ParentNode as XmlElement;
                Console.WriteLine(z.GetAttribute("id"));
            }
            else if (cmd == "getIndex") //获取当前节点索引
            {
                //第1种：XPath Axes访问
                var x = class23.SelectNodes("preceding-sibling::*");
                Console.WriteLine(x.Count);
            }
            else if (cmd == "brothers") //访问兄弟节点集合
            {
                //第1种：ChildNodes访问
                Console.WriteLine(class23.ParentNode.ChildNodes.Count.ToString());

                //第2种：Xpath访问
                var x = class23.SelectNodes("../*");
                Console.WriteLine(x.Count);

                //第3种：XPath Axes直接访问
                var y = class23.SelectNodes("preceding-sibling::* | following-sibling::* | .");
                Console.WriteLine(y.Count);
            }
            else if (cmd == "head3") //前3个节点集合
            {
                //第1种：XPath访问
                var x = class23.SelectNodes("../*[position()<=3]");
                Console.WriteLine(x.Count);
            }
            else if (cmd == "all_parents") //父节点集合
            {
                //第1种：循环访问法
                List<XmlElement> list_parents = new List<XmlElement>();
                var z = class23;
                while (z as XmlElement != class23.OwnerDocument.DocumentElement) { z = z.ParentNode as XmlElement; list_parents.Add(z); }
                Console.WriteLine(list_parents.Count.ToString());

                //第2种：XPath Axes访问
                var y = class23.SelectNodes("ancestor::*");
                Console.WriteLine(y.Count.ToString());
            }
            else if (cmd == "all_parents_or_self") //包括自己的父节点集合
            {
                //第1种：循环访问
                List<XmlElement> list_parents = new List<XmlElement>();
                var z = class23;
                list_parents.Add(z);
                while (z as XmlElement != class23.OwnerDocument.DocumentElement) { z = z.ParentNode as XmlElement; list_parents.Add(z); }
                Console.WriteLine(list_parents.Count.ToString());

                //第2种：XPath Axes访问
                var y = class23.SelectNodes("ancestor-or-self::*");
                Console.WriteLine(y.Count.ToString());
            }

            else if (cmd == "childs") //子节点集合
            {
                //第1种：ChildNodes访问
                var classes = grade3.ChildNodes.Count;
                Console.WriteLine(classes.ToString());

                //第2种：XPath访问
                var x = grade3.SelectNodes("./*");
                Console.WriteLine(x.Count.ToString());

                //第3种：XPath Axes访问
                var y = grade3.SelectNodes("child::*");
                Console.WriteLine(y.Count.ToString());

                //第2种：XPath访问
                var d = grade3.SelectNodes("*");
                Console.WriteLine(d.Count.ToString());
            }
            else if (cmd == "allchilds") //所有后代节点访问
            {
                //第1种：递归访问
                var classes = GetAllChilds(grade3);
                Console.WriteLine(classes.ToString());

                //第2种：XPath访问
                var x = grade3.SelectNodes(".//*");
                Console.WriteLine(x.Count.ToString());

                //第3种：XPath Axes访问
                var y = grade3.SelectNodes("descendant::*");
                Console.WriteLine(y.Count.ToString());
            }
            else if (cmd == "allchilds_or_self") //包括自己的所有后代节点访问
            {
                //第1种：递归访问
                var classes = GetAllChilds_Or_Self(grade3);
                Console.WriteLine(classes.ToString());

                //第2种：XPath访问
                var x = grade3.SelectNodes(".//* | .");
                Console.WriteLine(x.Count.ToString());

                //第3种：XPath Axes访问
                var y = grade3.SelectNodes("descendant-or-self::*");
                Console.WriteLine(y.Count.ToString());
            }
            else if (cmd == "all_nodes") //所有节点
            {
                //第1种：XPath访问
                var c = grade3.SelectNodes("//*");
                Console.WriteLine(c.Count.ToString());

                //第2种：根节点XPath访问
                var x = grade3.OwnerDocument.SelectNodes("//*");
                Console.WriteLine(x.Count.ToString());

                //第3种：根节点XPath访问
                var y = grade3.OwnerDocument.SelectNodes(".//*");
                Console.WriteLine(y.Count.ToString());
            }
            else if (cmd == "doc_nodes") //不包含根节点的所有节点
            {
                //第1种：根节点XPath访问
                var x = grade3.OwnerDocument.ChildNodes[0].SelectNodes(".//*");
                Console.WriteLine(x.Count.ToString());

                //第2种：根节点XPath访问
                var y = grade3.OwnerDocument.DocumentElement.SelectNodes(".//*");
                Console.WriteLine(y.Count.ToString());
            }
            else if (cmd == "doc_roots") //第一级目录集合
            {
                //第1种：根节点XPath访问
                var x = grade3.OwnerDocument.ChildNodes[0].SelectNodes("./*");
                Console.WriteLine(x.Count.ToString());

                //第2种：根节点XPath访问
                var y = grade3.OwnerDocument.DocumentElement.SelectNodes("./*");
                Console.WriteLine(y.Count.ToString());

                //第3种：根节点XPath访问
                var z = grade3.OwnerDocument.DocumentElement.SelectNodes("*");
                Console.WriteLine(z.Count.ToString());
            }
            Console.ReadKey();

        }
        private static int GetAllChilds(XmlNode xn)
        {
            var c = 0;
            foreach (XmlNode x in xn.ChildNodes) { c++;  c += GetAllChilds(x); }
            return c;
        }
        private static int GetAllChilds_Or_Self(XmlNode xn)
        {
            var c = 1;
            foreach (XmlNode x in xn.ChildNodes) c += GetAllChilds_Or_Self(x);
            return c;
        }
        private static XmlElement AddChildOnParent(String newName, String newID, XmlElement parent)
        {
            var xeNew = parent.OwnerDocument.CreateElement(newName);
            xeNew.SetAttribute("id", newID);
            parent.AppendChild(xeNew);
            return xeNew;
        }
    }
}
