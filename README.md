# Top Down 2D Unity Controller

## Overview

This project demonstrates a simple, responsive top-down 2D player controller in Unity, along with smooth object rotation to face the mouse cursor. It is designed for clarity, best practices, and easy extensibility for 2D games.

## Features

- **Top-Down Player Movement**
  - WASD controls for smooth, physics-based movement using Rigidbody2D.
  - All movement logic handled in `FixedUpdate()` for consistent physics.
  - Input is cached in `Update()` for responsiveness.
  - Animation and sprite flipping based on movement direction.

- **Smooth Object Rotation**
  - Object (e.g., gun or barrel) rotates to always face the mouse cursor.
  - Mouse position is cached in `Update()`, rotation logic is in `FixedUpdate()`.
  - Uses `Quaternion.Slerp` for smooth, non-snapping rotation.

- **Line Rendering (Optional)**
  - Draws a line from the player to the mouse position for aiming feedback.

## Getting Started

1. **Clone the repository:**
  ```
  git clone https://github.com/Towhidul-Islam5797/Top_Down_2D_Unity.git
  ```
2. **Open the project in Unity (version 6000.0.46f1 or newer recommended).**
3. **Open the main scene and press Play.**

## Project Structure

- `Assets/Scripts/PlayerController.cs` — Handles player movement and animation.
- `Assets/Scripts/BarrelToMouse.cs` — Rotates an object to face the mouse.
- `Assets/Scripts/AimLineController.cs` — Draws a line from player to mouse and rotates object.

## Controls

- **Move:** WASD keys
- **Aim:** Mouse cursor (object/barrel will rotate smoothly to face the cursor)

## Requirements

- Unity 6000.0.46f1 (or compatible Unity 6.x version)
- No additional packages required

## .gitignore

This project uses a Unity-optimized `.gitignore` to exclude auto-generated and local files. See `.gitignore` for details.

## License

This project is provided for educational and demonstration purposes.

---

Feel free to fork, modify, or extend this project for your own 2D Unity games!
2. **Open the project in Unity (version 6000.0.46f1 or newer recommended).**
3. **Open the main scene and press Play.**

## Project Structure

- `Assets/Scripts/PlayerController.cs` — Handles player movement and animation.
- `Assets/Scripts/BarrelToMouse.cs` — Rotates an object to face the mouse.
- `Assets/Scripts/AimLineController.cs` — Draws a line from player to mouse and rotates object.

## Controls

- **Move:** WASD keys
- **Aim:** Mouse cursor (object/barrel will rotate smoothly to face the cursor)

## Requirements

- Unity 6000.0.46f1 (or compatible Unity 6.x version)
- No additional packages required

## .gitignore

This project uses a Unity-optimized `.gitignore` to exclude auto-generated and local files. See `.gitignore` for details.

## License

This project is provided for educational and demonstration purposes.

---

Feel free to fork, modify, or extend this project for your own 2D Unity games!
