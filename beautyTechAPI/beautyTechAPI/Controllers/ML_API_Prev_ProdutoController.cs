using Microsoft.AspNetCore.Mvc;
using beautyTechAPI.Data;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace beautyTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_ML_PREV_PRODUTO : ControllerBase
    {
        private readonly MLContext _mlContext;
        private ITransformer _modeloTreinado;
        private readonly AppDbContext _context;

        public API_ML_PREV_PRODUTO(AppDbContext context)
        {
            _mlContext = new MLContext();
            _context = context;

            var dadosTreinamento = CarregarDadosTreinamento();
            if (dadosTreinamento.Count == 0)
            {
                throw new InvalidOperationException("O conjunto de dados de treinamento está vazio.");
            }

            _modeloTreinado = TreinarModelo(dadosTreinamento);
        }

        public class ClienteInput
        {
            public string PELE_CLIENTE { get; set; }
            public string ESTADO_CIVIL_CLIENTE { get; set; }
            public string CABELO_CLIENTE { get; set; }
        }

        public class ProdutoOutput
        {
            public int ID_PRODUTO { get; set; }
            public string NM_PRODUTO { get; set; }
        }

        private List<ClienteProdutoData> CarregarDadosTreinamento()
        {
            var historico = (from h in _context.HistoricoPesquisa
                             join c in _context.Clientes on h.ID_CLIENTE equals c.ID_CLIENTE
                             join p in _context.Produtos on h.ID_PRODUTO equals p.ID_PRODUTO
                             select new ClienteProdutoData
                             {
                                 PELE_CLIENTE = c.PELE_CLIENTE,
                                 ESTADO_CIVIL_CLIENTE = c.ESTADO_CIVIL_CLIENTE,
                                 CABELO_CLIENTE = c.CABELO_CLIENTE,
                                 NM_PRODUTO = p.NM_PRODUTO
                             }).ToList();

            // Log para verificar a contagem de dados
            Console.WriteLine($"Total de instâncias carregadas: {historico.Count}");

            return historico;
        }

        public class ClienteProdutoData
        {
            [LoadColumn(0)] public string PELE_CLIENTE { get; set; }
            [LoadColumn(1)] public string ESTADO_CIVIL_CLIENTE { get; set; }
            [LoadColumn(2)] public string CABELO_CLIENTE { get; set; }
            [LoadColumn(3)] public string NM_PRODUTO { get; set; }
        }

        public class ProdutoPrediction
        {
            [ColumnName("PredictedLabel")] public string PredictedProduto { get; set; }
        }

        private ITransformer TreinarModelo(List<ClienteProdutoData> dadosTreinamento)
        {
            var dados = _mlContext.Data.LoadFromEnumerable(dadosTreinamento);

            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(ClienteProdutoData.NM_PRODUTO))
                .Append(_mlContext.Transforms.Categorical.OneHotEncoding("PELE_CLIENTE"))
                .Append(_mlContext.Transforms.Categorical.OneHotEncoding("ESTADO_CIVIL_CLIENTE"))
                .Append(_mlContext.Transforms.Categorical.OneHotEncoding("CABELO_CLIENTE"))
                .Append(_mlContext.Transforms.Concatenate("Features", "PELE_CLIENTE", "ESTADO_CIVIL_CLIENTE", "CABELO_CLIENTE"))
                .Append(_mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var modelo = pipeline.Fit(dados);
            return modelo;
        }

        // Método assíncrono para a previsão de produto
        [HttpGet("recommend")]
        public async Task<ActionResult<ProdutoOutput>> Recommend([FromQuery] int clientId)
        {
            var cliente = await _context.Clientes.FindAsync(clientId);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            var input = new ClienteInput
            {
                PELE_CLIENTE = cliente.PELE_CLIENTE,
                ESTADO_CIVIL_CLIENTE = cliente.ESTADO_CIVIL_CLIENTE,
                CABELO_CLIENTE = cliente.CABELO_CLIENTE
            };

            var previsao = PreverProduto(input);
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.NM_PRODUTO == previsao);

            if (produto == null)
            {
                return NotFound("Produto recomendado não encontrado.");
            }

            return new ProdutoOutput
            {
                ID_PRODUTO = produto.ID_PRODUTO,
                NM_PRODUTO = produto.NM_PRODUTO
            };
        }

        private string PreverProduto(ClienteInput cliente)
        {
            var dadosCliente = new ClienteProdutoData
            {
                PELE_CLIENTE = cliente.PELE_CLIENTE,
                ESTADO_CIVIL_CLIENTE = cliente.ESTADO_CIVIL_CLIENTE,
                CABELO_CLIENTE = cliente.CABELO_CLIENTE
            };

            var dadosParaPrevisao = _mlContext.Data.LoadFromEnumerable(new List<ClienteProdutoData> { dadosCliente });
            var previsoes = _modeloTreinado.Transform(dadosParaPrevisao);
            var preditor = _mlContext.Data.CreateEnumerable<ProdutoPrediction>(previsoes, reuseRowObject: false).FirstOrDefault();

            return preditor?.PredictedProduto ?? "Produto não encontrado";
        }
    }
}
