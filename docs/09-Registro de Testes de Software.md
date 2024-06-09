# Registro de Testes de Software

As funcionalidades dos testes realizados na aplicação web:

### CT01: **Cadastro de projetos**

- Para cadastrar um novo projeto, os alunos devem acessar o navegar e informar o endereço da aplicação. Logo a seguir fazer o "*Login*", e em seguida clicar em "*Gerenciar Projetos*".

![1-Gerenciar projetos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/ea849963-ab22-49fb-88b6-18634f2b6bf7)

- Logo em seguida a aplicação redireciona para uma nova página onde possui as visualizações dos projetos cadastrados e a opção de "*Cadastrar Projetos*".

![2-Gerencia projetos 1_cadastrar projetos](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/43cdd5c8-efba-45ef-82f5-57e4469bf68b)

- Após clicar no botão “*Cadastrar Projeto*”, um pop-up surgirá, dando a opção de você colocar a URL do repositório do Github. Isso vai fazer a aplicação verificar se esse projeto (URL do repositório) já está cadastrado. 

![3-Gerenciar projetos 2_CriarNovProje](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/e4c112bf-ef73-4d1b-a47d-cf7543b7d198)

- Selecionando o botão “*Verificar*”, irá redirecionar para uma página em que possibilitará preencher os dados do seu projeto
e bem como nos campos obrigatório (nome do projeto, descrição, integrantes do grupo).

![4-Prova de conceito_A](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/92f4a39c-5f53-4972-ae46-1c5d9aaa6f3d)

- Depois de os dados preenchidos, clicar no botão “*Salvar projeto*”.

![5-Prova de conceito_B1](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/8b0936ae-bef1-48c7-8949-ab042df18334)

- Logo em seguida, redireciona para a página anterior com o projeto cadastrado.

  ![6-Prova de conceito_5](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/144956029/952af900-f027-4126-9619-232b21845637)

**Descrição dos testes**

Foi realizado os teste no intuito de verificar o cadastro de um novo projeto e suas funcionalidades, Para observar possíveis falhas e seu funcionamento está correto de acordo com o plano de teste. 

**Resultados dos testes**

Foi observado que os testes apresentados ocorreu de maneira correta e dentro do esperado. Uma observação é 
quando clicar o botão [criar], não é possível cadastrar o projeto, demostrando o campo a ser obrigatório em 
destaque em vermelho, conforme esperado.


### CT02: **Filtrar projetos**

**Objetivo do teste:** Verificar se a funcionalidade de filtragem de projetos funciona corretamente, permitindo filtrar por categoria, nome, entre outros critérios.

**Passo a passo**:
- Acessar a página inicial do TalentHub
- Utilizar a pesquisa genérica localizada no topo da página ou então a pesquisa refinada na lateral esquerda

**Resultado:**

Foi observado que os projetos foram filtrados corretamente de acordo com os filtros fornecidos pelo usuário, conforme exemplo abaixo:

![filtros-talenthub](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/56805870/8a010940-b120-48a2-8881-0cfe15511407)

### CT04: **Avaliar projeto**

**Objetivo do teste:**  Acessar um projeto e realizar a avaliação do mesmo.

**Passo a passo:**
- Realizar o login no TalentHub
- Selecionar o projeto para avaliar
- Clicar em [Avaliar projeto]
- Selecionar a nota e inserir um comentário para o projeto

**Resultado:**

Conforme o exemplo abaixo foi possível observar que a avaliação do projeto foi salva e informada ao usuário por meio da mensagem 'Avaliação salva com sucesso!' e foi exibida corretamente no rodapé do projeto na seção 'Avaliações e comentários'.

![avaliar-projeto](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t8-pmv-ads-2024-1-e2-talenthub/assets/56805870/6efcc35f-cc80-42d5-816c-1fe30935d1f9)

### CT05: **Anotação no projeto**

**Objetivo do teste:**  Acessar um projeto e realizar a anotações no mesmo.

**Passo a passo:**
- Realizar o login no TalentHub
- Selecionar o projeto
- Clicar em [ Fazer anotação ]
- Inserir uma anotação sobre o projeto
- Clicar em [ Salvar Anotação ]

**Resultado:**

Conforme o exemplo abaixo foi possível observar que a anotação no projeto foi salva e informada ao usuário por meio da mensagem 'Anotação salva com sucesso!' e foi exibida corretamente clicando novamente em 'Minha notação'.

![anotação-projeto]()
                                     
## Avaliação

Discorra sobre os resultados do teste. Ressaltando pontos fortes e fracos identificados na solução. Comente como o grupo pretende atacar esses pontos nas próximas iterações. Apresente as falhas detectadas e as melhorias geradas a partir dos resultados obtidos nos testes.

> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
