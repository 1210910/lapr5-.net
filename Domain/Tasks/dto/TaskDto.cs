namespace DDDSample1.Domain.Tasks
{
    public  class TaskDto
    {
        
        public string Id { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public string RoomDest { get; set; }
        public string RoomOrig { get; set; }
      
        // Additional properties if needed
    
        protected TaskDto(string id ,string description, string user, string roomDest, string roomOrig)
        {
            Id = id;
            Description = description;
            User = user;
            RoomDest = roomDest;
            RoomOrig = roomOrig;
        }
        
    }
}