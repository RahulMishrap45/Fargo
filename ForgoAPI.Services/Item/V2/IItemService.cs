using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;

namespace ForgoAPI.Services.Item.V2
{
    public interface IItemService
    {
         CommonResponse<ItemModel> GetAllItems(string itemName = "", int itemId = 0);
         ItemModel AddItem(ItemRequestModel itemRequestModel);
    }
}
