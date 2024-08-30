using Component;
using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using Repository.Item.V1;

namespace ForgoAPI.Services.Item.V1
{
    public class ItemService : BaseItemService, IItemService
    {
        private IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public CommonResponse<ItemModel> GetAllItems(ItemRequestModel itemRequestModel)
        {
            var itemList = _itemRepository.GetAllItems(itemRequestModel)?.ToList();
            if (itemList == null) 
                return new CommonResponse<ItemModel>
                { 
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound 
                };

            return new CommonResponse<ItemModel>
            {
                Model = itemList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };

        }
        public ItemModel AddItem(ItemRequestModel itemRequestModel)
        {
            return _itemRepository.AddItem(itemRequestModel);
        }
    }
}
