# Registro de Testes de Software

As funcionalidades dos testes realizados na aplicação web:

### CT01: **Cadastro de projetos**

- Para cadastrar um novo projeto, os alunos devem acessar o navegar e informar o endereço da aplicação. Logo a seguir fazer o "_Login_", e em seguida clicar em "_Gerenciar Projetos_".

![1-Gerenciar projetos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/ea849963-ab22-49fb-88b6-18634f2b6bf7)

- Logo em seguida a aplicação redireciona para uma nova página onde possui as visualizações dos projetos cadastrados e a opção de "_Cadastrar Projetos_".

![2-Gerencia projetos 1_cadastrar projetos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/43cdd5c8-efba-45ef-82f5-57e4469bf68b)

- Após clicar no botão “_Cadastrar Projeto_”, um pop-up surgirá, dando a opção de você colocar a URL do repositório do Github. Isso vai fazer a aplicação verificar se esse projeto (URL do repositório) já está cadastrado.

![3-Gerenciar projetos 2_CriarNovProje](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/e4c112bf-ef73-4d1b-a47d-cf7543b7d198)

- Selecionando o botão “_Verificar_”, irá redirecionar para uma página em que possibilitará preencher os dados do seu projeto
  e bem como nos campos obrigatório (nome do projeto, descrição, integrantes do grupo).

![4-Prova de conceito_A](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/92f4a39c-5f53-4972-ae46-1c5d9aaa6f3d)

- Depois de os dados preenchidos, clicar no botão “_Salvar projeto_”.

![5-Prova de conceito_B1](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/8b0936ae-bef1-48c7-8949-ab042df18334)

- Logo em seguida, redireciona para a página anterior com o projeto cadastrado.

  ![6-Prova de conceito_5](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/952af900-f027-4126-9619-232b21845637)

**Descrição dos testes**

Foi realizado os teste no intuito de verificar o cadastro de um novo projeto e suas funcionalidades, Para observar possíveis falhas e seu funcionamento está correto de acordo com o plano de teste.

**Resultados dos testes**

Foi observado que os testes apresentados ocorreu de maneira correta e dentro do esperado. Uma observação é
quando clicar o botão [criar], não é possível cadastrar o projeto, demostrando o campo a ser obrigatório em
destaque em vermelho, conforme esperado.

### **Edição de projetos**

- Para editar o projeto cadastrado na aplicação é importante o usuário depois de fazer o seu login, clicar na guia "_Gerenciar Projeto_". Pois essa ação redireciona para a página dos projetos cadastrados pelo próprio cadastrante.

  ![01_editar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/1ea6ba6b-d781-453b-bb8d-f1919fcb2471)

- A essa página redirecionada, lista os projetos cadastrados. Pegamos o último projeto cadatrado "POMODORO'S ORGANIZER" como exemplo para a edição.

![02_editar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/ee7b3a25-355c-4b9a-96f4-b8aa73aaa224)

- Em cada projeto cadastrado parecerá um botão de "_Editar_" e "_Apagar_". Clicando no botão _"Editar_" será redirecionado para a página de cadastro do projeto, possibilitando alterar e editar os campos desejados. Pegamos os campos "Integrantes" e "Imformações de contato" como exemplo.

![04_editar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/476efd3a-9001-44ce-97bd-fa89a6bafc62)

![05_editar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/abe5b028-d369-416b-a2db-ebf91fc9b61b)

- Logo depois de editado o campo desejado logo em seguida clicar no botão "_Salvar projeto_", vai parecer uma mensage no topo da página "**Projeto atualizado com sucesso!**".

![06_editar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/4cadf05c-7d39-40a9-ab61-582dd63c85c6)

### Observação:

Só é possível editar somente os projetos que cadastrou, ou seja, impossibilita a edição de projetos de outros cadastrantes.

**Descrição do teste:**

Para observar possíveis falhas em seu funcionamentos, possibilitando que os usuários tenha êxodo na sua funcionalidades.

**Resultado do teste:**

Foi observado que os testes apresentados ocorreu de maneira correta e dentro do esperado.

### CT02: **Filtrar projetos**

**Objetivo do teste:** Verificar se a funcionalidade de filtragem de projetos funciona corretamente, permitindo filtrar por categoria, nome, entre outros critérios.

**Passo a passo**:

- Acessar a página inicial do TalentHub
- Utilizar a pesquisa genérica localizada no topo da página ou então a pesquisa refinada na lateral esquerda

**Resultado:**

Foi observado que os projetos foram filtrados corretamente de acordo com os filtros fornecidos pelo usuário, conforme exemplo abaixo:

![filtros-talenthub](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/56805870/8a010940-b120-48a2-8881-0cfe15511407)

### CT04: **Avaliar projeto**

**Objetivo do teste:** Acessar um projeto e realizar a avaliação do mesmo.

**Passo a passo:**

- Realizar o login no TalentHub
- Selecionar o projeto para avaliar
- Clicar em [Avaliar projeto]
- Selecionar a nota e inserir um comentário para o projeto

**Resultado:**

Conforme o exemplo abaixo foi possível observar que a avaliação do projeto foi salva e informada ao usuário por meio da mensagem 'Avaliação salva com sucesso!' e foi exibida corretamente no rodapé do projeto na seção 'Avaliações e comentários'.

![avaliar-projeto](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/56805870/6efcc35f-cc80-42d5-816c-1fe30935d1f9)

### CT05: **Anotação no projeto**

**Objetivo do teste:** Acessar um projeto e realizar a anotações no mesmo.

**Passo a passo:**

- Realizar o login no TalentHub
- Selecionar o projeto
- Clicar em [ Fazer anotação ]
- Inserir uma anotação sobre o projeto
- Clicar em [ Salvar Anotação ]

**Resultado:**

Conforme o exemplo abaixo foi possível observar que a anotação no projeto foi salva e informada ao usuário por meio da mensagem 'Anotação salva com sucesso!' e foi exibida corretamente clicando novamente em 'Minha notação'.

![anotação-projeto](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/61726518/ed9a3081-cfc6-478a-8aa4-e8292d3c5968)
