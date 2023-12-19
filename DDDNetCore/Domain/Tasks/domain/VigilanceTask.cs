using DDDSample1.Domain.Shared.generalValueObjects;

namespace DDDSample1.Domain.Tasks
{
    public class VigilanceTask : Task
    {
        public PhoneNumber RequestNumber { get; private set; }
        
        public Name RequestName { get; private set; }
        
        public VigilanceTask(string description, string user, string roomDest, string roomOrig,string requestName,string requestPhoneNumber) : base(description, user, roomDest, roomOrig)
        {
            this.RequestName=new Name(requestName);
            this.RequestNumber = new PhoneNumber(requestPhoneNumber);
        }

        public void ChangeDescription(string dtoDescription)
        {
            base.changeDescription(dtoDescription);
        }
    }
}