namespace RocketLeagueStats.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public team()
        {
            players = new HashSet<player>();
        }

        public int teamid { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Team")]
        public string name { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Region")]
        public string region { get; set; }

        [Display(Name = "Wins")]
        public int wins { get; set; }

        [Display(Name = "Losses")]
        public int losses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player> players { get; set; }
    }
}
