using System;
using DDDSample1.Domain.Shared;

namespace DDDNetCore.Domain.TaskRequests.dto{

public class VigilanceTaskRequestDto: TaskRequestOutputDTO
{
    public string RequestName { get; set; }
    public string RequestNumber { get; set; }
        
    protected VigilanceTaskRequestDto() { }

    public VigilanceTaskRequestDto(string id,string description, string user, string roomDest, string roomOrig, 
        string requestName, string requestNumber, string state)
        : base(id,description, user, roomDest, roomOrig, state, TaskTypeEnum.Vigilance.ToString())
    {
       
        RequestName = requestName;
        RequestNumber = requestNumber;
        
    }
}
}