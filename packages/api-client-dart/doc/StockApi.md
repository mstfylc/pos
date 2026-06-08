# mansis_pos_api_client.api.StockApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *http://localhost:5254*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiV1StockCountPost**](StockApi.md#apiv1stockcountpost) | **POST** /api/v1/stock/count | 
[**apiV1StockDestroyPost**](StockApi.md#apiv1stockdestroypost) | **POST** /api/v1/stock/destroy | 
[**apiV1StockMovementsGet**](StockApi.md#apiv1stockmovementsget) | **GET** /api/v1/stock/movements | 
[**apiV1StockStockInPost**](StockApi.md#apiv1stockstockinpost) | **POST** /api/v1/stock/stock-in | 
[**apiV1StockStockOutPost**](StockApi.md#apiv1stockstockoutpost) | **POST** /api/v1/stock/stock-out | 
[**apiV1StockTransfersIdCancelPost**](StockApi.md#apiv1stocktransfersidcancelpost) | **POST** /api/v1/stock/transfers/{id}/cancel | 
[**apiV1StockTransfersIdConfirmPost**](StockApi.md#apiv1stocktransfersidconfirmpost) | **POST** /api/v1/stock/transfers/{id}/confirm | 
[**apiV1StockTransfersIdReceivePost**](StockApi.md#apiv1stocktransfersidreceivepost) | **POST** /api/v1/stock/transfers/{id}/receive | 
[**apiV1StockTransfersPost**](StockApi.md#apiv1stocktransferspost) | **POST** /api/v1/stock/transfers | 


# **apiV1StockCountPost**
> StockMovementDto apiV1StockCountPost(stockCountRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new StockApi();
var stockCountRequest = new StockCountRequest(); // StockCountRequest | 

try {
    var result = api_instance.apiV1StockCountPost(stockCountRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->apiV1StockCountPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stockCountRequest** | [**StockCountRequest**](StockCountRequest.md)|  | 

### Return type

[**StockMovementDto**](StockMovementDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1StockDestroyPost**
> StockMovementDto apiV1StockDestroyPost(destroyStockRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new StockApi();
var destroyStockRequest = new DestroyStockRequest(); // DestroyStockRequest | 

try {
    var result = api_instance.apiV1StockDestroyPost(destroyStockRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->apiV1StockDestroyPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **destroyStockRequest** | [**DestroyStockRequest**](DestroyStockRequest.md)|  | 

### Return type

[**StockMovementDto**](StockMovementDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1StockMovementsGet**
> PagedResultOfStockMovementDto apiV1StockMovementsGet(companyId, storeId, productId, movementType, from, to, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new StockApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var storeId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var productId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var movementType = 56; // int | 
var from = 2013-10-20T19:20:30+01:00; // DateTime | 
var to = 2013-10-20T19:20:30+01:00; // DateTime | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1StockMovementsGet(companyId, storeId, productId, movementType, from, to, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->apiV1StockMovementsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **storeId** | **String**|  | [optional] 
 **productId** | **String**|  | [optional] 
 **movementType** | **int**|  | [optional] 
 **from** | **DateTime**|  | [optional] 
 **to** | **DateTime**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfStockMovementDto**](PagedResultOfStockMovementDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1StockStockInPost**
> StockMovementDto apiV1StockStockInPost(stockAdjustmentRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new StockApi();
var stockAdjustmentRequest = new StockAdjustmentRequest(); // StockAdjustmentRequest | 

try {
    var result = api_instance.apiV1StockStockInPost(stockAdjustmentRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->apiV1StockStockInPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stockAdjustmentRequest** | [**StockAdjustmentRequest**](StockAdjustmentRequest.md)|  | 

### Return type

[**StockMovementDto**](StockMovementDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1StockStockOutPost**
> StockMovementDto apiV1StockStockOutPost(stockAdjustmentRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new StockApi();
var stockAdjustmentRequest = new StockAdjustmentRequest(); // StockAdjustmentRequest | 

try {
    var result = api_instance.apiV1StockStockOutPost(stockAdjustmentRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->apiV1StockStockOutPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stockAdjustmentRequest** | [**StockAdjustmentRequest**](StockAdjustmentRequest.md)|  | 

### Return type

[**StockMovementDto**](StockMovementDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1StockTransfersIdCancelPost**
> StoreProductTransferDto apiV1StockTransfersIdCancelPost(id, cancelTransferRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new StockApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var cancelTransferRequest = new CancelTransferRequest(); // CancelTransferRequest | 

try {
    var result = api_instance.apiV1StockTransfersIdCancelPost(id, cancelTransferRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->apiV1StockTransfersIdCancelPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **cancelTransferRequest** | [**CancelTransferRequest**](CancelTransferRequest.md)|  | 

### Return type

[**StoreProductTransferDto**](StoreProductTransferDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1StockTransfersIdConfirmPost**
> StoreProductTransferDto apiV1StockTransfersIdConfirmPost(id, confirmTransferRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new StockApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var confirmTransferRequest = new ConfirmTransferRequest(); // ConfirmTransferRequest | 

try {
    var result = api_instance.apiV1StockTransfersIdConfirmPost(id, confirmTransferRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->apiV1StockTransfersIdConfirmPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **confirmTransferRequest** | [**ConfirmTransferRequest**](ConfirmTransferRequest.md)|  | 

### Return type

[**StoreProductTransferDto**](StoreProductTransferDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1StockTransfersIdReceivePost**
> StoreProductTransferDto apiV1StockTransfersIdReceivePost(id, receiveTransferRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new StockApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var receiveTransferRequest = new ReceiveTransferRequest(); // ReceiveTransferRequest | 

try {
    var result = api_instance.apiV1StockTransfersIdReceivePost(id, receiveTransferRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->apiV1StockTransfersIdReceivePost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **receiveTransferRequest** | [**ReceiveTransferRequest**](ReceiveTransferRequest.md)|  | 

### Return type

[**StoreProductTransferDto**](StoreProductTransferDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1StockTransfersPost**
> StoreProductTransferDto apiV1StockTransfersPost(createTransferRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new StockApi();
var createTransferRequest = new CreateTransferRequest(); // CreateTransferRequest | 

try {
    var result = api_instance.apiV1StockTransfersPost(createTransferRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->apiV1StockTransfersPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **createTransferRequest** | [**CreateTransferRequest**](CreateTransferRequest.md)|  | 

### Return type

[**StoreProductTransferDto**](StoreProductTransferDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

