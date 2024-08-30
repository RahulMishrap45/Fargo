using Component;
using ForgoAPI.Entity.Item.BusinessModels;
using ForgoAPI.Entity.Item.RequestModels;
using Repository.Branch.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Branch.V1
{
    public class BranchRepository : BaseRepository, IBranchRepository
    {
        public BranchModel AddBranch(BranchRequestModel branchRequestModel)
        {
            object paramObjects = new
            {
                Flag = strctCRUDAction.Create,
                @BranchName = branchRequestModel.BranchName,
                @Address = branchRequestModel.Address,
                @ContactNumber = branchRequestModel.ContactNumber,
               
                @DataSource = branchRequestModel.DataSource,
                @IsActive = branchRequestModel.IsActive,
                @CreatedBy = branchRequestModel.CreatedBy,
                @ModifiedBy = branchRequestModel.ModifiedBy,
                @DeletedBy = branchRequestModel.DeletedBy
            };
            var branchModel = base.GetSPResults<BranchModel>("cit.spBranch", paramObjects);
            return branchModel.FirstOrDefault() ?? new BranchModel();
        }

        public BranchModel DeleteBranch(int branchId, int deletedBy)
        {
            object paramObjects = new
            {
               
                @DeletedBy = deletedBy
            };
            var result = base.GetSPResults<BranchModel>("cit.spDeleteBranch", paramObjects);
            return result.FirstOrDefault() ?? new BranchModel();
        }

        public IEnumerable<BranchModel> GetAllBranch()
        {
            object paramObjects = new { };
            List<BranchModel> branch = base.GetSPResults<BranchModel>("cit.spGetAllBranch", paramObjects);
            return branch;
        }

        public BranchModel GetBranch(int branchId)
        {
            object paramObjects = new
            {
               
            };
            var branchModel = base.GetSPResults<BranchModel>("cit.spGetBranch", paramObjects);
            return branchModel.FirstOrDefault() ?? new BranchModel();
        }

        public BranchModel UpdateBranch(BranchRequestModel branchRequestModel)
        {
            object paramObjects = new
            {
               
                @CustomerName = branchRequestModel.BranchName,
                @Address = branchRequestModel.Address,
                @ContactNumber = branchRequestModel.ContactNumber,
               
                @IsActive = branchRequestModel.IsActive,
                @ModifiedBy = branchRequestModel.ModifiedBy
            };
            var UpdateBranch = base.GetSPResults<BranchModel>("cit.spUpdateBranch", paramObjects);
            return UpdateBranch.FirstOrDefault() ?? new BranchModel();
        }
    }
}
