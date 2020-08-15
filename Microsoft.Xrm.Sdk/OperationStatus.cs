﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.OperationStatus
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Represents the current state of an operation.</summary>
  public enum OperationStatus
  {
    /// <summary>The operation has failed. Value = 0.</summary>
    Failed,
    /// <summary>The operation has been canceled. Value = 1.</summary>
    Canceled,
    /// <summary>The operation is being retried. Value = 2.</summary>
    Retry,
    /// <summary>The operation has been suspended. Value = 3.</summary>
    Suspended,
    /// <summary>The operation has succeeded. Value = 4.</summary>
    Succeeded,
  }
}
