using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.User.ChangeUserStatusToActive;

public class ChangeUserStatusToActiveResponse(int Id, string FullName, string Email, UserLevelEnum Level, UserStatusEnum Status);