
# Metodologia

Esta documentação apresenta a metodologia adotada pelo grupo para desenvolver o Talenthub, detalhando as ferramentas e ambientes de trabalho utilizados. Isso engloba a descrição dos ambientes de desenvolvimento e a estrutura para gerenciamento do código-fonte. Além disso, abordamos o processo e as ferramentas empregadas para organizar e gerenciar o time de desenvolvimento de forma eficiente.

## Gerenciamento de Projeto

Nosso time está utilizando a metodologia ágil de base para gerenciar de forma eficiente todo o processo de planejamento e desenvolvimento.
O time está organizado da seguinte forma:

**Scrum Master:** Thiago Pires

**Equipe de Desenvolvimento:**

- André Santana
- Thiago Pires
- Rodolfo Lannazo
- Jozimar Santos
- Bruno Lopes

### Processo

Para uma melhor organização e gerenciamento do projeto, o time optou por utilizar um quadro KANBAN do Trello estruturado da seguinte forma:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/67551515/c7e7de44-9b37-4efb-942a-c7fa4fcb032b)

- Backlog: Esta é a primeira etapa do quadro Kanban, onde todas as tarefas ou itens a serem realizados são listados.
- A fazer: É a área de entrada para novas demandas ou requisitos. 
- Fazendo: Nesta etapa, os itens que estão sendo trabalhados atualmente são movidos para cá. Aqui, a equipe está ativamente envolvida na execução das tarefas.
- Feito: Uma vez que uma tarefa tenha passado por todas as etapas anteriores e esteja pronta para ser entregue, é movida para esta etapa. Isso indica que a tarefa está pronta para ser lançada ou entregue
- Impedimento: Esta tem como objetivo listar possíveis impedimentos para prosseguir com a demanda.

### Ferramentas

As ferramentas empregadas no projeto são:

- Editor de código.
- Ferramentas de comunicação
- Ferramentas de desenho de tela (_wireframing_)

O editor de código foi escolhido porque ele possui uma integração com o
sistema de versão. As ferramentas de comunicação utilizadas possuem
integração semelhante e por isso foram selecionadas. Por fim, para criar
diagramas utilizamos essa ferramenta por melhor captar as
necessidades da nossa solução.

Liste quais ferramentas foram empregadas no desenvolvimento do projeto, justificando a escolha delas, sempre que possível.
 
> **Possíveis Ferramentas que auxiliarão no gerenciamento**: 
> - [Slack](https://slack.com/)
> - [Github](https://github.com/)

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

Discuta como a configuração do projeto foi feita na ferramenta de versionamento escolhida. Exponha como a gerência de tags, merges, commits e branchs é realizada. Discuta como a gerência de issues foi realizada.
