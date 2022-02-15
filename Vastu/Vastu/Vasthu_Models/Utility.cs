using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vasthu_Models
{
    public class Utility
    {
		public static string CreateXML(object ClassObject)
		{
			string empty = string.Empty;
			XmlSerializer xmlSerializer = new XmlSerializer(ClassObject.GetType());
			using (MemoryStream memoryStream = new MemoryStream())
			{
				xmlSerializer.Serialize(memoryStream, ClassObject);
				memoryStream.Position = (long)0;
				empty = (new StreamReader(memoryStream)).ReadToEnd();
			}
			return empty;
		}
	}
}
