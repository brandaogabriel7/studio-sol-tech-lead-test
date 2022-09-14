# Studio Sol - Tech Lead Back-end - Prova prática

## Introdução

O problema consiste em extrair números romanos de uma string composta apenas por letras, identificar o menor número primo entre os encontrados e retorná-lo (em romano e em valor numérico).

## Processo

Abaixo está descrito meu processo, desde a decisão das tecnologias e padrões, passando pelo raciocíno na resolução dos problemas até a solução final.

### Tecnologias e padrões

Meus primeiros esforços se voltaram para decidir a Stack de desenvolvimento as configurações do projeto.

Eu decidi desenvolver a API com `GraphQL` usando `ASP.NET Core`. Então, o primeiro passo foi criar a solução com os projetos. A solução continha, inicialmente, dois projetos: o projeto principal ASP.NET Core e um projeto para testes com `xunit`.

Para facilitar a execução da aplicação e deploy para algum ambiente, caso desse tempo, eu resolvi criar uma `Dockerfile` para gerar a imagem `Docker`.

Além disso, eu criei um pipeline para realizar o build e rodar os testes com todos os Pull Requests que eu subisse, visto que usei o `Git` e o `Github` para controle de versão.

> Outro ponto é que eu desenvolvo com TDD, então meus testes de unidade são um bom norte para entender o que o código faz.

#### **Lista completa:**

- ASP.NET Core
- API em padrões GraphQL
- Docker
- Github e Github Actions
- xunit, FluentAssertions e NSubstitute
- graphql-dotnet/server com Altair UI

> Alguns dos itens foram decididos em etapas posteriores mas já estão na lista completa, acima.

### Configurações do GraphQL

Eu nunca tinha usado GraphQL antes desse desafio. Então, antes de iniciar essa solução eu tirei algumas horas de estudo e fiz alguns testes. Mas não cheguei a utilizar GraphQL com .NET durante esses estudos, então tive que dedicar algum tempo entendendo as bibliotecas/frameworks que poderiam me auxiliar.

