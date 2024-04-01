# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Não deixe de enumerar os casos de teste de forma sequencial e de garantir que o(s) requisito(s) associado(s) a cada um deles está(ão) correto(s) - de acordo com o que foi definido na seção "2 - Especificação do Projeto". 

Por exemplo:
 
### CT-01 - Cadastrar Projetos

| **Caso de Teste**        | **CT-01 – Cadastrar Projetos** |
|--------------------------|--------------------------------|
| **Requisito Associado**  | RF-001 - Os alunos devem ser capazes de cadastrar seus projetos na aplicação, fornecendo informações essenciais como nome do projeto, descrição, integrantes do grupo. |
| **Objetivo do Teste**    | Verificar se os alunos conseguem cadastrar seus projetos na aplicação. |
| **Passos**               | - Acessar o navegador<br>- Informar o endereço da aplicação<br>- Navegar até a seção de "Cadastrar Projeto"<br>- Preencher os campos obrigatórios (nome do projeto, descrição, integrantes do grupo)<br>- Clicar em "Salvar Projeto" |
| **Critério de Êxito**    | O cadastro do projeto é realizado com sucesso e os detalhes do projeto cadastrado são exibidos corretamente na aplicação. |

### CT-02 - Filtrar Projetos

| **Caso de Teste**        | **CT-02 – Filtrar Projetos** |
|--------------------------|------------------------------|
| **Requisito Associado**  | RF-004 - Deve ser possível filtrar os projetos por categoria, nome e outros filtros relevantes. |
| **Objetivo do Teste**    | Verificar se a funcionalidade de filtragem de projetos funciona corretamente, permitindo filtrar por categoria, nome, entre outros critérios. |
| **Passos**               | - Acessar o navegador<br>- Informar o endereço da aplicação<br>- Navegar até a seção de projetos<br>- Utilizar os filtros disponíveis para filtrar projetos por categoria, nome, etc.<br>- Verificar se os resultados são exibidos conforme os filtros aplicados. |
| **Critério de Êxito**    | A aplicação filtra e exibe os projetos de acordo com os critérios selecionados pelo usuário. |

### CT-03 - Destaque de Projetos

| **Caso de Teste**        | **CT-03 – Destaque de Projetos** |
|--------------------------|-----------------------------------|
| **Requisito Associado**  | RF-005 - A página inicial deve destacar projetos com base em critérios como maiores avaliações e número de acessos. |
| **Objetivo do Teste**    | Verificar se a página inicial destaca projetos conforme especificado, baseando-se em critérios como avaliações e número de acessos. |
| **Passos**               | - Acessar o navegador<br>- Informar o endereço da aplicação<br>- Observar a página inicial para identificar os projetos em destaque<br>- Verificar se os projetos destacados atendem aos critérios de seleção mencionados. |
| **Critério de Êxito**    | Os projetos com maiores avaliações e número de acessos são destacados na página inicial conforme esperado. |

### CT-04 - Recebimento de Notificações

| **Caso de Teste**        | **CT-04 – Recebimento de Notificações** |
|--------------------------|-----------------------------------------|
| **Requisito Associado**  | RF-006 - Os alunos devem receber novas notificações sobre atualizações importantes, como novas avaliações nos projetos. |
| **Objetivo do Teste**    | Verificar se os alunos recebem notificações sobre atualizações importantes relacionadas aos projetos. |
| **Passos**               | - Acessar o navegador<br>- Fazer login na aplicação com uma conta de aluno<br>- Verificar a seção de notificações para novas mensagens relacionadas a atualizações importantes nos projetos. |
| **Critério de Êxito**    | Os alunos recebem notificações sobre atualizações importantes, como novas avaliações nos projetos, de forma clara e tempestiva. |

 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
