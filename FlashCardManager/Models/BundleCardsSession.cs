using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class BundleCardsSession
    {
        public int Id { get; set; }
        public int BundleSessionId { get; set; }
        public bool? IsGoodAnswers { get; set; }

        public virtual BundleSession BundleSession { get; set; }
    }
}
