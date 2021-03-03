using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class Bundle
    {
        public Bundle()
        {
            BundleCards = new HashSet<BundleCard>();
            BundleOwners = new HashSet<BundleOwner>();
            BundleSessions = new HashSet<BundleSession>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? CardsQuantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? NativeLangId { get; set; }
        public int? ForeignLangId { get; set; }
        public bool? Public { get; set; }

        public virtual Language ForeignLang { get; set; }
        public virtual Language NativeLang { get; set; }
        public virtual ICollection<BundleCard> BundleCards { get; set; }
        public virtual ICollection<BundleOwner> BundleOwners { get; set; }
        public virtual ICollection<BundleSession> BundleSessions { get; set; }
    }
}
