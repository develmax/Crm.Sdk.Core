using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to import a solution. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ImportSolutionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets whether any unmanaged customizations that have been applied over existing managed solution components should be overwritten. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the any unmanaged customizations that have been applied over existing managed solution components should be overwritten; otherwise, false.</returns>
    public bool OverwriteUnmanagedCustomizations
    {
      get
      {
        return this.Parameters.Contains(nameof (OverwriteUnmanagedCustomizations)) && (bool) this.Parameters[nameof (OverwriteUnmanagedCustomizations)];
      }
      set
      {
        this.Parameters[nameof (OverwriteUnmanagedCustomizations)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether any processes (workflows) included in the solution should be activated after they are imported. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the any processes (workflows) included in the solution should be activated after they are imported; otherwise, false.</returns>
    public bool PublishWorkflows
    {
      get
      {
        return this.Parameters.Contains(nameof (PublishWorkflows)) && (bool) this.Parameters[nameof (PublishWorkflows)];
      }
      set
      {
        this.Parameters[nameof (PublishWorkflows)] = (object) value;
      }
    }

    /// <summary>Gets or sets the compressed solutions file to import. Required.</summary>
    /// <returns>Type: Returns_Byte[]The compressed solutions file to import. Required.</returns>
    public byte[] CustomizationFile
    {
      get
      {
        return this.Parameters.Contains(nameof (CustomizationFile)) ? (byte[]) this.Parameters[nameof (CustomizationFile)] : (byte[]) null;
      }
      set
      {
        this.Parameters[nameof (CustomizationFile)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the import job that will be created to perform this import. Required.</summary>
    /// <returns>Type: Returns_GuidThe the ID of the import job that will be created to perform this import. This corresponds to the ImportJob.ImportJobId attribute, which is the primary key for the ImportJob entity.</returns>
    public Guid ImportJobId
    {
      get
      {
        return this.Parameters.Contains(nameof (ImportJobId)) ? (Guid) this.Parameters[nameof (ImportJobId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ImportJobId)] = (object) value;
      }
    }

    /// <summary>Direct the system to convert any matching unmanaged customizations into your managed solution. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the system should convert any matching unmanaged customizations into your managed solution; otherwise, false.</returns>
    public bool ConvertToManaged
    {
      get
      {
        return this.Parameters.Contains(nameof (ConvertToManaged)) && (bool) this.Parameters[nameof (ConvertToManaged)];
      }
      set
      {
        this.Parameters[nameof (ConvertToManaged)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether enforcement of dependencies related to product updates should be skipped.</summary>
    /// <returns>Type: Returns_Booleantrue if enforcement of dependencies related to product updates should be skipped; otherwise, false.</returns>
    public bool SkipProductUpdateDependencies
    {
      get
      {
        return this.Parameters.Contains(nameof (SkipProductUpdateDependencies)) && (bool) this.Parameters[nameof (SkipProductUpdateDependencies)];
      }
      set
      {
        this.Parameters[nameof (SkipProductUpdateDependencies)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ImportSolutionRequest"></see> class</summary>
    public ImportSolutionRequest()
    {
      this.RequestName = "ImportSolution";
      this.OverwriteUnmanagedCustomizations = false;
      this.PublishWorkflows = false;
      this.CustomizationFile = (byte[]) null;
      this.ImportJobId = new Guid();
    }
  }
}
