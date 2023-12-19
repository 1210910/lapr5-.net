namespace DDDSample1.Domain.Tasks
{
    public class VigilanceTaskDto: TaskDto
    {
        public string RequestName { get; set; }
        public string RequestNumber { get; set; }
    
        // Additional properties if needed
    
        public VigilanceTaskDto(string id,string description, string user, string roomDest, string roomOrig,
            string requestName, string requestPhoneNumber)
            : base(id,description, user, roomDest, roomOrig)
        {
            RequestName = requestName;
            RequestNumber = requestPhoneNumber;
        }
    }
}