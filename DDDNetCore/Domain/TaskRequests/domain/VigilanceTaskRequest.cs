using DDDSample1.Domain.Shared.generalValueObjects;

namespace DDDNetCore.Domain.TaskRequests.domain
{


public class VigilanceTaskRequest: TaskRequest
{
    public PhoneNumber RequestNumber { get; private set; }
        
    public Name RequestName { get; private set; }
    
    public VigilanceTaskRequest(string description, string user, string roomDest, string roomOrig
        ,string requestName,string requestPhoneNumber) : base(description, user, roomDest, roomOrig)
    {
        this.RequestName=new Name(requestName);
        this.RequestNumber = new PhoneNumber(requestPhoneNumber);
    }
    
    private VigilanceTaskRequest() : base("", "", "", "")
    {
        // Valores padrão ou nulos podem ser atribuídos aqui
    }
    public void approve()
    {
        base.aproveRequest();
    }
    
    public void reject()
    {
        base.rejectRequest();
    }
    
}
}