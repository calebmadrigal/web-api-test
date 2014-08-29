# web-api-test

Demonstrates how to build a simple RESTful API with .NET WebAPI.

## Usage

### List

	curl http://localhost:49990/api/product

Example Response:

	{
	  "Data": [
	    {
	      "id": "0",
	      "name": "Chai"
	    },
	    {
	      "id": "1",
	      "name": "Espresso"
	    },
	    {
	      "id": "2",
	      "name": "Smoothie"
	    }
	  ]
	}

### Get

	curl http://localhost:49990/api/product/1

Example response:

	{
	  "Data": {
	    "id": "1",
	    "name": "Espresso"
	  }
	}

### Create

	curl -X POST http://localhost:49990/api/product -H "Content-Type: application/json" -d "{'name': 'Juice'}"

### Update

	curl -X PUT http://localhost:49990/api/product/1 -H "Content-Type: application/json" -d "{'name': 'Juice'}"

