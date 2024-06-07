# Plano de Testes de Usabilidade

- **Desempenho:** Avaliar a eficiência e a rapidez da aplicação em responder às interações dos usuários.
- **Acessibilidade:** Verificar a acessibilidade da aplicação para garantir que todos os usuários, incluindo aqueles com deficiências, possam utilizar a aplicação sem problemas.
- **Práticas recomendadas:** Assegurar que a aplicação siga as melhores práticas recomendadas para aplicações web modernas.

### CTU-01: Diagnóstico de Desempenho

| **Caso de Teste Usabilidade** | **Diagnóstico de Desempenho**                                                                                                                                                                                                  |
| ----------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Objetivo do Teste             | Avaliar o desempenho da aplicação em termos de tempo de carregamento e eficiência de uso dos recursos.                                                                                                                         |
| Passos                        | - Executar a aplicação e medir as seguintes métricas: <br> - First Contentful Paint (FCP) <br> - Largest Contentful Paint (LCP) <br> - Total Blocking Time (TBT) <br> - Cumulative Layout Shift (CLS) <br> - Speed Index (SI). |
| Critério de Êxito             | A aplicação deve apresentar tempos baixos para FCP, LCP, TBT e SI, e um valor de CLS próximo a zero.                                                                                                                           |

### CTU-02: Diagnóstico de Acessibilidade

| **Caso de Teste Usabilidade** | **Diagnóstico de Acessibilidade**                                                                                                                                                                                            |
| ----------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Objetivo do Teste             | Verificar se a aplicação é acessível para todos os usuários, incluindo aqueles com deficiências.                                                                                                                             |
| Passos                        | - Utilizar ferramentas automáticas de verificação de acessibilidade. <br> - Testar o contraste de cores. <br> - Verificar a presença de nomes e etiquetas em elementos de formulário. <br> - Testar a navegação por teclado. |
| Critério de Êxito             | A aplicação deve cumprir os padrões de acessibilidade web, facilitando o uso para todos os usuários.                                                                                                                         |

### CTU-03: Diagnóstico de Práticas Recomendadas

| **Caso de Teste Usabilidade** | **Diagnóstico de Práticas Recomendadas**                                                                                                                                |
| ----------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Objetivo do Teste             | Assegurar que a aplicação siga as melhores práticas recomendadas para desenvolvimento web.                                                                              |
| Passos                        | - Verificar o uso eficiente de recursos. <br> - Analisar o carregamento de imagens e uso de formatos modernos. <br> - Avaliar o uso de CSS e JavaScript não utilizados. |
| Critério de Êxito             | A aplicação deve seguir as melhores práticas recomendadas, garantindo um desempenho otimizado e uma boa experiência de usuário.                                         |

### Métricas Avaliadas

- **First Contentful Paint (FCP):** Tempo até que o primeiro conteúdo significativo seja exibido.
- **Largest Contentful Paint (LCP):** Tempo até que o maior conteúdo significativo seja exibido.
- **Total Blocking Time (TBT):** Tempo total durante o qual a página ficou bloqueada e não respondeu às interações do usuário.
- **Cumulative Layout Shift (CLS):** Medida de estabilidade visual da página.
- **Speed Index (SI):** Velocidade de carregamento da página.

Os resultados das métricas serão usados para aprimorar a aplicação, garantindo que ela seja acessível, responsiva e de alto desempenho para todos os usuários.
