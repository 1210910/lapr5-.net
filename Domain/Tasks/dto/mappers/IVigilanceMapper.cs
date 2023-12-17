namespace DDDSample1.Domain.Tasks.mappers;

using System.Linq;
using System.Collections.Generic;


public interface IVigilanceMapper<T, TDTO> where T : VigilanceTask where TDTO : VigilanceTaskDto
{
    public TDTO ToDTO(T task);

    public IEnumerable<TDTO> ToDTOList(IEnumerable<T> tasks)
    {
        return tasks.Select(ToDTO);
    }

    public T ToEntity( VigilanceTaskDto dto);
}