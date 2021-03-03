using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class BundleSession
    {
        public BundleSession()
        {
            BundleCardsSessions = new HashSet<BundleCardsSession>();
        }

        public int Id { get; set; }
        public int BundleId { get; set; }
        public int UserId { get; set; }
        public int? GoodAnswers { get; set; }
        public int? BadAnswers { get; set; }
        public double? Percentage { get; set; }
        public byte[] SessionDate { get; set; }

        public virtual Bundle Bundle { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BundleCardsSession> BundleCardsSessions { get; set; }
    }
}
