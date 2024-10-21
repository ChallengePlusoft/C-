using beautyTech.DTO;
using beautyTech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace beautyTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET: Exibe a página de login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Faz o login e obtém o token JWT
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.PostAsJsonAsync("api/Auth/login", loginViewModel); // Rota de login

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                var token = loginResponse?.Token;

                // Armazenar o token JWT em uma sessão
                HttpContext.Session.SetString("JWToken", token);

                // Redirecionar para a página de listagem de produtos
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login falhou. Verifique suas credenciais.");
                return View(loginViewModel);
            }
        }

        // Exemplo de como usar o token para acessar rotas privadas
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("APIClient");

            // Adicionar o token JWT no cabeçalho das requisições
            var token = HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login"); // Redireciona se não houver token
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            List<Produto> produtos = null;
            List<Empresa> empresas = null;
            List<Cliente> clientes = null;

            // Buscar produtos
            HttpResponseMessage responseProdutos = await client.GetAsync("api/produtos"); // Rota protegida da API
            if (responseProdutos.IsSuccessStatusCode)
            {
                produtos = await responseProdutos.Content.ReadFromJsonAsync<List<Produto>>();
            }

            // Buscar empresas
            HttpResponseMessage responseEmpresas = await client.GetAsync("api/empresas"); // Rota protegida da API
            if (responseEmpresas.IsSuccessStatusCode)
            {
                empresas = await responseEmpresas.Content.ReadFromJsonAsync<List<Empresa>>();
            }

            // Buscar clientes
            HttpResponseMessage responseClientes = await client.GetAsync("api/clientes"); // Rota protegida da API
            if (responseClientes.IsSuccessStatusCode)
            {
                clientes = await responseClientes.Content.ReadFromJsonAsync<List<Cliente>>();
            }

            // Passando os dados para a View usando ViewBag
            ViewBag.Produtos = produtos;
            ViewBag.Empresas = empresas;
            ViewBag.Clientes = clientes;

            return View();
        }
    }
}
