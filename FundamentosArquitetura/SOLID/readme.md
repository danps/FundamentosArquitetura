# Fundamentos de Arquitetura de Software

## SOLID

1. **SRP - Single Responsibility Principle**

Uma classe deve ter um, e apenas um, motivo para ser modificada.

**Violação:** Imagine uma classe `Cliente` que armazena dados do cliente (Repository), envia e-mails e valida tipos complexos (como email e CPF). Ou seja, esta classe possui vários motivos para ser modificada e muitos pontos de falha (troca do serviço de email, conexão com o banco de dados, etc). Qualquer erro pode gerar um impacto significativo, pois todas as responsabilidades da classe precisam ser testadas. 

**Solução:** Aplicar o SRP não resolve todos os problemas por si só, mas é um passo importante. Outros princípios do SOLID também devem ser aplicados. > O `ClienteService` não viola o princípio SRP, pois é um serviço de orquestração. Sua responsabilidade é validar, persistir e enviar e-mails.

2. **OCP – Open Closed Principle**

Entidades de software (classes, módulos, funções) devem estar abertas para extensão, mas fechadas para modificação.

**Exemplo de Violação:** No exemplo `OCP.Violacao`, quando um novo tipo de conta é criado, isso gera uma alteração na classe principal.

**Solução:** Utilizar herança para implementar a classe abstrata e/ou criar métodos de extensão para os novos tipos de conta.

2. OCP – Open Closed Principle

Entidades de software (classes, módulos, funções) devem estar abertas para extensão, mas fechadas para modificação.

**Violação** para cada novo tipo de conta, gera uma alteração na classe principal.

**Solução** Utilizar herança para implementar a Class abstract e/ou criar Extensions methods para os novos tipos de contas.

3. **LSP - Liskov Substitution Principle**

   > Subclasses devem ser substituíveis por suas superclasses.

Se algo nada como um pato, voa como um pato, mas precisa de baterias, provavelmente há um problema de abstração. A violação ocorre quando uma classe `PatoBorracha` herda de `Pato`. O `PatoBorracha` não deveria herdar de `Pato`, pois precisa de pilhas para funcionar.

**Solução:** A solução tem um exemplo de um metodo que calcula a area de um Paralelogramo, que pode receber um objeto quadrado e um objeto retangulo. 

4. **ISP - Interface Segregation Principle**

O Princípio da Segregação de Interfaces (ISP) sugere que muitas interfaces específicas são melhores do que uma única interface genérica.

**Violação:** Uma única interface genérica de cadastro força a implementação de métodos desnecessários em classes que não precisam de todos os métodos. Isso resulta em classes inchadas e difíceis de manter.

**Solução:** Criar interfaces específicas para cada contexto, por exemplo, uma interface para cadastro de cliente e outra para cadastro de produto. Ambas as interfaces podem implementar uma interface base comum.


5. **DIP - Dependency Inversion Principle**

O princípio da Inversão de Dependência dita que: Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações.

Abstrações não devem depender de detalhes. Detalhes devem depender de abstrações.

Em outras palavras, a lógica de alto nível da aplicação (módulos de alto nível) não deve conhecer os detalhes de implementação (módulos de baixo nível). Em vez disso, ambos devem depender de interfaces ou abstrações. Isso ajuda a criar um sistema mais flexível e de fácil manutenção.

> Dependa de uma abstração e não de uma implementação.

**Violação** Na violação desse princípio, a classe ClienteService (módulo de alto nível) é obrigada a saber como criar e gerenciar uma instância de ClienteRepository (módulo de baixo nível). Isso cria uma dependência direta que torna o código menos flexível e mais difícil de modificar ou testar.

**Solução** Para seguir o princípio DIP, criamos interfaces específicas como IClienteRepository, IEmailService e IClienteService. O ClienteService agora depende dessas interfaces em vez de implementações concretas. Isso permite usar um container de injeção de dependência para gerenciar essas dependências.

Uso de um Container de Injeção de Dependência: Com interfaces e injeção de dependência, podemos usar um container para resolver dependências automaticamente.

Ao usar abstrações, o sistema se torna mais modular, facilitando a substituição ou modificação de componentes individuais sem afetar o restante da aplicação. Isso melhora a testabilidade e a manutenibilidade do código.


## CleanCode

"Qualquer tolo consegue escrever código que um computador entenda. Bons programadores escrevem código que humanos possam entender." Martin Fowler
