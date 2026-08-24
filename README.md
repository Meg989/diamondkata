# Diamond Kata

## Project Overview

This repository contains a production-quality C# (.NET 8) console application for the Diamond Kata. The application accepts a numeric value in a configurable range (default `2` to `5`), maps that value to a maximum letter, and generates a centered diamond pattern.

## Requirements

### Functional Requirements

- Prompt the user to enter a single number.
- Accept only values between configured lower and upper limits.
- By default, interpret the values as the maximum diamond letter:
  - `2 = B`
  - `3 = C`
  - `4 = D`
  - `5 = E`
- Generate the correct diamond output for valid input.
- Validate invalid inputs and return the required messages:
  - Empty input: `Error: Input cannot be empty.`
  - Non-numeric input: `Error: Please enter a numeric value between <lower> and <upper>.`
  - Out-of-range numeric input: `Error: Value must be between <lower> and <upper>.`

### Technical Requirements

- .NET 8 console application
- Business logic separated from console input/output
- xUnit unit tests
- Clean, maintainable design aligned with SOLID principles

## Assumptions

- Defaults are `2` (lower) and `5` (upper), and both can be changed in configuration.
- The solution is implemented as a console application.
- All messages are presented in English.

## Solution Design

### Components

- `Program.cs`: Console entry point responsible only for prompting, validating, and displaying output.
- `appsettings.json`: Stores configurable input bounds under `DiamondSettings`.
- `Services/InputValidator.cs`: Validates empty, numeric, and range rules.
- `Services/DiamondGenerator.cs`: Generates the diamond string with no console coupling.
- `Services/RangeSettingsProvider.cs`: Loads configured lower and upper bounds.
- `Models/ValidationResult.cs`: Carries validation status, parsed level, and error message.
- `Models/RangeSettings.cs`: Represents configured lower and upper bounds.
- `Tests/DiamondGeneratorTests.cs`: Verifies the expected diamond output for levels 2 through 5.
- `Tests/InputValidatorTests.cs`: Verifies valid, range, non-numeric, and empty input scenarios.

### Design Decisions

- Validation is isolated from generation so each class has a single responsibility.
- `DiamondGenerator.Generate` returns a string, which keeps the business logic testable and reusable.
- Defensive programming is applied by guarding the generator against unsupported levels.
- Dependencies are injected through object usage boundaries rather than embedding business logic in the console entry point.

## Configuration

The lower and upper input limits are configurable in `DiamondKata/appsettings.json`:

```json
{
  "DiamondSettings": {
    "LowerLimit": 2,
    "UpperLimit": 5
  }
}
```

If the user enters a value outside the configured range, the application shows a validation message and exits gracefully without generating output.

## Running the Application

```bash
dotnet restore
dotnet build
dotnet run --project DiamondKata/DiamondKata.csproj
```

## Running Tests

```bash
dotnet test
```

## Sample Outputs

### Input: 2

```text
 A
B B
 A
```

### Input: 3

```text
  A
 B B
C   C
 B B
  A
```

### Input: 5

```text
    A
   B B
  C   C
 D     D
E       E
 D     D
  C   C
   B B
    A
```

## Future Enhancements

- Lowercase support
- Web UI
- API endpoint

## Key Design Decisions

- The console application remains intentionally thin so interview reviewers can quickly see the separation between user interaction and business rules.
- Focused unit tests cover the required valid and invalid cases and support high confidence in behavior changes.
