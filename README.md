📌 Investimento API

Este projeto é parte de um desafio técnico onde estou desenvolvendo uma API para consulta e cadastro de investimentos de clientes. Durante a implementação, estou ajustando o cronograma e as decisões técnicas conforme necessário, sempre buscando uma solução simples, funcional e bem estruturada.


📅 Cronograma do Projeto
| Dia  | Tarefa | Tempo Estimado |
| ------------- | ------------- | ------------ |
| 1️⃣  | Configuração inicial  | 5h |
| 2️⃣  | Implementação do endpoint  | 5h |
| 3️⃣  | Testes  | 5h |
| 4️⃣  | Observabilidade  | 8h |
| 5️⃣  | Docker  | 5h |
| 6️⃣  | AWS e ajustes gerais  | 5h |
| 7️⃣  | Documentação e revisão final  | 5h |


📌 Como Dividi as Tarefas
| Dia  | Tarefa | Tempo Estimado |
| ------------- | ------------- | ------------ |
| 1️⃣   | Criar repositório e estrutura  | 1,5h |
|      | Configurar banco de dados  | 2h |
|     | Criar endpoint mock  | 2h |
|     | Versionamento inicial  | 0,5h |
| 2️⃣  | Criar repositório  | 2h |
|   | Implementar endpoint real  | 2h |
|   | Testar API local  | 1h |
| 3️⃣  | Criar testes unitários  | 2h |
|   | Criar testes de integração  | 2h |
|   | Executar e corrigir falhas  | 1h |
| 4️⃣  | Estudar Serilog, OpenTelemetry e Prometheus  | 2,5h |
|   | Implementar Serilog  | 1,5h |
|   | Implementar OpenTelemetry  | 1,5h |
|   | Implementar Prometheus  | 1,5h |
|   | Executar e corrigir falhas  | 1h |
| 5️⃣  | Estudar Docker  | 1h |
|   | Criar Dockerfile  | 2h |
|   | Criar docker-compose  | 2h |
| 6️⃣  | Estudo AWS  | 2h |
|   | Criar desenho de arquitetura  | 2h |
|   | Ajustes finais  | 1h |
| 7️⃣  | Escrever documentação  | 2h |
|   | Revisão final  | 2h |
|   | Commit final  | 1h |



🚀 Andamento do Projeto

✅ Dia 1 - Configuração Inicial

O primeiro dia foi mais focado no planejamento e na criação da estrutura base do projeto. 
Quis definir um modelo que fosse organizado e flexível, então escolhi seguir DDD (Domain-Driven Design) e pensei em uma estrutura SOA (Service-Oriented Architecture).

Nesse momento, não quis complicar demais com microsserviços, então mantive tudo dentro de uma API monolítica, mas com organização modular para facilitar qualquer refatoração futura.

🔹 O que foi feito?

- [x] Estruturado o projeto no GitHub
- [x] Criado repositório e organizado as camadas (Controller → AppService → Service → Repository)
- [x] Configurado o banco de dados SQL Server
- [x] Criado um endpoint mockado para testes iniciais


✅ Dia 2 - Implementação dos Endpoints e Banco de Dados


No segundo dia, veio a dúvida sobre usar RabbitMQ e quebrar a API em uma arquitetura separada entre API e Worker. Eu pensei bastante sobre isso e vi que poderia ser uma boa ideia, mas, por enquanto, decidi seguir com a API monolítica para garantir que a entrega fosse funcional. Se sobrar tempo, faço uma análise mais detalhada sobre a viabilidade dessa mudança.

🔹 O que foi feito?

- [x] Finalizado repositório, contexto do banco e injeção de dependências
- [x] Implementação da lógica real para os endpoints
- [x] Testes manuais via Postman para garantir que a API responde corretamente

🔹 Decisão técnica importante:
- [x] RabbitMQ fica em pausa – Decidi manter o foco na API monolítica e avaliar a necessidade da fila depois.

📌 Dia 3 → Testes unitários e de integração

🔹 O que foi feito?

- [x]

  
📌 Dia 4 → Observabilidade com Serilog, OpenTelemetry e Prometheus

🔹 O que foi feito?

- [x]

  
📌 Dia 5 → Preparar a API para rodar no Docker

🔹 O que foi feito?

- [x]


📌 Dia 6 → Estudo de AWS e planejamento do 

🔹 O que foi feito?

- [x]


📌 Dia 7 → Documentação e revisão final

🔹 O que foi feito?

- [x]
