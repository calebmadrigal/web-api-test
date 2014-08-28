# web-api-test

Demonstrates how to build a simple RESTful API with .NET WebAPI.

## Usage

List:

	curl http://localhost:49990/api/product

Get:

	curl http://localhost:49990/api/product/1

Create:

	curl -X POST http://localhost:49990/api/product -H "Content-Type: application/json" -d "\"Juice\""

Update:

	curl -X PUT http://localhost:49990/api/product/0 -H "Content-Type: application/json" -d "\"Chai Tea\""
