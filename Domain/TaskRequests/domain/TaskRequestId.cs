﻿using System;
using DDDSample1.Domain.Shared;
using Newtonsoft.Json;

namespace DDDNetCore.Domain.TaskRequests.domain{

public class TaskRequestId: EntityId
{
    [JsonConstructor]
        
    public TaskRequestId(Guid value) : base(value)
    {
    }

    public TaskRequestId(String value) : base(value)
    {
            
    }
        
        
    override 
        protected  Object createFromString(String text)
    {
        return new Guid(text);
    }
        
        
    override 
        public String AsString()
    {
        Guid obj = (Guid)base.ObjValue;
        return obj.ToString();
    }

    public Guid AsGuid()
    {
        return (Guid)base.ObjValue;
    }
}
}