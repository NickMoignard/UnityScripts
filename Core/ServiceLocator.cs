using System;
using System.Collections.Generic;

/// <summary>
/// A simple Service Locator implementation for managing service instances
/// </summary>
public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    /// <summary>
    /// Register service into the locator dictionary
    /// </summary>
    /// <param name="service"></param>
    /// <typeparam name="T"></typeparam>
    public static void RegisterService<T>(T service) where T : class
    {
        var type = typeof(T);
        if (services.ContainsKey(type))
        {
            UnityEngine.Debug.LogWarning($"Service {type.Name} already registered. Replacing.");
        }
        services[type] = service;
    }

    
    /// <summary>
    /// Get service from the locator dictionary
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static T Get<T>() where T : class
    {
        var type = typeof(T);
        if (services.TryGetValue(type, out var service))
        {
            return service as T;
        }
        
        throw new Exception($"Service {type.Name} not registered");
    }
    
    
    /// <summary>
    /// Check if service is registered
    /// </summary>
    /// <param name="service"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool TryGet<T>(out T service) where T : class
    {
        var type = typeof(T);
        if (services.TryGetValue(type, out var obj))
        {
            service = obj as T;
            return true;
        }

        service = null;
        return false;
    }

    
    /// <summary>
    /// Clear all registered services
    /// </summary>
    public static void Clear()
    {
        services.Clear();
    }
    
}