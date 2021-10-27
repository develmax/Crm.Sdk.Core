﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using Microsoft.Xrm.Sdk.Client;

namespace Microsoft.Xrm.Sdk.Linq
{
	internal sealed partial class QueryProvider
	{
		[SecuritySafeCritical]
		private Delegate CompileExpression(LambdaExpression expression)
		{
			try
			{
				new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
				return expression.Compile();
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}

		[SecuritySafeCritical]
		private object DynamicInvoke(Delegate project, params object[] args)
		{
			try
			{
				new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess).Assert();
				return project.DynamicInvoke(args);
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}

		[SecuritySafeCritical]
		private object ConstructorInvoke(ConstructorInfo ci, object[] parameters)
		{
			try
			{
				new ReflectionPermission(ReflectionPermissionFlag.MemberAccess).Assert();
				return ci.Invoke(parameters);
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
		}


	}
}
