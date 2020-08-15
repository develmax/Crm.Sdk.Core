using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Base interface that defines the contextual information passed to a plug-in or custom workflow activity at run-time.</summary>
  public interface IExecutionContext
  {
    /// <summary>Gets the mode of plug-in execution.</summary>
    /// <returns>Type: Returns_Int32The mode of plug-in execution.</returns>
    int Mode { get; }

    /// <summary>Gets a value indicating if the plug-in is executing in the sandbox.</summary>
    /// <returns>Type: Returns_Int32Indicates if the plug-in is executing in the sandbox. </returns>
    int IsolationMode { get; }

    /// <summary>Gets the current depth of execution in the call stack.</summary>
    /// <returns>Type: Returns_Int32T the current depth of execution in the call stack.</returns>
    int Depth { get; }

    /// <summary>Gets the name of the Web service message that is being processed by the event execution pipeline.</summary>
    /// <returns>Type: Returns_StringThe name of the Web service message being processed by the event execution pipeline.</returns>
    string MessageName { get; }

    /// <summary>Gets the name of the primary entity for which the pipeline is processing events.</summary>
    /// <returns>Type: Returns_StringThe name of the primary entity for which the pipeline is processing events.</returns>
    string PrimaryEntityName { get; }

    /// <summary>Gets the GUID of the request being processed by the event execution pipeline.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_Guid&gt;The GUID of the request being processed by the event execution pipeline. This corresponds to the <see cref="P:Microsoft.Xrm.Sdk.OrganizationRequest.RequestId"></see> property, which is the primary key for the <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see> class from which specialized request classes are derived.</returns>
    Guid? RequestId { get; }

    /// <summary>Gets the name of the secondary entity that has a relationship with the primary entity.</summary>
    /// <returns>Type: Returns_StringThe name of the secondary entity that has a relationship with the primary entity.</returns>
    string SecondaryEntityName { get; }

    /// <summary>Gets the parameters of the request message that triggered the event that caused the plug-in to execute.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ParameterCollection"></see>The parameters of the request message that triggered the event that caused the plug-in to execute.</returns>
    ParameterCollection InputParameters { get; }

    /// <summary>Gets the parameters of the response message after the core platform operation has completed.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ParameterCollection"></see>The parameters of the response message after the core platform operation has completed.</returns>
    ParameterCollection OutputParameters { get; }

    /// <summary>Gets the custom properties that are shared between plug-ins.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ParameterCollection"></see>The custom properties that are shared between plug-ins.</returns>
    ParameterCollection SharedVariables { get; }

    /// <summary>Gets the GUID of the system user for whom the plug-in invokes web service methods on behalf of.</summary>
    /// <returns>Type: Returns_GuidThe GUID of the system user for whom the plug-in invokes web service methods on behalf of. This property corresponds to the SystemUserId property, which is the primary key for the SystemUser entity.</returns>
    Guid UserId { get; }

    /// <summary>Gets the GUID of the system user account under which the current pipeline is executing.</summary>
    /// <returns>Type: Returns_GuidThe GUID of the system user account under which the current pipeline is executing. This property corresponds to the SystemUserId property, which is the primary key for the SystemUser entity.</returns>
    Guid InitiatingUserId { get; }

    /// <summary>Gets the GUIDGUID of the business unit that the user making the request, also known as the calling user, belongs to.</summary>
    /// <returns>Type: Returns_GuidThe GUID of the business unit. This property corresponds to the BusinessUnitId property, which is the primary key for the BusinessUnit entity.</returns>
    Guid BusinessUnitId { get; }

    /// <summary>Gets the GUID of the organization that the entity belongs to and the plug-in executes under.</summary>
    /// <returns>Type: Returns_GuidThe GUID of the organization that the entity belongs to and the plug-in executes under. This corresponds to the OrganizationId attribute, which is the primary key for the Organization entity.</returns>
    Guid OrganizationId { get; }

    /// <summary>Gets the unique name of the organization that the entity currently being processed belongs to and the plug-in executes under.</summary>
    /// <returns>Type: Returns_StringThe unique name of the organization that the entity currently being processed belongs to and the plug-in executes under.</returns>
    string OrganizationName { get; }

    /// <summary>Gets the GUID of the primary entity for which the pipeline is processing events.</summary>
    /// <returns>Type: Returns_GuidThe GUID of the primary entity for which the pipeline is processing events. For example, if the event pipeline is processing an account, this corresponds to the AccountId attribute, which is the primary key for the Account entity.</returns>
    Guid PrimaryEntityId { get; }

    /// <summary>Gets the properties of the primary entity before the core platform operation has begins.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityImageCollection"></see>The properties of the primary entity before the core platform operation has begins.</returns>
    EntityImageCollection PreEntityImages { get; }

    /// <summary>Gets the properties of the primary entity after the core platform operation has been completed.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityImageCollection"></see>The properties of the primary entity after the core platform operation has been completed.</returns>
    EntityImageCollection PostEntityImages { get; }

    /// <summary>Gets a reference to the related SdkMessageProcessingingStep or ServiceEndpoint.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>A reference to the related SdkMessageProcessingingStep or ServiceEndpoint.entity.</returns>
    EntityReference OwningExtension { get; }

    /// <summary>Gets the GUID for tracking plug-in or custom workflow activity execution. </summary>
    /// <returns>Type: Returns_GuidThe GUID for tracking plug-in or custom workflow activity execution.</returns>
    Guid CorrelationId { get; }

    /// <summary>Gets whether the plug-in is executing from the pn_crm_outlook_offline_access client while it is offline. </summary>
    /// <returns>Type: Returns_Booleantrue if the plug-in is executing from the pn_crm_outlook_offline_access client while it is offline; otherwise, false.</returns>
    bool IsExecutingOffline { get; }

    /// <summary>Gets a value indicating if the plug-in is executing as a result of the pn_crm_outlook_offline_access client transitioning from offline to online and synchronizing with the pn_microsoftcrm server.</summary>
    /// <returns>Type: Returns_Booleantrue if the the plug-in is executing as a result of the pn_crm_outlook_offline_access client transitioning from offline to online; otherwise, false.</returns>
    bool IsOfflinePlayback { get; }

    /// <summary>Gets a value indicating if the plug-in is executing within the database transaction.</summary>
    /// <returns>Type: Returns_Booleantrue if the plug-in is executing within the database transaction; otherwise, false.</returns>
    bool IsInTransaction { get; }

    /// <summary>Gets the GUID of the related System Job.</summary>
    /// <returns>Type: Returns_GuidThe GUID of the related System Job. This corresponds to the AsyncOperationId attribute, which is the primary key for the System Job entity.</returns>
    Guid OperationId { get; }

    /// <summary>Gets the date and time that the related System Job was created.</summary>
    /// <returns>Type: Returns_DateTimeThe date and time that the related System Job was created.</returns>
    DateTime OperationCreatedOn { get; }
  }
}
