using NetCoreWithAngular.DataContracts;

namespace NetCoreWithAngular.DAL.Entities
{
    public class CardDbo : EntityBaseDbo
    {
        public string Name { get; set; }
        public int ItemsCount { get; set; }
    }
}
