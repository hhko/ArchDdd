<!--- SIREN_START -->
```mermaid
	%%{init: {'theme':'neutral'}}%%
	erDiagram
	Blog {
		INTEGER Id 
	}
	BlogHeader {
		INTEGER Id 
		INTEGER BlogId FK
	}
BlogHeader|o--||Blog : ""
```
<!--- SIREN_END -->
