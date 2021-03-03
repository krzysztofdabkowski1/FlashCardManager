using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class BundleCard
    {
        public BundleCard()
        {
            BundleCardDescriptions = new HashSet<BundleCardDescription>();
            BundleCardExamples = new HashSet<BundleCardExample>();
        }

        public int Id { get; set; }
        public int? BundleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? NativeCardId { get; set; }
        public int? ForeignCardId { get; set; }

        public virtual Bundle Bundle { get; set; }
        public virtual CardReverse ForeignCard { get; set; }
        public virtual Card NativeCard { get; set; }
        public virtual ICollection<BundleCardDescription> BundleCardDescriptions { get; set; }
        public virtual ICollection<BundleCardExample> BundleCardExamples { get; set; }
    }
}
