using System.Collections.Generic;
using System.Linq;

namespace DDDSample1.Domain.Tasks.mappers;

public interface IDeliveryTaskMapper<T, TDTO> where T : DeliveryTask where TDTO : DeliveryTaskDto
{
    public TDTO ToDto(T task);

    public IEnumerable<TDTO> ToDTOList(IEnumerable<T> tasks)
    {
        return tasks.Select(ToDto);
    }

    public T ToEntity(DeliveryTaskDto dto);
}