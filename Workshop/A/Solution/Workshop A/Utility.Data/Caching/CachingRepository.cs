using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static Wincubate.WorkshopA.Utility.Data.CachingExtensions;

namespace Wincubate.WorkshopA.Utility.Data
{
    public class CachingRepository<T> : IRepository<T>, IDisposable
        where T : IEntity
    {
        private readonly IRepository<T> _inner;
        private readonly MemoryCache _cache;

        #region IDisposable Members

        private bool _isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose( bool disposing )
        {
            if (_isDisposed == false)
            {
                if (disposing)
                {
                    _cache?.Dispose();
                }
            }
            _isDisposed = true;
        }

        #endregion

        #region IRepository<T> Members

        public T GetById( int id )
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(CachingRepository<T>));
            }

            string cacheKey = id.ToCacheKey();

            // Retrieve cached element for id, if exists
            if (_cache.TryGetValue(cacheKey, out T element) == false)
            {
                // Lookup underlying repository and update cache
                element = _inner.GetById(id);
                _cache.Set(cacheKey, element);
            }

            // Could consider making a copy of element here if not immutable, but...
            return element;
        }

        public IQueryable<T> GetAll()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(CachingRepository<T>));
            }

            // See if all was previously cached as a list
            if (_cache.TryGetValue(AllCacheKey, out IList<T> all) == false)
            {
                // Update all the individual items in the cache, because we do not know if we have seen all elements
                all = _inner
                        .GetAll()
                        .ToList();
                foreach (T element in all)
                {
                    _cache.Set(element.Id.ToCacheKey(), element);
                }

                // Create a separate cache item for the full collection as a list
                // (for easy returning as well as re-updating when Add() is later invoked again)
                _cache.Set(AllCacheKey, all);
            }

            // Necessary to copy T elements to a new array to avoid exposing cached
            // List <T>-object to clients (as the list itself is *not* immutable)
            return all.ToArray()
                .AsQueryable();
        }

        // A bit simplistic, but IQueryable does not play well with caching... :-)
        public IQueryable<T> GetAll( Expression<Func<T, bool>> filter )
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(CachingRepository<T>));
            }

            IQueryable<T> queryableAll = null;
            // See if all was previously cached as a list
            if (_cache.TryGetValue(AllCacheKey, out IList<T> all) == true)
            {
                // It was
                queryableAll = all.AsQueryable();
            }
            else
            {
                // It wasn't! Get it...
                queryableAll = GetAll();
            }

            // In either case, use the all now in cache as a basis for
            // performing the filter query
            return queryableAll.Where(filter);
        }

        public void Add( T element )
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(CachingRepository<T>));
            }

            // Always upsert underlying repository and update cache
            _inner.Add(element);
            _cache.Set(element.Id.ToCacheKey(), element);

            // See if all was previously cached as a list
            if (_cache.TryGetValue(AllCacheKey, out IList<T> all) == true)
            {
                // We need to upsert the cached element as the full list
                // has now been modified
                IList<T> newAll = all
                    .Where(p => p.Id != element.Id)
                    .ToList();
                newAll.Add(element);

                _cache.Set(AllCacheKey, newAll);
            }
        }

        public void Remove( T element )
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(CachingRepository<T>));
            }

            // Always remove from underlying repository and update cache
            _inner.Remove(element);
            _cache.Remove(element.Id.ToCacheKey());

            // See if all was previously cached as a list in all
            if (_cache.TryGetValue(AllCacheKey, out IList<T> all) == true)
            {
                // We need to remove the cached element as the full list
                // has now been modified
                IList<T> newAll = all
                    .Where(p => p.Id != element.Id)
                    .ToList();

                _cache.Set(AllCacheKey, newAll);
            }
        }

        #endregion

        public CachingRepository( IRepository<T> inner )
        {
            _inner = inner;
            _cache = new MemoryCache(new MemoryCacheOptions());
        }
    }
}
