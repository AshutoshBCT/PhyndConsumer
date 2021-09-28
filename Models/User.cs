using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndConsumer.Models
{
    public class User
    {
        public int Id { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastNmae { get; set; }
        public string Email { get; set; }
        public int UserHospitalId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
