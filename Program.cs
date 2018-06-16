using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CombineBigXml
{
    class Program
    {
        static void Main(string[] args)
        {
            List<XElement> tags = XDocument.Load(@"D:\tags1.xml").Element("root")?.Elements("Tag").ToList();
            tags?.AddRange(XDocument.Load(@"D:\tags2.xml").Element("root")?.Elements("Tag") ??
                           throw new InvalidOperationException());
            var xTags = new XDocument();
            var xRoot = new XElement("root");
            xTags.Add(xRoot);

            var count = 0;
            if (tags != null)
                foreach (var tag in tags)
                {
                    xRoot.Add(tag);
                    count++;
                }
            xTags.Save(@"D:\CombinedTags.xml");

            Console.WriteLine($"{count} tags combined");
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
