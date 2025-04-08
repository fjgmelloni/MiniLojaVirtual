
# Mini Loja Virtual - Gestão de Produtos e Categorias

## Sobre o Projeto

Esse é o Projeto do Modulo 1 do MBA DevXpert do desenvolvedor.io

**Está pronto para baixar e rodar!**

Este projeto é uma aplicação web para gestão de uma mini loja virtual. Ele permite aos vendedores realizar o cadastro, edição, visualização e remoção de produtos e categorias. Além disso, a plataforma oferece autenticação de usuários, API RESTful, e integração com JWT para segurança de rotas. A solução está implementada utilizando ASP.NET Core MVC, Entity Framework Core, SQLite e Swagger para documentação da API.

**Autor:** Felicio Melloni

---

## Tecnologias Utilizadas

- **ASP.NET Core MVC**: Para a criação da interface web da aplicação.
- **Entity Framework Core**: Para a interação com o banco de dados SQLite.
- **SQLite**: Banco de dados utilizado para persistência de dados.
- **JWT (JSON Web Token)**: Para autenticação e autorização de usuários via token.
- **Swagger**: Para documentação da API RESTful.
- **CORS**: Para permitir que a aplicação seja acessada por diferentes origens durante o desenvolvimento.
- **ASP.NET Core Identity**: Para o gerenciamento de usuários e autenticação.
  
---

## Funcionalidades

- **Cadastro de Categorias**: Os usuários podem cadastrar, editar e excluir categorias de produtos.
- **Cadastro de Produtos**: Os vendedores podem cadastrar, editar e excluir produtos, associando-os a uma categoria.
- **Autenticação de Usuários**: Utilizando o ASP.NET Core Identity para registrar e autenticar usuários.
- **API RESTful**: Exposição de endpoints para CRUD de produtos e categorias. Proteção das rotas com JWT.
- **Visualização de Produtos**: Exibição dos produtos na página inicial com informações sobre nome, descrição, preço, estoque, e imagem.

---

## Configuração e Instalação

### Pré-requisitos

- **.NET SDK**: Versão 8.0 ou superior.
- **Visual Studio 2022** ou outro editor de sua escolha com suporte ao ASP.NET Core.
- **SQLite**: Banco de dados embutido (não há necessidade de instalar o SQL Server ou qualquer outra base de dados).

### Passos para rodar o projeto

1. **Clone o repositório**:
   
   ```bash
   git clone https://github.com/fjgmelloni/MiniLojaVirtual
   ```

2. **Instale os pacotes NuGet**:
   
   Execute o comando no Visual Studio ou no terminal:

   ```bash
   dotnet restore
   ```

3. **Configuração do banco de dados**:
   
   Após restaurar os pacotes, crie as migrações e aplique-as ao banco de dados:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. **Configuração do `appsettings.json`**:

   No arquivo `appsettings.json`, ajuste a chave JWT para a sua configuração:

   ```json
   "Jwt": {
       "Key": "SUA_CHAVE_SECRETA_AQUI",
       "Issuer": "MiniLojaVirtual",
       "Audience": "MiniLojaVirtualAPI",
       "ExpireHours": 3
   }
   ```

5. **Executando a aplicação**:

   Após as configurações, você pode iniciar o servidor de desenvolvimento:

   ```bash
   dotnet run
   ```

6. **Acessando o Swagger**:

   Após iniciar o servidor, você pode acessar a documentação da API via Swagger:

   [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## Testes de API

### Login

- **Endpoint**: `POST /api/auth/login`
- **Body**:

   ```json
   {
       "email": "usuario@exemplo.com",
       "senha": "senha123"
   }
   ```

- **Resposta**:

   Se o login for bem-sucedido, você receberá um token JWT:

   ```json
   {
       "token": "seu_token_jwt_aqui"
   }
   ```

### Produtos

- **Listar Produtos**: `GET /api/produtos`
- **Criar Produto**: `POST /api/produtos`
- **Editar Produto**: `PUT /api/produtos/{id}`
- **Excluir Produto**: `DELETE /api/produtos/{id}`

---

## Autenticação e Autorização

A autenticação na aplicação é realizada utilizando o **ASP.NET Core Identity**, onde o usuário pode fazer login via email e senha. Após o login, um token JWT é gerado e utilizado para autenticar as requisições às rotas da API.

---

## Contato

Caso tenha dúvidas ou sugestões, entre em contato:

- **E-mail**: feliciomelloni@live.com
- **GitHub**: [https://github.com/fjgmelloni](https://github.com/fjgmelloni)

---
