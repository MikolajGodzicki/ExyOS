# ExyOS - Command Executer

Project that I used to learn some new things in .NET and C#. Code is clear and easily editable.

## Features

- TextEditor
- Easily command creator
- embedded interface ICommand and container of all executable commands
- Authenticator from .json file
- CE has own folders and files



# ExyOS Class Diagram

```mermaid
classDiagram
    %% Main Application Classes
    class Program {
        +Main(string[] args)$ void
    }

    class ExyOs {
        -instance: ExyOs$
        +Instance: ExyOs$
        -lexer: Lexer
        -interpreter: Interpreter
        -defaultFiles: DefaultFiles
        +user: User$
        -commandContainer: CommandContainer
        +logicPath: string$
        +osPath: string$
        -version: string
        +IsTextEditorOpened: bool$
        +ExyOs()
        +MainLoop() void
        +GetFiles() List~string~
        +GetFilesNames() List~string~
        +GetDirectories() List~string~
        +GetDirectoriesNames() List~string~
        -DisplayConsole(string path)$ void
        +GetCurrentDirectoryName()$ string
        +GetDBDirectory()$ string
        -DisplayLogo() void
    }

    %% Core Processing Classes
    class Lexer {
        +InterpretInputToCommand(string input) Command
    }

    class Interpreter {
        +Execute(Command command) void
    }

    %% Authentication System
    class Authenticator {
        +Authenticate() User
        -GetName() string
        -GetPassword() string
    }

    %% User Management
    class User {
        +ID: uint
        +Name: string
        +Password: string
        +User(string name, string password)
        +User()
        +ToString() string
    }

    class UserContainer {
        -instance: UserContainer$
        +Instance: UserContainer$
        +users: List~User~
        +UserContainer()
        +CheckIfUserIsValid(User user) CheckedUser
    }

    class CheckedUser {
        +isValid: bool
        +ID: uint
        +CheckedUser(bool isValid, uint iD)
    }

    %% Command System
    class ICommand {
        <<interface>>
        +Execute(string[] args) void
    }

    class Command {
        +commandType: string
        +commandArgs: string[]
    }

    class CommandContainer {
        +commands: Dictionary~string, ICommand~$
        +CommandContainer()
        -Initialize() void
    }

    %% Command Implementations
    class _WhoAmI {
        +Execute(string[] args) void
    }

    class _Clear {
        +Execute(string[] args) void
    }

    class _Cd {
        +Execute(string[] args) void
    }

    class _Ls {
        +Execute(string[] args) void
    }

    class _Cat {
        +Execute(string[] args) void
    }

    class _Touch {
        +Execute(string[] args) void
    }

    class _Exit {
        +Execute(string[] args) void
    }

    class _Rm {
        +Execute(string[] args) void
    }

    class _ExyTE {
        +Execute(string[] args) void
    }

    class _Help {
        +Execute(string[] args) void
    }

    %% Text Editor System
    class Editor {
        -_buffer: Buffer
        -_cursor: Cursor
        -_history: Stack~object~
        -filePath: string
        +Editor(string filePath)
        +Run() void
        -HandleInput() void
        -IsTextChar(ConsoleKeyInfo character) bool
        -Render() void
        -SaveSnapshot() void
        -RestoreSnapshot() void
        -SaveFile() void
    }

    class Buffer {
        +_lines: string[]
        +Buffer(IEnumerable~string~ lines)
        +Render() void
        +LineCount() int
        +LineLength(int row) int
        +Insert(string character, int row, int col) Buffer
        +Delete(int row, int col) Buffer
        +SplitLine(int row, int col) Buffer
    }

    class Cursor {
        +Row: int
        +Col: int
        +Cursor(int row, int col)
        +Up(Buffer buffer) Cursor
        +Down(Buffer buffer) Cursor
        +Left(Buffer buffer) Cursor
        +Right(Buffer buffer) Cursor
        -Clamp(Buffer buffer) Cursor
        +MoveToCol(int col) Cursor
    }

    class ANSI {
        +ClearScreen()$ void
        +MoveCursor(int row, int col)$ void
    }

    %% File Management
    class DefaultFiles {
        +CreateFilesIfNotExist(string path) void
        -CreateDirectory(string path) void
        -CreateFile(string path) void
        -CreateUsersFile(string path) void
    }

    class FileConst {
        +rootPath: string$
    }

    %% Attributes
    class DescriptionAttribute {
        +Name: string
        +Description: string
        +DescriptionAttribute(string name, string description)
    }

    %% Relationships
    Program --> ExyOs : creates
    Program --> Authenticator : creates
    Program --> User : uses

    ExyOs --> Lexer : contains
    ExyOs --> Interpreter : contains
    ExyOs --> DefaultFiles : contains
    ExyOs --> CommandContainer : contains
    ExyOs --> User : static reference

    Lexer --> Command : creates
    Interpreter --> Command : uses
    Interpreter --> CommandContainer : uses

    Authenticator --> User : creates
    Authenticator --> UserContainer : uses
    UserContainer --> User : manages
    UserContainer --> CheckedUser : returns

    CommandContainer --> ICommand : stores
    CommandContainer --> _WhoAmI : creates
    CommandContainer --> _Clear : creates
    CommandContainer --> _Cd : creates
    CommandContainer --> _Ls : creates
    CommandContainer --> _Cat : creates
    CommandContainer --> _Touch : creates
    CommandContainer --> _Exit : creates
    CommandContainer --> _Rm : creates
    CommandContainer --> _ExyTE : creates
    CommandContainer --> _Help : creates

    ICommand <|.. _WhoAmI : implements
    ICommand <|.. _Clear : implements
    ICommand <|.. _Cd : implements
    ICommand <|.. _Ls : implements
    ICommand <|.. _Cat : implements
    ICommand <|.. _Touch : implements
    ICommand <|.. _Exit : implements
    ICommand <|.. _Rm : implements
    ICommand <|.. _ExyTE : implements
    ICommand <|.. _Help : implements

    Editor --> Buffer : uses
    Editor --> Cursor : uses
    Editor --> ANSI : uses
    Buffer --> Editor : used by
    Cursor --> Buffer : interacts with

    ExyOs --> DefaultFiles : uses
    DefaultFiles --> FileConst : may use

    DescriptionAttribute --> _WhoAmI : decorates
    DescriptionAttribute ..> Command : can decorate
