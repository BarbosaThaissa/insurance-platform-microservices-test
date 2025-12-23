using PropostaService.Application.DTOs;
using PropostaService.Application.Interfaces;
using PropostaService.Domain.Entities;

namespace PropostaService.Application.UseCases;

public class CreateProposalUseCase(IProposalRepository repository)
{
    private readonly IProposalRepository _repository = repository;

    public async Task<Guid> ExecuteAsync(CreateProposalInput input)
    {
        var proposal = new Proposal(
            input.CustomerName,
            input.Amount
        );

        await _repository.AddAsync(proposal);

        return proposal.Id;
    }
}
