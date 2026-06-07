# mansis_pos_api_client.api.ReportsApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *http://localhost:5088*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiV1ReportsEntryProductsGet**](ReportsApi.md#apiv1reportsentryproductsget) | **GET** /api/v1/reports/entry-products | 


# **apiV1ReportsEntryProductsGet**
> BuiltList<EntryProductDeliveryReportRow> apiV1ReportsEntryProductsGet(companyId, from, to, branchId, posId, productId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new ReportsApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var from = 2013-10-20T19:20:30+01:00; // DateTime | 
var to = 2013-10-20T19:20:30+01:00; // DateTime | 
var branchId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var posId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var productId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1ReportsEntryProductsGet(companyId, from, to, branchId, posId, productId);
    print(result);
} catch (e) {
    print('Exception when calling ReportsApi->apiV1ReportsEntryProductsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **from** | **DateTime**|  | [optional] 
 **to** | **DateTime**|  | [optional] 
 **branchId** | **String**|  | [optional] 
 **posId** | **String**|  | [optional] 
 **productId** | **String**|  | [optional] 

### Return type

[**BuiltList<EntryProductDeliveryReportRow>**](EntryProductDeliveryReportRow.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

