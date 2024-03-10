# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas


| **FOTO** | **NOME** | **IDADE** | **OCUPAÇÃO** | **MOTIVAÇÕES** | **INSATISFAÇÕES** | **HOBBIES** |
| --------- | -------- | ---- |------------ | ----------- | -------------- | ------- |
| ![Isabel Mendes](img/personas/Isabel-Mendes.jpg) | Isabel Mendes | 43 anos| Professora | Ensinar, desenvolver habilidades, incentivar pesquisa, preparar para o mercado, inspirar alunos e contribuir para o avanço da disciplina |  Dispersão de projetos em diferentes plataformas, demandando esforço extra para revisão individual. A falta de centralização compromete a eficiência da avaliação acadêmica | Ler, ir em observatórios, museus, assistir documentários |
| ![Ana Silva](img/personas/Ana-Silva.jpg) | Ana Silva | 22 anos | Estudante de Análise e Desenvolvimento de Sistemas | Engajar em projetos acadêmicos, deseja compartilhar seu trabalho, receber feedbacks e melhorar constantemente.  | Dificuldade em encontrar projetos relevantes, falta de filtros por área de estudo e popularidade limitando a experiência de aprendizado e inspiração  | Escrever, ir ao cinema, assistir séries |
| ![Lucas Santos](img/personas/Lucas-Santos.jpg) | Lucas Santos | 25 anos | Visitante | Busca inspiração e aprendizado além dos limites do seu curso, tanto por curiosidade quanto por impulsionar o desenvolvimento pessoal | Falta de um sistema de avaliações e ranking, limitam oportunidades de estudo e inspiração em projetos para aprendizado e desenvolvimento | Sair com a família, viajar, ler |
| ![Rodrigo Oliveira](img/personas/Rodrigo-Oliveira.jpg) |Rodrigo Oliveira |  33 anos | Tech Recruiter | Recrutar talentos que impulsionem o crescimento futuro | Dificuldade em encontrar bons profissionais em início de carreira para contratação | Jogar futebol, assistir a filmes de ação |

## Histórias de Usuários

| **EU COMO...** | **QUERO/PRECISO DE...** | **PARA ...** |
| -------------- | --------------------- | ------------ |
|Isabel Mendes (Professora) | Organizar projetos em uma plataforma | Acessar todos os projetos de uma única plataforma|
|Isabel Mendes (Professora) | Avaliar projetos | Avaliá-los de maneira mais organizada e eficiente por comentários (sugestões, críticas) e numero de estrelas|
|Ana Silva (Aluna) | Divulgar meus projetos | Avaliação, feedback e visibilidade|
|Ana Silva (Aluna) | Buscar Projetos | Facilitar a busca e visualização dos projetos| 
|Ana Silva (Aluna) | Filtrar Projetos | Filtrar projetos por área de estudo, popularidade e avaliação média| 
|Ana Silva (Aluna) |Acessar projetos de diferentes turmas |Promover a interação e a colaboração entre alunos de diferentes grupos e cursos |
|Ana Silva (Aluna)  | Receber Avaliações| Aprimorar meu trabalho com base em críticas, feedbacks e avaliações| 
|Ana Silva (Aluna)  | Avaliar Projetos (estrelas)| Dar destaque para os projetos que acharam interessantes|
|Ana Silva (Aluna)  | Acesso fácil a projetos de destaque| Inspirar-me em trabalhos para elevar a qualidade dos meus projetos| 
|Lucas Santos (Visitante) |Encontrar projetos inspiradores | Inspiração para desenvolver projetos mais criativos e impactantes |
|Lucas Santos (Visitante) |Ter uma plataforma intuitiva | Facilitar a navegação e a busca por projetos relevantes de diferentes áreas de estudo |
|Rodrigo Oliveira (Visitante-Tech Recruiter) | Identificar talentos promissores| Encontrar candidatos qualificados para fortalecer minha equipe de desenvolvimento|
|Rodrigo Oliveira (Visitante-Tech Recruiter) | Acesso fácil a projetos destacados| Encontrar rapidamente trabalhos acadêmicos de alta qualidade para análise e recrutamento|
|Rodrigo Oliveira (Visitante-Tech Recruiter) | Avaliar potencial de novos talentos|Identificar estudantes com habilidades alinhadas às demandas do mercado de trabalho|

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Os alunos devem ser capazes de cadastrar seus projetos na aplicação, fornecendo informações essenciais como nome do projeto, descrição, integrantes do grupo | ALTA | 
|RF-002| A aplicação deve permitir que os professores cadastrem comentários em cada projeto, facilitando o feedback direto aos alunos  | ALTA |
|RF-003| Deve ser possível filtrar os projetos por categoria, nome e outros filtros relevantes | ALTA |
|RF-004| Tanto professores quanto alunos devem poder avaliar os projetos por meio de um sistema de estrelas | MÉDIA |
|RF-005| A página inicial deve destacar projetos com base em critérios como maiores avaliações e número de acessos | MÉDIA |
|RF-007| Os alunos devem receber novas notificações sobre atualizações importantes, como novos comentários nos projetos | BAIXA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve ser responsiva e acessível através de diferentes dispositivos e navegadores | MÉDIA |
|RNF-002| A aplicação deve ser fácil de utilizar, com uma interface intuitiva para todos os usuários | MÉDIA |
|RNF-003| A aplicação deve ter suporte para usuários que utilizam leitores de tela. | BAIXA |
|RNF-004| A aplicação deve responder rapidamente às solicitações do usuário, mesmo durante períodos de alta demanda | BAIXA |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| A aplicação deverá ser concluído dentro de um cronograma específico |
|02| Não é permitido o uso de qualquer framework frontend (como Angular, React, etc) no desenvolvimento do projeto |

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
