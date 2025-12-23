using PropostaService.Domain.Enums;

namespace PropostaService.Domain.Entities;

public class Proposal
{
    public Guid Id { get; private set; }
    public string CustomerName { get; private set; }
    public decimal Amount { get; private set; }
    public ProposalStatus Status { get; private set; }

    protected Proposal() { }

    public Proposal(string customerName, decimal amount)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentException("Nome do cliente é obrigatório");

        if (amount <= 0)
            throw new ArgumentException("Valor da proposta deve ser maior que zero");

        Id = Guid.NewGuid();
        CustomerName = customerName;
        Amount = amount;
        Status = ProposalStatus.UnderReview;
    }

    public void Approve()
    {
        if (Status != ProposalStatus.UnderReview)
            throw new InvalidOperationException("Somente propostas em análise podem ser aprovadas");

        Status = ProposalStatus.Approved;
    }

    public void Reject()
    {
        if (Status != ProposalStatus.UnderReview)
            throw new InvalidOperationException("Somente propostas em análise podem ser rejeitadas");

        Status = ProposalStatus.Rejected;
    }
}
