# README.md

### Mini Loja Virtual — Projeto Módulo 01 MBA DevXpert

Este projeto é uma aplicação web completa com back-end em ASP.NET Core 9.0, separada em três camadas:
- **MiniLojaVirtual.Core**: entidades, contexto e seed de dados
- **MiniLojaVirtual.Api**: API RESTful com autenticação JWT
- **MiniLojaVirtual.Web**: front-end MVC com autenticação por cookie

---

### Funcionalidades
- Cadastro e login de vendedores via Identity
- Autenticação protegida com JWT na API
- CRUD de **Produtos** com vínculo ao vendedor logado
- CRUD de **Categorias**, com validação para não excluir se houver produtos
- Listagem pública de produtos e busca por categoria
- Vitrine com produtos no front-end

---

### Como executar o projeto

1. Clone o repositório e abra a solution `.sln` no Visual Studio

2. Certifique-se de que os 3 projetos estejam incluídos:
   - `MiniLojaVirtual.Core`
   - `MiniLojaVirtual.Api`
   - `MiniLojaVirtual.Web`

3. **Banco de dados**: será criado automaticamente com SQLite ao executar a aplicação.
   - Local: `MiniLojaVirtual.Core/loja.db`

4. Ao Compilar:
   - O banco é migrado automaticamente
   - Um usuário de teste será criado:
     - Email: `felicio@felicio.com`
     - Senha: `Felicio#12`

5. Acesse a interface Web:
   - `http://localhost:5145`

6. Acesse a API com Swagger:
   - `http://localhost:5062` (ou porta configurada)

7. Para testar endpoints protegidos:
   - Faça login via `/api/Auth/login`
   - Use o token no botão **Authorize** do Swagger (Bearer TOKEN)

---

### Tecnologias usadas
- ASP.NET Core 9.0
- Entity Framework Core + SQLite
- ASP.NET Identity
- JWT Bearer Authentication
- Swagger para documentação da API