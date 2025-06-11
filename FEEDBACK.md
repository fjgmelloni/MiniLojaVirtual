# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Projeto MVC com rotas e views funcionais para produtos, categorias e autenticação.
    - Estrutura clara para navegação administrativa.

  * Pontos negativos:
    - Nenhum.

### Design
  - Layout simples e objetivo, funcional para o gerenciamento administrativo da loja.

### Funcionalidade
  * Pontos positivos:
    - CRUD implementado em API e MVC.
    - Identity implementado corretamente com JWT na API e Cookie no MVC.
    - Migrations automáticas e seed de dados configurados com SQLite.
    - Arquitetura enxuta com as três camadas essenciais (API, Core, MVC).
    - Modelagem das entidades está adequada e coerente.

  * Pontos negativos:
    - A criação do vendedor com o ID compartilhado do Identity não está implementada em nenhuma das camadas (API ou MVC).
    - A inicialização do seed/migrations está comentada no `Program.cs` da aplicação MVC.
    - `Program.cs` da API e do MVC está verboso e poderia ser refatorado com abstrações/modularizações.

## Back End

### Arquitetura
  * Pontos positivos:
    - Divisão entre API, Core e MVC clara e funcional.
    - Estrutura de pasta e uso de arquivos `.sln` organizados.

  * Pontos negativos:
    - Falta abstração em `Program.cs` e organização de inicializações.

### Funcionalidade
  * Pontos positivos:
    - Operações principais de CRUD e autenticação funcionam conforme esperado.

  * Pontos negativos:
    - A ausência de criação do vendedor com o usuário do Identity.
    - Seed de dados não ativo na aplicação MVC (apenas comentado).

### Modelagem
  * Pontos positivos:
    - Modelagem enxuta, organizada e aderente ao escopo proposto.

  * Pontos negativos:
    - Nenhum.

## Projeto

### Organização
  * Pontos positivos:
    - Estrutura organizada com `src`, `.sln` na raiz e documentação presente.
    - Código limpo e organizado.

  * Pontos negativos:
    - Nenhum ponto estrutural grave, apenas melhorias em boas práticas mencionadas.

### Documentação
  * Pontos positivos:
    - `README.md` e `FEEDBACK.md` presentes com orientações básicas.
    - Swagger na API.

### Instalação
  * Pontos positivos:
    - SQLite funcional, migrations automáticas e seed (com ressalvas) implementado.

  * Pontos negativos:
    - Seed de dados comentado no `Program.cs` da camada MVC.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 9        | 2,7                                      |
| **Qualidade do Código**       | 20%      | 9        | 1,8                                      |
| **Eficiência e Desempenho**   | 20%      | 9        | 1,8                                      |
| **Inovação e Diferenciais**   | 10%      | 9        | 0,9                                      |
| **Documentação e Organização**| 10%      | 10       | 1,0                                      |
| **Resolução de Feedbacks**    | 10%      | 10       | 1,0                                      |
| **Total**                     | 100%     | -        | **9,2**                                  |

## 🎯 **Nota Final: 9,2 / 10**
