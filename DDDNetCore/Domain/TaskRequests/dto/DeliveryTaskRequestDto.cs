namespace DDDNetCore.Domain.TaskRequests.dto{

public class DeliveryTaskRequestDto: TaskRequestDto
{
    public string DestName { get; set; }
    public string OrigName { get; set; }
    public string DestPhoneNumber { get; set; }
    public string OrigPhoneNumber { get; set; }
    public string Code { get; set; }
    
        
    
    public DeliveryTaskRequestDto(string id ,string description, string user, string roomDest, string roomOrig, 
        string destName, string origName, string destPhoneNumber, string origPhoneNumber,string state, string code)
        : base(id,description, user, roomDest, roomOrig, state)
    {
        DestName = destName;
        OrigName = origName;
        DestPhoneNumber = destPhoneNumber;
        OrigPhoneNumber = origPhoneNumber;
        Code = code;
        
    }
}
}