using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;

namespace Repository.Item.V1
{
    public interface IItemRepository
    {
        IEnumerable<ItemModel> GetAllItems(ItemRequestModel itemRequestModel);
        ItemModel AddItem(ItemRequestModel itemRequestModel);
    }
}
