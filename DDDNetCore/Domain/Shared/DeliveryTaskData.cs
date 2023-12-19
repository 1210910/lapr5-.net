namespace DDDSample1.Domain.Shared
{
    public class DeliveryTaskData
    {
        public string description { get; set; }
        public string user { get; set; }
        public string roomDest { get; set; }
        public string roomOrig { get; set; }
        public string destName { get; set; }
        public string origName { get; set; }
        public string destPhoneNumber { get; set; }
        public string origPhoneNumber { get; set; }
        
        public string code { get; set; }
    }
}