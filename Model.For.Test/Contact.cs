using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Linq;

namespace Model.For.Test
{
	[System.Runtime.Serialization.DataContract()]
	[EntityLogicalName(Contact.EntityLogicalName)]

	public class Contact: Entity
	{
		public Contact() : base(EntityLogicalName) { }
		public const string EntityLogicalName = "contact";

		[AttributeLogicalName("firstname")]
		public string FirstName
		{
			get => GetAttributeValue<string>("firstname");
			set => SetAttributeValue("firstname", value);
		}

		[AttributeLogicalName("lastname")]
		public string LastName
		{
			get => GetAttributeValue<string>("lastname");
			set => SetAttributeValue("lastname", value);
		}

		[AttributeLogicalName("ownerid")]
		public EntityReference OwnerId
		{
			get => GetAttributeValue<EntityReference>("ownerid");
			set => SetAttributeValue("ownerid", value);
		}
	}

	[System.Runtime.Serialization.DataContract()]
	[EntityLogicalName(SystemUser.EntityLogicalName)]

	public class SystemUser: Entity
	{
		public SystemUser() : base(EntityLogicalName) { }
		public const string EntityLogicalName = "systemuser";

		[AttributeLogicalName("systemuserid")]
		public EntityReference SystemUserId
		{
			get => GetAttributeValue<EntityReference>("systemuserid");
			set => SetAttributeValue("systemuserid", value);
		}

		[AttributeLogicalName("firstname")]
		public string FirstName
		{
			get => GetAttributeValue<string>("firstname");
			set => SetAttributeValue("firstname", value);
		}
	}
}
