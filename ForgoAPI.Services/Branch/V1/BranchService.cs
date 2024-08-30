using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity;
using ForgoAPI.Services.Customer.V1;
using Repository.Branch.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgoAPI.Entity.Item.RequestModels;
using Repository.Customer.V1;

namespace ForgoAPI.Services.Branch.V1
{
    public class BranchService : BaseService, IBranchService
    {
        private IBranchRepository branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            branchRepository = branchRepository;
        }
        public BranchModel AddBranch(BranchRequestModel branchRequestModel)
        {
            return branchRepository.AddBranch(branchRequestModel);
        }

        public BranchModel DeleteBranch(int branchId, int deletedBy)
        {
            return branchRepository.DeleteBranch(branchId, deletedBy);
        }

        public CommonResponse<BranchModel> GetAllBranch()
        {
            var branchList = branchRepository.GetAllBranch().ToList();
            if (branchList == null)
                return new CommonResponse<BranchModel>
                {
                    ResponseCode = ResponseCodes.NoDataFound,
                    ResponseMessage = ResponseMessages.NoDataFound
                };
            return new CommonResponse<BranchModel>
            {
                Model = branchList,
                ResponseCode = ResponseCodes.Success,
                ResponseMessage = ResponseMessages.Success
            };

      }
        public BranchModel GetBranch(int branchId)
        {
                return branchRepository.GetBranch(branchId); throw new NotImplementedException();
        }

        public BranchModel UpdateBranch(BranchRequestModel branchRequestModel)
        {
           return branchRepository.UpdateBranch(branchRequestModel);
        }
    }
}