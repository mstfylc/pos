# mansis_pos_api_client.api.AppApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *https://api.example.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**createAppOrder**](AppApi.md#createapporder) | **POST** /api/v1/app/orders | 
[**getAppCustomerWallet**](AppApi.md#getappcustomerwallet) | **GET** /api/v1/app/customers/{customerId}/wallet | 


# **createAppOrder**
> Order createAppOrder(createOrderRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AppApi();
var createOrderRequest = new CreateOrderRequest(); // CreateOrderRequest | 

try {
    var result = api_instance.createAppOrder(createOrderRequest);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->createAppOrder: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **createOrderRequest** | [**CreateOrderRequest**](CreateOrderRequest.md)|  | 

### Return type

[**Order**](Order.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getAppCustomerWallet**
> WalletAccount getAppCustomerWallet(customerId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AppApi();
var customerId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAppCustomerWallet(customerId);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->getAppCustomerWallet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **String**|  | 

### Return type

[**WalletAccount**](WalletAccount.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

