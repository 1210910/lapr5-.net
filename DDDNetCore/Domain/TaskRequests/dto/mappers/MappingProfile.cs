using DDDNetCore.Domain.TaskRequests.domain;
using DDDSample1.Domain.Shared.generalValueObjects;

namespace DDDNetCore.Domain.TaskRequests.dto.mappers;

using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TaskRequestId, string>().ConvertUsing(id => id.Value);
        CreateMap<Code, string>().ConvertUsing(confirmationCode => confirmationCode.Value);
        CreateMap<TaskRequest, TaskRequestOutputDTO>()
            .Include<DeliveryTaskRequest, DeliveryTaskRequestDto>()
            .Include<VigilanceTaskRequest, VigilanceTaskRequestDto>();
        // Add mappings for other subclasses if needed
        CreateMap<DeliveryTaskRequest, DeliveryTaskRequestDto>(); // Map DeliveryTaskRequest to DeliveryTaskRequestDto
        CreateMap<VigilanceTaskRequest, VigilanceTaskRequestDto>(); // Map VigilanceTaskRequest to VigilanceTaskRequestDto
    }
}