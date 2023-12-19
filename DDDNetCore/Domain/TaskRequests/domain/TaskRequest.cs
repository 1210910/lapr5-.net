
using System;
using DDDSample1.Domain.Shared;

namespace DDDNetCore.Domain.TaskRequests.domain
{

    public abstract class TaskRequest : Entity<TaskRequestId>, IAggregateRoot
    {
        
        public string Description { get; private set; }

        public string User { get; private set; }

        public string RoomDest { get; private set; }

        public string RoomOrig { get; private set; }

        public string State { get; private set; }


        protected TaskRequest(string description, string user, string roomDest, string roomOrig)
        {
            if (string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(roomDest) || string.IsNullOrWhiteSpace(roomOrig))
            {
                throw new ArgumentException("The description of the task request cannot be null or empty.");
            }
            this.Id = new TaskRequestId(Guid.NewGuid());
            this.Description = description;
            this.User = user;
            this.RoomOrig = roomOrig;
            this.RoomDest = roomDest;
            this.State = States.Pending.ToString();

        }
        
        private TaskRequest() 
        {
            // Valores padrão ou nulos podem ser atribuídos aqui
        }


        protected void aproveRequest()
        {
            this.State = States.Accepted.ToString();
        }

        protected void rejectRequest()
        {
            this.State = States.Rejected.ToString();
        }

    }
}