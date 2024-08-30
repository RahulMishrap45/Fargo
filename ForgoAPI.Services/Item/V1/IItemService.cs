using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;

namespace ForgoAPI.Services.Item.V1
{
    public interface IItemService
    {
        CommonResponse<ItemModel> GetAllItems(ItemRequestModel itemRequestModel);
        ItemModel AddItem(ItemRequestModel itemRequestModel);
    }
}
