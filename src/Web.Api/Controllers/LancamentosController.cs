using Domain.Dtos;
using Domain.Services;
using Infrastructure.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CPObjects.Infrastructure.Finder;
using Domain.Finders;

namespace Web.Api.Controllers
{
    [Route("lancamentos")]
    public class LancamentosController : ControllerBase
    {
        private readonly IDomainService _domainService;
        private readonly ILancamentoFinder _lancamentosFinder;

        public LancamentosController(IDomainService domainService, ILancamentoFinder lancamentosFinder)
        {
            _domainService = domainService;
            _lancamentosFinder = lancamentosFinder;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync()
        {
            await _domainService
                .NewGuid(out var aggregateId)
                .Execute<ILancamentoService>(async service => await service.CriarAsync(aggregateId))
                .CommitAsync();

            return Ok(aggregateId);
        }

        [HttpGet("{aggregateId}")]
        public async Task<IActionResult> ObterAsync(Guid aggregateId, [FromQuery]Pagination pagination)
        {
            return Ok(await _lancamentosFinder.ObterPor(aggregateId, pagination));
        }

        [HttpPut("{aggregateId}/debitar")]
        public async Task<IActionResult> DebitarAsync(Guid aggregateId, [FromBody] RealizarLancamentoDto dto)
        {
            await _domainService
                .Execute<ILancamentoService>(async service => await service.DebitarAsync(aggregateId, dto.Valor))
                .CommitAsync();

            return Ok(aggregateId);
        }

        [HttpPut("{aggregateId}/creditar")]
        public async Task<IActionResult> CreditarAsync(Guid aggregateId, [FromBody] RealizarLancamentoDto dto)
        {
            await _domainService
                .Execute<ILancamentoService>(async service => await service.CreditarAsync(aggregateId, dto.Valor))
                .CommitAsync();

            return Ok(aggregateId);
        }
    }
}
