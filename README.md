# KennzeichenAPIClient

[🇬🇧 English](#english) | [🇩🇪 Deutsch](#deutsch)

---

## English

A Windows desktop app (WPF) for managing German licence plate codes. It talks to my own REST API [KFZKennzeichenInfo](https://github.com/JonasKinader/KFZKennzeichenInfo) over HTTP.

Built during my retraining as an IT specialist for application development, 10/2025.

### Features

- Load and display all licence plate entries from the API
- Add, edit and delete entries
- Refresh the list at any time
- All API calls run asynchronously, so the window stays responsive

### Tech stack

- C# / .NET 9, WPF
- HttpClient with async/await
- JSON (de)serialization

### Getting started

1. Start the API first (see [KFZKennzeichenInfo](https://github.com/JonasKinader/KFZKennzeichenInfo)), it runs on http://localhost:5294
2. Clone this repository and open `KennzeichenAPIClient.sln` in Visual Studio
3. Run the project

### What I learned

- Consuming a REST API from a desktop application
- Asynchronous programming with async/await
- Splitting an application into backend (API) and frontend (client)

---

## Deutsch

Eine Windows-Desktop-App (WPF) zum Verwalten von KFZ-Kennzeichen. Sie spricht über HTTP mit meiner eigenen REST-API [KFZKennzeichenInfo](https://github.com/JonasKinader/KFZKennzeichenInfo).

Entstanden während meiner Umschulung zum Fachinformatiker für Anwendungsentwicklung (10/2025).

### Funktionen

- Alle Kennzeichen-Einträge aus der API laden und anzeigen
- Einträge hinzufügen, ändern und löschen
- Liste jederzeit aktualisieren
- Alle API-Aufrufe laufen asynchron, das Fenster bleibt also bedienbar

### Technik

- C# / .NET 9, WPF
- HttpClient mit async/await
- JSON-Verarbeitung

### Projekt starten

1. Zuerst die API starten (siehe [KFZKennzeichenInfo](https://github.com/JonasKinader/KFZKennzeichenInfo)), sie läuft unter http://localhost:5294
2. Dieses Repository klonen und `KennzeichenAPIClient.sln` in Visual Studio öffnen
3. Projekt starten

### Was ich dabei gelernt habe

- Eine REST-API aus einer Desktop-Anwendung heraus nutzen
- Asynchron programmieren mit async/await
- Eine Anwendung in Backend (API) und Frontend (Client) aufteilen
