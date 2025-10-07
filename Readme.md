#  School Management System

Sistema de gestão escolar desenvolvido com .NET 8, React e Next.js. 
Este projeto demonstra princípios SOLID, testes automatizados (unitários e de integração) e autenticação por perfil.

## Instalação de Pacotes nuget

SchoolManagement.Tests.Unit/
	• dotnet add package NUnit
	• dotnet add package Moq
	• dotnet add package Microsoft.NET.Test.Sdk
	• dotnet add package NUnit3TestAdapter

## Estrutura da Solution

- SchoolManagement.API/
	- Controllers/
		- EscolaController.cs
		- MensalidadeController.cs
		- ParcelaController.cs
		- AuthController.cs
		- Middleware/
		- ExceptionHandlingMiddleware.cs
	- Program.cs
	- appsettings.json
- SchoolManagement.Application/
	- Interfaces/
		- IEscolaService.cs
		- IParcelaService.cs
	- Services/
		- EscolaService.cs
		- ParcelaService.cs
	- DTOs/
		- EscolaDto.cs
		- ParcelaDto.cs
		- LoginDto.cs
- SchoolManagement.Domain/
	- Entities/
		- Escola.cs
		- Mensalidade.cs
		- Aluno.cs
		- Parcela.cs
	- Enums/
		- StatusPagamento.cs
	- Interfaces/
		- IEscolaRepository.cs
		- IParcelaRepository.cs
	- Rules/
		- ParcelaRules.cs
- SchoolManagement.Infrastructure/
	- Data/
		- AppDbContext.cs
		- SeedData.cs
	- Repositories/
		- EscolaRepository.cs
		- ParcelaRepository.cs
	- Migrations/
- SchoolManagement.Tests.Unit/
	- Services/
		- EscolaServiceTests.cs
		- ParcelaServiceTests.cs
	- Rules/
		- ParcelaRulesTests.cs
- SchoolManagement.Tests.Integration/
	- API/
		- EscolaControllerTests.cs
		- ParcelaControllerTests.cs
	- Setup/
		- TestServerFactory.cs
- SchoolManagement.Factory/
	- ParcelaFactory.cs
- SchoolManagement.WebApp/
	- pages/
		- login.tsx
		- admin.tsx
		- responsavel.tsx
	- components/
		- EscolaList.tsx
		- MensalidadeList.tsx
		- ParcelaList.tsx
	- services/
		- api.ts
	- context/
		- AuthContext.tsx


##  Responsabilidades

- SchoolManagement.API
	- Expor endpoints REST
	- Configurar injeção de dependência
	- Middleware para tratamento de erros
	- Autenticação local
- SchoolManagement.Application
	- Orquestrar regras de negócio
	- Transformar entidades em DTOs
	- Validar dados de entrada
	- Gerenciar autenticação e perfi
- SchoolManagement.Domain
	- Modelar entidades e relacionamentos
	- Definir interfaces de repositórios
	- Implementar regras de negócio (ex: cálculo de juros)
- SchoolManagement.Infrastructure
	- Configurar EF Core e SQL Server
	- Implementar repositórios
	- Gerenciar migrations e seed
- SchoolManagement.Tests.Unit
	- Testar regras de negócio e serviços isoladamente
	- Usar NUnit + Moq para mocks
- SchoolManagement.Tests.Integration
	- Testar endpoints com banco real ou em memória
	- Validar fluxo completo de pagamento
- SchoolManagement.Factory
	- Criar parcelas com lógica de vencimento
	- Calcular valor pago com juros
- SchoolManagement.WebApp
	- Tela de login com seleção de perfil
	- Página de administrador: lista escolas e mensalidades
	- Página de responsável: lista parcelas e botão "Marcar como paga"
	- Mensagens de erro/sucesso visíveis

## Técnicas e padrões

- Injeção de dependência com Microsoft.Extensions.DependencyInjection
- Repositórios com interfaces no domínio
- Factory para criação de parcelas e cálculo de pagamento
- Tratamento de erros com middleware customizado e mensagens amigáveis

## Autenticação
- Tela de login simples com seleção de perfil (Administrador ou Responsável)
- Autenticação local com email/senha
- Redirecionamento por perfil

## Funcionalidades

- API RESTful com endpoints para escolas, mensalidades e parcelas
- Cálculo automático de juros em parcelas atrasadas
- Autenticação local com perfis: Administrador e Responsável
- Front-end com páginas distintas por perfil
- Testes automatizados (unitários e integração)
- Empacotamento com Docker
- CI/CD com GitHub Actions
- Pronto para deploy no Azure App Service

## UX
- Mensagens de sucesso/erro visíveis após cada ação
- Feedback visual para carregamento e validação

## Endpoints REST
		
/api/escolas		
/api/escolas/{id}/mensalidades		
/api/alunos/{id}/parcelas		
/api/parcelas/{id}/pagar		

## Regras de negócio

Status:
	- "pago": ValorPago > 0
	- "não pago": ValorPago == 0 e DataVencimento >= hoje
	- "atraso": ValorPago == 0 e DataVencimento < hoje
Juros: valorJuros = diasAtraso * 0.01 * valorInicial
ValorPago = valorInicial + valorJuros

## Testes
Testes unitários: dotnet test SchoolManagement.Tests.Unit
Testes integrados: dotnet test SchoolManagement.Tests.Integration

## Rodar com Docker

bash
docker-compose up --build

Acesse:
	API: http://localhost:5000
	Web: http://locaclhost:3000

## Perfis de Acesso

Administrador: Visualiza escolas e mensalidades
Responsável: Visualiza parcelas e pode marcar como pagas

## Tecnologias

- .NET 8 + Entity Framework Core
- React + Next.js
- SQL Server
- NUnit + Moq
- Docker
- GitHub Actions
- Azure App Service

## Autor
Felipe — Engenheiro de Software apaixonado por arquitetura limpa, automação e soluções escaláveis.
Email: felipepiresdemiranda@hotmail.com


