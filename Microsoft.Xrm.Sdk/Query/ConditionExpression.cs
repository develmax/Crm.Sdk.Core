using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Contains a condition expression used to filter the results of the query.</summary>
    [DataContract(Name = "ConditionExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class ConditionExpression : IExtensibleDataObject
    {
        private string _attributeName;
        private ConditionOperator _conditionOperator;
        private DataCollection<object> _values;
        private string _entityName;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see> class.</summary>
        public ConditionExpression()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see> class setting the attribute name, condition operator and an array of value objects.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>. The condition operator.</param>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute in the condition expression.</param>
        /// <param name="values">Type: Returns_Object[]. The array of attribute values.</param>
        public ConditionExpression(
          string attributeName,
          ConditionOperator conditionOperator,
          params object[] values)
          : this((string)null, attributeName, conditionOperator, values)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see> class.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>. The condition operator.</param>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute in the condition expression.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity in the condition expression.</param>
        /// <param name="values">Type: Returns_Object[]. The array of attribute values.</param>
        public ConditionExpression(
          string entityName,
          string attributeName,
          ConditionOperator conditionOperator,
          params object[] values)
        {
            this._entityName = entityName;
            this._attributeName = attributeName;
            this._conditionOperator = conditionOperator;
            if (values == null)
                return;
            this._values = new DataCollection<object>((IList<object>)values);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see> class setting the attribute name, condition operator and value object.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>. The condition operator.</param>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute in the condition expression.</param>
        /// <param name="value">Type: Returns_Object. The attribute value.</param>
        public ConditionExpression(
          string attributeName,
          ConditionOperator conditionOperator,
          object value)
          : this(attributeName, conditionOperator, new object[1]
          {
        value
          })
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see> class.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>. The condition operator.</param>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute in the condition expression.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity in the condition expression.</param>
        /// <param name="value">Type: Returns_Object. The attribute value.</param>
        public ConditionExpression(
          string entityName,
          string attributeName,
          ConditionOperator conditionOperator,
          object value)
          : this(entityName, attributeName, conditionOperator, new object[1]
          {
        value
          })
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see> class setting the attribute name and condition operator.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>. The condition operator.</param>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute in the condition expression.</param>
        public ConditionExpression(string attributeName, ConditionOperator conditionOperator)
          : this((string)null, attributeName, conditionOperator, new object[0])
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see> class.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>. The condition operator.</param>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute in the condition expression.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity in the condition expression.</param>
        public ConditionExpression(
          string entityName,
          string attributeName,
          ConditionOperator conditionOperator)
          : this(entityName, attributeName, conditionOperator, new object[0])
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see> class setting the attribute name, condition operator and a collection of values.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>. The condition operator.</param>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute in the condition expression.</param>
        /// <param name="values">Type: Returns_ICollection. The collection of attribute values.</param>
        public ConditionExpression(
          string attributeName,
          ConditionOperator conditionOperator,
          ICollection values)
        {
            this._attributeName = attributeName;
            this._conditionOperator = conditionOperator;
            if (values == null)
                return;
            this._values = new DataCollection<object>();
            foreach (object obj in (IEnumerable)values)
                this._values.Add(obj);
        }

        /// <summary>Gets or sets the entity name for the condition.</summary>
        /// <returns>Type: Returns_StringThe name of the entity.</returns>
        [DataMember(Order = 60)]
        public string EntityName
        {
            get
            {
                return this._entityName;
            }
            set
            {
                this._entityName = value;
            }
        }

        /// <summary>Gets or sets the logical name of the attribute in the condition expression.</summary>
        /// <returns>Type: Returns_String
        /// The logical name of the attribute in the condition expression.</returns>
        [DataMember]
        public string AttributeName
        {
            get
            {
                return this._attributeName;
            }
            set
            {
                this._attributeName = value;
            }
        }

        /// <summary>Gets or sets the condition operator.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>
        /// The condition operator.</returns>
        [DataMember]
        public ConditionOperator Operator
        {
            get
            {
                return this._conditionOperator;
            }
            set
            {
                this._conditionOperator = value;
            }
        }

        /// <summary>Gets or sets the values for the attribute.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;Returns_Object&gt;The attribute values.</returns>
        [DataMember]
        public DataCollection<object> Values
        {
            get
            {
                if (this._values == null)
                    this._values = new DataCollection<object>();
                return this._values;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set
            {
                this._values = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void Accept(IQueryVisitor visitor)
        {
            visitor.Visit(this);
        }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return this._extensionDataObject;
            }
            set
            {
                this._extensionDataObject = value;
            }
        }
    }
}
