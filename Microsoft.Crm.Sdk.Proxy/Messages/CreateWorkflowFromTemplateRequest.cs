// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CreateWorkflowFromTemplateRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a workflow (process) from a workflow template.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CreateWorkflowFromTemplateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the new workflow. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the new workflow.</returns>
    public string WorkflowName
    {
      get
      {
        return this.Parameters.Contains(nameof (WorkflowName)) ? (string) this.Parameters[nameof (WorkflowName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (WorkflowName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the workflow template. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the workflow template.</returns>
    public Guid WorkflowTemplateId
    {
      get
      {
        return this.Parameters.Contains(nameof (WorkflowTemplateId)) ? (Guid) this.Parameters[nameof (WorkflowTemplateId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (WorkflowTemplateId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the CreateWorkflowFromTemplateRequest class.</summary>
    public CreateWorkflowFromTemplateRequest()
    {
      this.RequestName = "CreateWorkflowFromTemplate";
      this.WorkflowName = (string) null;
      this.WorkflowTemplateId = new Guid();
    }
  }
}
