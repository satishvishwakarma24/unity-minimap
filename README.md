# Unity Minimap - NavMesh Visual Navigator

A Unity project that provides an interactive visual map/minimap system for real-time navigation visualization during gameplay. This system leverages Unity's NavMesh technology to display player position and navigation paths within your game world.

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Development](#development)
- [Contributing](#contributing)
- [License](#license)

## 🎮 Overview

**Unity Minimap** is a navigation visualization system designed to enhance gameplay experience by providing players with a real-time minimap. The system integrates with Unity's built-in NavMesh system to display navigation information and player position within the game world.

This project is built following Unity best practices and guidelines to ensure scalability, performance, and maintainability.

## ✨ Features

- **Real-time Navigation Visualization** - Display live player position and navigation path on the minimap
- **NavMesh Integration** - Seamless integration with Unity's NavMesh system for accurate pathfinding visualization
- **Interactive Minimap** - Visual representation of the game world with dynamic updates during gameplay
- **Performance Optimized** - Efficient rendering and update cycles for minimal performance impact
- **Modular Architecture** - Clean, reusable components following Unity project guidelines

## 📦 Requirements

- **Unity Engine** - 2020 LTS or newer (recommended: 2022 LTS+)
- **C#** - 8.0 or higher
- **Visual Studio Code** - With C# extensions installed
- **Git** - For version control and branch management

### Recommended Setup

- **IDE**: Visual Studio Code with C# extensions
- **OS**: Windows 10+, macOS 10.14+, or Linux
- **RAM**: 8GB minimum (16GB recommended for development)

## 🚀 Installation

### Step 1: Clone the Repository

```bash
git clone https://github.com/satishvishwakarma24/unity-minimap.git
cd unity-minimap
```

### Step 2: Switch to Development Branch

```bash
git checkout navmesh--local-dev
```

### Step 3: Open in Unity

1. Open Unity Hub
2. Click "Open Project"
3. Navigate to the cloned repository folder
4. Select and open the project
5. Wait for Unity to import assets and compile scripts

### Step 4: Configure Your Development Environment

1. Open the project in Visual Studio Code:
   ```bash
   code .
   ```
2. Install recommended C# extensions:
   - C# (powered by OmniSharp)
   - Debugger for Unity

## 💡 Usage

### Basic Setup

1. Create a scene with a terrain or game level
2. Add a NavMesh to your scene:
   - Select your terrain/level
   - Go to `Window > AI > Navigation`
   - Configure NavMesh settings
   - Click "Bake"

3. Add the Minimap UI to your canvas:
   - Drag the Minimap prefab into your scene
   - Attach your player object reference
   - Configure minimap parameters (scale, position, etc.)

### Example Code

```csharp
// Get the minimap controller
MinimapController minimapController = GetComponent<MinimapController>();

// Update minimap with player position
minimapController.UpdatePlayerPosition(playerTransform);

// Visualize a navigation path
minimapController.DisplayNavigationPath(waypoints);
```

## 📁 Project Structure

```
unity-minimap/
├── Assets/
│   ├── Scripts/
│   │   ├── Core/              # Core minimap functionality
│   │   ├── UI/                # UI management components
│   │   ├── Navigation/        # NavMesh related scripts
│   │   └── Utils/             # Utility functions
│   ├── Prefabs/               # Reusable prefabs
│   ├── Scenes/                # Example scenes
│   ├── UI/                    # UI layouts and assets
│   └── Materials/             # Shaders and materials
├── ProjectSettings/           # Unity project settings
└── README.md                  # This file
```

## 🛠️ Development

### Code Style Guidelines

Follow the [Unity C# Style Guide](https://docs.unity3d.com/Manual/ScriptStyleGuideIntroduction.html):

- Use PascalCase for class names and public methods
- Use camelCase for private fields and local variables
- Add XML documentation comments for public methods
- Keep methods focused and single-purpose

### Building and Testing

1. **Build the project**:
   - File > Build and Run
   - Select target platform
   - Configure build settings

2. **Run in Editor**:
   - Press `Ctrl+P` (or `Cmd+P` on Mac) to play
   - Test minimap functionality in real-time

### Branch Strategy

- `main` - Stable release branch
- `navmesh--local-dev` - Development branch for NavMesh features
- Feature branches - Created from development branch for specific features

## 🤝 Contributing

Contributions are welcome! Please follow these guidelines:

1. Create a feature branch from `navmesh--local-dev`
2. Follow the project's code style guidelines
3. Test your changes thoroughly
4. Submit a pull request with a clear description
5. Ensure all tests pass before merging

## 📄 License

This project is open source and available under the MIT License. See LICENSE file for details.

---

## 📞 Support & Questions

For questions, issues, or suggestions, please create an issue on the [GitHub repository](https://github.com/satishvishwakarma24/unity-minimap).

**Happy Developing! 🎮**
