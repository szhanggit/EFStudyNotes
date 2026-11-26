using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadConnStrDynamically.Models
{
    [Table("tb_p_product", Schema = "product")]
    public class Product
    {
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("program_id")]
        public int ProgramId { get; set; }
        [Column("product_code")]
        public string ProductCode { get; set; }
        [Column("external_product_code")]
        public string ExternalProductCode { get; set; }
        [Column("brand_id")]
        public int? BrandId { get; set; }
        [Column("sku_id")]
        public int? SkuId { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("product_type")]
        public byte ProductType { get; set; }
        [Column("product_base_type")]
        public byte ProductBaseType { get; set; }
        [Column("multiple_selection_type")]
        public byte MultipleSelectionType { get; set; }
        [Column("redeem_time")]
        public byte RedeemTime { get; set; }
        [Column("can_topup")]
        public bool CanTopup { get; set; }
        [Column("is_master")]
        public bool IsMaster { get; set; }
        [Column("is_dynamic")]
        public bool IsDynamic { get; set; }
        [Column("is_deferred_child")]
        public bool? IsDeferredChild { get; set; }
        [Column("is_cart_version")]
        public bool? IsCartVersion { get; set; }
        [Column("status")]
        public bool Status { get; set; }
        [Column("can_issue")]
        public bool CanIssue { get; set; }
        [Column("stop_issue_time")]
        public DateTime? StopIssueTime { get; set; }
        [Column("reminder_id")]
        public int ReminderId { get; set; }
        [Column("product_category")]
        public byte? ProductCategory { get; set; }
        [Column("product_tag")]
        public byte? ProductTag { get; set; }
        [Column("product_issuer")]
        public byte ProductIssuer { get; set; }
        [Column("pin_code_type")]
        public byte? PinCodeType { get; set; }
        [Column("pin_code_length")]
        public byte? PinCodeLength { get; set; }
        [Column("operation_note")]
        public string? OperationNote { get; set; }
        [Column("sales_note")]
        public string? SalesNote { get; set; }
        [Column("customer_service_note")]
        public string? CustomerServiceNote { get; set; }
        [Column("min_redeem_quantity")]
        public int MinRedeemQuantity { get; set; }
        [Column("max_issuing_quantity")]
        public int? MaxIssuingQuantity { get; set; }
        [Column("valid_from")]
        public DateTime ValidFrom { get; set; }
        [Column("valid_to")]
        public DateTime ValidTo { get; set; }
        [Column("reverse_limit_id")]
        public int ReverseLimitId { get; set; }
        [Column("pre_authorization_expiry_interval")]
        public int PreAuthorizationExpiryInterval { get; set; }
        [Column("pre_authorization_expiry_unit")]
        public int PreAuthorizationExpiryUnit { get; set; }
        [Column("use_time_control")]
        public short UseTimeControl { get; set; }
        [Column("use_time_control_interval")]
        public short UseTimeControlInterval { get; set; }
        [Column("max_total_redeem_amount_control")]
        public int MaxTotalRedeemAmountControl { get; set; }
        [Column("max_total_redeem_amount_control_interval")]
        public short MaxTotalRedeemAmountControlInterval { get; set; }
        [Column("max_single_redeem_amount")]
        public int MaxSingleRedeemAmount { get; set; }
        [Column("add_to_wallet")]
        public bool AddToWallet { get; set; }
        [Column("wallet_status")]
        public int? WalletStatus { get; set; }
        [Column("can_extend")]
        public bool CanExtend { get; set; }
        [Column("extension_scheme_id")]
        public int? ExtensionSchemeId { get; set; }
        [Column("max_extend_times")]
        public int? MaxExtendTimes { get; set; }
        [Column("extension_end_date")]
        public DateTime? ExtensionEndDate { get; set; }
        [Column("same_as_contract_end_date")]
        public bool? SameAsContractEndDate { get; set; }
        [Column("acceptance_loop_id")]
        public int? AcceptanceLoopId { get; set; }
        [Column("template_id")]
        public int? TemplateId { get; set; }
        [Column("price_id")]
        public int? PriceId { get; set; }
        [Column("expiry_scheme_id")]
        public int? ExpirySchemeId { get; set; }
        [Column("expiry_date")]
        public DateTime? ExpiryDate { get; set; }
        [Column("redeem_date_blacklist_id")]
        public int? RedeemDateBlacklistId { get; set; }
        [Column("redeem_time_restriction_id")]
        public int? RedeemTimeRestrictionId { get; set; }
        [Column("combo_id")]
        public int? ComboId { get; set; }
        [Column("external_property_id")]
        public int? ExternalPropertyId { get; set; }
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
        [Column("last_updated_by")]
        public string? LastUpdatedBy { get; set; }
        [Column("last_updated_on")]
        public DateTime? LastUpdatedOn { get; set; }
    }
}
