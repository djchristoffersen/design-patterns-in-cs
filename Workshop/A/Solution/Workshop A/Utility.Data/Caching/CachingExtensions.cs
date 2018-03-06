namespace Wincubate.WorkshopA.Utility.Data
{
    internal static class CachingExtensions
    {
        internal static string AllCacheKey => "Elements/all";
        internal static string ToCacheKey( this int id ) => $"Elements/{id}";
    }
}
