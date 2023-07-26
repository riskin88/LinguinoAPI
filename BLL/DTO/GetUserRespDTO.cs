namespace BLL.DTO
{
    public class GetUserRespDTO
    {
        public string? id { get; set; }
        public string? username { get; set; }
        public long? streak { get; set; }
        public long? balance { get; set; }
        public bool? accountInitialized { get; set; }
    }
}
