# GoF Patterns (Gang of Four)

In this project you can find very basic implementations of the OOP patterns described in the 1994 book **Design Patterns: Elements of Reusable Object-Oriented Software**.

Special thanks to https://refactoring.guru for pattern descriptions.

## Currently implemented patterns

### Creational
- *AbstractFactory* - multiple classes with a shared interface which are responsible for creating families of related objects
- *Builder* - a class which allows the user to create a complex object
- *Factory Method* - replaces direct object initialization with a single method 
- *Prototype* - allows object creation by copying existing objects
- *Singleton* - provides an object that has only one instance

### Structural
- *Adapter* - adapts the interface of one class to another
- *Bridge* - separates abstraction from implementation using 2 parts
- *Composite* - composes objects into tree structures
- *Decorator* - allows attaching new behaviors to objects by wrapping them
- *Facade* - simplifies outside interaction with a group of interlinked objects
- *Flyweight* - allows to replace multiple instances of a commonly created object with just one
- *Proxy* - provides a placeholder for another object

### Behavioral
- *Chain of Responsibility* - allows to pass a request along a chain of handlers
- *Command* - incapsulates requests in objects
- *Interpreter* - defines a grammatical representation for a language
- *Iterator* - provides a way to iterate over all elements of an object without exposing the object contents
- *Mediator* - reduces chaotic dependencies between objects
- *Momento* - allows to save and restore object state
- *Observer* - defines a subscription mechanism for notifying multiple objects