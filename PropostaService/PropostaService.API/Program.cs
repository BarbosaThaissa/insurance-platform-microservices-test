using PropostaService.Application.Interfaces;
using PropostaService.Application.UseCases;
using PropostaService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProposalRepository, InMemoryProposalRepository>();

builder.Services.AddScoped<CreateProposalUseCase>();
builder.Services.AddScoped<ChangeProposalStatusUseCase>();
builder.Services.AddScoped<GetAllProposalsUseCase>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();