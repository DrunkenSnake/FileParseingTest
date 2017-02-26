# FileParseingTest

Basic file parsing wpf program compatible with file paths and drag and drop

for install the setup.exe is located in the root directory, simply run and then go to the shortcut to access the program


in order to properly pull nuget as well as InstallShield LE needs to be added to (preferably) Visual Studio 2015, after each build, before a commit, change to "release" and build the Install project directly (right click -> build project) then open the release folder and copy the SetUp back to the root to keep the installer updated

The program itself will accept either a drag and drop of multiple files, or a fully qualified file path

tests can use either local files if you want, or new resource files, the comments should walk you through how to convert a resource file into a usable test file
