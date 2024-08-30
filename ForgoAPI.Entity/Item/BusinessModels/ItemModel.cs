using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ForgoAPI.Entity.Item.BusinessModels
{
    [Table("ItemList")]
    public class ItemModel
    {
        public long ItemID { get; set; }
        public string ? ItemName { get; set; }
        public string  ? Type { get; set; }
        public decimal Price { get; set; }
        [DefaultValue(false)]
        [JsonIgnore]
        public bool ? IsDeleted { get; private set; }
    }
}
