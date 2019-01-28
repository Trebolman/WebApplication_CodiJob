using Application.DTOs;
using Application.DTOs.CustomDTO;
using Application.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Transversal.Authentication
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private IUsuarioPerfilService ServiceUsuarioPerfil;
        private readonly AppSettings _appSettings;
        public UserService(UserManager<IdentityUser> userMgr,
        SignInManager<IdentityUser> signInMgr,
        IUsuarioPerfilService serviceUsuarioPerfil,
        IOptions<AppSettings> appSettings)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            ServiceUsuarioPerfil = serviceUsuarioPerfil;
            _appSettings = appSettings.Value;
        }
        public async Task<UsuarioPerfilDTO> AuthenticateAsync(string username, string
        password)
        {
            IdentityUser Iuser = await userManager.FindByNameAsync(username);
            if (Iuser != null)
            {
                await signInManager.SignOutAsync();
                if ((await signInManager.PasswordSignInAsync(Iuser, password, false,
                false)).Succeeded)
                {
                    var UserDTO = ServiceUsuarioPerfil.GetUsuarioPerfil(Guid.Parse(Iuser.Id));

                    //Add WebToken after Login sucsessfully
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, UserDTO.UsuperId.ToString())
                    }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    UserDTO.Token = tokenHandler.WriteToken(token);

                    return UserDTO;
                }
            }
            return null;
        }

        public async Task AddUserAsync(AddUserDTO dto)
        {
            IdentityUser userExist = await userManager.FindByNameAsync(dto.UserName);
            if (userExist == null)
            {
                Guid NewId = Guid.NewGuid();
                userExist = new IdentityUser(dto.UserName);
                userExist.Id = NewId.ToString();
                IdentityResult result = await userManager.CreateAsync(userExist, dto.Password);
                StringBuilder Stringerror = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    Stringerror.Append(error.Description);
                    Stringerror.Append("\n");
                }
                if (result.Errors.Count() > 0)
                {
                    throw new Exception(Stringerror.ToString());
                }
                else
                {
                    UsuarioPerfilDTO usuartioPerfilDTO = new UsuarioPerfilDTO()
                    {
                        UsuperId = NewId,
                        UsuperDesc = dto.Descripcion,
                        UsuperGit = dto.Git,
                        UsuperBlog = dto.Blog,
                        UsuperWeb = dto.Web
                    };
                    await ServiceUsuarioPerfil.InsertWithID(usuartioPerfilDTO);
                }
            }
            else
            {
                throw new Exception($"The username({dto.UserName}) is being used");
            }
        }
    }
    public class AppSettings
    {
        public string Secret { get; set; }
    }
}