using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Domain
{
    public class DomainService : IDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceProvider _provider;

        private readonly ICollection<Func<Task>> Commands;

        public DomainService(IUnitOfWork unitOfWork, IServiceProvider provider)
        {
            _unitOfWork = unitOfWork;
            _provider = provider;
            Commands = new List<Func<Task>>();
        }

        public IDomainService NewGuid(out Guid aggregateId)
        {
            aggregateId = GuidGenerator.Generate;
            return this;
        }

        public IDomainService Execute<TService>(Func<TService, Task> srv)
        {
            var service = _provider.GetService<TService>();
            Commands.Add(async () => await srv(service));

            return this;
        }

        public async Task CommitAsync()
        {
            try
            {
                foreach (var task in Commands.Select(c => c()))
                    await task;

                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}