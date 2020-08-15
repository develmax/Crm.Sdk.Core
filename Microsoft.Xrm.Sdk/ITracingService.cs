namespace Microsoft.Xrm.Sdk
{
  /// <summary>Provides a method of logging run-time trace information for plug-ins.</summary>
  public interface ITracingService
  {
    /// <summary>Logs trace information.</summary>
    /// <param name="format">Type: Returns_String. Information to be logged.</param>
    /// <param name="args">Type: Returns_Object[]. Not documented at this time.</param>
    void Trace(string format, params object[] args);
  }
}
