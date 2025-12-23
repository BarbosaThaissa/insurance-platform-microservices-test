using PropostaService.Application.Interfaces;
using PropostaService.Domain.Entities;

namespace PropostaService.Infrastructure.Repositories;

public class InMemoryProposalRepository : IProposalRepository
{
    private static readonly List<Proposal> _proposals = [];

    public Task AddAsync(Proposal proposal)
    {
        _proposals.Add(proposal);
        return Task.CompletedTask;
    }

    public Task<Proposal?> GetByIdAsync(Guid id)
    {
        var proposal = _proposals.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(proposal);
    }

    public Task<IEnumerable<Proposal>> GetAllAsync()
    {
        return Task.FromResult(_proposals.AsEnumerable());
    }

    public Task UpdateAsync(Proposal proposal)
    {
        return Task.CompletedTask;
    }
}
