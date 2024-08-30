using ForgoAPI.Entity.Item.RequestModels;
using ApiVersionV1 = ForgoAPI.Services.Item.V1;
using ApiVersionV2 = ForgoAPI.Services.Item.V2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ForgoAPI.Entity.Item.BusinessModels;
using Component;
using System.Reflection;
using ForgoAPI.Entity.Item.ResponseModels;
using ForgoAPI.Entity;

namespace Forgo.Task.Controllers
{
    [ApiController]
    [Route("api/ItemAPI")]
    public class ItemsController :  BaseController
    {
        private readonly ApiVersionV1.IItemService _itemService1;
        private readonly ApiVersionV2.IItemService _itemService2;
        public ItemsController(ApiVersionV1.IItemService itemService, ApiVersionV2.IItemService itemService2)
        {
            _itemService1 = itemService;
            _itemService2 = itemService2;
        }
      
        [HttpPost]
        [Route("api/GetAllItemsAPI")]
        public IActionResult GetAllItems(ItemRequestModel itemRequestModel)
        {
            try
            {
                CommonResponse<ItemModel> itemModels = new CommonResponse<ItemModel>();
                if (ModelState.IsValid)
                {
                    
              
                   if (itemRequestModel.Version == APIVersions.Version2)
                    {
                        itemModels = _itemService2.GetAllItems(itemRequestModel.ItemName??"", itemRequestModel.ItemId);
                    }
                    else
                    {
                        itemModels = _itemService1.GetAllItems(itemRequestModel);
                    }
                }

                return Ok(itemModels);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }

        }

        [HttpPost]
        [Route("api/AddItemsAPI")]
        public IActionResult AddItems(ItemRequestModel itemRequestModel)
        {
            try
            {
                ItemModel itemModel = new ItemModel();
                if (ModelState.IsValid)
                {


                    if (itemRequestModel.Version == APIVersions.Version2)
                    {
                        itemModel = _itemService2.AddItem(itemRequestModel);
                    }
                    else
                    {
                        itemModel = _itemService1.AddItem(itemRequestModel);
                    }
                }

                return Ok(itemModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }

        }

        //[HttpGet]
        //[Route("api/ItemsAPI")]
        //public IActionResult GetItems([FromRoute(Name = "ItemId")] int ItemId)
        //{
        //    try
        //    {
        //        ItemModel itemModel = new ItemModel();
        //        itemModel = _itemService2.GetAllItems(ItemId);
        //        return Ok(branchModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(ex.Message, ex.StackTrace);

        //    }

        //}

        //[HttpPut]
        //[Route("api/UpdateBranchAPI")]

        //public IActionResult UpdateBranch(BranchRequestModel branchRequestModel)
        //{
        //    try
        //    {
        //        BranchModel branchModel = new BranchModel();
        //        if (ModelState.IsValid)
        //        {
        //            branchModel = _branchService.UpdateBranch(branchRequestModel);
        //        }
        //        return Ok(branchModel);

        //    }
        //    catch (Exception ex)
        //    {

        //        return Problem(ex.Message, ex.StackTrace);
        //    }
        //}

        //[HttpDelete]
        //[Route("api/DeleteBranchAPI")]
        //public IActionResult DeleteBranch(int branchId, int deletedBy)
        //{
        //    try
        //    {
        //        BranchModel branchModel = new BranchModel();
        //        branchModel = _branchService.DeleteBranch(branchId, deletedBy);
        //        return Ok("The user is Deleted");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(ex.Message, ex.StackTrace);

        //    }
        //}
    }
}
