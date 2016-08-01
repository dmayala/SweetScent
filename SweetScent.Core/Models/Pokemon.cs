using Realms;

namespace SweetScent.Core.Models
{
    public class Pokemon : RealmObject
    {
        [ObjectId]
        public long EncounterId { get; set; }
        [Indexed]
        public string Name { get; set; }
        public int Number { get; set; }
        public long Expires { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
