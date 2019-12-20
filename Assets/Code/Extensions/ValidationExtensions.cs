using System;

namespace Assets.Code.Extensions
{
    public static class ValidationExtensions
    {
        public static void AssertGreaterThan<T>(this T assertionTarget, T value) where T : IComparable<T>
        {
            if (assertionTarget.CompareTo(value) <= 0)
                throw new ArgumentException($"{assertionTarget} is not greater than {value}");
        }
    }
}
