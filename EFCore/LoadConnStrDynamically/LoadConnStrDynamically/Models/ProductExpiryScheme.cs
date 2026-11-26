using System.ComponentModel.DataAnnotations.Schema;

namespace LoadConnStrDynamically.Models
{
    [Table("tb_pess_product_expiry_scheme_set", Schema = "product")]
    public class ProductExpiryScheme
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("product_expiry_scheme_id")]
        public int? ProductExpirySchemeId { get; set; }
        [Column("expiration_policy_id")]
        public int ExpirationPolicyId { get; set; }
    }
}
