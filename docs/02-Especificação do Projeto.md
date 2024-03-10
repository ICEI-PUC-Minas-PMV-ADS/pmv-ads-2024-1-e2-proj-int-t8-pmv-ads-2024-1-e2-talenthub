# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

| **FOTO**                                               | **NOME**         | **IDADE** | **OCUPAÇÃO**                                       | **MOTIVAÇÕES**                                                                                                                           | **INSATISFAÇÕES**                                                                                                                                                          | **HOBBIES**                                              |
| ------------------------------------------------------ | ---------------- | --------- | -------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------- |
| ![Isabel Mendes](img/personas/Isabel-Mendes.jpg)       | Isabel Mendes    | 43 anos   | Professora                                         | Ensinar, desenvolver habilidades, incentivar pesquisa, preparar para o mercado, inspirar alunos e contribuir para o avanço da disciplina | Dispersão de projetos em diferentes plataformas, demandando esforço extra para revisão individual. A falta de centralização compromete a eficiência da avaliação acadêmica | Ler, ir em observatórios, museus, assistir documentários |
| ![Ana Silva](img/personas/Ana-Silva.jpg)               | Ana Silva        | 22 anos   | Estudante de Análise e Desenvolvimento de Sistemas | Engajar em projetos acadêmicos, deseja compartilhar seu trabalho, receber feedbacks e melhorar constantemente.                           | Dificuldade em encontrar projetos relevantes, falta de filtros por área de estudo e popularidade limitando a experiência de aprendizado e inspiração                       | Escrever, ir ao cinema, assistir séries                  |
| ![Lucas Santos](img/personas/Lucas-Santos.jpg)         | Lucas Santos     | 25 anos   | Visitante                                          | Busca inspiração e aprendizado além dos limites do seu curso, tanto por curiosidade quanto por impulsionar o desenvolvimento pessoal     | Falta de um sistema de avaliações e ranking, limitam oportunidades de estudo e inspiração em projetos para aprendizado e desenvolvimento                                   | Sair com a família, viajar, ler                          |
| ![Rodrigo Oliveira](img/personas/Rodrigo-Oliveira.jpg) | Rodrigo Oliveira | 33 anos   | Tech Recruiter                                     | Recrutar talentos que impulsionem o crescimento futuro                                                                                   | Dificuldade em encontrar bons profissionais em início de carreira para contratação                                                                                         | Jogar futebol, assistir a filmes de ação                 |

## Histórias de Usuários

| **EU COMO...**                              | **QUERO/PRECISO DE...**               | **PARA ...**                                                                                                 |
| ------------------------------------------- | ------------------------------------- | ------------------------------------------------------------------------------------------------------------ |
| Isabel Mendes (Professora)                  | Organizar projetos em uma plataforma  | Acessar todos os projetos de uma única plataforma                                                            |
| Isabel Mendes (Professora)                  | Avaliar projetos                      | Avaliá-los de maneira mais organizada e eficiente por comentários (sugestões, críticas) e numero de estrelas |
| Ana Silva (Aluna)                           | Divulgar meus projetos                | Avaliação, feedback e visibilidade                                                                           |
| Ana Silva (Aluna)                           | Buscar Projetos                       | Facilitar a busca e visualização dos projetos                                                                |
| Ana Silva (Aluna)                           | Filtrar Projetos                      | Filtrar projetos por área de estudo, popularidade e avaliação média                                          |
| Ana Silva (Aluna)                           | Acessar projetos de diferentes turmas | Promover a interação e a colaboração entre alunos de diferentes grupos e cursos                              |
| Ana Silva (Aluna)                           | Receber Avaliações                    | Aprimorar meu trabalho com base em críticas, feedbacks e avaliações                                          |
| Ana Silva (Aluna)                           | Avaliar Projetos (estrelas)           | Dar destaque para os projetos que acharam interessantes                                                      |
| Ana Silva (Aluna)                           | Acesso fácil a projetos de destaque   | Inspirar-me em trabalhos para elevar a qualidade dos meus projetos                                           |
| Lucas Santos (Visitante)                    | Encontrar projetos inspiradores       | Inspiração para desenvolver projetos mais criativos e impactantes                                            |
| Lucas Santos (Visitante)                    | Ter uma plataforma intuitiva          | Facilitar a navegação e a busca por projetos relevantes de diferentes áreas de estudo                        |
| Rodrigo Oliveira (Visitante-Tech Recruiter) | Identificar talentos promissores      | Encontrar candidatos qualificados para fortalecer minha equipe de desenvolvimento                            |
| Rodrigo Oliveira (Visitante-Tech Recruiter) | Acesso fácil a projetos destacados    | Encontrar rapidamente trabalhos acadêmicos de alta qualidade para análise e recrutamento                     |
| Rodrigo Oliveira (Visitante-Tech Recruiter) | Avaliar potencial de novos talentos   | Identificar estudantes com habilidades alinhadas às demandas do mercado de trabalho                          |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

