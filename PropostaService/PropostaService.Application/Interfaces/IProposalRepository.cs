using PropostaService.Domain.Entities;

namespace PropostaService.Application.Interfaces;

public interface IProposalRepository
{
    Task AddAsync(Proposal proposal);
    Task<Proposal?> GetByIdAsync(Guid id);
    Task<IEnumerable<Proposal>> GetAllAsync();
    Task UpdateAsync(Proposal proposal);
}
