# 📚 WebApi DotNet Core 8 - Livros e Autores

Bem-vindo ao **WebApi DotNet Core 8**, uma API RESTful para gerenciar **livros** e **autores** utilizando **.NET Core 8** e **Entity Framework Core**.  
Este projeto implementa operações CRUD completas com tratamento de erros e resposta padronizada.

---

## 🚀 Tecnologias Utilizadas

- ![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white) **C#**
- ![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=flat&logo=dotnet&logoColor=white) **ASP.NET Core 8**
- ![Entity Framework](https://img.shields.io/badge/Entity_Framework-512BD4?style=flat&logo=dotnet&logoColor=white) **Entity Framework Core**
- ![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white) **SQL Server**
- ![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=flat&logo=visual-studio&logoColor=white) **Visual Studio 2022**

---

## 📌 Funcionalidades

### Livros
- 🔹 Listar todos os livros  
- 🔹 Buscar livro por ID  
- 🔹 Buscar livros por autor  
- 🔹 Criar novo livro  
- 🔹 Editar livro existente  
- 🔹 Excluir livro  

### Autores
- 🔹 Listar todos os autores  
- 🔹 Buscar autor por ID  
- 🔹 Buscar autor por livro  
- 🔹 Criar novo autor  
- 🔹 Editar autor existente  
- 🔹 Excluir autor  

---

## 🛠 Estrutura do Projeto

WebApi8/
├── Controllers/ # Controllers da API
├── Data/ # DbContext e configuração do EF
├── Dto/ # Data Transfer Objects
├── Models/ # Modelos de domínio
├── Services/ # Lógica de negócio (CRUD)
├── appsettings.json # Configurações da aplicação
├── Program.cs # Configuração e inicialização da API
└── README.md # Este arquivo

---

## ⚡ Exemplos de Uso

### Listar Livros
```http
GET /api/livros
POST /api/autores
Content-Type: application/json

{
  "nome": "João",
  "sobrenome": "Silva"
}
POST /api/livros
Content-Type: application/json

{
  "titulo": "Aprendendo C#",
  "autor": {
    "id": 1
  }
}

Todas as respostas utilizam o modelo ResponseModel<T>:
{
  "status": true,
  "mensagem": "Livro criado com sucesso!",
  "dados": [ ... ]
}
