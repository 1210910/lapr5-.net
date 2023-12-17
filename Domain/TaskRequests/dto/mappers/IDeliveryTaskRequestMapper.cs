using System.Collections.Generic;
using System.Linq;
using DDDNetCore.Domain.TaskRequests.domain;


namespace DDDNetCore.Domain.TaskRequests.dto.mappers
{
    public interface IDeliveryTaskRequestMapper<T, TDTO> where T : DeliveryTaskRequest where TDTO : DeliveryTaskRequestDto
    {
        public TDTO ToDTO(T task);

        public IEnumerable<TDTO> ToDTOList(IEnumerable<T> tasks)
        {
            return tasks.Select(ToDTO);
        }

        public T ToEntity(DeliveryTaskRequestDto dto);
    }
}

