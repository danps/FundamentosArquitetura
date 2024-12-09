# Fundamentos de Arquitetura de Software

## OOP - Programação Orientada a Objetos
A Programação Orientada a Objetos (OOP) é um paradigma de programação baseado no conceito de "objetos", que podem conter dados e código: dados na forma de campos (também conhecidos como atributos ou propriedades), e código na forma de procedimentos (também conhecidos como métodos).

### Classe x Objeto
- **Classe:** Um molde ou modelo que define a estrutura e comportamento de objetos. É uma definição do que o objeto pode fazer e quais dados ele pode armazenar.
- **Objeto:** Uma instância de uma classe. É a concretização da classe em tempo de execução, com valores específicos nos campos definidos pela classe.

### Pilares OOP
1. **Estado e Comportamento:**
   - **Estado:** Representa os dados ou atributos de um objeto.
   - **Comportamento:** Define o que o objeto pode fazer, ou seja, os métodos ou funções que operam sobre os dados do objeto.

2. **Herança:**
   - Permite que uma classe herde propriedades e métodos de outra classe. Facilita a reutilização de código e a criação de hierarquias de classes.

3. **Abstração:**
   - A prática de simplificar objetos complexos escondendo detalhes desnecessários e expondo apenas as partes relevantes. Isso ajuda a reduzir a complexidade e aumentar a eficiência do design.

4. **Polimorfismo:**
   - Permite que objetos de diferentes classes sejam tratados de forma unificada, usando a mesma interface ou método. Polimorfismo pode ser estático (sobrecarga) ou dinâmico (sobrescrita).

5. **Encapsulamento:**
   - A prática de esconder os detalhes internos de um objeto e permitir que ele seja manipulado apenas através de métodos definidos. Isso protege a integridade dos dados e promove uma interação controlada e segura com o objeto.

Esses pilares são a base para a construção de sistemas bem estruturados e moduláveis, facilitando a manutenção, expansão e compreensão do código.

### Interface x Implementação 

1. **Interface:**
   - Define o "o que" uma classe deve fazer. É um contrato sem implementação.
   
2. **Implementação:**
   - Define o "como" a classe faz o que foi especificado na interface. É o código concreto.

Uma interface é um contrato que define um conjunto de métodos e propriedades que uma classe deve implementar, mas não fornece a implementação desses métodos.

Utilizar interfaces e implementações separadas promove um design mais modular, flexível e fácil de manter, permitindo a substituição e o teste independente das implementações.

### Herança x Composição

1. **Herança**
   - Estabelece uma relação "é um" (e.g., um Cachorro é um Animal). Promove a reutilização de código, mas pode levar a um acoplamento forte e hierarquias rígidas.

2. **Composição**
   - Estabelece uma relação "tem um" (e.g., um Carro tem um Motor). É mais flexível e modular, permitindo a troca de componentes sem afetar o sistema global.
   
Ambos os conceitos são fundamentais para criar sistemas bem estruturados e reutilizáveis, cada um com suas próprias vantagens dependendo do contexto e das necessidades do projeto.