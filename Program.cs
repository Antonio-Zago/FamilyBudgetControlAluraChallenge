using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using FamilyBudgetControlAluraChallenge.EndPoints;
using FamilyBudgetControlAluraChallenge.EndPoints.DespedaEndPoints;
using FamilyBudgetControlAluraChallenge.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionStrings:SqlServerPc"]);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapMethods(ReceitaPost.Template,ReceitaPost.Methods,ReceitaPost.handle);
app.MapMethods(ReceitaGetAll.Template, ReceitaGetAll.Methods, ReceitaGetAll.handle);
app.MapMethods(ReceitaGet.Template, ReceitaGet.Methods, ReceitaGet.handle);
app.MapMethods(ReceitaPut.Template, ReceitaPut.Methods, ReceitaPut.handle);
app.MapMethods(ReceitaDelete.Template, ReceitaDelete.Methods, ReceitaDelete.handle);

app.MapMethods(DespesaPost.Template, DespesaPost.Methods, DespesaPost.handle);





app.Run();

