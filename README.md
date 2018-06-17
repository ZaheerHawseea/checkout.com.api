# checkout.com.api
OData API for checkout.com technical test. Built with asp.net core and visual studio 2017.

### Folder Structure
- checkout.com.api contain the solution to build the api. ll entities, controllers, stores and logics are defined there.
- checkout.com.api.test is the unit test based on xunit and fluentassertions.
- checkout.com.api.client is the client code used to consume the api.
- Checkout.postman_collection.json is the list of api requests in postman.

### Api Calls
- OData $metadata endpoint.
GET http://localhost:51573/api/$metadata

- Get all products.
GET http://localhost:51573/api/Product

- Get specify product.
GET http://localhost:51573/api/Product('id')

- Add product.
POST http://localhost:51573/api/Product

```json
{
    "Name":"Asus Rog Motherboard",
    "Brand":"Price",
    "Price":350.0
}
```

- Get all orders.
GET http://localhost:51573/api/Order

- Get list of items for an order.
GET http://localhost:51573/api/Item?$filter=OrderId eq 'orderId'

- Create order.
POST http://localhost:51573/api/Order

- Add items to an order.
POST http://localhost:51573/api/Order('id')/Checkout.AddItems

- Remove items from an order.
POST http://localhost:51573/api/Order('id')/Checkout.RemoveItems

- Clear an order.
POST http://localhost:51573/api/Order('id')/Checkout.Clear

- Process order.
POST http://localhost:51573/api/Order('id')/Checkout.Process

- Change Quantity of an item.
PUT/PATCH http://localhost:51573/api/Item('id)

### Creating an odata client
To create a client that consume an odata api:

1. Install odata client generator extension in visual studio.
2. Add an odata client - This will generate all the codes needed to communicate  with the api.
3. Update the api url & run custom tool.
4. Use objects to communicate with the api.

[Reference](https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/create-an-odata-v4-client-app)