| ID     | Descrição do Requisito                                            | Prioridade |
| ------ | ----------------------------------------------------------------- | ---------- |
| RF-001 | A aplicação deve permitir que o usuário gerencie suas tarefas     | ALTA       |
| RF-002 | A aplicação deve emitir um relatório de tarefas realizadas no mês | MÉDIA      |

### Requisitos não Funcionais

| ID      | Descrição do Requisito                                            | Prioridade |
| ------- | ----------------------------------------------------------------- | ---------- |
| RNF-001 | A aplicação deve ser responsiva                                   | MÉDIA      |
| RNF-002 | A aplicação deve processar requisições do usuário em no máximo 3s | BAIXA      |

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
  (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
  correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
  Lembre-se que cada requisito deve corresponder à uma e somente uma
  característica alvo da sua solução. Além disso, certifique-se de que
  todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

| ID  | Restrição                                             |
| --- | ----------------------------------------------------- |
| 01  | O projeto deverá ser entregue até o final do semestre |
| 02  | Não pode ser desenvolvido um módulo de backend        |

Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
>
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

    @startuml
    skinparam style strictuml
    skinparam backgroundColor #EEEBDC

    left to right direction
    skinparam packageStyle rectangle
    actor Aluno
    actor Professor
    actor "Agente Externo" as AE

    rectangle TalentHub {
      (Login) as Login
      (Cadastrar Projeto) as CP
      (Buscar/Consultar Projetos) as BCP
      (Fazer Anotações sobre Projetos) as FAP
      (Avaliar Qualidade do Projeto) as AQP
      (Obter Contato para Projetos) as OCP

      Login -down-> CP : <<include>>
      Login -down-> FAP : <<include>>
      Login -down-> AQP : <<include>>
      Login -down-> OCP : <<include>>

      CP --> BCP : <<include>>

      Aluno -right-> Login : Realiza\npara atividades específicas
      Professor -right-> Login : Realiza\npara atividades específicas
      AE -right-> Login : Realiza para\nObter Contato

      Aluno --> BCP : Utiliza
      Professor --> BCP : Utiliza
      AE --> BCP : Utiliza
    }
    @enduml

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/3586967/d7c7ce1c-1f35-4257-b455-dbc1e691261a)

| Ator           | Caso de Uso                    | Descrição                                                                                 |
| -------------- | ------------------------------ | ----------------------------------------------------------------------------------------- |
| Aluno          | Login                          | Alunos precisam realizar login para acessar funcionalidades específicas do sistema.       |
| Aluno          | Cadastrar Projeto              | Alunos podem cadastrar novos projetos após realizar login.                                |
| Aluno          | Buscar/Consultar Projetos      | Alunos podem buscar e consultar projetos sem necessidade de login.                        |
| Professor      | Login                          | Professores precisam realizar login para acessar funcionalidades específicas do sistema.  |
| Professor      | Fazer Anotações sobre Projetos | Professores podem fazer anotações em projetos após realizar login.                        |
| Professor      | Avaliar Qualidade do Projeto   | Professores podem avaliar a qualidade dos projetos após realizar login.                   |
| Professor      | Buscar/Consultar Projetos      | Professores podem buscar e consultar projetos sem necessidade de login.                   |
| Agente Externo | Login                          | Agentes externos precisam realizar login para obter contato para projetos.                |
| Agente Externo | Obter Contato para Projetos    | Agentes externos podem obter informações de contato para projetos específicos após login. |
| Agente Externo | Buscar/Consultar Projetos      | Agentes externos podem buscar e consultar projetos sem necessidade de login.              |
