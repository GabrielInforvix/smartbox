using smartbox.Enums;

namespace SmartBox.Model
{
    public class PackageModel
    {
        public int Id { get; set; }
        public int custumerId { get; set; }
        public DateTime delivered_at { get; set; }
        public DateTime picked_up_at { get; set; }
        public StatePackage state { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
