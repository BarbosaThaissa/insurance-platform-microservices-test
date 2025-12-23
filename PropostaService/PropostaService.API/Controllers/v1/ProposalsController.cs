using Microsoft.AspNetCore.Mvc;
using PropostaService.Application.DTOs;
using PropostaService.Application.UseCases;
using PropostaService.Domain.Enums;

namespace PropostaService.API.Controllers.v1;

[ApiController]
[Route("api/proposals")]
public class ProposalsController(
    CreateProposalUseCase createProposal,
    ChangeProposalStatusUseCase changeStatus,
    GetAllProposalsUseCase getAll) : ControllerBase
{
    private readonly CreateProposalUseCase _createProposal = createProposal;
    private readonly ChangeProposalStatusUseCase _changeStatus = changeStatus;
    private readonly GetAllProposalsUseCase _getAll = getAll;

    [HttpPost]
    public async Task<IActionResult> Create(CreateProposalInput input)
    {
        var id = await _createProposal.ExecuteAsync(input);
        return CreatedAtAction(nameof(GetAll), new { id });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var proposals = await _getAll.ExecuteAsync();
        return Ok(proposals);
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> ChangeStatus(Guid id, [FromQuery] ProposalStatus status)
    {
        await _changeStatus.ExecuteAsync(id, status);
        return NoContent();
    }
}
