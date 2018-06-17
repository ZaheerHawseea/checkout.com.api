# checkout.com.api
OData API for checkout.com technical test. Built with asp.net core and visual studio 2017.

### Folder Structure
- checkout.com.api contain the solution to build the api. ll entities, controllers, stores and logics are defined there.
- checkout.com.api.test is the unit test based on xunit and fluentassertions.
- checkout.com.api.client is the client code used to consume the api.
- Checkout.postman_collection.json is the list of api requests in postman.

### Api Calls
- OData $metadata endpoint  
```javascript
GET http://localhost:51573/api/$metadata
```

- Get all products  
```javascript
GET http://localhost:51573/api/Product
```

- Get specify product  
```javascript
GET http://localhost:51573/api/Product('id')
```

- Add product 
```javascript
POST http://localhost:51573/api/Product
```
```json
{
    "Name" : "Asus Rog Motherboard",
    "Brand" : "Price",
    "Price" : 350.0
}
```

- Get all orders  
```javascript
GET http://localhost:51573/api/Order
```

- Get list of items for an order  
```javascript
GET http://localhost:51573/api/Item?$filter=OrderId eq 'orderId'
```

- Create order  
```javascript
POST http://localhost:51573/api/Order
```
```json
{
	"CustomerName" : "Zaheer Hawseea"
}
```

- Add items to an order 
```javascript 
POST http://localhost:51573/api/Order('id')/Checkout.AddItems
```
```json
{
	"Items" : [
		{
			"OrderId" : "8414cc46-ead2-4ed6-8d2e-cc9401aad701",
			"ProductId" : "992ce680-5f16-4072-8c26-392b0d52b67a",
			"Quantity" : 1
		}	
	]
}
```

- Remove items from an order  
```javascript
POST http://localhost:51573/api/Order('id')/Checkout.RemoveItems
```
```json
{
	"Items" : [
		{
			"OrderId" : "224e1abf-7d59-4f0f-94bc-c489ad35ba6d",
			"Id" : "3c4fc5a0-5ec1-4dfc-b832-bd9d0263d08c",
		}	
	]
}
```

- Clear an order  
```javascript
POST http://localhost:51573/api/Order('id')/Checkout.Clear
```
```json
{
	"Delete" : false
}
```

- Process order  
```javascript
POST http://localhost:51573/api/Order('id')/Checkout.Process
```
```json
{
	"Billing" : {
		"CreditCardNumber" : "0046521005706",
		"CCV" : "327"
	}
}
```

- Change Quantity of an item  
```javascript
PATCH http://localhost:51573/api/Item('id)
```
```json
{
	"Quantity" : 2
}
```

### Creating an odata client
To create a client that consume an odata api:

1. Install odata client generator extension in visual studio.
2. Add an odata client - This will generate all the codes needed to communicate  with the api.
3. Update the api url & run custom tool.
4. Use objects to communicate with the api.

[Reference](https://docs.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/create-an-odata-v4-client-app)
