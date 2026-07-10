using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.User.ChangeUserToPremium;

public class ChangeUserToPremiumResponse(int Id, string FullName, string Email, UserLevelEnum Level, UserStatusEnum Status);