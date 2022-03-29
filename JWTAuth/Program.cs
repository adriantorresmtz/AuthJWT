using JWTAuth.Extensions;
using JWTAuth.Models;
using JWTAuth.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Define Configuration
builder.Services.AddConfig(builder.Configuration);
var app = builder.Build();

// Define Routers
#region Routers

    app.MapPost("/login",
        (UserLogin user, IUserService service) => Login(user, service));

#endregion

// Actions
#region Actions

    IResult Login(UserLogin user, IUserService service) 
    {
        var loggedUser = service.Get(user);

        if (loggedUser is null) return Results.NotFound("User not found");

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, loggedUser.Username),
            new Claim(ClaimTypes.Email, loggedUser.EmailAddress),
            new Claim(ClaimTypes.GivenName, loggedUser.GivenName),
            new Claim(ClaimTypes.Surname, loggedUser.Surname),
            new Claim(ClaimTypes.Role, loggedUser.Rol)
        };

        var token = new JwtSecurityToken
        (
            issuer: builder.Configuration["Jwt:Issuer"],
            audience: builder.Configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(5),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])), 
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        string[] roles = new string[1] { loggedUser.Rol };

        var reponse = new { token = tokenString, role = roles };

        return Results.Ok(reponse);
    }
    
#endregion

// Set Configuration
app.SetServices();
app.Run();
