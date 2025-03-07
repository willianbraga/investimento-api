# investimento-api
Projeto para avaliação 

Cronograma Parcial

Dia 1 - configuracao inicial 5h
Dia 2 - implementacao endpoint 5h
Dia 3 - testes 5h
Dia 4 - observabilidade 7h
Dia 5 - Docker 5h
Dia 6 - aws e ajustes gerais 5h
Dia 7 - docs e revisao final 5h

Quebrando tarefas

Dia 1
Criar repo e estrutura 1.5h
Configurar banco 2h
Criar endpoint e mock 2h
Versionar 0.5h

Dia 2 
Criar repo 2h
Implementar endpoint 2h
Testar api local 1h

Dia 3
Criar testes unitarios 2h
Criar testes integracao 2h
Run e correcao necessaria 1h

Dia 4
Estudo ferramentas Serilog, OpenTelemetry e Prometheus 2h
Implementar Serilog 2h
Implementar OpenTelemetry 2h
Implementar Prometheus 1h

Dia 5
Estudo ferramenta docker 1h
Criar dockerfile 2h
Criar docker-compose 2h

Dia 6
Estudo AWS 2h
Criar desenho arquitetura 2h
Ajustes gerais 1h

Dia 7 
Documentacao 2h
Revisao final 2h
commit final 1h


Andamento

Dia 1

A principio no primeiro dia, pensei em me planejar em questao de tempo e atividades pendentes tentando imaginar a solucao de acordo com os pre requisitos solicitados.
Estruturei a solucao utilizando DDD ja pensando em uma estrutura SOA.

Dia 2

Analisando no dia seguinte a solucao me veio a ideia de considera em quebrar a api em api e worker utilizando rabbitmq para enfileirar as requisicoes, a principio seria muito bem viavel mas tem pontos a se considerar como concorrencia, necessidade atual da solucao entre outros pontos, deixarei para decidir no futuro tal mudanca a principio irie continuar com o desenvolvimento.

Repositorio finalizado, conexao com banco de dados funcional, concluido estrutura, controller-app-service-repo e feito testes manuais via postman, tudo funcional.