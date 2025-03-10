📌 Investimento API

Este projeto é parte de um desafio técnico onde estou desenvolvendo uma API para consulta e cadastro de investimentos de clientes. Durante a implementação, estou ajustando o cronograma e as decisões técnicas conforme necessário, sempre buscando uma solução simples, funcional e bem estruturada.


📅 Cronograma do Projeto
| Dia  | Tarefa | Tempo Estimado | Realizado |
| ------------- | ------------- | ------------ | ------------ |
| 1️⃣  | Configuração inicial  | 5h | 3h |
| 2️⃣  | Implementação do endpoint  | 5h | 3,5h |
| 3️⃣  | Testes  | 5h | 4h |
| 4️⃣  | Observabilidade  | 8h | 7h |
| 5️⃣  | Docker  | 5h | 8h |
| 6️⃣  | AWS e ajustes gerais  | 5h |
| 7️⃣  | Documentação e revisão final  | 5h |


📌 Como Dividi as Tarefas
| Dia  | Tarefa | Tempo Estimado | Realizado |
| ------------- | ------------- | ------------ | ------------ |
| 1️⃣   | Criar repositório e estrutura  | 1,5h | 1h |
|      | Configurar banco de dados  | 2h | 1h |
|     | Criar endpoint mock  | 2h | 0,5h |
|     | Versionamento inicial  | 0,5h | 0,5h |
| 2️⃣  | Criar repositório  | 2h | 1h |
|   | Implementar endpoint real  | 2h | 2h |
|   | Testar API local  | 1h | 0,5h |
| 3️⃣  | Criar testes unitários  | 1,5h | 1h |
|   | Criar testes de integração  | 1,5h | 1h |
|   | Executar e corrigir falhas  | 2h | 2h |
| 4️⃣  | Estudar Serilog, OpenTelemetry e Prometheus  | 2,5h | 1h |
|   | Implementar Serilog  | 1,5h | 1h |
|   | Implementar Seq | 1,5h | 1h |
|   | Implementar OpenTelemetry  | 1,5h | 1h |
|   | Implementar Prometheus  | 1,5h | 1h |
|   | Implementar Grafana | 1,5h | 1h |
|   | Executar e corrigir falhas  | 1h | 2h |
| 5️⃣  | Estudar Docker  | 1h | 2h |
|   | Criar Dockerfile  | 2h | 1h |
|   | Criar docker-compose  | 2h | 1h |
|   | Migrar solução para Docker | 2h | 4h |
| 6️⃣  | Estudo AWS  | 2h |
|   | Criar desenho de arquitetura  | 2h |
|   | Ajustes finais  | 1h |
| 7️⃣  | Escrever documentação  | 2h |
|   | Revisão final  | 2h |
|   | Commit final  | 1h |



🚀 Andamento do Projeto

✅ Dia 1 - Configuração Inicial (Tempo gasto: **3h**)

O primeiro dia foi mais focado no planejamento e na criação da estrutura base do projeto. 
Quis definir um modelo que fosse organizado e flexível, então escolhi seguir DDD (Domain-Driven Design) e pensei em uma estrutura SOA (Service-Oriented Architecture).

Nesse momento, não quis complicar demais com microsserviços, então mantive tudo dentro de uma API monolítica, mas com organização modular para facilitar qualquer refatoração futura.

🔹 O que foi feito?

- [x] Estruturado o projeto no GitHub
- [x] Criado repositório e organizado as camadas (Controller → AppService → Service → Repository)
- [x] Configurado o banco de dados SQL Server
- [x] Criado um endpoint mockado para testes iniciais


✅ Dia 2 - Implementação dos Endpoints e Banco de Dados (Tempo gasto: **3,5h**)


No segundo dia, veio a dúvida sobre usar RabbitMQ e quebrar a API em uma arquitetura separada entre API e Worker. Eu pensei bastante sobre isso e vi que poderia ser uma boa ideia, mas, por enquanto, decidi seguir com a API monolítica para garantir que a entrega fosse funcional. Se sobrar tempo, faço uma análise mais detalhada sobre a viabilidade dessa mudança.

🔹 O que foi feito?

- [x] Finalizado repositório, contexto do banco e injeção de dependências
- [x] Implementação da lógica real para os endpoints
- [x] Testes manuais via Postman para garantir que a API responde corretamente

🔹 Decisão técnica importante:
- [x] RabbitMQ fica em pausa – Decidi manter o foco na API monolítica e avaliar a necessidade da fila depois.

✅ Dia 3 → Testes unitários e de integração (Tempo gasto: **4h**)

Iniciando o terceiro dia com foco na implementação dos testes unitários e de integração. Se possível, tentarei adiantar parte do desenvolvimento do Dia 4 para ganhar tempo extra para possíveis melhorias no projeto.

🔹 O que foi feito?

