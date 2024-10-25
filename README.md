# Projeto BeautyTech

## Integrantes

- **CARLOS EDUARDO MENDONÇA DA SILVA** - RM552164
- **CARLOS ALBERTO MACHARELLI JUNIOR** – RM551677
- **EDUARDO TOSHIO ROCHA OKUBO** – RM551763
- **KAUÊ ALEXANDRE DE OLIVEIRA** – RM551812
- **VITOR MACHADO MIRANDA** – RM551451

## Arquitetura

Usei a **arquitetura monolítica**, onde todo o sistema é implantado em uma única aplicação, com todas as interfaces e funcionalidades interconectadas no projeto. Estou utilizando essa arquitetura porque, ao manter todo o sistema em uma única aplicação, ela facilita o desenvolvimento e o gerenciamento a curto prazo, permitindo que alterações ou correções sejam feitas de forma rápida. Além disso, essa abordagem tem um custo menor em termos de controle e gerenciamento da infraestrutura.

## Padrões Utilizados

- **Singleton Pattern**: Não está exatamente implícito no código, mas está sendo utilizado pelo Swagger e outros middlewares do ASP.NET Core, pois são serviços que utilizam uma única instância durante todo o ciclo de vida da aplicação.

- **Dependency Injection**: As dependências (por exemplo, `AppDbContext`) são injetadas nas classes em vez de serem instanciadas diretamente, promovendo maior flexibilidade e facilidade de manutenção.

- **Projeto de Recomendação de Produtos**:
Este projeto implementa um sistema de recomendação de produtos com base nas características dos clientes, como tipo de cabelo, pele e estado civil. O código foi desenvolvido com ênfase em Clean Code e nos princípios SOLID, visando garantir uma base sólida, manutenível e escalável.

As práticas de Clean Code foram aplicadas para tornar o código mais legível e compreensível, utilizando nomes significativos, métodos pequenos e focados, evitando duplicação de código e utilizando comentários de forma eficaz. Cada classe foi projetada com uma única responsabilidade, facilitando a manutenção e a compreensão.

Os princípios SOLID foram seguidos para criar um código modular e flexível. As classes estão abertas para extensão, mas fechadas para modificação, permitindo que novos modelos sejam adicionados sem alterar a lógica existente. As subclasses podem ser usadas de forma intercambiável com suas classes base, e as interfaces específicas foram criadas para garantir que os clientes não dependam de métodos que não utilizam.

O código depende de abstrações, não de implementações concretas, através da injeção de dependência, o que aumenta a flexibilidade e a testabilidade do sistema. Essas abordagens resultam em um código mais legível e de fácil manutenção, melhorando a colaboração em equipe e facilitando a implementação de novas funcionalidades no futuro.

## Instruções para Rodar a API:

### Passos para Execução

1. **Clone o repositório do github**:
2. **Banco de Dados**: Configure o banco de dados que será utilizado pela API e atualize a string de conexão no arquivo `appsettings.json`.
3. **Criar migrations**: Rode no cmd "dotnet ef migrations add InitialCreate".
4. **Banco de Dados**: Aplique as alterações no banco "dotnet ef database update".
5. **Projeto**: Rode o projeto.
6. **SWAGGER**: Voce ira acessar o Swagger em um caminho semelhante a esse https://localhost:5001/swagger.
7. **Teste*: Teste a API da Classe "Empresa", teste todo o CRUD.

### TESTES SWAGGER

- **POST-ML**

![Post3](imagens-swagger/POST3.png)

- **POST**

![Post](imagens-swagger/POST.png)
![Post2](imagens-swagger/POST2.png)


- **GET/SELECT**
  
![Getall](imagens-swagger/GETALL.png)
![Get](imagens-swagger/GET.png)
![Select](imagens-swagger/SELECT.png)


- **PUT/GET/SELECT**
  
![Put](imagens-swagger/PUT.png)
![Get2](imagens-swagger/GET2.png)
![Select2](imagens-swagger/SELECT2.png)


- **DELETE/SELECT**
  
![Delete](imagens-swagger/DELET.png)
![Select3](imagens-swagger/SELECT3.png)

