Acabei me decidindo por utilizar a [graphql-dotnet/server](https://github.com/graphql-dotnet/server).

Então configurei a API para usar GraphQL e configurei o Altair UI como playground para testes.

Depois disso, configurei o schema e mutation search com classes e as funcionalidades da biblioteca.

### Identificação do menor número romano no texto

Quando eu cheguei nessa etapa, me escapou que eu devia recuperar o menor número _primo_ presente no texto. Então, a lógica que eu vou descrever nessa etapa só recupera o menor número romano, independente dele ser primo.

O algoritmo que eu bolei foi o seguinte:

1. identificar todos os números romanos

   - Substituir todos os caracteres que não fossem dígitos romanos (`I, V, X, L, C, D, M`) por um espaço em branco. Dessa forma, só os números romanos ficariam na cadeia e os espaços me permitiriam quebrar em grupos sem separar números compostos por mais de um dígito.

   - Remover espaços no início e fim e separar os grupos de números romanos quebrando a cadeia nos espaços.

1. Com os números romanos identificados e agrupados, o próximo passo seria identificar o valor numérico dos números romanos. A lógica que pensei foi a seguinte:

   - Subsituir todos os dígitos romanos por seus valores numéricos e fazer o cálculo começando de trás pra frente.

   - Começando do último dígito, checa se o dígito anterior é menor que o atual. Se for, deve-se subtraí-lo. Senão, deve-se somá-lo.

   - Seguindo essa lógica até o primeiro dígito, obtém-se o valor numérico do número em romano.

1. Depois, com uma coleção de números romanos e seus respectivos valores numéricos. Bastava identificar o menor entre eles:

   - Percorrer a coleção.

   - Salvar o primeiro número como menor.

   - A partir do segundo número, comparar com atual menor número. Se for menor, substituí-lo como menor. Senão, passar para as próximas iterações até o fim da coleção.

Seguindo o algoritmo acima, pode-se obter o menor número romano de um texto.

**Exemplo:**

Entrada: `"HAHAHAXLVIIOPAAAAAIV"`

1. Substituindo tudo que não é dígito romano por espaço:

   `" XLVII IV"`

1. Removendo espaços no início e fim.

   `XLVII IV"

1. Quebrando em coleção.

   `["XLVII", "IV"]`

1. Para cada número, substituir os dígitos pelos valores numéricos.

   `"XLVII" -> [10, 50, 5, 1, 1]`

   `"IV" -> [1, 5]`

1. Começando de trás para frente, subtrair os números se o atual for maior que o anterior e somar se for menor ou igual.

   `[10, 50, 5, 1, 1] = 1 + 1 + 5 + 50 - 10 = 47`

   `[1, 5] = 5 - 1 = 4`

1. Com isso temos 2 números romanos identificados:

   `{ "number": "XLVII", "value": 47 };`

   `{ "number": "IV", "value": 4 }`

1. Identificar o menor:

   `{ "number": "IV", "value": 4 }`

### Desacoplando o serviço da lógica de números primos

Quando eu terminei essa solução, eu achei que tava tudo pronto. Mas o caso demonstrado no PDF da prova não deu certo (claramente). Aí eu reli o enunciado e percebi que faltou checar por números primos. Esse era o próximo passo.

Eu não tinha certeza de quais eram as melhores formas de checar se um número é primo. Não sabia se era melhor gerar uma coleção de números primos no início da aplicação ou calcular para cada requisição.

Tendo isso em mente, eu injetei uma dependência que ficaria responsável por essa lógica e mockei a chamada dessa dependência para desacoplar meus testes de unidade atuais e testar o restante da lógica. Além disso, dessa forma fica simples de injetar várias versões do algoritmo e fazer vários testes.

Se fosse uma aplicação real, meu código do serviço não ficaria dependende de qual algoritmo eu uso para identificar números primos. Essa implementação poderia ser alterada várias vezes no container de injeção de dependências sem nenhuma alteração no serviço.

### Implementando função que identifica números primos

Depois de algumas análises, eu decidi que seria mais vantajoso ter uma função que checa se um número é primo em tempo real ao invés de armazenar uma coleção muito grande de números primos. Dependendo do tamanho da coleção, o acesso poderia ser ainda mais custoso para números maiores do que o cálculo. Além disso, poderia ocupar bastante memória.

Tendo isso em mente, eu considerei algumas formas de otimizar o algoritmo, como guardar cache de números primos já calculados, checar se os números são primos em múltiplas threads ou usar algoritmos mais complexos mas que são mais rápidos para identificar se um número é primo.

Contudo, eu já estava gastando muito tempo pensando em cenários de performance ruim sem ter ao menos uma implementação simples. E, como em um caso de uma API real, não faz sentido ser excessivamente minucioso com a performance a não ser que seja uma aplicação crítica ou que já tenha métricas da aplicação funcionando em produção que demonstrem que o código não está performando bem.

Um algoritmo mais simples como "Trial division" usando algumas otimizações menores pode ser mais que o suficiente para o caso. Então resolvi implementá-lo e pensar em outras otimizações caso a performance ficasse insatisfatória nos testes.

Eu li um pouco sobre os algoritmos e otimizações [nesse site](https://cp-algorithms.com/algebra/primality_tests.html) e resolvi seguir com o "Trial division" com algumas otimizações simples mencionadas [nesse artigo](https://cp-algorithms.com/algebra/factorization.html).

> Eu considerei a definição de número primo como sendo um número que é divisível por exatamente 2 números, 1 e ele mesmo. Então o número 1 não foi considerado como um número primo.

### Otimizações do algoritmo

Depois de fazer a primeira implementação, sem otimizações, eu identifiquei pelos meus testes de unidade, que a função é bem rápida. Cada caso de teste levou menos de 1ms. Apenas um dos casos de teste levou 6ms para executar, o do número 550. Uma performance já satisfatória.

```csharp
public bool IsPrimeNumber(int value)
{
   if (value == 1)
   {
         return default;
   }

   for (var divisor = 2; divisor * divisor <= value; divisor++)
   {
         if (value % divisor == 0)
         {
            return default;
         }
   }
   return true;
}
```

Apesar dos resultados satisfatórios, resolvi implementar uma otimização simples usando uma regra que encontrei, chamada 6k+-1. Em resumo, todos os números primos depois do 2 e do 3 seguem a forma de 6n -1. Então, para implementá-la, a minha função pode checar se o número é divisível por 2 ou 3 antes de entrar no laço, e, depois disso, o incremento do laço para passar pelos outros divisores muda para 6, diminuindo bastante o número de iterações.

```csharp
public bool IsPrimeNumber(int value)
{
   if (value == 2 || value == 3)
   {
         return true;
   }

   if (value <= 1 || value % 2 == 0 || value % 3 == 0)
   {
         return default;
   }

   for (var divisor = 5; divisor * divisor <= value; divisor += 6)
   {
         if (value % divisor == 0)
         {
            return default;
         }
   }
   return true;
}
```
