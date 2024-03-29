﻿using API.Dtos;

namespace API.Services
{
    public interface IUserService
    {
        Task<CommandResult<UserDto>> LoginUser(LoginDto loginDto);
        
        Task<CommandResult<bool>> RegisterUser(RegisterDto registerDto, HttpRequest request);

        Task<CommandResult<bool>> ResetPasswordRequest(ResetPasswordRequestDto resetPasswordRequestDto, HttpRequest request);
        
        Task<CommandResult<bool>> ResetPassword(ResetPasswordDto resetPasswordDto);

        Task<CommandResult<bool>> ConfirmEmail(ConfirmEmailDto confirmEmailDto);

        Task<CommandResult<bool>> ChangePassword(ChangePasswordDto changePasswordDto);
        
        Task<CommandResult<UserDto>> ChangeEmail(ChangeEmailDto changeEmailDto);

        Task<CommandResult<UserDto>> ProfileEdit(string userName, ProfileEditDto profileEditDto);

        Task<CommandResult<UserDto>> AvatarEdit(string userName, AvatarEditDto avatarEditDto);

        Task<UserDto> GetCurrentUserAsync(string userName);
    }
}
