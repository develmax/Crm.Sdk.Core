
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Microsoft.Crm
{
    [SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Justification = "BASELINE: BackLog, [tobinz]: Base line for new rules.", MessageId = "")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "BASELINE: BackLog", MessageId = "Util")]
    public class SharedUtil
    {
        protected SharedUtil()
        {
        }

        public static XmlReader CreateXmlReader(string xml)
        {
            return SharedUtil.CreateXmlReader(xml, false);
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "StringReader required for life of XmlReader")]
        public static XmlReader CreateXmlReader(string xml, bool preserveWhiteSpace)
        {
            return XmlReader.Create((TextReader)new StringReader(xml), new XmlReaderSettings()
            {
                IgnoreWhitespace = !preserveWhiteSpace
            });
        }

        public static XmlReader CreateXmlReader(Stream xmlStream)
        {
            return XmlReader.Create(xmlStream, new XmlReaderSettings()
            {
                IgnoreWhitespace = true
            });
        }

        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", Justification = "BASELINE: BackLog", MessageId = "System.Xml.XmlNode")]
        public static XmlDocument CreateXmlDocument()
        {
            return new XmlDocument()
            {
                XmlResolver = (XmlResolver)null
            };
        }

        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", Justification = "BASELINE: BackLog", MessageId = "System.Xml.XmlNode")]
        public static XmlDocument CreateXmlDocument(XmlReader reader)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.XmlResolver = (XmlResolver)null;
            xmlDocument.Load(reader);
            reader.Close();
            return xmlDocument;
        }

        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", Justification = "BASELINE: BackLog", MessageId = "System.Xml.XmlNode")]
        public static XmlDocument CreateXmlDocument(Stream input)
        {
            using (XmlReader reader = XmlReader.Create(input, new XmlReaderSettings()
            {
                IgnoreWhitespace = true
            }))
                return SharedUtil.CreateXmlDocument(reader);
        }

        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", Justification = "BASELINE: BackLog", MessageId = "System.Xml.XmlNode")]
        public static XmlDocument CreateXmlDocument(string xml)
        {
            switch (xml)
            {
                case "":
                case null:
                    return new XmlDocument()
                    {
                        XmlResolver = (XmlResolver)null
                    };
                default:
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.IgnoreWhitespace = true;
                    using (StringReader stringReader = new StringReader(xml))
                    {
                        using (XmlReader reader = XmlReader.Create((TextReader)stringReader, settings))
                            return SharedUtil.CreateXmlDocument(reader);
                    }
            }
        }

        [SuppressMessage("Microsoft.Security", "CA9876:AvoidLoadXmlUsage", Justification = "The xmlDocument is created using the wrapper library. So it is safe.")]
        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", Justification = "BASELINE: BackLog", MessageId = "System.Xml.XmlNode")]
        public static XmlDocument CreateXmlDocument(string xml, bool preserveWhiteSpace)
        {
            XmlDocument xmlDocument = SharedUtil.CreateXmlDocument();
            if (string.IsNullOrEmpty(xml))
                return xmlDocument;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = !preserveWhiteSpace;
            xmlDocument.PreserveWhitespace = preserveWhiteSpace;
            using (StringReader stringReader = new StringReader(xml))
            {
                using (XmlReader reader = XmlReader.Create((TextReader)stringReader, settings))
                    xmlDocument.Load(reader);
            }
            return xmlDocument;
        }

        [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Already disposing object correctly", MessageId = "")]
        public static IEnumerable<XElement> GetXElementsByNodeName(
          string xml,
          string nodeName)
        {
            using (XmlReader reader = XmlReader.Create((TextReader)new StringReader(xml)))
            {
                int content = (int)reader.MoveToContent();
                while (!reader.EOF)
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == nodeName)
                    {
                        XElement element = XNode.ReadFrom(reader) as XElement;
                        yield return element;
                    }
                    else
                        reader.Read();
                }
                reader.Close();
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", Justification = "BASELINE: BackLog", MessageId = "System.Xml.XmlNode")]
        public static XmlDocument LoadXmlDocumentFromFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                return SharedUtil.CreateXmlDocument((Stream)fileStream);
        }

        public static string ReadXmlFromStream(Stream input)
        {
            XmlReader xmlReader = XmlReader.Create(input, new XmlReaderSettings()
            {
                IgnoreWhitespace = true
            });
            int content = (int)xmlReader.MoveToContent();
            return xmlReader.ReadOuterXml();
        }

        public static T XmlFileToObject<T>(string fileName)
        {
            return SharedUtil.XmlStringToObject<T>(SharedUtil.LoadXmlDocumentFromFile(fileName).OuterXml);
        }

        public static T XmlStringToObject<T>(string xml)
        {
            using (MemoryStream memoryStream = new MemoryStream(new UTF8Encoding().GetBytes(xml)))
                return (T)new XmlSerializer(typeof(T)).Deserialize((Stream)memoryStream);
        }

        public static string XmlObjectToString<T>(T xmlObject)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.OmitXmlDeclaration = true;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create((Stream)memoryStream, settings))
                {
                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    namespaces.Add(string.Empty, string.Empty);
                    xmlSerializer.Serialize(xmlWriter, (object)xmlObject, namespaces);
                    return new UTF8Encoding().GetString(memoryStream.ToArray());
                }
            }
        }

        public static XmlWriter CreateXmlWriter(TextWriter textWriter, bool indented)
        {
            return XmlWriter.Create(textWriter, new XmlWriterSettings()
            {
                Encoding = Encoding.UTF8,
                Indent = indented,
                OmitXmlDeclaration = true
            });
        }

        public static XmlWriter CreateXmlWriter(
          string fileName,
          Encoding encoding,
          bool indented)
        {
            return XmlWriter.Create(fileName, new XmlWriterSettings()
            {
                Encoding = encoding,
                Indent = indented,
                OmitXmlDeclaration = true
            });
        }

        public static XmlNodeType GetFirstXmlNodeType(string xml)
        {
            using (XmlReader xmlReader = SharedUtil.CreateXmlReader(xml))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType != XmlNodeType.Comment)
                        return xmlReader.NodeType;
                }
            }
            return XmlNodeType.None;
        }
    }
}
