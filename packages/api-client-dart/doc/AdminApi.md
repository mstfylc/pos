# mansis_pos_api_client.api.AdminApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *https://api.example.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**listAdminCompanies**](AdminApi.md#listadmincompanies) | **GET** /api/v1/admin/companies | 
[**listAdminProducts**](AdminApi.md#listadminproducts) | **GET** /api/v1/admin/products | 


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

