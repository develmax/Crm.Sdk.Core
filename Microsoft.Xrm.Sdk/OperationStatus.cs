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
