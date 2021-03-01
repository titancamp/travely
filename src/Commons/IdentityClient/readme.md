# Usage

Add project reference to *Travely.IdentityClient* project.
Add `[Authorize(Roles = UserTypes.Admin)]` attribute to your action or grpc server method. That`s it folks.

To get authenticated user info in action or server method use `GetTravelyUserInfo()` extension method.
