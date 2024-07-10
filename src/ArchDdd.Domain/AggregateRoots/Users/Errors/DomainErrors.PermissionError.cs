//using ArchDdd.Domain.Abstractions.Results;
//using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

//namespace ArchDdd.Domain.AggregateRoots.Users.Errors;

//public static partial class DomainErrors
//{
//    public static class PermissionError
//    {
//        public static Error NotFound(string uniqueValue)
//        {
//            return Error.New(
//                $"{nameof(DomainErrors)}.{nameof(Permission)}.{nameof(NotFound)}",
//                $"{nameof(Permission)} for '{uniqueValue}' was not found.");
//        }
//    }
//}