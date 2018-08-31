# rats-game .NET Core client

This is an example client for the rats-game, written in .NET Core. It deals with
the minimal amount of work that needs to be done to communicate with the game server.
It contains examples of sending commands and retrieving game information from the server.

This implementation doesn't contain any sophisticated logic. You will have to
figure it out on your own.

# how to use

When started, the client will enter a game loop that will wait for its turn and
execute actions based on the game phase (more information in the game ruleset).

It is recommended to use the latest version of Visual Studio Code with .NET Core installed.

At the begining you may set configuration in appsettings.json where are included informations about server, port, and given token.

Then you can build this app in terminal or powershell using command: 
> dotnet build

or run app using command:
> dotnet run

