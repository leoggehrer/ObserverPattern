# Umsetzung vom Observer-Pattern mit C#

Das **Observer-Pattern** definiert das Lösungsmuster unabhängig von der verwendeten Programmiersprache. Die einzige Vorraussetzung ist, dass die Programmiersprache das **objektorientierte** Paradigma unterstütz.

In diesem Abschnitt soll gezeigt werden, wie mit **C#** das Muster in unterschiedlichen Varianten umgesetzt werden kann.

## Umsetzung mit Schnittstellen

Die Umsetzung mit Schnittstellen erfordert die Bereitstellung von Klassen und Schnittstellen. Diese Anforderungen erfüllen in der Regel alle **objektorientierten** Programmiersprachen. So bietet auch **C#** die Möglichkeit, die Umsetzung des Musters mit Klassen und Schnittstellen durchzuführen.

Bei der Implementierung wurde darauf geachtet, dass das Muster auch in einer **Multitasking** Umgebung stabil angewendet werden kann. Den Quellcode für  die "*Umsetztung mit Schnittstellen*" finden Sie auf GitHub unter folgendem [Link](https://github.com/leoggehrer/ObserverPattern/tree/main/ObserverPattern.Logic/WithInterfaces).

**Erklärung der Komponenten:**

1. I**Subject (Subject-Interface)**
   * Definert die beiden Methoden `Attach(...)` und `Detach(...)`.
2. **`Subject` (Publisher):**
   * Enthält eine Liste von Beobachtern (`_observers`) und bietet Methoden zum Hinzufügen (`Attach`) und Entfernen (`Detach`) von Beobachtern.
   * Die `Notify`All-Methode ruft die `Update`-Methode jedes registrierten Beobachters auf. Diese Methode ist `protected` gekennzeichnet und kann nur innerhalb der Vererbungshierachie aufgerufen werden.
3. **Konkretes Subject (InterfaceSubject):**
   * Erbt von der abstrakten Klasse `Subject` und kann diese um weitere Members erweitern.
4. **`IObserver` (Subscriber-Interface):**
   * Definiert die `Update`-Methode, die jeder konkrete Beobachter implementieren muss.
   * Der Parameter `sender` informiert den Beobachte über den Sender.
   * Der Parameter `e` bietet die Möglichkeit Daten an den Beobachter zu übertragen.
5. **Konkreter Beobachter (`InterfaceObserver`):**
   * Implementieren das** **`IObserver`-Interface und spezifiziert, was passiert, wenn sie benachrichtigt wird.
6. **Beispiel in** **`Main` (Program):**
   * Die Methode `RunInterfaceSubject()` demonstriert, wie das Subjekt und die Beobachter interagieren, einschließlich der Registrierung und Benachrichtigung.

### Threadsicherheitsmaßnahmen in dieser Umsetzung

* **Synchronisierte Zugriffe mit** **`lock`:**

  * Die `Attach`- und `Detach`-Methoden verwenden ein** `lock`-Objekt, um die Liste der Beobachter vor gleichzeitigen Änderungen durch mehrere Threads zu schützen.
* **Snapshot der Liste:**

  * In der `Notify`-Methode wird ein Snapshot (`List<IObserver> snapshot`) der aktuellen Beobachter erstellt. Dadurch wird verhindert, dass Änderungen an der Liste (z. B. Hinzufügen oder Entfernen von Beobachtern) die Iteration beeinflussen.
* **Unveränderlichkeit während der Benachrichtigung:

  Die Benachrichtigung erfolgt auf einem Snapshot der Beobachterliste. Dies verhindert, dass der Zustand der Liste durch parallele Threads beeinflusst wird, während die Benachrichtigung läuft.
  **

### Umsetzung mit Events

Ein **Event** in **C#** ist ein spezielles Member einer Klasse oder eines Objekts, das verwendet wird, um Benachrichtigungen auszulösen. Events basieren auf Delegates und ermöglichen eine einfache und flexible Möglichkeit, eine Publish-Subscribe-Interaktion zwischen Objekten zu implementieren. Den Quellcode für  die "*Umsetztung mit Events*" finden Sie auf GitHub unter folgendem [Link](https://github.com/leoggehrer/ObserverPattern/tree/main/ObserverPattern.Logic/WithEvents).

**Eigenschaften von Events:**

* **Kapselung von Delegates:** Events basieren auf Delegates, schränken jedoch den Zugriff ein, sodass nur die Klasse, die das Event deklariert, es auslösen kann.
* **Subscribe/Unsubscribe:** Andere Klassen können sich mithilfe der Operatoren **`+=` und** `-=` auf das Event abonnieren oder davon abmelden.
* **Callback-Mechanismus:** Sie ermöglichen die Kommunikation zwischen Objekten durch Rückruffunktionen.

**Erklärung der Komponenten:**

1. **Subject (Publisher)**

   * Definert ein `Event-Property` zum Anmelden und Abmelden von Abonennten.
   * **Lock-Objekt (`_lock`):**
     * Dient zur Synchronisation des Zugriffs auf das Event-Delegatfeld `_notifyEvent`.
     * Verhindert, dass mehrere Threads gleichzeitig das Event abonnieren oder abmelden.
   * **Lokaler Snapshot von `_notifyEvent`:**
     * In der `Notify`-Methode wird ein lokaler Snapshot des Event-Delegaten erstellt, nachdem der Zugriff synchronisiert wurde. Dies stellt sicher, dass das Event nicht null wird oder sich während der Benachrichtigung ändert.

## Gegenüberstellung der beiden Varianten

Hier ist eine tabellarische Gegenüberstellung der beiden Varianten:

| Kriterium | Observer mit Schnittstellen | Observer mit Events |
| --------- | --------------------------- | ------------------- |
| Mechanismus| Verwendung von Attach, Detach und einer Liste von Beobachtern.	| Nutzung von Delegates und Events, die von C# bereitgestellt werden. |
| Kopplung | Höhere Kopplung, da das Subjekt direkt mit den Beobachtern interagiert. | Lose Kopplung, da der Event-Mechanismus die Details abstrahiert. |
| Flexibilität | Kann mehr benutzerdefinierte Logik für das Hinzufügen/Entfernen von Beobachtern enthalten.	| Begrenzte Anpassbarkeit; Abonnenten folgen dem +=/-=-Schema. |
| Lesbarkeit des Codes | Etwas verbundener Code durch explizite Verwaltung der Beobachter. | Klarer und kompakter Code durch den Event-Mechanismus. |
| Performance | Potenziell schneller, da keine zusätzlichen Event-Delegaten erzeugt werden. | Etwas mehr Overhead durch Event-Delegates und Abstraktion. |
| Threadsicherheit | Erfordert explizite Synchronisation (z. B. lock). | Events sind von Natur aus sicherer, aber erfordern auch Synchronisation für komplexere Szenarien. |
| Mehrfachabonnements | Beobachter können nur einmal registriert werden (bei richtiger Implementierung). | Derselbe Handler kann mehrfach auf ein Event abonniert werden, was unbeabsichtigt sein kann. |
| Verwendung in C#-Idiomen | Weniger idiomatisch für C#. | Sehr idiomatisch und eng in das Design von C# integriert. |
| Erweiterbarkeit	| Einfacher durch benutzerdefinierte Methoden oder zusätzliche Schnittstellen. | Erweiterung erfolgt oft durch Definition neuer Events oder benutzerdefinierter Event-Handler. |
| Komplexität | Mehr Boilerplate-Code, insbesondere für das Hinzufügen und Entfernen von Beobachtern. | Weniger Boilerplate-Code, da Events den Mechanismus kapseln. |
| Beispiele für Anwendungen | Systeme mit vielen benutzerdefinierten Anforderungen (z. B. komplexe Beobachterlisten). | Typische Event-Driven-Architekturen, z. B. GUI-Entwicklung. |

**Wann sollte man welche Variante wählen?**

| Einsatzfall | Observer mit Schnittstellen | Observer mit Events |
| ----------- | --------------------------- | ------------------- |
| Komplexe Beobachterlogik | Wenn zusätzliche Logik für das Hinzufügen/Entfernen erforderlich ist. | Wenn es hauptsächlich um die Benachrichtigung geht. |
| Flexibilität bei der Erweiterung | Wenn erweiterte Funktionalitäten notwendig sind (z. B. mehrere Typen von Beobachtern). | Wenn die Erweiterung über neue Events realisierbar ist. |
| Einfachheit und Lesbarkeit | Weniger geeignet, da mehr Boilerplate-Code erforderlich ist. | Ideal, da Events den Mechanismus abstrahieren. |
Performance-kritische Anwendungen | Besser geeignet, da der Overhead von Events entfällt. | Geeignet, wenn Performance keine große Rolle spielt. |
| Idiomatic C#-Code | Kann verwendet werden, ist aber weniger üblich. | Bevorzugte Wahl für idiomatischen C#-Code. |

### Fazit

Observer mit Schnittstellen: Geeignet für komplexere Szenarien, bei denen spezifische Logik für die Verwaltung der Beobachter erforderlich ist.
Observer mit Events: Einfacher und kompakter, perfekt für typische Event-Driven-Architekturen und Szenarien, bei denen der Mechanismus selbst nicht erweitert werden muss.
Die Wahl hängt stark von den Anforderungen an Flexibilität, Lesbarkeit und Performance ab.
