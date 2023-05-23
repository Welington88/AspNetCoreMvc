using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetMvcRoles.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetMvcRoles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager; //herda IdentityUser
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = await _userManager.GetUserAsync(HttpContext.User); /// pegar usuario                                                          // 
                
                // Obtenha o usuário para o qual você deseja adicionar um login externo
                var user = await _userManager.FindByIdAsync(userId.Id);

                // Crie uma ClaimsIdentity com as informações do usuário
                var claimsIdentity = new ClaimsIdentity("AuthenticationTypeLogin");
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

                // Crie um ClaimsPrincipal com a ClaimsIdentity
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Crie o objeto ExternalLoginInfo com o ClaimsPrincipal e outras informações
                var externalLoginInfo = new ExternalLoginInfo(claimsPrincipal, "Microsoft " , "ProviderKey: " + HttpContext.Connection.RemoteIpAddress , "Ip: " + HttpContext.Connection.LocalIpAddress);

                // Adicione o login externo ao usuário
                await _userManager.AddLoginAsync(user, externalLoginInfo);
            }
            return View();
        }
        // criar usuário
        public IActionResult CriarUser()
        {
            criarUser();
            return Json(new { mensagem = "Usuário criado com Sucesso" });
        }

        private async void criarUser()
        {
            var newUser = new IdentityUser
            {
                UserName = "Neymar", // Nome de usuário
                Email = "neymar@santos.com.br", // Endereço de e-mail
                //PhoneNumber = "123456789" // Número de telefone (opcional)
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(newUser, "@Password123");
        }

        // alterar usuário
        public IActionResult AlterarUser()
        {
            var result = alterarUser();
            return Content($"Usuário Alterado {result}");
        }

        private async Task<string> alterarUser()
        {
            var userUpdate = await _userManager.FindByIdAsync("f3f4a0ca-5440-4fa3-afcb-d7e7d97e1d89");
            userUpdate.UserName = "neymarsantos@teste.com.br";
            userUpdate.EmailConfirmed = true;
            var result = await _userManager.UpdateAsync(userUpdate);

            return result.ToString();
        }

        // criar Role
        public IActionResult RoleUser()
        {
            roleUsers();
            return Content("Role Adicionada para usuario com sucesso");
        }

        //criar regra para usuario
        public async void roleUsers()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User); /// pegar usuario                                                          // 
                await _userManager.AddToRoleAsync(user, "Root"); //colocar regra e usuario

                _logger.LogInformation("Role Criada com Sucesso");
            }
        }

        // criar Role
        public IActionResult CriarRole()
        {
            var result = criarRoles();
            return Content(result.Result);
        }

        //criar regra para usuario
        public async Task<string> criarRoles()
        {
            var result = await _roleManager.CreateAsync(new IdentityRole("Test01")); // cria regra

            return result.ToString();
        }

        // alterar Role
        public IActionResult AlterarRole()
        {
            var result = alterarRoles();
            return Content(result.Result);
        }

        //alterar regra para usuario
        public async Task<string> alterarRoles()
        {
            var role = await _roleManager.FindByNameAsync("Test01"); // cria regra
            role.Name = "Coord";
            var result = await _roleManager.UpdateAsync(role); // cria regra

            return result.ToString();
        }


        // excluir Role
        public IActionResult ExcluirRole()
        {
            var result = excluirRoles();
            return Content(result.Result);
        }

        //excluir regra para usuario
        public async Task<string> excluirRoles()
        {
            var role = await _roleManager.FindByNameAsync("Coord"); // cria regra
            var result = await _roleManager.DeleteAsync(role); // cria regra

            return result.ToString();
        }

        // criar Role
        public IActionResult CriarClaim()
        {
            var result = criarClaims();
            return Content(result.Result);
        }

        //criar regra para usuario
        public async Task<string> criarClaims()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var claim = new Claim(ClaimTypes.Name, user.UserName);

            var claimRole = new Claim(ClaimTypes.Role, "Basic");

            var listClaims = new List<Claim>()
            {
                   claim,
                   claimRole
            };
            
            var result = await _userManager.AddClaimsAsync(user, listClaims);

            return result.ToString();
        }



        // Resert Password
        public IActionResult ResertPassword()
        {
            var result = resertPasswords();
            return Content($"Usuário Alterado {result}");
        }

        private async Task<string> resertPasswords()
        {
            var userReserPassword = await _userManager.FindByIdAsync("f6488c0e-a866-4960-a910-d660ca09edf2");
            var token = await _userManager.GeneratePasswordResetTokenAsync(userReserPassword);

            var result = await _userManager.ResetPasswordAsync(userReserPassword, token, "@Password123");

            return result.ToString();
        }

        // Gerar Token
        public IActionResult GerarToken()
        {
            var result = gerarTokens();
            return Json(result);
        }

        private async Task<string> gerarTokens()
        {
            var user = await _userManager.FindByIdAsync("f3f4a0ca-5440-4fa3-afcb-d7e7d97e1d89");
            
            var token = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "TokenAcesso");

            await _userManager.SetAuthenticationTokenAsync(user, "Microsoft", "TokenUserTest", token);

            return token;
        }

        // Gerar Token
        public IActionResult RoleClaim()
        {
            var result = roleClaims();
            return Json(result);
        }

        private async Task<string> roleClaims()
        {
            var role = await _roleManager.FindByNameAsync("Root");

            var claim = new Claim(ClaimTypes.Name, "wellintons@teste.com.br");

            var result = await _roleManager.AddClaimAsync(role, claim);

            return result.ToString();
        }

        //fim criar regra 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
