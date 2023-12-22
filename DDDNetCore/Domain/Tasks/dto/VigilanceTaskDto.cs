namespace DDDSample1.Domain.Tasks
{
    public class VigilanceTaskDto: TaskDto
    {
        public string RequestName { get; set; }
        public string RequestNumber { get; set; }
    
        // Additional properties if needed
    
        public VigilanceTaskDto(string id,string description, string user, string roomDest, string roomOrig,
            string requestName, string requestPhoneNumber, string robotId, string status)
            : base(id,description, user, roomDest, roomOrig,robotId,status)
        {
            RequestName = requestName;
            RequestNumber = requestPhoneNumber;
        }
    }
}