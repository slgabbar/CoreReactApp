﻿namespace API.Dtos
{
    public class UserLoginDataDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
    }
}
