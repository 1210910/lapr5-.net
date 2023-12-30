using DDDSample1.Domain.Shared.generalValueObjects;

namespace DDDNetCore.Domain.TaskRequests.dto{

public class DeliveryTaskRequestDto: TaskRequestOutputDTO
{
    public string DestName { get; set; }
    public string OrigName { get; set; }
    public string DestPhoneNumber { get; set; }
    public string OrigPhoneNumber { get; set; }
    public string ConfirmationCode { get; set; }
    
    protected DeliveryTaskRequestDto() { }
    
    public DeliveryTaskRequestDto(string id ,string description, string user, string roomDest, string roomOrig, 
        string destName, string origName, string destPhoneNumber, string origPhoneNumber,
        string state, string confirmationCode)
        : base(id,description, user, roomDest, roomOrig, state)
    {
        DestName = destName;
        OrigName = origName;
        DestPhoneNumber = destPhoneNumber;
        OrigPhoneNumber = origPhoneNumber;
        ConfirmationCode = confirmationCode;
        
    }
}
}