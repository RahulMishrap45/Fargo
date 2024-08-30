namespace ForgoAPI.Services.Item
{
    public abstract class BaseItemService : BaseService
    {
        protected Repository.Item.V1.IItemRepository ItemRepository { get; set; }
        public BaseItemService() {

            ItemRepository=new Repository.Item.V1.ItemRepository();
        }    
    }
}
