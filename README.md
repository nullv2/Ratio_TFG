[![Build MAUI Android APK (.NET 8)](https://github.com/nullv2/Ratio_TFG/actions/workflows/build-apk.yml/badge.svg?branch=main)](https://github.com/nullv2/Ratio_TFG/actions/workflows/build-apk.yml)

# Ratio_TFG

**Ratio_TFG** is an Android application designed to assist players of Warhammer 40,000: Kill Team in managing and simulating various aspects of the game. Built with Domain-Driven Design (DDD) principles and adhering to Clean Code practices, the app provides comprehensive tools for simulating combat scenarios, managing kill teams, and planning strategies.

## Features

- **Android Platform**: Optimized for Android devices, providing a seamless user experience.
- **Kill Team Management**: Includes four fully implemented kill teams, allowing users to manage operatives and their equipment.
- **Combat Simulation**:
  - **Weapon and Effect Simulation**: Simulate weapon effects, including special rules and modifiers.
  - **Fight and Shooting Phases**: Accurately simulate combat phases with detailed outcomes.
- **Strategic Planning**:
  - **Ploys and Equipment**: Infrastructure in place to implement strategic and firefight ploys, as well as equipment effects.
  - **Combat Contexts**: Differentiate between various combat scenarios for more accurate simulations.
- **Architecture**:
  - **Domain-Driven Design (DDD)**: Structured around DDD principles for maintainability and scalability.
  - **Clean Code Practices**: Emphasis on readable, efficient, and testable code.
  - **Create Pattern**: Utilizes the Create pattern to manage object creation and dependencies.

## Project Structure

- **Ratio.Mobile**: Main Android application containing the user interface and interaction logic.
- **Ratio.Application**: Core application logic and use cases.
- **Ratio.Domain**: Domain models and business rules.
- **Ratio.Infrastructure**: Data access and external service integrations.
- **Ratio.Console**: Console application for testing and development purposes.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) for backend projects.
- [Visual Studio](https://visualstudio.microsoft.com/) for console application development.

### Building the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/nullv2/Ratio_TFG.git
   cd Ratio_TFG
   ```
2. Open `Ratio.Mobile` in Visual Studio to build and run the MAUI Hybrid application.
3. Open `RATIO.sln` in Visual Studio to build and run the console application for testing.

## Usage

- **Android Application**: Use the app to manage your kill teams, simulate combat scenarios, and plan strategies during gameplay.
- **Console Application**: Utilize the console app for testing purposes, such as validating combat simulations and debugging logic.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request with your enhancements. For significant changes, open an issue to discuss your proposed modifications.

## Acknowledgments

- [Games Workshop](https://www.games-workshop.com/) for Warhammer 40,000: Kill Team.
