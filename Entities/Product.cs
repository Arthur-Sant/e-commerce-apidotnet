using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apidotnetwiwthdapper.Entities {
    public class Product {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
