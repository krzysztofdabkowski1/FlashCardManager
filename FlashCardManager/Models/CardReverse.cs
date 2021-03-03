using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class CardReverse
    {
        public CardReverse()
        {
            BundleCards = new HashSet<BundleCard>();
        }

        public int Id { get; set; }
        public int? CardId { get; set; }
        public string Term { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? LangId { get; set; }
        public bool? Public { get; set; }

        public virtual Card Card { get; set; }
        public virtual Language Lang { get; set; }
        public virtual ICollection<BundleCard> BundleCards { get; set; }
    }
}
