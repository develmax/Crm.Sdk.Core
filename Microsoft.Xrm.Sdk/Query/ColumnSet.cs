using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Specifies the attributes for which non-null values are returned from a query.</summary>
    [DataContract(Name = "ColumnSet", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class ColumnSet : IExtensibleDataObject
    {
        private bool _allColumns;
        private DataCollection<string> _columns;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see> class.</summary>
        public ColumnSet()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see> class setting the <see cref="P:Microsoft.Xrm.Sdk.Query.ColumnSet.AllColumns"></see> property.</summary>
        /// <param name="allColumns">Type: Returns_Boolean. A Boolean that specifies whether to retrieve all attributes of a record.</param>
        public ColumnSet(bool allColumns)
        {
            this._allColumns = allColumns;
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see> class setting the <see cref="P:Microsoft.Xrm.Sdk.Query.ColumnSet.Columns"></see> property.</summary>
        /// <param name="columns">Type: Returns_String[]. Specifies an array of Strings containing the names of the attributes.</param>
        public ColumnSet(params string[] columns)
        {
            this._columns = new DataCollection<string>((IList<string>)columns);
        }

        /// <summary>Adds the specified attribute to the column set.</summary>
        /// <param name="columns">Type: Returns_String[]. Specifies an array of Strings containing the names of the attributes.</param>
        public void AddColumns(params string[] columns)
        {
            foreach (string column in columns)
                this.Columns.Add(column);
        }

        /// <summary>Adds the specified attribute to the column set.</summary>
        /// <param name="column">Type: Returns_String. Specifies a String containing the name of the attribute.</param>
        public void AddColumn(string column)
        {
            this.Columns.Add(column);
        }

        /// <summary>Gets or sets whether to retrieve all the attributes of a record.</summary>
        /// <returns>Type: Returns_Booleantrue to specify to retrieve all attributes; false to to retrieve only specified attributes.</returns>
        [DataMember]
        public bool AllColumns
        {
            get
            {
                return this._allColumns;
            }
            set
            {
                this._allColumns = value;
            }
        }

        /// <summary>Gets the collection of Strings containing the names of the attributes to be retrieved from a query.</summary>
        /// <returns>Type: Returns_ICollection_Generic
        /// The collection of attribute names to return from a query.</returns>
        [DataMember]
        public DataCollection<string> Columns
        {
            get
            {
                if (this._columns == null)
                    this._columns = new DataCollection<string>();
                return this._columns;
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
