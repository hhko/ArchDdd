<!--- SIREN_START -->
```mermaid
	%%{init: {'theme':'neutral'}}%%
	erDiagram
	Role {
		VarChar128 Name PK
	}
	RoleUser {
		VarChar128 RoleName FK
		Char26 UserId PK,FK
	}
	User {
		Char26 Id PK
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
