using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class BundleOwner
    {
        public int Id { get; set; }
        public int BundleId { get; set; }
        public int? UserId { get; set; }
        public bool? IsUserActive { get; set; }

        public virtual Bundle Bundle { get; set; }
        public virtual User User { get; set; }
    }
}
