using System.Collections.Generic;
using System.Linq;
using DDDNetCore.Domain.TaskRequests.domain;


namespace DDDNetCore.Domain.TaskRequests.dto.mappers{

public interface IVigilanceTaskRequest<T, TDTO> where T : VigilanceTaskRequest where TDTO : VigilanceTaskRequestDto
{
    public TDTO ToDTO(T task);

    public IEnumerable<TDTO> ToDTOList(IEnumerable<T> tasks)
    {
        return tasks.Select(ToDTO);
    }

    public T ToEntity( VigilanceTaskRequestDto dto);
}
}