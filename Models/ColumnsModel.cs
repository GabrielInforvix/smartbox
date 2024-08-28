using smartbox.Enums;

namespace SmartBox.Model
{
    public class ColumnsModel
    {
        public int Id { get; set; }
        public int boxesId { get; set; }
        public string pos { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
