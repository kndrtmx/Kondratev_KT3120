namespace KM_KT3120.Tests
{
    internal class KondratevDbContext
    {
        private object dbContextOptions;

        public KondratevDbContext(object dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }
    }
}