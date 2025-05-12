# Task Manager API

## Descrição

O **Task Manager** é uma API desenvolvida para gerenciar tarefas. Foi projetada utilizando as melhores práticas de **Clean Code** e arquitetura **Minimal API**, com a aplicação dos princípios **SOLID** para garantir código limpo, modular e fácil de manter. O projeto utiliza **.NET 8** com **Entity Framework Core** para persistência de dados e **Swagger** para documentação.

## Funcionalidades

- **Criação de Tarefas**: Permite criar tarefas com nome e descrição.
- **Atualização de Tarefas**: Atualiza o nome, descrição.
- **Exclusão de Tarefas**: Permite deletar tarefas específicas.
- **Visualização de Tarefas**: Consulta tarefas por nome ou ID.

## Tecnologias Utilizadas

- **.NET 8**: Framework utilizado para construção da API.
- **Minimal APIs**: Arquitetura leve e performática para construção dos endpoints.
- **Entity Framework Core**: ORM para interagir com o banco de dados.
- **Swagger/OpenAPI**: Para geração automática de documentação da API.
- **SOLID Principles**: Aplicação de princípios de design de software para criar código flexível, reutilizável e de fácil manutenção.
- **Clean Code**: Adoção de boas práticas de código limpo e organizado.

## Estrutura de Diretórios

A estrutura do projeto segue uma abordagem modular, dividindo o código de forma clara e simples:

```plaintext
/TaskManager
├── /API
│   ├── Endpoints: Definição dos endpoints da API.
│   ├── Extensions: Métodos de extensão e configurações.
│   └── Program.cs e appsettings.json: Configuração principal da aplicação.
├── /Application
│   ├── UseCase: Casos de uso da aplicação.
│   └── Extensions: Métodos de extensão relacionados à camada de aplicação.
├── /Domain
│   ├── DTOs: Objetos de transferência de dados.
│   ├── Entities: Entidades do domínio.
│   ├── Enum: Enumerações utilizadas no domínio.
│   └── Interfaces: Interfaces das entidades e serviços do domínio.
├── /Infrastructure
│   ├── Data: Configurações do banco de dados e contexto.
│   ├── Migrations: Migrações do Entity Framework.
│   ├── Repository: Implementações dos repositórios.
│   └── Extensions: Métodos de extensão da infraestrutura.
```
## Endpoints

### `GET /task`

Retorna todas as tarefas cadastradas no sistema.

#### Exemplo de resposta:

```json
[
  {
    "id": "1",
    "name": "Tarefa de Exemplo",
    "description": "Descrição da tarefa",
    "completed": "incompleto",
    "dateRegistration": "2025-05-11T17:09:08.949148",
    "dateCompleted": null
  }
]

```
### `GET /task/{id}`

Retorna uma tarefa específica pelo ID.

### `POST /task/create`

Cria uma nova tarefa. Recebe os seguintes parâmetros no corpo da requisição:

- **name**: Nome da tarefa.
- **description**: Descrição da tarefa.

### `PUT /task/update/{id}`

Atualiza uma tarefa existente, recebendo os seguintes parâmetros no corpo da requisição:

- **name**: Novo nome da tarefa.
- **description**: Nova descrição da tarefa.

### `PUT /task/completed/{name}`

Marca uma tarefa como concluída, passando o nome da tarefa.

### `DELETE /task/delete/{id}`

Deleta uma tarefa pelo ID.

## Como Rodar o Projeto

### Pré-requisitos

- **.NET 8 SDK** instalado.
- **Banco de dados**: A aplicação utiliza **Entity Framework Core** para persistência de dados.

### Passos para rodar

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/TaskManager.git
   cd TaskManager
   ```
2. Restaure as dependências do projeto:

   ```bash
   dotnet restore
   ```
3. Aplique as migrações para criar o banco de dados:

   ```bash
   dotnet ef database update
   ```
4. Inicie o projeto:

   ```bash
   dotnet run
   ```
5. Acesse a API no navegador ou via ferramenta como **Postman**:

   - URL: `http://localhost:5000`
   - Documentação Swagger: `http://localhost:5000/swagger`
