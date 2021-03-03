using System;
using System.Collections.Generic;

#nullable disable

namespace FlashCardManager.Models
{
    public partial class User
    {
        public User()
        {
            BundleCardDescriptions = new HashSet<BundleCardDescription>();
            BundleCardExamples = new HashSet<BundleCardExample>();
            BundleOwners = new HashSet<BundleOwner>();
            BundleSessions = new HashSet<BundleSession>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BundleCardDescription> BundleCardDescriptions { get; set; }
        public virtual ICollection<BundleCardExample> BundleCardExamples { get; set; }
        public virtual ICollection<BundleOwner> BundleOwners { get; set; }
        public virtual ICollection<BundleSession> BundleSessions { get; set; }
    }
}
