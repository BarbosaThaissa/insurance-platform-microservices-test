using PropostaService.Application.Interfaces;
using PropostaService.Domain.Enums;

namespace PropostaService.Application.UseCases;

public class ChangeProposalStatusUseCase(IProposalRepository repository)
{
    private readonly IProposalRepository _repository = repository;

    public async Task ExecuteAsync(Guid proposalId, ProposalStatus newStatus)
    {
        var proposal = await _repository.GetByIdAsync(proposalId);

        if (proposal is null)
            throw new InvalidOperationException("Proposta não encontrada");

        switch (newStatus)
        {
            case ProposalStatus.Approved:
                proposal.Approve();
                break;

            case ProposalStatus.Rejected:
                proposal.Reject();
                break;

            default:
                throw new InvalidOperationException("Alteração de status inválida");
        }

        await _repository.UpdateAsync(proposal);
    }
}
