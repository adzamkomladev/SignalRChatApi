﻿using Microsoft.EntityFrameworkCore;
using SignalRChatApi.Data.Dtos.Users;
using SignalRChatApi.Domains;
using SignalRChatApi.Repositories;

namespace SignalRChatApi.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User?> CreateAsync(CreateUserDto userDto)
    {
        var user = await _unitOfWork.Users.FindByUsername(userDto.Username);

        if (user is not null) return null;

        user = new User
        {
            Username = userDto.Username
        };

        await _unitOfWork.Users.Add(user);
        await _unitOfWork.Complete();

        return user;
    }
}