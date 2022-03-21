Thos project contains 2 different porojects:

1) JWT Auth project helps to create tokens, authorization and authentication base on user inforamtion.
2) Web Api projects exponse some endpoints base on JWT Auth.

Implement JWT

Create a JWT ->

1) We need to call Endpoint -> /login  with user credentials
 
   Example -> 
   
   url:  https://jwtauthatm.azurewebsites.net/login
   payload:
   {
    "Username":"admin",
    "Password":"admin"
   }

  Response:
  {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoidXNlci5hZG1pbkBlbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9naXZlbm5hbWUiOiJBZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJNYWluIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW5pc3RyYXRvciIsIm5iZiI6MTY0NjY4Mzc5MCwiZXhwIjoxNjQ2Njg0MDkwLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MjYzLyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6Nzk4OSJ9.scPO7tgCJOb9gpaaOw0A2ZMWZbHu4mN-Z7JtUHdSkeo"
  }
  
  Using JWT
  
  In WebApi endpoints we need to pass in header Bearer token
  
  The API Projects has enable swagger, so we could use authorize button
  
  ![image](https://user-images.githubusercontent.com/21364401/157110711-ba0a129a-865a-47c0-ac2d-a61300dc686c.png)

   we pass token into Value textbox ->
   
   ![image](https://user-images.githubusercontent.com/21364401/157110884-0c8cef5a-b4cb-40d5-bb5f-1554bea5e53f.png)

  Now we could call authenticated endpoints
  

  
