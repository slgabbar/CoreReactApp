using API.Dtos;
using API.Entities;
using API.Models;
using API.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MimeKit;
using System.IO;
using System.IO.Compression;
using System.Linq.Expressions;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : BaseApiController
{
    private readonly IUserService _userService;
    
    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) =>
        CommandResult(await _userService.LoginUser(loginDto));

    [HttpPost("register")]
    public async Task<ActionResult<bool>> Register(RegisterDto registerDto) =>
        CommandResult(await _userService.RegisterUser(registerDto, Request));

    [HttpPost("resetPasswordRequest")]
    public async Task<ActionResult<bool>> ResetPasswordRequest(ResetPasswordRequestDto resetPasswordRequestDto) =>
        CommandResult(await _userService.ResetPasswordRequest(resetPasswordRequestDto, Request));

    [HttpPost("resetPassword")]
    public async Task<ActionResult<bool>> ResetPassword(ResetPasswordDto resetPasswordDto) =>
     CommandResult(await _userService.ResetPassword(resetPasswordDto));

    [HttpPost("confirmEmail")]
    public async Task<ActionResult<bool>> ConfirmEmail(ConfirmEmailDto confirmEmailDto) =>
        CommandResult(await _userService.ConfirmEmail(confirmEmailDto));

    [Authorize]
    [HttpPost("changePassword")]
    public async Task<ActionResult<bool>> ChangePassword(ChangePasswordDto changePasswordDto) =>
      CommandResult(await _userService.ChangePassword(changePasswordDto));

    [Authorize]
    [HttpPost("changeEmail")]
    public async Task<ActionResult<UserDto>> ChangeEmail(ChangeEmailDto changeEmailDto) =>
      CommandResult(await _userService.ChangeEmail(changeEmailDto));

    [Authorize]
    [HttpPost("profileEdit")]
    public async Task<ActionResult<UserDto>> ProfileEdit(ProfileEditDto profileEditDto) =>
        CommandResult(await _userService.ProfileEdit(User.Identity!.Name!, profileEditDto));

    [Authorize]
    [HttpPost("avatarEdit")]
    public async Task<ActionResult<UserDto>> EditAvatar([FromForm] AvatarEditDto avatarEditDto) =>
        CommandResult(await _userService.AvatarEdit(User.Identity!.Name!, avatarEditDto));

    [Authorize]
    [HttpGet("currentUser")]
    public async Task<ActionResult<UserDto>> GetCurrentUser() =>
        await _userService.GetCurrentUserAsync(User.Identity!.Name!);
}
