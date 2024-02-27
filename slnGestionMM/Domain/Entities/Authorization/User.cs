using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities.Authorization
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string LastName { get; set; }
        public required string Username { get; set; }
        public RolesUser? RolesUser { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public bool isActive { get; set; }
    }
}
