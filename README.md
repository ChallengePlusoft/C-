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
