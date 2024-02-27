using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Authorization
{
    public  class RolesUser
    {
        public int RolesUserId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
