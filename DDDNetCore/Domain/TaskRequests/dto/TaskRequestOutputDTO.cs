using DDDNetCore.Domain.TaskRequests.domain;

namespace DDDNetCore.Domain.TaskRequests.dto;

public class TaskRequestOutputDTO
{
    public string Id { get; set; }
    public string Description { get; set; }
    public string User { get; set; }
    public string RoomDest { get; set; }
    public string RoomOrig { get; set; }
    public string State { get; set; }
    
    public string UserFriendlyId { get; set; }
    
    // public string Date { get; set; }
    
    protected TaskRequestOutputDTO() { }
    // Additional properties if needed
    public TaskRequestOutputDTO (string id,string description, string user, 
        string roomDest, string roomOrig, string state)
    {
        Id = id;
        Description = description;
        User = user;
        RoomDest = roomDest;
        RoomOrig = roomOrig;
        State = state;
        if (string.IsNullOrEmpty(id)) { UserFriendlyId = ""; }
        else { UserFriendlyId = Id.Substring(0, 6);; }
       
    }

}