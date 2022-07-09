using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationManager.Domain.Models
{
    public class UserPhoto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PhotoId { get; set; }
    }
}
