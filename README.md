# FamilyBudgetControlAluraChallenge
API para controle de orçamento familiar. Projeto proposto para desenvolvimento no Back End Challenger da Alura. #alurachallengebackend4

## :clipboard: Tecnologias

<div style="display: inline_block">
  <img align="center"  height="100" width="100" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" />
  <img align="center"  height="100" width="100" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original.svg" />
  <img align="center"  height="100" width="100" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" /> 
  <img align="center"  height="100" width="100" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain.svg" />
  <img align="center"  height="100" width="100" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/trello/trello-plain.svg" />
</div>

<br>

## :hourglass_flowing_sand: Planejamento de Entregas
- [x] [SPRINT 1] - 01/08/2022 a 07/08/2022

- [ ] [SPRINT 2] - 08/08/2022 a 14/08/2022

- [ ] [SPRINT 3] - 15/08/2022 a 21/08/2022



## :card_index_dividers: Backlog SPRINT 1
* Banco de dados da aplicação
* Cadastro de receita
* Listagem de receitas
* Detalhamento de receita
* Atualização de receita
* Exclusão de receita
* Cadastro de despesa
* Listagem de despesas
* Detalhamento de despesa
* Atualização de despesa
* Exclusão de despesa
* Testes da API

## :computer: EndPoints da API
* /receitas       --> GET receitas: para pegar todas as receitas.
* /receitas/{id}  --> GET receita por id: para detalhar uma receita.
* /receitas       --> POST receita: cadastrar uma receita, passando os parametros pelo body. Não pode ser passado uma receita com o mesma descrição, o mesmo mês e ano que uma já existente no banco. Exemplo de requisição passada pelo body:
```
    {
      "Descricao":"Salario",
      "Valor" : 2000,
      "Data" : "2022-04-17"
    }
```
* /receitas/{id}  --> PUT receita: editar uma receita, passando os parametros pelo body.
```
    {
      "Descricao":"Salario",
      "Valor" : 2000,
      "Data" : "2022-04-17"
    }
```
* /receitas/{id}  --> DELETE receita: excluir uma receita através do id.


* /despesas       --> GET despesas: para pegar todas as despesas.
* /despesas/{id}  --> GET despesa por id: para detalhar uma despesa.
* /despesas       --> POST despesa: cadastrar uma despesas, passando os parametros pelo body. Não pode ser passado uma despesa com a mesma descrição, o mesmo mês e ano que uma já existente no banco. Exemplo de requisição passada pelo body:
```
    {
      "Descricao":"Salario",
      "Valor" : 2000,
      "Data" : "2022-04-17"
    }
```
* /despesas/{id}  --> PUT despesa: editar uma despesa, passando os parametros pelo body.
```
    {
      "Descricao":"Salario",
      "Valor" : 2000,
      "Data" : "2022-04-17"
    }
```
* /despesas/{id}  --> DELETE despesa: excluir uma despesa através do id.


