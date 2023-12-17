namespace DDDSample1.Domain.Tasks.mappers;

using System.Linq;
using System.Collections.Generic;


public interface ITaskMapper<T, TDTO> where T : Task where TDTO : TaskDto
{
    public TDTO ToDTO(T task);

    public IEnumerable<TDTO> ToDTOList(IEnumerable<T> tasks)
    {
        return tasks.Select(ToDTO);
    }

    public T ToEntity( TaskDto dto);
}
