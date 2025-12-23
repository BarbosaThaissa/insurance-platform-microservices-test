using PropostaService.Domain.Enums;

namespace PropostaService.Application.DTOs;

public record ProposalOutput(
    Guid Id,
    string CustomerName,
    decimal Amount,
    ProposalStatus Status
);
