//using ArchDdd.Domain.Abstractions.Results;

//namespace ArchDdd.Domain.AggregateRoots.Users.ValueObjects;

//public sealed partial class Username
//{
//    public class UsernameError
//    {
//        public static Error Empty()
//        {
//            return Error.New(
//                $"{{nameof(Username)}.{nameof(Empty)}",
//                $"{nameof(Username)} name is empty.");
//        }

//        public static Error TooLong(string value)
//        {
//            return Error.New(
//                $"{{nameof(Username)}.{nameof(TooLong)}",
//                $"{nameof(Username)} name must be at most {Username.MaxLength} characters.");
//        }

//        public static Error ContainsIllegalCharacter(string value)
//        {
//            return Error.New(
//                $"{{nameof(Username)}.{nameof(ContainsIllegalCharacter)}",
//                $"{nameof(Username)} contains illegal character.");
//        }

//        //public static readonly Error Empty = Error.New(
//        //    $"{{nameof(Username)}.{nameof(Empty)}",
//        //    $"{nameof(Username)} name is empty.");

//        //public static readonly Error TooLong = Error.New(
//        //    $"{{nameof(Username)}.{nameof(TooLong)}",
//        //    $"{nameof(Username)} name must be at most {Username.MaxLength} characters.");

//        //public static readonly Error ContainsIllegalCharacter = Error.New(
//        //    $"{{nameof(Username)}.{nameof(ContainsIllegalCharacter)}",
//        //    $"{nameof(Username)} contains illegal character.");
//    }
//}
