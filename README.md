## Requirement

To Create the following public APIs:

- **GET - "/keys/{key}"**: Retrieve a key-value pair by providing the key. If the key does not exist, return a 404 (Not Found) error.

- **POST or PUT - "/keys"**: Add a new key-value pair. Accept a JSON body with the specified schema. If the key already exists, return a 409 (Conflict) error.

- **PATCH - "/keys/{key}/{value}"**: Update the value of a key. If the key does not exist, return a 404 (Not Found) error.

- **DELETE - "/keys/{key}"**: Delete a key-value pair by providing the key. If the key does not exist, return a 404 (Not Found) error.
