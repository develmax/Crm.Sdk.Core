using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal static class PagingCookieHelper
  {
    public static object[] ToContinuationToken(string pagingCookie, int pageNumber)
    {
      return PagingCookieHelper.Deserialize(pagingCookie, pageNumber).ToArray();
    }

    public static string ToPagingCookie(object[] continuationToken, out int pageNumber)
    {
      return PagingCookieHelper.Serialize(continuationToken, out pageNumber);
    }

    private static List<object> Deserialize(string pagingCookie, int pageNumber)
    {
      ClientExceptionHelper.ThrowIfNegative(pageNumber, nameof (pageNumber));
      List<object> objectList = new List<object>();
      try
      {
        using (XmlReader xmlReader = PagingCookieHelper.CreateXmlReader(pagingCookie))
        {
          xmlReader.Read();
          objectList.Add((object) pageNumber);
          string attribute1 = xmlReader.GetAttribute("parentEntityId");
          if (!string.IsNullOrEmpty(attribute1))
          {
            objectList.Add((object) new Guid(attribute1));
            string attribute2 = xmlReader.GetAttribute("parentAttributeName");
            ClientExceptionHelper.ThrowIfNullOrEmpty(attribute2, "parentAttributeName");
            objectList.Add((object) attribute2);
            int result = -1;
            if (int.TryParse(xmlReader.GetAttribute("parentEntityObjectTypeCode"), out result))
              objectList.Add((object) result);
            else
              ClientExceptionHelper.ThrowIfNegative(result, "parentOtc");
          }
          while (xmlReader.Read())
          {
            if (xmlReader.NodeType != XmlNodeType.EndElement)
            {
              string name = xmlReader.Name;
              ClientExceptionHelper.ThrowIfNullOrEmpty(name, "field");
              objectList.Add((object) name);
              if (xmlReader.AttributeCount != 2)
                throw new NotSupportedException("Malformed XML Passed to in the Paging Cookie. We expect at most two attributes (first/firstNull and last/lastNull)");
              string attribute2 = xmlReader.GetAttribute("last");
              if (attribute2 == null)
              {
                if (xmlReader.GetAttribute("lastnull") == null)
                  throw new NotSupportedException("Malformed XML Passed to in the Paging Cookie. Value for attribute last was not specified, and it was not null either.");
                objectList.Add((object) null);
              }
              else
                objectList.Add((object) attribute2);
              string attribute3 = xmlReader.GetAttribute("first");
              if (attribute3 == null)
              {
                if (xmlReader.GetAttribute("firstnull") == null)
                  throw new NotSupportedException("Malformed XML Passed to in the Paging Cookie. Value for attribute first was not specified, and it was not null either.");
                objectList.Add((object) null);
              }
              else
                objectList.Add((object) attribute3);
            }
          }
        }
      }
      catch (XmlException ex)
      {
        throw new NotSupportedException("Malformed XML in the Paging Cookie", (Exception) ex);
      }
      catch (FormatException ex)
      {
        throw new NotSupportedException("Malformed XML in the Paging Cookie", (Exception) ex);
      }
      return objectList;
    }

    private static string Serialize(object[] pagingElements, out int pageNumber)
    {
      pageNumber = 0;
      if (pagingElements == null || pagingElements.Length == 0)
        return (string) null;
      if (pagingElements.Length % 3 != 1)
        throw new NotSupportedException("Skip token has incorrect length");
      if (pagingElements[0] == null || !(pagingElements[0].GetType() == typeof (int)) || (int) pagingElements[0] < 0)
        throw new NotSupportedException("Skip token has incorrect page value");
      pageNumber = (int) pagingElements[0];
      using (StringWriter stringWriter = new StringWriter((IFormatProvider) CultureInfo.InvariantCulture))
      {
        using (XmlWriter xmlWriter = PagingCookieHelper.CreateXmlWriter((TextWriter) stringWriter))
        {
          xmlWriter.WriteStartElement("cookie");
          xmlWriter.WriteAttributeString("page", pageNumber.ToString((IFormatProvider) CultureInfo.InvariantCulture));
          int num = 1;
          if (pagingElements[1] != null && pagingElements[1].GetType() == typeof (Guid) && (pagingElements[2] != null && pagingElements[2].GetType() == typeof (string)) && (pagingElements[3] != null && pagingElements[3].GetType() == typeof (int)))
          {
            num = 4;
            xmlWriter.WriteAttributeString("parentEntityId", pagingElements[1].ToString());
            xmlWriter.WriteAttributeString("parentAttributeName", (string) pagingElements[2]);
            xmlWriter.WriteAttributeString("parentEntityObjectTypeCode", pagingElements[3].ToString());
          }
          for (int index = num; index < pagingElements.Length; index += 3)
          {
            string pagingElement = (string) pagingElements[index];
            ClientExceptionHelper.ThrowIfNullOrEmpty(pagingElement, "attributeName");
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string str1 = (string) pagingElements[index + 1];
            string str2 = (string) pagingElements[index + 2];
            xmlWriter.WriteStartElement(pagingElement);
            string localName1;
            if (str1 != null)
            {
              localName1 = "last";
            }
            else
            {
              localName1 = "lastnull";
              str1 = "1";
            }
            string localName2;
            if (str2 != null)
            {
              localName2 = "first";
            }
            else
            {
              localName2 = "firstnull";
              str2 = "1";
            }
            xmlWriter.WriteAttributeString(localName1, str1);
            xmlWriter.WriteAttributeString(localName2, str2);
            xmlWriter.WriteEndElement();
          }
          xmlWriter.WriteEndElement();
        }
        return stringWriter.ToString();
      }
    }

    private static XmlWriter CreateXmlWriter(TextWriter textWriter)
    {
      return XmlWriter.Create(textWriter, new XmlWriterSettings()
      {
        Encoding = Encoding.UTF8,
        OmitXmlDeclaration = true
      });
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "StringReader required for life of XmlReader")]
    private static XmlReader CreateXmlReader(string xml)
    {
      return XmlReader.Create((TextReader) new StringReader(xml), new XmlReaderSettings()
      {
        IgnoreWhitespace = true
      });
    }
  }
}
