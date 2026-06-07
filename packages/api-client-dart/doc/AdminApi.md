# mansis_pos_api_client.api.AdminApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *https://api.example.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**createAdminCategory**](AdminApi.md#createadmincategory) | **POST** /api/v1/admin/categories | 
[**createAdminCustomer**](AdminApi.md#createadmincustomer) | **POST** /api/v1/admin/customers | 
[**createAdminDiscount**](AdminApi.md#createadmindiscount) | **POST** /api/v1/admin/discounts | 
[**createAdminPos**](AdminApi.md#createadminpos) | **POST** /api/v1/admin/pos | 
[**createAdminPosProduct**](AdminApi.md#createadminposproduct) | **POST** /api/v1/admin/pos-products | 
[**createAdminProduct**](AdminApi.md#createadminproduct) | **POST** /api/v1/admin/products | 
[**createAdminStore**](AdminApi.md#createadminstore) | **POST** /api/v1/admin/stores | 
[**deleteAdminCategory**](AdminApi.md#deleteadmincategory) | **DELETE** /api/v1/admin/categories/{id} | 
[**deleteAdminCustomer**](AdminApi.md#deleteadmincustomer) | **DELETE** /api/v1/admin/customers/{id} | 
[**deleteAdminDiscount**](AdminApi.md#deleteadmindiscount) | **DELETE** /api/v1/admin/discounts/{id} | 
[**deleteAdminPos**](AdminApi.md#deleteadminpos) | **DELETE** /api/v1/admin/pos/{id} | 
[**deleteAdminProduct**](AdminApi.md#deleteadminproduct) | **DELETE** /api/v1/admin/products/{id} | 
[**deleteAdminStore**](AdminApi.md#deleteadminstore) | **DELETE** /api/v1/admin/stores/{id} | 
[**listAdminCategories**](AdminApi.md#listadmincategories) | **GET** /api/v1/admin/categories | 
[**listAdminCompanies**](AdminApi.md#listadmincompanies) | **GET** /api/v1/admin/companies | 
[**listAdminCustomers**](AdminApi.md#listadmincustomers) | **GET** /api/v1/admin/customers | 
[**listAdminDiscounts**](AdminApi.md#listadmindiscounts) | **GET** /api/v1/admin/discounts | 
[**listAdminOrders**](AdminApi.md#listadminorders) | **GET** /api/v1/admin/orders | 
[**listAdminPos**](AdminApi.md#listadminpos) | **GET** /api/v1/admin/pos | 
[**listAdminProducts**](AdminApi.md#listadminproducts) | **GET** /api/v1/admin/products | 
[**listAdminStores**](AdminApi.md#listadminstores) | **GET** /api/v1/admin/stores | 
[**updateAdminCategory**](AdminApi.md#updateadmincategory) | **PUT** /api/v1/admin/categories/{id} | 
[**updateAdminCustomer**](AdminApi.md#updateadmincustomer) | **PUT** /api/v1/admin/customers/{id} | 
[**updateAdminDiscount**](AdminApi.md#updateadmindiscount) | **PUT** /api/v1/admin/discounts/{id} | 
[**updateAdminPos**](AdminApi.md#updateadminpos) | **PUT** /api/v1/admin/pos/{id} | 
[**updateAdminPosProduct**](AdminApi.md#updateadminposproduct) | **PUT** /api/v1/admin/pos-products/{id} | 
[**updateAdminProduct**](AdminApi.md#updateadminproduct) | **PUT** /api/v1/admin/products/{id} | 
[**updateAdminStore**](AdminApi.md#updateadminstore) | **PUT** /api/v1/admin/stores/{id} | 


# **createAdminCategory**
> Category createAdminCategory(categoryWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var categoryWrite = new CategoryWrite(); // CategoryWrite | 

try {
    var result = api_instance.createAdminCategory(categoryWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminCategory: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **categoryWrite** | [**CategoryWrite**](CategoryWrite.md)|  | 

### Return type

[**Category**](Category.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminCustomer**
> Customer createAdminCustomer(customerWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var customerWrite = new CustomerWrite(); // CustomerWrite | 

try {
    var result = api_instance.createAdminCustomer(customerWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminCustomer: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerWrite** | [**CustomerWrite**](CustomerWrite.md)|  | 

### Return type

[**Customer**](Customer.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminDiscount**
> Discount createAdminDiscount(discountWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var discountWrite = new DiscountWrite(); // DiscountWrite | 

try {
    var result = api_instance.createAdminDiscount(discountWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminDiscount: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **discountWrite** | [**DiscountWrite**](DiscountWrite.md)|  | 

### Return type

[**Discount**](Discount.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminPos**
> Pos createAdminPos(posWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var posWrite = new PosWrite(); // PosWrite | 

try {
    var result = api_instance.createAdminPos(posWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminPos: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **posWrite** | [**PosWrite**](PosWrite.md)|  | 

### Return type

[**Pos**](Pos.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminPosProduct**
> PosProduct createAdminPosProduct(posProductWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var posProductWrite = new PosProductWrite(); // PosProductWrite | 

try {
    var result = api_instance.createAdminPosProduct(posProductWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminPosProduct: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **posProductWrite** | [**PosProductWrite**](PosProductWrite.md)|  | 

### Return type

[**PosProduct**](PosProduct.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminProduct**
> Product createAdminProduct(productWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var productWrite = new ProductWrite(); // ProductWrite | 

try {
    var result = api_instance.createAdminProduct(productWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminProduct: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **productWrite** | [**ProductWrite**](ProductWrite.md)|  | 

### Return type

[**Product**](Product.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminStore**
> Store createAdminStore(storeWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var storeWrite = new StoreWrite(); // StoreWrite | 

try {
    var result = api_instance.createAdminStore(storeWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminStore: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **storeWrite** | [**StoreWrite**](StoreWrite.md)|  | 

### Return type

[**Store**](Store.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminCategory**
> deleteAdminCategory(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminCategory(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminCategory: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 
 **userId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminCustomer**
> deleteAdminCustomer(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminCustomer(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminCustomer: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 
 **userId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminDiscount**
> deleteAdminDiscount(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminDiscount(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminDiscount: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 
 **userId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminPos**
> deleteAdminPos(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminPos(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminPos: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 
 **userId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminProduct**
> deleteAdminProduct(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminProduct(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminProduct: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 
 **userId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminStore**
> deleteAdminStore(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminStore(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminStore: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 
 **userId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminCategories**
> BuiltList<Category> listAdminCategories(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminCategories(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminCategories: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<Category>**](Category.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminCompanies**
> BuiltList<Company> listAdminCompanies()



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();

try {
    var result = api_instance.listAdminCompanies();
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminCompanies: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**BuiltList<Company>**](Company.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminCustomers**
> BuiltList<Customer> listAdminCustomers(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminCustomers(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminCustomers: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<Customer>**](Customer.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminDiscounts**
> BuiltList<Discount> listAdminDiscounts(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminDiscounts(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminDiscounts: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<Discount>**](Discount.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminOrders**
> BuiltList<OrderListItem> listAdminOrders(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminOrders(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminOrders: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<OrderListItem>**](OrderListItem.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminPos**
> BuiltList<Pos> listAdminPos(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminPos(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminPos: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<Pos>**](Pos.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminProducts**
> BuiltList<Product> listAdminProducts(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminProducts(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminProducts: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<Product>**](Product.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminStores**
> BuiltList<Store> listAdminStores(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminStores(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminStores: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<Store>**](Store.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminCategory**
> Category updateAdminCategory(id, categoryWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var categoryWrite = new CategoryWrite(); // CategoryWrite | 

try {
    var result = api_instance.updateAdminCategory(id, categoryWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminCategory: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **categoryWrite** | [**CategoryWrite**](CategoryWrite.md)|  | 

### Return type

[**Category**](Category.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminCustomer**
> Customer updateAdminCustomer(id, customerWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var customerWrite = new CustomerWrite(); // CustomerWrite | 

try {
    var result = api_instance.updateAdminCustomer(id, customerWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminCustomer: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **customerWrite** | [**CustomerWrite**](CustomerWrite.md)|  | 

### Return type

[**Customer**](Customer.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminDiscount**
> Discount updateAdminDiscount(id, discountWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var discountWrite = new DiscountWrite(); // DiscountWrite | 

try {
    var result = api_instance.updateAdminDiscount(id, discountWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminDiscount: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **discountWrite** | [**DiscountWrite**](DiscountWrite.md)|  | 

### Return type

[**Discount**](Discount.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminPos**
> Pos updateAdminPos(id, posWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var posWrite = new PosWrite(); // PosWrite | 

try {
    var result = api_instance.updateAdminPos(id, posWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminPos: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **posWrite** | [**PosWrite**](PosWrite.md)|  | 

### Return type

[**Pos**](Pos.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminPosProduct**
> PosProduct updateAdminPosProduct(id, posProductWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var posProductWrite = new PosProductWrite(); // PosProductWrite | 

try {
    var result = api_instance.updateAdminPosProduct(id, posProductWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminPosProduct: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **posProductWrite** | [**PosProductWrite**](PosProductWrite.md)|  | 

### Return type

[**PosProduct**](PosProduct.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminProduct**
> Product updateAdminProduct(id, productWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var productWrite = new ProductWrite(); // ProductWrite | 

try {
    var result = api_instance.updateAdminProduct(id, productWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminProduct: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **productWrite** | [**ProductWrite**](ProductWrite.md)|  | 

### Return type

[**Product**](Product.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminStore**
> Store updateAdminStore(id, storeWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var storeWrite = new StoreWrite(); // StoreWrite | 

try {
    var result = api_instance.updateAdminStore(id, storeWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminStore: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **storeWrite** | [**StoreWrite**](StoreWrite.md)|  | 

### Return type

[**Store**](Store.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

