using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;

namespace ITEC_API.IServices
{
    public interface IAdminAuthService
    {
        Task<List<RoleResponse>> getAllRoles();
        Task addAccount(RegisterAccounRequest registerAccounRequest);
        Task<List<AccounNameResponse>> getAllAccounts();
        Task addPassword(PasswordRequest passwordRequest);
        Task<string> login(loginRequest loginRequest);
    }
}
