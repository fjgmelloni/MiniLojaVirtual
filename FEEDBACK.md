# Feedback - Avaliação Geral

## Front End
### Navegação
  * Pontos positivos:
    - O projeto possui views e rotas definidas para as funcionalidades, seguindo o padrão do ASP.NET Core MVC. As views estão presentes e permitem a navegação entre as principais operações de produtos e categorias.

### Design
    - Será avaliado na entrega final

### Funcionalidade
  * Pontos positivos:
    - As funcionalidades de cadastro, edição, visualização e exclusão de produtos e categorias estão implementadas no front-end, conforme os casos de uso esperados para uma mini loja virtual.

## Back End
### Arquitetura
  * Pontos positivos:
    - O projeto utiliza uma arquitetura simples, adequada para um CRUD básico, com uso do padrão MVC.

  * Pontos negativos:
    - A implementação da API RESTful está misturada ao projeto MVC, ou seja, não há separação clara entre API e front-end. Isso não segue a recomendação de separação de responsabilidades por camadas/projetos distintos.
    - As responsabilidades de negócio estão concentradas nas Controllers,o que não é um problema para tamanha complexidade do projeto, mas irá gerar duplicação de código na implementação das controllers da API.
    - Para esse desafio ter projetos (MVC, API, Core) como solução seria a melhor decisão.

### Funcionalidade
  * Pontos positivos:
    - As operações CRUD para produtos e categorias estão implementadas e expostas tanto via views quanto via endpoints de API.
    - O projeto utiliza Entity Framework Core com SQLite, conforme especificação.

### Modelagem
  * Pontos positivos:
    - A modelagem das entidades é simples e direta, adequada para o contexto de uma mini loja virtual.
    - O uso direto do contexto do EF Core é aceitável para o escopo do projeto.

  * Pontos negativos:
    - As regras de negócio estão implementadas diretamente nas Controllers, o que não é recomendado. O ideal seria extrair essas regras para uma camada de serviço, mesmo em projetos simples, para melhor organização e manutenção e evitar a duplicação entre MVC e API

## Projeto
### Organização
  * Pontos positivos:
    - O projeto está organizado em pastas, com separação de controllers, views e models, seguindo o padrão do ASP.NET Core MVC.
    - O arquivo de solução (`MiniLojaVirtual.sln`) está presente na raiz do repositório.

  * Pontos negativos:
    - Não há uso da pasta `src` na raiz, mas a estrutura está adequada para projetos de pequeno porte.

### Documentação
  * Pontos positivos:
    - O repositório possui um arquivo `README.md` bem documentado, com informações do projeto e instruções de execução.
    - A documentação da API via Swagger está presente.

  * Pontos negativos:
    - O arquivo `FEEDBACK.md` não foi encontrado no repositório.

### Instalação
  * Pontos positivos:
    - O projeto utiliza SQLite como banco de dados.
    - O README orienta sobre a criação e aplicação de migrations, facilitando a configuração inicial.

  * Pontos negativos:
    - Não foi identificada a implementação de seed de dados e migrations automática no start da aplicação. 
    - Recomenda-se adicionar essa funcionalidade para facilitar o uso e testes do sistema.