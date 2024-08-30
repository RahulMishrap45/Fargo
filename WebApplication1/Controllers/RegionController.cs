using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity;
using Microsoft.AspNetCore.Mvc;
using ApiVersionV1 = ForgoAPI.Services.Region.V1;
using ForgoAPI.Entity.Item.RequestModels;

namespace Forgo.Task.Controllers
{
    [ApiController]
    [Route("api/RegionAPI")]
    public class RegionController : ControllerBase
    {
        private readonly ApiVersionV1.IRegionTypeService _regionTypeService;
        public RegionController(ApiVersionV1.IRegionTypeService iregionTypeService)
        {
            _regionTypeService = iregionTypeService;
        }
        [HttpGet]
        [Route("api/GetAllRegionAPI")]
        public IActionResult GetAllRegion()
        {
            try
            {
                CommonResponse<RegionModel> regionModelModels = new CommonResponse<RegionModel>();

                regionModelModels = _regionTypeService.GetAllRegion();

                return Ok(regionModelModels);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpPost]
        [Route("api/AddRegionAPI")]

        public IActionResult AddRegion(RegionRequestModel regionRequestModel)
        {
            try
            {
                RegionModel regionModel = new RegionModel();
                if (ModelState.IsValid)
                {
                    if (regionRequestModel.Version == APIVersions.Version2)
                    {
                        regionModel = _regionTypeService.AddRegion(regionRequestModel);
                    }
                    else
                    {
                        regionModel = _regionTypeService.AddRegion(regionRequestModel);
                    }
                }
                return Ok(regionModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpGet]
        [Route("api/GetRegionAPI")]

        public IActionResult GetRegion([FromRoute(Name = "RegionId")] int RegionId)
        {
            try
            {
                RegionModel regionModelModel = new RegionModel();
                regionModelModel = _regionTypeService.GetRegion(RegionId);
                return Ok(regionModelModel);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);

            }

        }

        [HttpPut]
        [Route("api/UpdateRegionAPI")]

        public IActionResult UpdateRegion(RegionRequestModel regionRequestModel)
        {
            try
            {
                RegionModel regionModel = new RegionModel();
                if (ModelState.IsValid)
                {
                    regionModel = _regionTypeService.UpdateRegion(regionRequestModel);
                }
                return Ok(regionModel);

            }
            catch (Exception ex)
            {

                return Problem(ex.Message, ex.StackTrace);
            }
        }

        [HttpDelete]
        [Route("api/DeleteRegionAPI")]

        public IActionResult DeleteRegion(int RegionId, int deletedBy)
        {
            try
            {
                RegionModel regionModel = new RegionModel();
                regionModel = _regionTypeService.DeleteRegion(RegionId, deletedBy);
                return Ok("The user is Deleted");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, ex.StackTrace);

            }
        }
    }
}
