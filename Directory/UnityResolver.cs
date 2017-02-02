// <copyright file="UnityResolver.cs" company="Adam Miller">
// Copyright (c) Adam Miller. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

/// <summary>
/// Dependency injection resolver source:
/// https://www.asp.net/web-api/overview/advanced/dependency-injection
/// </summary>

public class UnityResolver : IDependencyResolver
{
    private IUnityContainer container;

    public UnityResolver(IUnityContainer container)
    {
        if (container == null)
        {
            throw new ArgumentNullException("container");
        }

        this.container = container;
    }

    public object GetService(Type serviceType)
    {
        try
        {
            return this.container.Resolve(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return null;
        }
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        try
        {
            return this.container.ResolveAll(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return new List<object>();
        }
    }

    public IDependencyScope BeginScope()
    {
        var child = this.container.CreateChildContainer();
        return new UnityResolver(child);
    }

    public void Dispose()
    {
        this.container.Dispose();
    }
}