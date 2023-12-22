using DDDSample1.Domain.Shared.generalValueObjects;

namespace DDDNetCore.Domain.TaskRequests.domain
{

    public class DeliveryTaskRequest : TaskRequest
    {
        
        public PhoneNumber DestPhoneNumber { get; private set; }

        public PhoneNumber OrigPhoneNumber { get; private set; }

        public Code ConfirmationCode { get; private set; }

        public Name OrigName { get; private set; }

        public Name DestName { get; private set; }

        public DeliveryTaskRequest(string description, string user, string roomDest, string roomOrig,
            string destName, string origName, string destPhoneNumber, string origPhoneNumber, string code
        ) : base(description, user, roomDest, roomOrig)
        {
            this.DestName = new Name(destName);
            this.OrigName = new Name(origName);
            this.DestPhoneNumber = new PhoneNumber(destPhoneNumber);
            this.OrigPhoneNumber = new PhoneNumber(origPhoneNumber);
            this.ConfirmationCode = Code.Create(code);
        }
        
        private DeliveryTaskRequest() : base()
        {
            // Valores padrão ou nulos podem ser atribuídos aqui
        }
        
        


        public new void aproveRequest()
        {
            base.aproveRequest();
        }

        public new void rejectRequest()
        {
            base.rejectRequest();
        }

    }
}