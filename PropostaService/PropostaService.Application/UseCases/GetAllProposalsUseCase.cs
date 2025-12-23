using PropostaService.Application.DTOs;
using PropostaService.Application.Interfaces;

namespace PropostaService.Application.UseCases;

public class GetAllProposalsUseCase(IProposalRepository repository)
{
    private readonly IProposalRepository _repository = repository;

    public async Task<IEnumerable<ProposalOutput>> ExecuteAsync()
    {
        var proposals = await _repository.GetAllAsync();

        return proposals.Select(p => new ProposalOutput(
            p.Id,
            p.CustomerName,
            p.Amount,
            p.Status
        ));
    }
}
