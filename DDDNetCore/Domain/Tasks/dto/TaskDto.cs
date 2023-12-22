namespace DDDSample1.Domain.Tasks
{
    public  class TaskDto
    {
        
        public string Id { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public string RoomDest { get; set; }
        public string RoomOrig { get; set; }
        
        public string RobotId { get; set; }
        
        public string Status { get; set; }

      
        // Additional properties if needed
    
        protected TaskDto(string id ,string description, string user, string roomDest, string roomOrig, string robotId,string status)
        {
            Id = id;
            Description = description;
            User = user;
            RoomDest = roomDest;
            RoomOrig = roomOrig;
            RobotId = robotId;
            Status = status;
        }
        
    }
}