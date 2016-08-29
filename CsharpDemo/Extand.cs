using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDemo
{
    static class Extand
    {
        internal static int Add1(this string i)
        {
            var j = int.Parse(i);
            return ++j;
        }
        internal static T Cast<T>(this object obj, T t)
        {
            return (T)obj;
        }
        public static void anonymous(dynamic a)
        {
            var d = a.t;
            Console.WriteLine(d.firstname);
            Console.WriteLine(d.lastname);
        }
    }
    /// <summary>
    /// 静态函数实例化ClassA
    /// </summary>
    public class ClassA : IDynamicMetaObjectProvider
    {
        public int this[int s] { get { return s; } }
        private string field;
        private ClassA(string s)
        {
            this.field = s;
        }
        public static ClassA Create(string s)
        {
            return new ClassA(s);
        }
        public static void ThrowEx(string s = null)
        {
            try
            {
                if (s == null)
                {
                    throw new ArgumentException("exception");
                }
                Console.Write("end");
            }
            catch (Exception e) when(e is FormatException||e is OverflowException)
            {
                
                Console.Write(e.Message);
            }
        }
        public DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter)
        {
            return new MetaClassA(parameter, this);
        }
        class MetaClassA : DynamicMetaObject
        {
            private static readonly System.Reflection.MethodInfo RightGuessMethod =
                typeof(ClassA).GetMethod("RespondToRightGuess", System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic);

            internal MetaClassA(System.Linq.Expressions.Expression expression, ClassA creator)
                : base(expression, BindingRestrictions.Empty, creator)
            { }
        }
    }
    #region Distinct
    public class CommonEqualityComparer<T, V> : IEqualityComparer<T>
    {
        private Func<T, V> keySelector;
        private IEqualityComparer<V> comparer;

        public CommonEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer;
        }

        public CommonEqualityComparer(Func<T, V> keySelector)
            : this(keySelector, EqualityComparer<V>.Default)
        { }

        public bool Equals(T x, T y)
        {
            return comparer.Equals(keySelector(x), keySelector(y));
        }

        public int GetHashCode(T obj)
        {
            return comparer.GetHashCode(keySelector(obj));
        }
    }
    public static class DistinctExtensions
    {
        public static IEnumerable<T> Distinct<T, V>(this IEnumerable<T> source, Func<T, V> keySelector,
            IEqualityComparer<V> comparer /*= EqualityComparer<V>.Default*/)
        {
            return source.Distinct(new CommonEqualityComparer<T, V>(keySelector, comparer));
        }
    }
    #endregion
}
