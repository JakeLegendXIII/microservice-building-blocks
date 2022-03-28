# Registering for a Conference

The api lets someone register for a conference.
They POST to our API a reservation, and we register them.

The operation:

```yaml
operation: registration-created
    operands:
        -
            - name: who
            - description: the identity
        -
            - name: conference
            - description: the conference they are attending
```

```http
POST /conference-registrations
Content-Type: application/json

{
    "conference": {
        "id": "someid",
        "name": "Microservice World 2022
    }
}

```

## Processing

## What is the response

```http
201 Created
Location http://server.com/conference-registrations/398398398

{
    "conference": {
        "id": "someid",
        "name": "Microservice World 2022"
    },
    "for": {
        "bob smith",
        "bob@aol.com"
    },
    "payment": {
        "charged": 217.52,
        "card": "AMEX"
    }
}

```