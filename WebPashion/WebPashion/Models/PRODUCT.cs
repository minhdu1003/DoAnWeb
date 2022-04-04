
namespace WebPashion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.PRODUCT_DETAIL = new HashSet<PRODUCT_DETAIL>();
            this.REVIEWS = new HashSet<REVIEWS>();
        }
    
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public Nullable<int> ProductCount { get; set; }
        public int Size { get; set; }
        public int Type { get; set; }
        public int Brand { get; set; }
        public int Sale { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> ProductCreatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_DETAIL> PRODUCT_DETAIL { get; set; }
        public virtual PRODUCT_BRAND PRODUCT_BRAND { get; set; }
        public virtual PRODUCT_SALE PRODUCT_SALE { get; set; }
        public virtual PRODUCT_SIZE PRODUCT_SIZE { get; set; }
        public virtual PRODUCT_TYPE PRODUCT_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REVIEWS> REVIEWS { get; set; }

        [NotMapped]
        public HttpStyleUriParser ImageUpload { get; set; }
    }
}
