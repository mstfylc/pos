# mansis_pos_api_client.api.StockApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *https://api.example.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**cancelStockTransfer**](StockApi.md#cancelstocktransfer) | **POST** /api/v1/stock/transfers/{id}/cancel | 
[**confirmStockTransfer**](StockApi.md#confirmstocktransfer) | **POST** /api/v1/stock/transfers/{id}/confirm | 
[**createStockDestroy**](StockApi.md#createstockdestroy) | **POST** /api/v1/stock/destroy | 
[**createStockIn**](StockApi.md#createstockin) | **POST** /api/v1/stock/stock-in | 
[**createStockOut**](StockApi.md#createstockout) | **POST** /api/v1/stock/stock-out | 
[**createStockTransfer**](StockApi.md#createstocktransfer) | **POST** /api/v1/stock/transfers | 
[**finalizeStockCount**](StockApi.md#finalizestockcount) | **POST** /api/v1/stock/count | 
[**listStockMovements**](StockApi.md#liststockmovements) | **GET** /api/v1/stock/movements | 
[**receiveStockTransfer**](StockApi.md#receivestocktransfer) | **POST** /api/v1/stock/transfers/{id}/receive | 


# **cancelStockTransfer**
> StoreProductTransfer cancelStockTransfer(id, cancelTransferRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new StockApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var cancelTransferRequest = new CancelTransferRequest(); // CancelTransferRequest | 

try {
    var result = api_instance.cancelStockTransfer(id, cancelTransferRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->cancelStockTransfer: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **cancelTransferRequest** | [**CancelTransferRequest**](CancelTransferRequest.md)|  | 

### Return type

[**StoreProductTransfer**](StoreProductTransfer.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **confirmStockTransfer**
> StoreProductTransfer confirmStockTransfer(id, confirmTransferRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new StockApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var confirmTransferRequest = new ConfirmTransferRequest(); // ConfirmTransferRequest | 

try {
    var result = api_instance.confirmStockTransfer(id, confirmTransferRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->confirmStockTransfer: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **confirmTransferRequest** | [**ConfirmTransferRequest**](ConfirmTransferRequest.md)|  | 

### Return type

[**StoreProductTransfer**](StoreProductTransfer.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createStockDestroy**
> StockMovement createStockDestroy(destroyStockRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new StockApi();
var destroyStockRequest = new DestroyStockRequest(); // DestroyStockRequest | 

try {
    var result = api_instance.createStockDestroy(destroyStockRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->createStockDestroy: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **destroyStockRequest** | [**DestroyStockRequest**](DestroyStockRequest.md)|  | 

### Return type

[**StockMovement**](StockMovement.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createStockIn**
> StockMovement createStockIn(stockAdjustmentRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new StockApi();
var stockAdjustmentRequest = new StockAdjustmentRequest(); // StockAdjustmentRequest | 

try {
    var result = api_instance.createStockIn(stockAdjustmentRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->createStockIn: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stockAdjustmentRequest** | [**StockAdjustmentRequest**](StockAdjustmentRequest.md)|  | 

### Return type

[**StockMovement**](StockMovement.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createStockOut**
> StockMovement createStockOut(stockAdjustmentRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new StockApi();
var stockAdjustmentRequest = new StockAdjustmentRequest(); // StockAdjustmentRequest | 

try {
    var result = api_instance.createStockOut(stockAdjustmentRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->createStockOut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stockAdjustmentRequest** | [**StockAdjustmentRequest**](StockAdjustmentRequest.md)|  | 

### Return type

[**StockMovement**](StockMovement.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createStockTransfer**
> StoreProductTransfer createStockTransfer(createTransferRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new StockApi();
var createTransferRequest = new CreateTransferRequest(); // CreateTransferRequest | 

try {
    var result = api_instance.createStockTransfer(createTransferRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->createStockTransfer: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **createTransferRequest** | [**CreateTransferRequest**](CreateTransferRequest.md)|  | 

### Return type

[**StoreProductTransfer**](StoreProductTransfer.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **finalizeStockCount**
> StockMovement finalizeStockCount(stockCountRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new StockApi();
var stockCountRequest = new StockCountRequest(); // StockCountRequest | 

try {
    var result = api_instance.finalizeStockCount(stockCountRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->finalizeStockCount: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stockCountRequest** | [**StockCountRequest**](StockCountRequest.md)|  | 

### Return type

[**StockMovement**](StockMovement.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listStockMovements**
> BuiltList<StockMovement> listStockMovements(companyId, storeId, productId, movementType, from, to)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new StockApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var storeId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var productId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var movementType = ; // StoreProductMovementType | 
var from = 2013-10-20T19:20:30+01:00; // DateTime | 
var to = 2013-10-20T19:20:30+01:00; // DateTime | 

try {
    var result = api_instance.listStockMovements(companyId, storeId, productId, movementType, from, to);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->listStockMovements: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 
 **storeId** | **String**|  | [optional] 
 **productId** | **String**|  | [optional] 
 **movementType** | [**StoreProductMovementType**](.md)|  | [optional] 
 **from** | **DateTime**|  | [optional] 
 **to** | **DateTime**|  | [optional] 

### Return type

[**BuiltList<StockMovement>**](StockMovement.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **receiveStockTransfer**
> StoreProductTransfer receiveStockTransfer(id, receiveTransferRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new StockApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var receiveTransferRequest = new ReceiveTransferRequest(); // ReceiveTransferRequest | 

try {
    var result = api_instance.receiveStockTransfer(id, receiveTransferRequest);
    print(result);
} catch (e) {
    print('Exception when calling StockApi->receiveStockTransfer: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **receiveTransferRequest** | [**ReceiveTransferRequest**](ReceiveTransferRequest.md)|  | 

### Return type

[**StoreProductTransfer**](StoreProductTransfer.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

