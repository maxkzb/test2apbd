using Test2A.DTOs;

namespace Test2A.Services;

public interface IDbService
{
    Task<RacerParticipationDto> GetRacerParticipation(int racerId);
    //Task<GetCustomerPurchasesDTO?> GetCustomerPurchasesAsync(int customerId);
    //Task<(bool Success, string ErrorMessage)> AddWashingMachineWithProgramAsync(
      //  AddWashingMachineDTO addWashingMachineDto);
}