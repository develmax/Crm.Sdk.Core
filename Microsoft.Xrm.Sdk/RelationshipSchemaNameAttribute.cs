using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Used by the code generation tool to create classes based on entities.</summary>
  [AttributeUsage(AttributeTargets.Property)]
  [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "Nullable arguments cause issues for compiler.")]
  public sealed class RelationshipSchemaNameAttribute : Attribute
  {
    private readonly Relationship _relationship;

    /// <summary>Gets the schema name for the entity relationship.</summary>
    /// <returns>Type: Returns_String
    /// The schema name for the entity relationship.</returns>
    public string SchemaName
    {
      get
      {
        return this._relationship.SchemaName;
      }
    }

    /// <summary>Gets the entity role for the entity.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityRole"></see>The entity role for the entity.</returns>
    public EntityRole? PrimaryEntityRole
    {
      get
      {
        return this._relationship.PrimaryEntityRole;
      }
    }

    internal Relationship Relationship
    {
      get
      {
        return this._relationship;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute"></see> class</summary>
    /// <param name="schemaName">Type: Returns_String
    /// The schema name for the entity relationship.</param>
    public RelationshipSchemaNameAttribute(string schemaName)
      : this(schemaName, new EntityRole?())
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute"></see> class</summary>
    /// <param name="primaryEntityRole">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityRole"></see>The entity role for the entity.</param>
    /// <param name="schemaName">Type: Returns_String
    /// The schema name for the entity relationship.</param>
    public RelationshipSchemaNameAttribute(string schemaName, EntityRole primaryEntityRole)
      : this(schemaName, new EntityRole?(primaryEntityRole))
    {
    }

    private RelationshipSchemaNameAttribute(string schemaName, EntityRole? primaryEntityRole)
    {
      if (string.IsNullOrWhiteSpace(schemaName))
        throw new ArgumentNullException(nameof (schemaName));
      this._relationship = new Relationship(schemaName);
      this._relationship.PrimaryEntityRole = primaryEntityRole;
    }
  }
}
