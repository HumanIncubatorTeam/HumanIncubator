namespace PhotoAlbum.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Images
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Images()
        {
            ImageDescriptions = new HashSet<ImageDescriptions>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid StatusId { get; set; }

        [Required]
        [StringLength(100)]
        public string NameWithExtension { get; set; }

        [Required]
        [StringLength(100)]
        public string UniqueName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageDescriptions> ImageDescriptions { get; set; }

        public virtual Statuses Statuses { get; set; }

        public virtual Users Users { get; set; }
    }
}
