namespace PropostaService.Application.DTOs;

public record CreateProposalInput(
    string CustomerName,
    decimal Amount
);
