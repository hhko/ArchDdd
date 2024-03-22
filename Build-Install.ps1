# 패키지 ID                              버전           명령
# --------------------------------------------------------------------
# dotnet-coverage                        17.9.6        dotnet-coverage
# dotnet-reportgenerator-globaltool      5.2.0         reportgenerator
# docfx                                  2.75.3        docfx

dotnet tool install --global dotnet-coverage --version 17.9.6
dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.2.0
dotnet tool install --global dotnet-format --version 5.1.250801

# Install Visual Studio 2022 (Community or higher) and make sure you have the latest updates.
# Install .NET SDK 6.x, 7.x and 8.x.
# Install NodeJS (20.x.x).
dotnet tool install --global docfx --version 2.75.3

dotnet tool list --global