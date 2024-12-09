# Fundamentos de Arquitetura de Software

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
