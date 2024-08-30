using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using HelperClasses;

namespace Repository.Item.V1
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public ItemModel AddItem(ItemRequestModel itemRequestModel)
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.Create,
                ItemName = itemRequestModel.ItemName,
                @type = itemRequestModel.Type,
                @Price = itemRequestModel.Price
            };
            var itemModel = base.GetSPResults<ItemModel>("Sp_ItemList", paramObjects);
            return itemModel.FirstOrDefault() ?? new ItemModel();
        }

        public IEnumerable<ItemModel> GetAllItems(ItemRequestModel itemRequestModel)
        {
            object paramObjects = new { Flag = strctCRUDAction.GetAll, ItemID = itemRequestModel.ItemId, ItemName = itemRequestModel.ItemName };
            List<ItemModel> items = base.GetSPResults<ItemModel>("Sp_ItemList", paramObjects);
            return items;
        }
    }
}
