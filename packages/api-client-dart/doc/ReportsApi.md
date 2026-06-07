# mansis_pos_api_client.api.ReportsApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *https://api.example.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**listEntryProductDeliveries**](ReportsApi.md#listentryproductdeliveries) | **GET** /api/v1/reports/entry-products | 


# **listEntryProductDeliveries**
> BuiltList<EntryProductDeliveryReportRow> listEntryProductDeliveries(companyId, from, to, branchId, posId, productId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new ReportsApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var from = 2013-10-20T19:20:30+01:00; // DateTime | 
var to = 2013-10-20T19:20:30+01:00; // DateTime | 
var branchId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var posId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var productId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listEntryProductDeliveries(companyId, from, to, branchId, posId, productId);
    print(result);
} catch (e) {
    print('Exception when calling ReportsApi->listEntryProductDeliveries: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 
 **from** | **DateTime**|  | 
 **to** | **DateTime**|  | 
 **branchId** | **String**|  | [optional] 
 **posId** | **String**|  | [optional] 
 **productId** | **String**|  | [optional] 

### Return type

[**BuiltList<EntryProductDeliveryReportRow>**](EntryProductDeliveryReportRow.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

