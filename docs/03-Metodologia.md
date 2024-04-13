
# Metodologia

Esta documentação apresenta a metodologia adotada pelo grupo para desenvolver o Talenthub, detalhando as ferramentas e ambientes de trabalho utilizados. Isso engloba a descrição dos ambientes de desenvolvimento e a estrutura para gerenciamento do código-fonte. Além disso, abordamos o processo e as ferramentas empregadas para organizar e gerenciar o time de desenvolvimento de forma eficiente.

## Gerenciamento de Projeto

Nosso time está utilizando a metodologia ágil de base para gerenciar de forma eficiente todo o processo de planejamento e desenvolvimento.
O time está organizado da seguinte forma:

**Scrum Master:** Thiago Pires

**Product Owner:** Rodolfo Iannazo

**Equipe de Desenvolvimento:**

- André Santana
- Bruno Lopes
- Jozimar Santos
- Rodolfo Iannazo
- Thiago Pires


### Processo

Para uma melhor organização e gerenciamento do projeto, o time optou por utilizar um quadro KANBAN do Trello que ficou estruturado assim:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/67551515/c7e7de44-9b37-4efb-942a-c7fa4fcb032b)

- Backlog: Esta é a primeira etapa do quadro Kanban, onde todas as tarefas ou itens a serem realizados são listados.
- A fazer: É a área de entrada para novas demandas ou requisitos. 
- Fazendo: Nesta etapa, os itens que estão sendo trabalhados atualmente são movidos para cá. Aqui, a equipe está ativamente envolvida na execução das tarefas.
- Feito: Uma vez que uma tarefa tenha passado por todas as etapas anteriores e esteja pronta para ser entregue, é movida para esta etapa. Isso indica que a tarefa está pronta para ser lançada ou entregue
- Impedimento: Esta tem como objetivo listar possíveis impedimentos para prosseguir com a demanda.

### Ferramentas

| Ferramenta       | Plataforma   | Justificativa                                                                                           |
|------------------|--------------|---------------------------------------------------------------------------------------------------------|
| Ferramenta de comunicação          | WhatsApp e Microsoft Teams   | Facilita a comunicação instantânea entre os membros da equipe, permitindo discussões rápidas, compartilhamento de arquivos e atualizações importantes. |
| Projeto de Interface e Wireframes     | JustInMind  | Oferece uma ampla gama de recursos para criar wireframes e projetar interfaces de usuário, além de permitir colaboração em tempo real e uma interface intuitiva. |
| Gerenciamento do projeto          | Trello  | É uma ferramenta eficaz para gerenciar o projeto, permitindo a criação de quadros Kanban personalizados para acompanhar o progresso das tarefas, atribuir responsabilidades e estabelecer prazos. |
| Editor de código        | VsCode    | É uma opção popular devido à sua grande variedade de extensões, integração com controle de versão e recursos avançados de edição, tornando-o adequado para desenvolvimento de software eficiente. |

## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software
- `unstable`: versão já testada do software, porém instável
- `testing`: versão em testes do software
- `dev`: versão de desenvolvimento do software

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

## Product Backlog e planos de sprints

| Etapa | Documentos/Atividades |
|-------|-----------------------|
| E1    | Documentação de contexto<br>Especificação do projeto |
| E2    | Diagrama de classes<br>Diagrama de Fluxo (fluxograma)<br>Wireframe interativo<br>Modelo Entidade Relacionamento (Projeto Conceitual)<br>Projeto da Base de Dados<br>Planos de Teste de Software e de Usabilidade<br>Documentação da Metodologia<br>Projeto do Github com Backlog e Plano de Sprints |
| E3    | Template Padrão da Aplicação<br>Funcionalidades Críticas<br>Registro de Testes de Software<br>Registro de Testes de Usabilidade |
| E4    | Template Padrão da Aplicação<br>Funcionalidades restantes<br>Registro de Testes de Software<br>Registro de Testes de Usabilidade |
| E5    | Relatórios de Teste de Software<br>Registro de Testes de Usabilidade |
