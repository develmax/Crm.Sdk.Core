using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Crm.Data
{
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "", MessageId = "")]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "", MessageId = "")]
    public class PropertyBagCollection : SortedDictionary<object, PropertyBag>
    {
        public static bool IsNullOrEmpty(PropertyBagCollection collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}