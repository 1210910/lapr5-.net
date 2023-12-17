using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Tasks
{
    public abstract class Task : Entity<TaskId>, IAggregateRoot
    {
        
        public string Description { get; private set; }
        
        public string User { get; private set; }
        
        public string RoomDest { get; private set; }
        
        public string RoomOrig { get; private set; }
        
        


        protected Task(string description, string user, string roomDest, string roomOrig)
        {
           
            this.Description = description;
            this.User = user;
            this.RoomOrig = roomOrig;
            this.RoomDest = roomDest;
            
        }


        protected void changeDescription(string dtoDescription)
        {
            this.Description = dtoDescription;
        }
    }
}