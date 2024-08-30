using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using ApiVersionV1 = ForgoAPI.Services.Branch.V1;
using ForgoAPI.Entity.Item.RequestModels;
using Microsoft.AspNetCore.Authorization;

namespace Forgo.Task.Controllers
{
    [ApiController]
    [Route("api/BranchAPI")]
    public class BranchController : ControllerBase
    {
        private readonly ApiVersionV1.IBranchService _branchService;

        public BranchController(ApiVersionV1.IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        [Route("api/GetAllBranchAPI")]
        public IActionResult GetAllbranch()
        {
            try
            {
                CommonResponse<BranchModel> branchModels = new CommonResponse<BranchModel>();

                branchModels = _branchService.GetAllBranch();

                return Ok(branchModels);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("api/AddbranchAPI")]
        public IActionResult Addbranch(BranchRequestModel branchRequestModel)
        {
            try
            {
                BranchModel branchModel = new BranchModel();
                if (ModelState.IsValid)
                {
                    if (branchRequestModel.Version == APIVersions.Version2)
                    {
                        branchModel = _branchService.AddBranch(branchRequestModel);
                    }
                    else
                    {
                        branchModel = _branchService.AddBranch(branchRequestModel);
                    }
                }
                return Ok(branchModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }

        }

        [HttpGet]
        [Route("api/GetBranchAPI")]
        public IActionResult GetBranch([FromRoute(Name = "branchId")] int branchId)
        {
            try
            {
                BranchModel branchModel = new BranchModel();
                branchModel = _branchService.GetBranch(branchId);
                return Ok(branchModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);

            }

        }

        [HttpPut]
        [Route("api/UpdateBranchAPI")]

        public IActionResult UpdateBranch(BranchRequestModel branchRequestModel)
        {
            try
            {
                BranchModel branchModel = new BranchModel();
                if (ModelState.IsValid)
                {
                    branchModel = _branchService.UpdateBranch(branchRequestModel);
                }
                return Ok(branchModel);

            }
            catch (Exception ex)
            {

                return Problem(ex.Message, ex.StackTrace);
            }
        }
       
        [HttpDelete]
        [Route("api/DeleteBranchAPI")]
        public IActionResult DeleteBranch(int branchId, int deletedBy)
        {
            try
            {
                BranchModel branchModel = new BranchModel();
                branchModel = _branchService.DeleteBranch(branchId, deletedBy);
                return Ok("The user is Deleted");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);

            }
        }
    }
}
