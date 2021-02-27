using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using FileService.Models;
using System.Threading;

namespace FileService.Tests
{
    public static class TestUtils
    {
        public static async Task<TException> ThrowsAsync<TException>(Func<Task> action, bool allowDerivedTypes = true) where TException : Exception
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                if (allowDerivedTypes && !(ex is TException))
                {
                    throw new Exception($"Delegate threw exception of type {ex.GetType().Name}, but {typeof(TException).Name} or a derived type was expected.", ex);
                }
                if (!allowDerivedTypes && ex.GetType() != typeof(TException))
                {
                    throw new Exception($"Delegate threw exception of type {ex.GetType().Name}, but {typeof(TException).Name} was expected.", ex);
                }
                return (TException)ex;
            }
            throw new Exception($"Delegate did not throw expected exception {typeof(TException).Name}.");
        }

        public static Task<Exception> AssertThrowsAsync(Func<Task> action)
        {
            return ThrowsAsync<Exception>(action, true);
        }

        public static async Task<TException> ThrowsAsyncEnumerable<TException>(Func<IAsyncEnumerable<FileMetadata>> action, bool allowDerivedTypes = true) where TException : Exception
        {
            try
            {
                await action().ToListAsync();
            }
            catch (Exception ex)
            {
                if (allowDerivedTypes && !(ex is TException))
                {
                    throw new Exception($"Delegate threw exception of type {ex.GetType().Name}, but {typeof(TException).Name} or a derived type was expected.", ex);
                }
                if (!allowDerivedTypes && ex.GetType() != typeof(TException))
                {
                    throw new Exception($"Delegate threw exception of type {ex.GetType().Name}, but {typeof(TException).Name} was expected.", ex);
                }
                return (TException)ex;
            }
            throw new Exception($"Delegate did not throw expected exception {typeof(TException).Name}.");
        }

        public static Task<Exception> AssertThrowsAsyncEnumerable(Func<IAsyncEnumerable<FileMetadata>> action)
        {
            return ThrowsAsyncEnumerable<Exception>(action, true);
        }

        public static async Task<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> source, CancellationToken cancellationToken=default)
        {
            var list = new List<T>();
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                list.Add(item);
            }

            return list;
        }
    }
}