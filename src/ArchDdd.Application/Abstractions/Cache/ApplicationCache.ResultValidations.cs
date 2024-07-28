using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using System.Collections.Frozen;
using System.Linq.Expressions;
using System.Reflection;

namespace ArchDdd.Application.Abstractions.Cache;

public static partial class ApplicationCache
{
    private const string Errors = "errors";
    public static readonly FrozenDictionary<Type, Func<Error[], IValidationResult>> ValidationResultCache;

    private static FrozenDictionary<Type, Func<Error[], IValidationResult>> CreateValidationResultCache()
    {
        Dictionary<Type, Func<Error[], IValidationResult>> resultValidationsCache = [];

        // public static ValidationResult WithErrors(ICollection<Error> validationErrors)
        //      Error[]             : ICollection<Error> validationErrors 입력
        //      IValidationResult   : ValidationResult 출력

        resultValidationsCache.TryAdd(typeof(Result), ValidationResult.WithErrors);
        resultValidationsCache.TryAdd(typeof(IResult), ValidationResult.WithErrors);

        var responseTypes = GetResponseTypes();

        foreach (var type in responseTypes)
        {
            AddToCache(resultValidationsCache, type);
        }

        //var keyResponseTypes = GetKeyResponseTypes();
        //var keyTypes = GetKeyTypes();

        //foreach (var pageResposneType in GetPageResponseTypes())
        //{
        //    foreach (var responseType in responseTypes)
        //    {
        //        var genericPageResponseType = pageResposneType.MakeGenericType(responseType);
        //        AddToCache(resultValidationsCache, genericPageResponseType);
        //    }

        //    foreach (var keyResponseType in keyResponseTypes)
        //    {
        //        foreach (var keyType in keyTypes)
        //        {
        //            var genericKeyResponseType = keyResponseType.MakeGenericType(keyType);
        //            var genericPageResponseType = pageResposneType.MakeGenericType(genericKeyResponseType);
        //            AddToCache(resultValidationsCache, genericPageResponseType);
        //        }
        //    }
        //}

        //foreach (var keyResponseType in keyResponseTypes)
        //{
        //    foreach (var keyType in keyTypes)
        //    {
        //        var genericKeyResponseType = keyResponseType.MakeGenericType(keyType);
        //        AddToCache(resultValidationsCache, genericKeyResponseType);
        //    }
        //}

        return resultValidationsCache.ToFrozenDictionary();
    }

    private static IEnumerable<Type> GetResponseTypes()
    {
        return Application.AssemblyReference.Assembly
            .GetTypesWithAnyMatchingInterface(i => i.Name.Contains(nameof(IResponse)))
            .Where(type => type.IsInterface is false)
            .Where(type => type.IsGenericType is false);
    }

    private static void AddToCache(Dictionary<Type, Func<Error[], IValidationResult>> resultValidationsCache, Type result)
    {
        var validationMethod = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(result)
            .GetMethod(nameof(ValidationResult.WithErrors))!;

        var validationDelegate = CompileFunc(validationMethod);
        var resultType = typeof(IResult<>).MakeGenericType(result);
        resultValidationsCache.TryAdd(resultType, validationDelegate);
    }

    private static Func<Error[], IValidationResult> CompileFunc(MethodInfo methodInfo)
    {
        var parameter = Expression.Parameter(typeof(Error[]), Errors);
        var call = Expression.Call(null, methodInfo, parameter);

        var lambda = Expression.Lambda<Func<Error[], IValidationResult>>(
            Expression.Convert(call, typeof(IValidationResult)),
            false,
            parameter);

        return lambda.Compile();
    }
}

public static class ReflectionUtilities
{
    public static IEnumerable<Type> GetTypesWithAnyMatchingInterface(this Assembly assembly, Func<Type, bool> typeInterfaceMatch)
    {
        return assembly
            .GetTypes()
            .Where(type => type.GetInterfaces().Any(typeInterfaceMatch));
    }
}