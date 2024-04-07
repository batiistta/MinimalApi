### Minimal API de Usuários

## 📋 Descrição
Esta é uma aplicação Minimal API que fornece endpoints para operações CRUD (Create, Read, Update, Delete) em usuários.

Esta aplicação utiliza o framework Carter para roteamento de endpoints e Entity Framework Core com um banco de dados em memória para persistência de dados.

## Endpoints
- GET /api/v1/users/buscarUsuarios: Retorna todos os usuários cadastrados.
- GET /api/v1/users/{id}: Retorna um usuário específico com o ID fornecido.
- POST /api/v1/users/salvarUsuario: Cria um novo usuário com os dados fornecidos.
- PUT /api/v1/users/{id}: Atualiza os dados de um usuário existente.
- DELETE /api/v1/users/{id}: Exclui um usuário existente.

## ⚙️ Configuração

Certifique-se de ter o SDK do .NET Core 7.0 ou superior instalado em sua máquina.

1. Clone este repositório:

   ```bash
   git clone https://github.com/seu-usuario/minimal-api-usuarios.git

2. Navegue até o diretório do projeto

3. Execute a aplicação:
   
dotnet run

## 🧪 Tecnologias Utilizadas

- Entity Framework Core
- Carter
  
## 🔍 Features

Para verificar as próximas features planejadas, [acesse o arquivo completo de features](Feature.md).**

## 💡 Contribuição
Agradecemos a todos os contribuidores que ajudaram a tornar este projeto possível! ✨

Se você também deseja contribuir, por favor, veja as [diretrizes de contribuição](CONTRIBUTING.md).

