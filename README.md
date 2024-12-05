# Umsetzung vom Observer-Pattern mit C#

Das **Observer-Pattern** definiert das Lösungsmuster unabhängig von der Programmiersprache in welche dieses umgesetzt wird. Die einzige Vorraussetzung ist, dass die Programmiersprache das **objektorientierte** Paradigma unterstütz.

In diesem Abschnitt soll gezeigt werden, wie mit **C#** das Muster in unterschiedlichen Varianten umgesetzt werden kann.

## Umsetzung mit Schnittstellen

Die Umsetzung mit Schnittstellen erfordert die Bereitstellung von Klassen und Schnittstellen. Diese Anforderungen erfüllen in der Regel alle **objektorientierten** Programmiersprachen. So bietet auch **C#** die Möglichkeit, die Umsetzung des Musters mit Schnittstellen durchzuführen.

Bei der Implementierung wurde darauf geachtet, dass das Muster auch in einer **Multitasking** Umgebung stabil angewendet werden kann. Den Quellcode für  die "*Umsetztung mit Schnittstellen*" finden Sie auf GitHub unter folgendem [Link](https://github.com/leoggehrer/ObserverPattern/tree/main/ObserverPattern.Logic/WithInterfaces).

### Erklärung der Komponenten

1. **`Subject` (Publisher):**
   * Enthält eine Liste von Beobachtern (`_observers`) und bietet Methoden zum Hinzufügen (`Attach`) und Entfernen (`Detach`) von Beobachtern.
   * Die** **`Notify`-Methode ruft die** **`Update`-Methode jedes registrierten Beobachters auf.
2. **`IObserver` (Subscriber-Interface):**
   * Definiert die `Update`-Methode, die jeder konkrete Beobachter implementieren muss.
   * Der Parameter `sender` informiert den Beobachte über den Sender.
   * Der Parameter `e` bietet die Möglichkeit Daten an den Beobachter zu übertragen.
3. **Konkrete Beobachter (`ConcreteObserver1`,** **`ConcreteObserver2`):**
   * Implementieren das** **`IObserver`-Interface und spezifizieren, was passiert, wenn sie benachrichtigt werden.
4. **Beispiel in** **`Main`:**
   * Demonstriert, wie das Subjekt und die Beobachter interagieren, einschließlich der Registrierung und Benachrichtigung.

### Threadsicherheitsmaßnahmen in dieser Umsetzung

1. **Synchronisierte Zugriffe mit** **`lock`:**
   * Die** **`Attach`- und** **`Detach`-Methoden verwenden ein** **`lock`-Objekt, um die Liste der Beobachter vor gleichzeitigen Änderungen durch mehrere Threads zu schützen.
2. **Snapshot der Liste:**
   * In der** **`Notify`-Methode wird ein Snapshot (`List<IObserver> snapshot`) der aktuellen Beobachter erstellt. Dadurch wird verhindert, dass Änderungen an der Liste (z. B. Hinzufügen oder Entfernen von Beobachtern) die Iteration beeinflussen.
3. **Unveränderlichkeit während der Benachrichtigung:**
   * Die Benachrichtigung erfolgt auf einem Snapshot der Beobachterliste. Dies verhindert, dass der Zustand der Liste durch parallele Threads beeinflusst wird, während die Benachrichtigung läuft.
