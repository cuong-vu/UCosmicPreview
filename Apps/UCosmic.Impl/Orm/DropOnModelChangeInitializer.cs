using System.Data.Entity;

namespace UCosmic.Orm
{
    // ReSharper disable ClassNeverInstantiated.Global
    public class DropOnModelChangeInitializer : DropCreateDatabaseIfModelChanges<UCosmicContext>
    // ReSharper restore ClassNeverInstantiated.Global
    {
        protected override void Seed(UCosmicContext context)
        {
            SqlInitializer.Seed(context);
        }
    }
}