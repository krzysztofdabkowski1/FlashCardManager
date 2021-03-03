using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class Language
    {
        public Language()
        {
            BundleForeignLangs = new HashSet<Bundle>();
            BundleNativeLangs = new HashSet<Bundle>();
            CardReverses = new HashSet<CardReverse>();
            Cards = new HashSet<Card>();
        }

        public int Id { get; set; }
        public string NameShort { get; set; }
        public string NameFull { get; set; }

        public virtual ICollection<Bundle> BundleForeignLangs { get; set; }
        public virtual ICollection<Bundle> BundleNativeLangs { get; set; }
        public virtual ICollection<CardReverse> CardReverses { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
