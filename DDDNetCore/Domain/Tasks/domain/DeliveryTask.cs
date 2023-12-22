using DDDSample1.Domain.Shared.generalValueObjects;

namespace DDDSample1.Domain.Tasks
{
    public class DeliveryTask : Task
    {
        
        public PhoneNumber DestPhoneNumber { get; private set; }
        
        public PhoneNumber OrigPhoneNumber { get; private set; }
        
        public Code ConfirmationCode { get; private set; }
        
        public Name OrigName { get; private set; }
        
        public Name DestName { get; private set; }
        
        
        public DeliveryTask(string description,string user ,string roomDest,string roomOrigin , 
            string destName , string origName, string destPhoneNumber, string origPhoneNumber, string code, string id , string robotId )
            : base (id,description,user,roomDest,roomOrigin,robotId)
        {
            this.DestName =new Name(destName);
            this.OrigName=new Name(origName);
            this.DestPhoneNumber= new PhoneNumber(destPhoneNumber);
            this.OrigPhoneNumber= new PhoneNumber(origPhoneNumber);
            this.ConfirmationCode= Code.Create(code);
        }
        
        private DeliveryTask() : base()
        {
            // Valores padrão ou nulos podem ser atribuídos aqui
        }

        public void ChangeDescription(string dtoDescription)
        {
            base.changeDescription(dtoDescription);
        }
        
        public void StartTask()
        {
            base.startTask();
        }
        
        public void FinishTask()
        {
            base.finishTask();
        }
    }
}