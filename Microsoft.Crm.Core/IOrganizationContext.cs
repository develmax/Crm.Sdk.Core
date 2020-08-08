using System;

namespace Microsoft.Crm
{
    public interface IOrganizationContext
    {
        Guid OrganizationId { get; }
    }
}