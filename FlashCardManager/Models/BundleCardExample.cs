using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class BundleCardExample
    {
        public int Id { get; set; }
        public int BundleCardId { get; set; }
        public int UserId { get; set; }
        public string Example { get; set; }

        public virtual BundleCard BundleCard { get; set; }
        public virtual User User { get; set; }
    }
}
