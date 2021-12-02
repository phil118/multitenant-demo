using Finbuckle.MultiTenant;

namespace MultiTenant.Models {
    public class TenantViewModel : ITenantInfo
    {
        public string? Id { get; set; }
        public string? Identifier { get; set; }
        public string? Name { get; set; }
        public string? Css { get; set; }
        public string? NFT { get; set; }
        public string? ConnectionString { get ; set ; }
    }
}