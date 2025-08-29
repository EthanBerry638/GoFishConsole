## 🎣 Go Fish Console Edition

A modular, console-based implementation of the classic card game *Go Fish*, built in C# with a focus on clean architecture, maintainability, and example-driven learning.

---

### 💡 Why This Project?

This game is part of my journey to become job-ready as a C#/.NET developer. It reflects my commitment to:

- Clean, scalable architecture
- Iterative code review and modular design
- Building portfolio projects that demonstrate technical growth and design reasoning

---

### 🕹️ Gameplay Overview

- Two-player game: Human vs AI  
- Players take turns guessing ranks in the opponent’s hand  
- If the guess is correct, the card is transferred; otherwise, the player "goes fish"  
- The game continues until all books (sets of four matching ranks) are completed by either player  

---

### 🚧 Current Status

- ✅ Basic card dealing and hand viewing  
- ✅ Input parsing with enum validation  
- ✅ Game loop and win condition scaffolding  

---

### 🛣️ Roadmap

- 📁 Leaderboard with file-based saving  
- 🧩 Refactor "Play" menu into "New Game" or "Continue" with up to 3 recent saves  
- 🧠 Difficulty levels for AI  

---

### 🛠️ How to Run

#### Prerequisites
- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download) installed  
- A terminal or IDE like Visual Studio or VS Code  



-Clone the repository
   ```bash
   git clone https://github.com/EthanBerry638/GoFishConsole.git
   cd GoFishConsole

-Build and run the project
dotnet build
dotnet run

-Follow the console prompts
-Choose to start a new game
-Enter card ranks when prompted (e.g., Ace, Seven, King)
-Play until all books are completed!