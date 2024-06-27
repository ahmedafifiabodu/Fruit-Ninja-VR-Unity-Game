# Fruit Ninja VR Game

Welcome to the official repository of Fruit Ninja VR Game, an immersive virtual reality experience that brings the thrilling action of fruit slicing right into your living room! Developed with Unity and optimized for VR platforms, this game lets you step into the shoes of a ninja, wielding your sword to slice through waves of fruits while avoiding bombs.

## Features

- **Immersive VR Gameplay:** Experience the thrill of slicing fruits in a fully immersive VR environment.
- **Dynamic Fruit Pooling:** Utilize an efficient pooling system for spawning fruits and bombs, ensuring smooth gameplay.
- **Interactive Menus:** Navigate through the game's menus with intuitive VR gestures.
- **Customizable Settings:** Adjust turn types and other settings to tailor the gameplay to your preferences.
- **Hand Animations:** Experience realistic hand animations for gripping and triggering, enhancing the immersive experience.
- **Teleportation and Grabbing Mechanics:** Seamlessly teleport within the game environment and interact with objects using VR controllers.

## Key Scripts

### Gameplay
- **[Game Controller.cs](#game-controller.cs-context):** Manages the core game loop, including fruit spawning, score tracking, and game over conditions.
- **[Player.cs](#player.cs-context):** Handles player-specific data such as health, score, and sword possession status.
- **[Sword Controller.cs](#sword-controller.cs-context):** Manages sword interactions, including slicing fruits and triggering special fruit effects.
- **[Fruit Movement.cs](#fruit-movement.cs-context):** Controls the physics and behavior of fruits and bombs in the game.
- **[Fruit Pooler.cs](#fruit-pooler.cs-context):** Implements an object pooling system for efficient fruit and bomb spawning.

### VR Interactions
- **[XR Offset Grab Interactable.cs](#xr-offset-grab-interactiable.cs-context):** Enhances object grabbing by adjusting the grab point based on the interactor's position.
- **[Activate Grab Ray.cs](#activate-grab-ray.cs-context):** Enables a visual ray for grabbing objects when the player's hands are empty.
- **[Activate Teleportation Ray.cs](#activate-teleportation-ray.cs-context):** Allows the player to teleport within the game environment using a visual ray.

### UI and Settings
- **[Hand Animation.cs](#hand-animation.cs-context):** Manages hand animations for gripping and triggering based on controller input.
- **[Set Turn Type.cs](#set-turn-type.cs-context):** Allows players to switch between snap turning and smooth turning.
- **[Game Menu Manager.cs](#game-menu-manager.cs-context):** Controls the in-game menu, including its appearance and position relative to the player.
- **[Main Menu.cs](#main-menu.cs-context):** Manages the main menu, including starting the game.

### Editor Tools
- **[Fruit Pooling Editor.cs](#fruit-pooling-editor.cs-context):** Provides a custom inspector for easier management of the fruit pooling system.

## Getting Started

To get started with Fruit Ninja VR Game, clone this repository and open the project in Unity. Ensure you have a compatible VR headset set up and connected. Follow the setup instructions specific to your VR platform, and you're ready to start slicing fruits in virtual reality!

## License

This project is licensed under the MIT License - see the LICENSE file for details.
