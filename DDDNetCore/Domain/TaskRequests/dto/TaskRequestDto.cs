namespace DDDNetCore.Domain.TaskRequests.dto
{


public class TaskRequestDto
{
    public string Id { get; set; }
    public string Description { get; set; }
    public string User { get; set; }
    public string RoomDest { get; set; }
    public string RoomOrig { get; set; }
    public string State { get; set; }
    
    // Additional properties if needed
    
    protected TaskRequestDto(string id,string description, string user, string roomDest, string roomOrig, string state)
    {
        Id = id;
        Description = description;
        User = user;
        RoomDest = roomDest;
        RoomOrig = roomOrig;
        State = state;
    }

}
}