// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.TemplateGenerationTypeCode
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

namespace Microsoft.Crm.Sdk
{
  /// <summary>Contains integer values that are used for the Template.GenerationTypeCode attribute.</summary>
  public static class TemplateGenerationTypeCode
  {
    /// <summary>Bulk duplicate detection has completed. Value = 1.</summary>
    public const int BulkDupDetectCompleted = 1;
    /// <summary>Bulk delete has completed. Value = 2.</summary>
    public const int BulkDeleteCompleted = 2;
    /// <summary>Bulk delete has completed, but failures occurred. Value = 3.</summary>
    public const int BulkDeleteCompletedWithFailures = 3;
    /// <summary>Bulk delete failed. Value = 4.</summary>
    public const int BulkDeleteFailed = 4;
    /// <summary>Import has completed. Value = 5.</summary>
    public const int ImportCompleted = 5;
    /// <summary>Import has failed. Value = 6.</summary>
    public const int ImportFailed = 6;
  }
}
