# Diamond Kata

## Project Overview

This repository contains a production-quality C# (.NET 8) console application for the Diamond Kata. The application accepts a numeric value from 2 to 5, maps that value to a maximum letter from B to E, and generates a centered diamond pattern.

## Requirements

### Functional Requirements

- Prompt the user to enter a single number.
- Accept only values `2`, `3`, `4`, or `5`.
- Interpret those values as the maximum diamond letter:
  - `2 = B`
  - `3 = C`
  - `4 = D`
  - `5 = E`
- Generate the correct diamond output for valid input.
- Validate invalid inputs and return the required messages:
  - Empty input: `Error: Input cannot be empty.`
  - Non-numeric input: `Error: Please enter a numeric value between 2 and 5.`
  - Out-of-range numeric input: `Error: Value must be between 2 and 5.`

### Technical Requirements

- .NET 8 console application
- Business logic separated from console input/output
- xUnit unit tests
- Clean, maintainable design aligned with SOLID principles

## Assumptions

- Only values from `2` to `5` are supported.
- The solution is implemented as a console application.
- All messages are presented in English.

## Solution Design

### Components

- `Program.cs`: Console entry point responsible only for prompting, validating, and displaying output.
- `Services/InputValidator.cs`: Validates empty, numeric, and range rules.
- `Services/DiamondGenerator.cs`: Generates the diamond string with no console coupling.
- `Models/ValidationResult.cs`: Carries validation status, parsed level, and error message.
- `Tests/DiamondGeneratorTests.cs`: Verifies the expected diamond output for levels 2 through 5.
- `Tests/InputValidatorTests.cs`: Verifies valid, range, non-numeric, and empty input scenarios.

### Design Decisions

- Validation is isolated from generation so each class has a single responsibility.
- `DiamondGenerator.Generate` returns a string, which keeps the business logic testable and reusable.
- Defensive programming is applied by guarding the generator against unsupported levels.
- Dependencies are injected through object usage boundaries rather than embedding business logic in the console entry point.

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

- Configurable maximum size
- Lowercase support
- Web UI
- API endpoint

## Key Design Decisions

- The console application remains intentionally thin so interview reviewers can quickly see the separation between user interaction and business rules.
- Focused unit tests cover the required valid and invalid cases and support high confidence in behavior changes.
