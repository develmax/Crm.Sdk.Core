using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Defines the contextual information sent to a remote service endpoint at run-time.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [KnownType("GetKnownParameterTypes")]
  public sealed class RemoteExecutionContext : IPluginExecutionContext, IExecutionContext, IExtensibleDataObject
  {
    private int _stage;
    private int _mode;
    private int _depth;
    private int _isolationMode;
    private string _messageName;
    private string _primaryEntityName;
    private string _secondaryEntityName;
    private string _organizationName;
    private bool _isOffline;
    private bool _isOfflinePlayback;
    private bool _isInTransaction;
    private ParameterCollection _inputParameters;
    private ParameterCollection _outputParameters;
    private ParameterCollection _sharedVariables;
    private Guid _userId;
    private Guid _initiatingUserId;
    private Guid _businessUnitId;
    private Guid _organizationId;
    private Guid _correlationId;
    private Guid _primaryEntityId;
    private Guid _asyncOperationId;
    private Guid? _requestId;
    private EntityReference _owningExtension;
    private EntityImageCollection _preImages;
    private EntityImageCollection _postImages;
    private DateTime _operationCreatedOnTime;
    private RemoteExecutionContext _parentContext;
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets the stage in the execution pipeline that a synchronous plug-in is registered for. </summary>
    /// <returns>Type: Returns_Int32. Valid values are 10, 20, 40, and 50The stage in the execution pipeline that a synchronous plug-in is registered for.</returns>
    [DataMember]
    public int Stage
    {
      get
      {
        return this._stage;
      }
      set
      {
        this._stage = value;
      }
    }

    /// <summary>Gets the mode of plug-in execution.</summary>
    /// <returns>Type: Returns_Int32The mode of plug-in execution. Valid values are 0 (synchronous) and 1 (asynchronous).</returns>
    [DataMember]
    public int Mode
    {
      get
      {
        return this._mode;
      }
      set
      {
        this._mode = value;
      }
    }

    /// <summary>Gets the name of the Web service message that is being processed by the event execution pipeline.</summary>
    /// <returns>Type:  Returns_StringThe name of the Web service message.</returns>
    [DataMember]
    public string MessageName
    {
      get
      {
        return this._messageName;
      }
      set
      {
        this._messageName = value;
      }
    }

    /// <summary>Gets the name of the primary entity for which the pipeline is processing events.</summary>
    /// <returns>Type: Returns_StringThe name of the primary entity.</returns>
    [DataMember]
    public string PrimaryEntityName
    {
      get
      {
        return this._primaryEntityName;
      }
      set
      {
        this._primaryEntityName = value;
      }
    }

    /// <summary>Gets the name of the secondary entity that has a relationship with the primary entity.</summary>
    /// <returns>Type: Returns_StringThe name of the secondary entity.</returns>
    [DataMember]
    public string SecondaryEntityName
    {
      get
      {
        return this._secondaryEntityName;
      }
      set
      {
        this._secondaryEntityName = value;
      }
    }

    /// <summary>Gets the global unique identifier of the request being processed by the event execution pipeline.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_Guid&gt;The global unique identifier of the request.</returns>
    [DataMember]
    public Guid? RequestId
    {
      get
      {
        return this._requestId;
      }
      set
      {
        this._requestId = value;
      }
    }

    /// <summary>Gets the parameters of the request message that triggered the event that caused the plug-in to execute.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ParameterCollection"></see> The parameters of the request message that triggered the event.</returns>
    [DataMember]
    public ParameterCollection InputParameters
    {
      get
      {
        if (this._inputParameters == null)
          this._inputParameters = new ParameterCollection();
        return this._inputParameters;
      }
    }

    /// <summary>Gets the parameters of the response message after the core platform operation has completed.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ParameterCollection"></see>The parameters of the response message.</returns>
    [DataMember]
    public ParameterCollection OutputParameters
    {
      get
      {
        if (this._outputParameters == null)
          this._outputParameters = new ParameterCollection();
        return this._outputParameters;
      }
    }

    /// <summary>Gets the custom properties that are shared between plug-ins.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ParameterCollection"></see>The custom properties that are shared between plug-ins.</returns>
    [DataMember]
    public ParameterCollection SharedVariables
    {
      get
      {
        if (this._sharedVariables == null)
          this._sharedVariables = new ParameterCollection();
        return this._sharedVariables;
      }
    }

    /// <summary>Gets the global unique identifier of the system user for whom the plug-in invokes Web service methods on behalf of.</summary>
    /// <returns>Type: Returns_GuidThe global unique identifier of the system user.</returns>
    [DataMember]
    public Guid UserId
    {
      get
      {
        return this._userId;
      }
      set
      {
        this._userId = value;
      }
    }

    /// <summary>Gets the global unique identifier of the system user account under which the current pipeline is executing.</summary>
    /// <returns>Type: Returns_GuidThe global unique identifier of the system user account.</returns>
    [DataMember]
    public Guid InitiatingUserId
    {
      get
      {
        return this._initiatingUserId;
      }
      set
      {
        this._initiatingUserId = value;
      }
    }

    /// <summary>Gets the global unique identifier of the business unit that the entity currently being processed by the event execution pipeline belongs to.</summary>
    /// <returns>Type: Returns_GuidThe global unique identifier of the business unit.</returns>
    [DataMember]
    public Guid BusinessUnitId
    {
      get
      {
        return this._businessUnitId;
      }
      set
      {
        this._businessUnitId = value;
      }
    }

    /// <summary>Gets the global unique identifier of the organization that the entity belongs to and the plug-in executes under.</summary>
    /// <returns>Type: Returns_GuidThe global unique identifier of the organization.</returns>
    [DataMember]
    public Guid OrganizationId
    {
      get
      {
        return this._organizationId;
      }
      set
      {
        this._organizationId = value;
      }
    }

    /// <summary>Gets the unique name of the organization that the entity currently being processed belongs to and the plug-in executes under.</summary>
    /// <returns>Type: Returns_StringThe unique name of the organization.</returns>
    [DataMember]
    public string OrganizationName
    {
      get
      {
        return this._organizationName;
      }
      set
      {
        this._organizationName = value;
      }
    }

    /// <summary>Gets the properties of the primary entity before the core platform operation has begins.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityImageCollection"></see>The properties of the primary entity.</returns>
    [DataMember]
    public EntityImageCollection PreEntityImages
    {
      get
      {
        if (this._preImages == null)
          this._preImages = new EntityImageCollection();
        return this._preImages;
      }
    }

    /// <summary>Gets the properties of the primary entity after the core platform operation has been completed.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityImageCollection"></see>The properties of the primary entity.</returns>
    [DataMember]
    public EntityImageCollection PostEntityImages
    {
      get
      {
        if (this._postImages == null)
          this._postImages = new EntityImageCollection();
        return this._postImages;
      }
    }

    /// <summary>Gets the global unique identifier for tracking plug-in execution. </summary>
    /// <returns>Type: Returns_GuidThe global unique identifier for tracking plug-in execution.</returns>
    [DataMember]
    public Guid CorrelationId
    {
      get
      {
        return this._correlationId;
      }
      set
      {
        this._correlationId = value;
      }
    }

    /// <summary>Gets the current depth of execution in the call stack.</summary>
    /// <returns>Type: Returns_Int32The current depth of execution in the call stack.</returns>
    [DataMember]
    public int Depth
    {
      get
      {
        return this._depth;
      }
      set
      {
        this._depth = value;
      }
    }

    /// <summary>Gets a value indicating if the plug-in is executing from the pn_crm_outlook_offline_access client while it is offline. </summary>
    /// <returns>Type: Returns_Booleantrue if the client is offline; otherwise false.</returns>
    [DataMember]
    public bool IsExecutingOffline
    {
      get
      {
        return this._isOffline;
      }
      set
      {
        this._isOffline = value;
      }
    }

    /// <summary>Gets a value indicating if the plug-in is executing as a result of the pn_crm_outlook_offline_access client transitioning from offline to online and synchronizing with the pn_microsoftcrm server.</summary>
    /// <returns>Type: Returns_Booleantrue if the plug-in is executing as a result of the client synchronizing with the pn_microsoftcrm server; otherwise, false.</returns>
    [DataMember]
    public bool IsOfflinePlayback
    {
      get
      {
        return this._isOfflinePlayback;
      }
      set
      {
        this._isOfflinePlayback = value;
      }
    }

    /// <summary>Gets a value indicating if the plug-in is executing in the sandbox.</summary>
    /// <returns>Type: Returns_Int32A value indicating if the plug-in is executing in the sandbox. Valid values are 1 (none) or 2 (sandbox).</returns>
    [DataMember]
    public int IsolationMode
    {
      get
      {
        return this._isolationMode;
      }
      set
      {
        this._isolationMode = value;
      }
    }

    /// <summary>Gets a value indicating if the plug-in is executing within the database transaction.</summary>
    /// <returns>Type: Returns_Booleantrue if the plug-in is executing within the database transaction; otherwise, false.</returns>
    [DataMember]
    public bool IsInTransaction
    {
      get
      {
        return this._isInTransaction;
      }
      set
      {
        this._isInTransaction = value;
      }
    }

    /// <summary>Gets the global unique identifier of the related System Job.</summary>
    /// <returns>Type:  Returns_GuidThe global unique identifier of the related System Job.</returns>
    [DataMember]
    public Guid OperationId
    {
      get
      {
        return this._asyncOperationId;
      }
      set
      {
        this._asyncOperationId = value;
      }
    }

    /// <summary>Gets a reference to the related SdkMessageProcessingingStep or ServiceEndpoint.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The reference to the related SdkMessageProcessingingStep or ServiceEndpoint.</returns>
    [DataMember]
    public EntityReference OwningExtension
    {
      get
      {
        return this._owningExtension;
      }
      set
      {
        this._owningExtension = value;
      }
    }

    /// <summary>Gets the global unique identifier of the primary entity for which the pipeline is processing events.</summary>
    /// <returns>Type: Returns_GuidThe global unique identifier of the primary entity.</returns>
    [DataMember]
    public Guid PrimaryEntityId
    {
      get
      {
        return this._primaryEntityId;
      }
      set
      {
        this._primaryEntityId = value;
      }
    }

    /// <summary>Gets the date and time that the related System Job was created.</summary>
    /// <returns>Type: Returns_DateTimeThe date and time the related System Job was created.</returns>
    [DataMember]
    public DateTime OperationCreatedOn
    {
      get
      {
        return this._operationCreatedOnTime;
      }
      set
      {
        this._operationCreatedOnTime = value;
      }
    }

    /// <summary>Gets the remote execution context from the parent operation.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.RemoteExecutionContext"></see>The remote execution context from the parent operation.</returns>
    [DataMember]
    public RemoteExecutionContext ParentContext
    {
      get
      {
        return this._parentContext;
      }
      set
      {
        this._parentContext = value;
      }
    }

    IPluginExecutionContext IPluginExecutionContext.ParentContext
    {
      get
      {
        return (IPluginExecutionContext) this.ParentContext;
      }
    }

    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
    private static IEnumerable<Type> GetKnownParameterTypes()
    {
      return KnownTypesProvider.RetrieveKnownValueTypes();
    }

    /// <summary>A structure that contains extra data.</summary>
    /// <returns>Type: Returns_ExtensionDataObjectA structure that contains extra data.</returns>
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
