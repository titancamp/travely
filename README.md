# Travely
# identity-manger

#TourModels
Shared Project that includes shared business models concerning Tours and it's components. These classes will be used for back-to-back communication between backend microservices.

To use the classes add the project as a reference with the following command:
```
dotnet add [path_to_project] reference src/Shared/TourEntities/TourEntities.csproj
```
Classes are defined as partial to avoid merge conflicts. In order to keep track of each team's changes please use the following format for defining your team's partial classes:
```
public partial class [Team name abbreviation][className]

For Example:
public partial class TMTour
```
