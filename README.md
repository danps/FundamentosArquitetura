# Fundamentos de Arquitetura de Software

Arquitetura vs Tempo

| Tradicional                 | Waterfall                           |
|-----------------------------|-------------------------------------|
| **Como fazer software**     | Tarefas e cronogramas em sequência  |
| **O que será entregue**     | Aplicações monolíticas              |
| **Onde**                    | Servidor físico                     |


| Atual                       | Agile                               |
|-----------------------------|-------------------------------------|
| **Como fazer software**     | Entregas parciais e incrementais    |
| **O que será entregue**     | Aplicações em camadas               |
| **Onde**                    | Virtualização privada               |

| Emergente                    | DevOps                                                    |
|-----------------------------|------------------------------------------------------------|
| **Como fazer software**     | Operações e desenvolvimento juntos, automação e entrega contínua em nuvem |
| **O que será entregue**     | Microserviços e APIs                                       |
| **Onde**                    | Containers (Docker) e nuvem híbrida (banco na nuvem e aplicação on-premise) |


| Futuro                      | NoOps                                             |
|-----------------------------|---------------------------------------------------|
| **Como fazer software**     | Serviços serverless - Funções que rodam em nuvem  |
| **O que será entregue**     | Computação serverless - totalmente em nuvem       |
| **Onde**                    | Funções hospedadas em uma nuvem pública           |


# Projetos

## OOP - Programação Orientada a Objetos

1. Classe x Objeto

2. Pilares OOP

   * Estado comportamento
   * Herança
   * Abstração
   * Polimorfismo
   * Encapsulamento

3. Interface x Implementação

4. Herança x Composição

## Modificadores

Os modificadores de acesso são palavras-chave usadas para especificar a acessibilidade declarada de um membro ou de um tipo. Esta seção apresenta os quatro modificadores de acesso:

* public: o acesso não é restrito.
* protected: o acesso é limitado à classe que os contém ou aos tipos derivados da classe que os contém.
* internal: o acesso é limitado ao assembly atual.
* protected internal: o acesso é limitado ao assembly atual ou aos tipos derivados da classe que os contém.
* private: o acesso é limitado ao tipo recipiente.
* private protected: o acesso é limitado à classe que o contém ou a tipos derivados da classe que o contém no assembly atual.
* file: o tipo declarado apenas é visível no arquivo de origem atual. Os tipos com escopo de arquivo geralmente são usados para geradores de fonte.


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


## Design Patterns

### Creational Patterns
1. **Abstract Factory**
   - Fornece uma interface para criar famílias de objetos relacionados ou dependentes sem especificar suas classes concretas.

2. **Factory Method**
   - Define uma interface para criar um objeto, mas permite que as subclasses alterem o tipo de objeto que será criado.

3. **Singleton**
   - Garante que uma classe tenha apenas uma instância e fornece um ponto de acesso global a essa instância.

### Structural Patterns
1. **Adapter**
   - Permite que a interface de uma classe existente seja usada como outra interface. É usado para fazer classes com interfaces incompatíveis trabalharem juntas.

2. **Facade**
   - Fornece uma interface simplificada para um conjunto complexo de classes, bibliotecas ou frameworks.

3. **Composite**
   - Componha objetos em estruturas de árvore para representar hierarquias parte-todo. Permite que clientes tratem objetos individuais e composições de objetos uniformemente.

### Behavioral Patterns
1. **Command**
   - Encapsula uma solicitação como um objeto, permitindo parametrizar clientes com filas, solicitações e operações reversíveis.

2. **Strategy**
   - Define uma família de algoritmos, encapsula cada um deles e os torna intercambiáveis. Permite que o algoritmo varie independentemente dos clientes que o utilizam.

3. **Observer**
   - Define uma dependência um-para-muitos entre objetos, para que, quando um objeto muda de estado, todos os seus dependentes sejam notificados e atualizados automaticamente.

## Links

1. [TOGAF - The Open Group Architecture Framework](https://www.opengroup.org/togaf)
2. [ISO 42010:2011 - Systems and Software Engineering](https://www.iso.org/standard/50508.html)
3. [Microsoft Architect Journal](https://www.microsoft.com/en-us/download/details.aspx?id=3559)
4. [IASA - International Association of Software Architects](https://iasaglobal.org)
5. [Zachman Framework for Enterprise Architecture](https://www.zachman.com)
6. [BPMN - Business Process Model and Notation](https://www.bpmn.org)
7. [Catálogo Web de Design Patterns](https://www.dofactory.com/net/design-patterns)
8. [Referências de CQRS](https://www.eduardopires.net.br/category/cqrs)
9. [IoC Performance](https://github.com/danielpalme/IocPerformance)