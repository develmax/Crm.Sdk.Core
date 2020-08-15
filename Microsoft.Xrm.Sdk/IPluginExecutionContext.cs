namespace Microsoft.Xrm.Sdk
{
  /// <summary>Defines the contextual information passed to a plug-in at run-time. Contains information that describes the run-time environment that the plug-in is executing in, information related to the execution pipeline, and entity business information.</summary>
  public interface IPluginExecutionContext : IExecutionContext
  {
    /// <summary>Gets the stage in the execution pipeline that a synchronous plug-in is registered for. </summary>
    /// <returns>Type: Returns_Int32.  Valid values are 10 (pre-validation), 20 (pre-operation), 40 (post-operation), and 50 (post-operation, deprecated).</returns>
    int Stage { get; }

    /// <summary>Gets the execution context from the parent pipeline operation.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.IPluginExecutionContext"></see>The execution context from the parent pipeline operation.</returns>
    IPluginExecutionContext ParentContext { get; }
  }
}
