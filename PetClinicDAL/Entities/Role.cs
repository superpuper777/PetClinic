using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicDAL.Entities
{
    [Table("Roles")]
    internal class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}