namespace ForgoAPI.Entity.Item.RequestModels
{
    public class ItemRequestModel:BaseRequest
    {
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
