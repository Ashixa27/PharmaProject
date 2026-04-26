# MiniPharmaSystem

A simple pharmacy system that calculates medicine prices with discounts.

## Features

- Calculate medicine prices with age and prescription discounts
- Browse medicine inventory
- Age-based discounts: 50% for under 18, 30% for seniors (65+)
- Prescription discounts available

## Usage

1. Calculate medicine price - enter medicine name, age, and prescription status
2. List medicines - view all available medicines
3. Exit - quit the program

## Project Structure

```
MiniPharmaSystem/
├── Models/                 # Domain models
├── Services/               # Business logic
├── Repositories/           # Data access layer
├── Factories/              # Object creation
├── RuleEngine/             # Pricing rules
├── Data/                   # Data files
└── Program.cs

MiniPharmaSystem.test/      # Unit tests
```

## Design Patterns

- **Repository Pattern**: Abstracts data access layer
- **Factory Pattern**: Encapsulates medicine object creation
- **Strategy Pattern**: Implements flexible pricing rules

## Technologies

- C# 12
- .NET 8.0
- JSON data storage
