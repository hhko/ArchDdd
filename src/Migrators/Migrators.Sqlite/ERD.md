<!--- SIREN_START -->
```mermaid
	%%{init: {'theme':'neutral'}}%%
	erDiagram
	Role {
		VarChar128 Name 
	}
	RoleUser {
		VarChar128 RoleName FK
		Char26 UserId FK
	}
	User {
		Char26 Id 
		TEXT CreatedOn 
		TEXT Email 
		NChar514 PasswordHash 
		TEXT UpdatedOn 
		TEXT Username 
	}
RoleUser}o--||Role : ""
RoleUser}o--||User : ""
```
<!--- SIREN_END -->