- [x] Testes unitários no repositório e serviços
- [x] Testes de integração corrigidos e rodando sem erros
- [x] Refatorações para melhorar performance e depuração

🔹 Decisão
- [x] Irei puxar alguma parte do dia 4 para adiantar parte do desenvolvimento e ganhar tempo.
  
🔹 Decisão técnica importante:

Durante o estudo sobre logs estruturados, avaliei algumas opções para melhorar a visualização e análise dos logs da API. Inicialmente, a ideia era apenas utilizar Serilog gravando em arquivo, mas percebi que isso poderia dificultar a leitura e a busca por eventos específicos.

Após estudar algumas soluções, decidi integrar o Seq, que oferece uma interface web intuitiva para análise dos logs em tempo real. Com essa mudança, agora posso monitorar os eventos da API de forma mais organizada, com filtros e buscas estruturadas.

🔹 Decisão tomada:

- [x] Implementar Serilog com Seq para melhorar a rastreabilidade dos logs.
- [x] Configurar o Seq localmente, permitindo análise em tempo real.
- [x] Manter a possibilidade de adicionar novos sinks (exemplo: arquivos, cloud, banco de dados) no futuro, se necessário.

Fiquei pensando... Com Serilog, OpenTelemetry e Prometheus/Grafana no projeto, será que realmente precisamos do Seq? No fim das contas as informações poderiam ser enviadas diretamente entre essas ferramentas ou até armazenadas em arquivos, banco ou outro destino sem depender dele. Hummm, por enquanto acho que vale a pena manter. Ele facilita a organização dos logs e torna o rastreamento de eventos bem mais prático. Se em algum momento começar a virar um peso extra de administração ou deixar de fazer sentido, dá pra remover sem grandes impactos. A estrutura já está flexível o suficiente pra isso.

🔹 O que foi feito? Tempo gasto: (**3h**)

- [x] Implementação do OpenTelemetry
- [x] Habilitação do suporte OTLP no Seq
- [x] Estudo sobre a necessidade do Seq

✅ Dia 4 → Observabilidade com Serilog, OpenTelemetry e Prometheus/Grafana (Tempo gasto: **7h**)

Como no dia anterior adiantei parte do Serilog, OpenTelemetry e da integração com o Seq, darei foco na finalização do Prometheus e Grafana.

🔹 O que foi feito? (**4h**)

- [x] Instalei e configurei o Prometheus e Grafana localmente
- [x] Implementei a captura de métricas na API usando o prometheus-net
- [x] Ajustei o Prometheus para coletar as métricas corretamente
- [x] Efetuei vários requests para garantir que os dados estavam sendo armazenados
- [x] Testei as consultas no Prometheus e configurei dashboards no Grafana
- [x] Fiz ajustes finais e tudo está funcional

Agora tentar adiantar a parte do Docker para otimizar o tempo e preparar a API para rodar de forma isolada.

🔹 O que foi feito? (**2h**)

- [x] Adiantado a instalação das ferramentas necessarias.
- [x] Efetuado a organização estrutural dos arquivos na solução
- [x] Iniciado a criação do DOCKERFILE e docker-compose.yaml

✅ Dia 5 → Preparar a API para rodar no Docker (Tempo gasto: **8h**)

Ontem já tinha adiantado boa parte dos arquivos de configuração, então hoje a ideia é focar nos testes e ajustes da aplicação rodando no Docker.

🔹 O que aconteceu?

Tive alguns problemas de recurso computacional, o Docker ficou instável e começou a crashar várias vezes. No começo tentei automatizar tudo ao máximo criando um entrypoint que configurava o banco, rodava um script para criar o banco, usuário, permissões e tudo mais. Fiz o script e tudo parecia bem mas começaram a surgir vários desafios na automatização total do banco e do migration.

No fim das contas percebi que isso estava tomando muito tempo. Então decidi simplificar. 
Vou deixar o Docker cuidando da API, do banco, do Seq, do Prometheus e do Grafana, mas a inicialização do banco vai ser manual (rodando o entrypoint e a migration na mão). Se no futuro isso virar um problema, aí penso em uma solução mais automatizada.

🔹 O que foi feito? (**6h**)

- [x] Finalizada a configuração do Dockerfile e docker-compose.yaml
- [x] Criei o entrypoint.sh e o init-db.sql para inicializar o banco
- [x] Resolvi o problema de restart infinito do container do SQL Server
- [x] Ajustei a conexão entre a API e o banco dentro do Docker
- [x] Testei a API e o banco rodando nos containers
- [x] Validei que a API funciona tanto localmente quanto via Docker
- [x] Ajustei o appsettings.json para suportar os dois ambientes (Docker/local)
- [x] Testei e finalizei a migração do banco no ambiente Docker

📌 Dia 6 → Estudo AWS, Desenho da solução utilizando serviços AWS

🔹 O que foi feito?

- [x]


📌 Dia 7 → Documentação e revisão final

🔹 O que foi feito?

- [x]
