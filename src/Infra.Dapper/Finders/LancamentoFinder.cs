using System;
using System.Threading.Tasks;
using CPObjects.Infrastructure.Finder;
using Dapper;
using Domain.Finders;
using Domain.Finders.Models;
using Infrastructure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infra.Dapper.Finders
{
    public class LancamentoFinder : FinderBase, ILancamentoFinder
    {
        public LancamentoFinder(IConfiguration configuration) : base(new DataProvider(configuration).SolutionDbContext)
        {

        }

        public async Task<LancamentoModel> ObterPor(Guid aggregateId, Pagination pagination)
        {
            const string QUERY = @"
            SELECT 
	            [l].[Saldo]
            FROM [RM].[Lancamentos] AS [l]
            WHERE [l].[AggregateId] = @AggregateId

            ;WITH [l] AS (
	            SELECT
		            [evt].[Data],
		            [le].[Descricao],
		            JSON_VALUE([evt].[Dados], '$.Valor') AS [Valor],
		            ROW_NUMBER() OVER (ORDER BY [evt].[Data] DESC) AS [RowNum]
	            FROM [RM].[Lancamentos] AS [l]
	            INNER JOIN [WM].[Events] AS [evt] ON [evt].[AggregateId] = [l].[AggregateId]
	            INNER JOIN [RM].[LancamentosEvento] AS [le] ON [le].[Evento] = [Evt].[Evento]
                WHERE [l].[AggregateId] = @AggregateId
            ) SELECT 
	            [l].[Data],
	            [l].[Descricao],
	            [l].[Valor]
            FROM [l]
            WHERE [l].[RowNum] > (@PageSize * (@PageNumber - 1))
            AND [l].[RowNum] <= (@PageSize * @PageNumber)
            ORDER BY [l].[RowNum]";

            using var conn = CreateSqlConnection();
            await using var multi = await conn.QueryMultipleAsync(QUERY, new {aggregateId, pagination.PageSize, pagination.PageNumber });

            var lancamento = await multi.ReadSingleOrDefaultAsync<LancamentoModel>();
            lancamento.Transacoes = await multi.ReadAsync<LancamentoTransacaoModel>();

            return lancamento;
        }
    }
}