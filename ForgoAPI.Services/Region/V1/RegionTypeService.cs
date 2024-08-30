using Component;
using ForgoAPI.Entity;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using ForgoAPI.Services.OrderType.V1;
using Repository.Region.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Services.Region.V1
{
    public class RegionTypeService : BaseService, IRegionTypeService
    {
        public readonly IRegionRepository _IregionRepository;

        public RegionTypeService(IRegionRepository iregionRepository)
        {
            _IregionRepository = iregionRepository;
        }

        public RegionModel AddRegion(RegionRequestModel regionRequestModel)
        {
            return _IregionRepository.AddRegion(regionRequestModel);
        }

        public RegionModel DeleteRegion(int RegionID, int deletedBy)
        {
            return _IregionRepository.DeleteRegion(RegionID, deletedBy);
        }

        public CommonResponse<RegionModel> GetAllRegion()
        {
            var RegionList = _IregionRepository.GetAllRegion().ToList();
            if (RegionList == null)
                return new CommonResponse<RegionModel>
                {
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound
                };
            return new CommonResponse<RegionModel>
            {
                Model = RegionList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };
        }

        public RegionModel GetRegion(int RegionID)
        {
            return _IregionRepository.GetRegion(RegionID);
        }

        public RegionModel UpdateRegion(RegionRequestModel regionRequestModel)
        {
            return _IregionRepository.UpdateRegion(regionRequestModel);
        }
    }
}
