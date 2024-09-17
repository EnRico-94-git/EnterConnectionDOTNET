# EnterConnectionDOTNET

Descrição do Projeto

O AdvancedBusinessDev é uma aplicação ASP.NET Core desenvolvida para gerenciar entidades relacionadas a um ecossistema de negócios avançado. O projeto inclui funcionalidades para o gerenciamento de clientes, empresas, e suas relações de negócio. Ele utiliza uma arquitetura baseada em repositórios e serviços, promovendo a separação de responsabilidades e permitindo que a aplicação seja extensível e de fácil manutenção.

Funcionalidades

Clientes: CRUD (Create, Read, Update, Delete) completo para a entidade Cliente.
Empresas: Relacionamento entre Cliente e Empresa, com gerenciamento eficiente dessas relações.
DTOs (Data Transfer Objects): Implementação de DTOs para abstrair e transferir dados de maneira otimizada entre a API e o banco de dados.
Arquitetura Limpa: Aplicação dos princípios de Clean Architecture, com separação clara entre camada de apresentação, camada de negócio (serviços) e camada de dados (repositórios).
Injeção de Dependência: Utilização de Dependency Injection para garantir a inversão de controle e facilitar o teste e manutenção do código.
Tecnologias Utilizadas

ASP.NET Core Web API: Framework principal utilizado para a construção da API.
Entity Framework Core: Para mapeamento objeto-relacional (ORM) e integração com o banco de dados.
Oracle: Banco de dados.
Swagger: Integração com Swagger para documentação da API, facilitando o desenvolvimento e o uso dos endpoints.
xUnit: Framework para testes unitários.
Estrutura do Projeto

Controllers
Os controllers expõem endpoints para a manipulação das entidades, seguindo os princípios RESTful. Cada controlador trabalha com um serviço que contém a lógica de negócio.

ClientesController: Gerencia as requisições relacionadas aos Clientes.
Services
A camada de serviços contém a lógica de negócio, incluindo validações e manipulação dos dados antes de serem persistidos ou recuperados.

ClienteService: Implementa as operações de negócio relacionadas à entidade Cliente.
Repositories
A camada de repositórios é responsável por interagir diretamente com o banco de dados, seguindo o padrão Repository Pattern. Ela permite que a aplicação seja facilmente testada e mantida, desacoplando o acesso a dados da lógica de negócio.

ClienteRepository: Contém as operações CRUD para a entidade Cliente, utilizando o Entity Framework para interagir com o banco de dados.
DTOs
Os DTOs (Data Transfer Objects) são usados para transportar dados de maneira otimizada entre a aplicação e o banco de dados, evitando o acoplamento direto com as entidades do domínio.

ClienteDTO: Define os campos que serão expostos via API, ocultando dados desnecessários.
