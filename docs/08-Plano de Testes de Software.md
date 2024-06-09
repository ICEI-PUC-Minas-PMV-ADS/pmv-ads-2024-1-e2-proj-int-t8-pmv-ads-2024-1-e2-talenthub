# Plano de Testes de Software

### CT-01

| **Caso de Teste**       | **Cadastrar Projetos**                                                                                                                                                                                                               |
| ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Requisito Associado** | RF-001 - Os alunos devem ser capazes de cadastrar seus projetos na aplicação, fornecendo informações essenciais como nome do projeto, descrição, integrantes do grupo.                                                               |
| **Objetivo do Teste**   | Verificar se os alunos conseguem cadastrar seus projetos na aplicação.                                                                                                                                                               |
| **Passos**              | - Acessar o navegador<br>- Informar o endereço da aplicação<br>- Navegar até a seção de "Cadastrar Projeto"<br>- Preencher os campos obrigatórios (nome do projeto, descrição, integrantes do grupo)<br>- Clicar em "Salvar Projeto" |
| **Critério de Êxito**   | O cadastro do projeto é realizado com sucesso e os detalhes do projeto cadastrado são exibidos corretamente na aplicação.                                                                                                            |

### CT-02

| **Caso de Teste**       | **Filtrar Projetos**                                                                                                                                                                                                                                              |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Requisito Associado** | RF-004 - Deve ser possível filtrar os projetos por categoria, nome e outros filtros relevantes.                                                                                                                                                                   |
| **Objetivo do Teste**   | Verificar se a funcionalidade de filtragem de projetos funciona corretamente, permitindo filtrar por categoria, nome, entre outros critérios.                                                                                                                     |
| **Passos**              | - Acessar o navegador<br>- Informar o endereço da aplicação<br>- Navegar até a seção de projetos<br>- Utilizar os filtros disponíveis para filtrar projetos por categoria, nome, etc.<br>- Verificar se os resultados são exibidos conforme os filtros aplicados. |
| **Critério de Êxito**   | A aplicação filtra e exibe os projetos de acordo com os critérios selecionados pelo usuário.                                                                                                                                                                      |

### CT-03

| **Caso de Teste**       | **Destaque de Projetos**                                                                                                                                                                                                   |
| ----------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Requisito Associado** | RF-005 - A página inicial deve destacar projetos com base em critérios como maiores avaliações e número de acessos.                                                                                                        |
| **Objetivo do Teste**   | Verificar se a página inicial destaca projetos conforme especificado, baseando-se em critérios como avaliações e número de acessos.                                                                                        |
| **Passos**              | - Acessar o navegador<br>- Informar o endereço da aplicação<br>- Observar a página inicial para identificar os projetos em destaque<br>- Verificar se os projetos destacados atendem aos critérios de seleção mencionados. |
| **Critério de Êxito**   | Os projetos com maiores avaliações e número de acessos são destacados na página inicial conforme esperado.                                                                                                                 |

### CT-04

| **Caso de Teste**       | **Avaliar projeto**                                                                                                        |
| ----------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| **Requisito Associado** | RF-003 - Deve ser possível realizar avaliações no projeto.                                                                 |
| **Objetivo do Teste**   | Verificar se está sendo gravado de forma correta a avaliação.                                                              |
| **Passos**              | - Acessar o navegador<br>- Fazer login na aplicação com uma conta de aluno<br>- Selecionar um projeto<br>-Avaliar o projeto|
| **Critério de Êxito**   | As avaliações devem ser gravadas corretamente e ser visualizadas.                                                          |

### CT-05

| **Caso de Teste**       | **Anotação no projeto**                                                                                                        |
| ----------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| **Requisito Associado** | RF-007 - Os usuários poderão realizar anotações nos projetos                                                                 |
| **Objetivo do Teste**   | Verificar se está sendo gravado de forma correta a anotação.                                                              |
| **Passos**              | - Acessar o navegador<br>- Fazer login na aplicação com uma conta de aluno<br>- Selecionar um projeto<br>-Realizar uma anotação no projeto|
| **Critério de Êxito**   | As anotações devem ser gravadas corretamente e ser visualizadas.                                                          |