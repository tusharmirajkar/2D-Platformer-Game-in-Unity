# 2D Platformer Game in Unity

A 2D platformer game project created as a learning exercise through Unity tutorials. Navigate through side-scrolling levels, jump across platforms, and shoot arrows at your enemies.

## 🎮 Features

- **Player Movement** – Smooth horizontal movement with left/right controls
- **Jumping Mechanics** – Jump with ground detection to prevent mid-air jumps
- **Arrow Shooting** – Fire arrows with mouse click
- **Animation System** – Character animations for running, jumping, and attacking
- **Tile-Based Levels** – Levels built using Unity's tilemap system
- **Physics-Based Movement** – Rigidbody2D for realistic character and projectile behavior
- **Lua Scripting** – Extended gameplay logic with Lua integration

## 📊 Tech Stack

- **Language:** C# (30.7%) + Lua (69.3%)
- **Engine:** Unity (2D game engine with Universal Render Pipeline)
- **Physics:** Physics2D for collision detection and movement
- **Animation:** Animator system for character states
- **Input:** New Input System for responsive controls

## 📁 Project Structure

```
Assets/
├── Script/                 # C# game logic and Lua bindings
│   ├── Player.cs          # Player movement, jumping, and arrow firing
│   └── Arrow.cs           # Arrow projectile behavior
├── Scenes/                # Game scenes and prefabs
│   ├── SampleScene.unity  # Main playable scene
│   ├── Player.prefab      # Player character prefab
│   ├── Arrow.prefab       # Arrow projectile prefab
│   ├── Grid.prefab        # Tilemap level layout
│   ├── BackGround.prefab  # Background elements
│   └── fillBacjgorunds.prefab
├── Sprites/               # Character and environment graphics
├── Anime/                 # Animation files
├── TileMap/               # Tile assets for level building
└── Settings/              # Unity configuration files
ProjectSettings/           # Project-wide Unity settings
```

## 🚀 Getting Started

### Prerequisites
- Unity (version compatible with URP — check your ProjectSettings)
- A code editor (VS Code, Visual Studio, or Rider recommended)
- Lua support/runtime (if using Lua scripts)

### Running the Game

1. **Clone or open the project** in Unity Hub
2. **Open the main scene:**
   - Navigate to `Assets/Scenes/SampleScene.unity`
3. **Press Play** in the Unity Editor to test

### Controls

| Input | Action |
|-------|--------|
| **A / D** or **Arrow Keys** | Move left/right |
| **Space** | Jump |
| **Mouse Click** | Fire arrow |

## 🎯 How It Works

### Player Movement (`Player.cs`)
- Horizontal movement controlled via Input System
- Ground detection using `Physics2D.OverlapCircle` to prevent mid-air jumping
- Character flips direction based on movement input
- Animation states managed through the Animator component

### Arrow Projectiles (`Arrow.cs`)
- Arrows instantiate at the player's `spawnPosition`
- Velocity applied via Rigidbody2D at configurable `arrowSpeed`
- Automatically destroys after 5 seconds to prevent memory buildup

### Level Design
- Levels built using tilemap prefabs (`Grid.prefab`)
- Background layers for visual depth
- Collision layers define walkable surfaces and obstacles

### Lua Integration
- Extended gameplay logic written in Lua (69.3% of codebase)
- C# scripts provide core functionality and bindings
- Lua handles configuration, balancing, and dynamic game behavior

## 🔧 Key Components

### Player Settings
- `JumpHight` – Jump velocity (default: 7f)
- `moveSpeed` – Horizontal movement speed (default: 5f)
- `arrowSpeed` – Arrow projectile speed (default: 20f)
- `groundLayer` – Layer mask for ground detection

### Physics
- Gravity applied via Rigidbody2D
- Collider2D for collision detection
- Layer-based ground checking for reliable jumping

## 📚 Learning Resources

This project was built following Unity tutorials covering:
- 2D character movement and animation
- Physics-based platformer mechanics
- Prefab instantiation and projectile systems
- Input handling with the new Input System
- Lua scripting integration with Unity

## 📄 License

This project is open for learning and educational purposes.

---

**Created by:** tusharmirajkar  
**Last Updated:** July 2026  
**Language Composition:** Lua (69.3%) | C# (30.7%)
