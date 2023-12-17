namespace DDDNetCore.Domain.TaskRequests.dto{

public class VigilanceTaskRequestDto: TaskRequestDto
{
    public string RequestName { get; set; }
    public string RequestNumber { get; set; }
        
    
    public VigilanceTaskRequestDto(string id,string description, string user, string roomDest, string roomOrig, 
        string destName, string destPhoneNumber, string state)
        : base(id,description, user, roomDest, roomOrig, state)
    {
       
        RequestName = destName;
        RequestNumber = destPhoneNumber;
        
    }
}
}