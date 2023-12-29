namespace DDDNetCore.Domain.TaskRequests.dto{

public class VigilanceTaskRequestDto: TaskRequestDto
{
    public string RequestName { get; set; }
    public string RequestPhoneNumber { get; set; }
        
    protected VigilanceTaskRequestDto() { }

    public VigilanceTaskRequestDto(string id,string description, string user, string roomDest, string roomOrig, 
        string requestName, string requestPhoneNumber, string state)
        : base(id,description, user, roomDest, roomOrig, state)
    {
       
        RequestName = requestName;
        RequestPhoneNumber = requestPhoneNumber;
        
    }
}
}