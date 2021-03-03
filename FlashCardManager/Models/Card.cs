using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class Card
    {
        public Card()
        {
            BundleCards = new HashSet<BundleCard>();
            CardReverses = new HashSet<CardReverse>();
        }

        public int Id { get; set; }
        public string NativeTerm { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? LangId { get; set; }

        public virtual Language Lang { get; set; }
        public virtual ICollection<BundleCard> BundleCards { get; set; }
        public virtual ICollection<CardReverse> CardReverses { get; set; }
    }
}
