using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgoAPI.Entity.Item.BusinessModels
{
    [Table("cit.UserMaster")]
    public class UserModel
    {
        public long UserID { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public long? RoleID { get; set; }
        public string? DataSource { get; set; }
        public bool? IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public long? DeletedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? AccessToken { get; set; }
    }
}
