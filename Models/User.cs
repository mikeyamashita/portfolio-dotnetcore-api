using Microsoft.AspNetCore.Identity;

namespace TodoApi.Models;

public class User : IdentityUser
{
    public string? NickName { get; set; }
}