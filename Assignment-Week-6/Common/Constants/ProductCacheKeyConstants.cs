namespace Assignment_Week_6.Common.Constants
{
    public class ProductCacheKeyConstants
    {
        private const string Prefix = BaseCacheKeyConstants.Prefix;
        public const string GetAll = Prefix + "get-all";
        public const string GetById = Prefix + "get-by-id-{0}";
    }
}
