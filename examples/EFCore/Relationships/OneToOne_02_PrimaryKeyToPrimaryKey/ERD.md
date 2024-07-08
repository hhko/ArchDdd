<!--- SIREN_START -->
```mermaid
	%%{init: {'theme':'neutral'}}%%
	erDiagram
	Blog {
		INTEGER Id PK
	}
	BlogHeader {
		INTEGER Id PK,FK
	}
BlogHeader|o--||Blog : ""
```
<!--- SIREN_END -->
