# mansis_pos_api_client.api.LoyaltyApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *https://api.example.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**getLoyaltyAccount**](LoyaltyApi.md#getloyaltyaccount) | **GET** /api/v1/loyalty/accounts/{customerId} | 


# **getLoyaltyAccount**
> LoyaltyAccount getLoyaltyAccount(customerId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new LoyaltyApi();
var customerId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getLoyaltyAccount(customerId);
    print(result);
} catch (e) {
    print('Exception when calling LoyaltyApi->getLoyaltyAccount: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **String**|  | 

### Return type

[**LoyaltyAccount**](LoyaltyAccount.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

