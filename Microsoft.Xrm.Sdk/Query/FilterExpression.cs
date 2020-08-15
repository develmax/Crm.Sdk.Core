using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Specifies complex condition and logical filter expressions used for filtering the results of the query.</summary>
    [DataContract(Name = "FilterExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class FilterExpression : IExtensibleDataObject
    {
        private LogicalOperator _filterOperator;
        private DataCollection<ConditionExpression> _conditions;
        private DataCollection<FilterExpression> _filters;
        private bool _isQuickFindFilter;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.FilterExpression"></see> class.</summary>
        public FilterExpression()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.FilterExpression"></see> class.</summary>
        /// <param name="filterOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.LogicalOperator"></see>. The filter operator.</param>
        public FilterExpression(LogicalOperator filterOperator)
        {
            this.FilterOperator = filterOperator;
        }

        /// <summary>Gets or sets the logical AND/OR filter operator.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.LogicalOperator"></see>The filter operator.</returns>
        [DataMember]
        public LogicalOperator FilterOperator
        {
            get
            {
                return this._filterOperator;
            }
            set
            {
                this._filterOperator = value;
            }
        }

        /// <summary>Gets condition expressions that include attributes, condition operators, and attribute values.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see>&gt;
        /// The collection of condition expressions. </returns>
        [DataMember]
        public DataCollection<ConditionExpression> Conditions
        {
            get
            {
                if (this._conditions == null)
                    this._conditions = new DataCollection<ConditionExpression>();
                return this._conditions;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set
            {
                this._conditions = value;
            }
        }

        /// <summary>Gets a collection of condition and logical filter expressions that filter the results of the query.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.Query.FilterExpression"></see>&gt;The collection of filters.</returns>
        [DataMember]
        public DataCollection<FilterExpression> Filters
        {
            get
            {
                if (this._filters == null)
                    this._filters = new DataCollection<FilterExpression>();
                return this._filters;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set
            {
                this._filters = value;
            }
        }

        /// <summary>Gets or sets whether the expression is part of a quick find query.</summary>
        /// <returns>Type: Returns_Booleantrue if the filter is part of a quick find query; otherwise, false.</returns>
        [DataMember(EmitDefaultValue = false, Order = 51)]
        public bool IsQuickFindFilter
        {
            get
            {
                return this._isQuickFindFilter;
            }
            set
            {
                this._isQuickFindFilter = value;
            }
        }

        /// <summary>Adds a condition to the filter expression setting the attribute name, condition operator, and value array.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>. The enumeration type.</param>
        /// <param name="attributeName">Type: Returns_String. The name of the attribute.</param>
        /// <param name="values">Type: Returns_Object[]. The array of values to add.</param>
        public void AddCondition(
          string attributeName,
          ConditionOperator conditionOperator,
          params object[] values)
        {
            this.Conditions.Add(new ConditionExpression(attributeName, conditionOperator, values));
        }

        /// <summary>Adds a condition to the filter expression setting the entity name, attribute name, condition operator, and value array.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionOperator"></see>. The enumeration type.</param>
        /// <param name="attributeName">Type: Returns_String. The name of the attribute.</param>
        /// <param name="entityName">Type: Returns_String. The name of the entity.</param>
        /// <param name="values">Type: Returns_Object[]. The array of values to add.</param>
        public void AddCondition(
          string entityName,
          string attributeName,
          ConditionOperator conditionOperator,
          params object[] values)
        {
            this.Conditions.Add(new ConditionExpression(entityName, attributeName, conditionOperator, values));
        }

        /// <summary>Adds a condition to the filter expression setting the condition expression.</summary>
        /// <param name="condition">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ConditionExpression"></see>. Specifies the condition expression to be added.</param>
        public void AddCondition(ConditionExpression condition)
        {
            this.Conditions.Add(condition);
        }

        /// <summary>Adds a child filter to the filter expression setting the logical operator.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.FilterExpression"></see>
        /// The new filter expression.</returns>
        /// <param name="logicalOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.LogicalOperator"></see>. The enumeration type.</param>
        public FilterExpression AddFilter(LogicalOperator logicalOperator)
        {
            FilterExpression filterExpression = new FilterExpression();
            filterExpression.FilterOperator = logicalOperator;
            this.Filters.Add(filterExpression);
            return filterExpression;
        }

        /// <summary>Adds a child filter to the filter expression.</summary>
        /// <param name="childFilter">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.FilterExpression"></see>. The filter to be added.</param>
        public void AddFilter(FilterExpression childFilter)
        {
            if (childFilter == null)
                return;
            this.Filters.Add(childFilter);
        }

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