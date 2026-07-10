using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.User.UpdateUser;

public class UpdateUserResponse(int Id, string FullName, string Email, UserLevelEnum Level, UserStatusEnum Status);