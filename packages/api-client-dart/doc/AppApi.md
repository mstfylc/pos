# mansis_pos_api_client.api.AppApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *http://localhost:5088*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiV1AppCategoriesGet**](AppApi.md#apiv1appcategoriesget) | **GET** /api/v1/app/categories | 
[**apiV1AppCustomersCustomerIdCardTokenPost**](AppApi.md#apiv1appcustomerscustomeridcardtokenpost) | **POST** /api/v1/app/customers/{customerId}/card-token | 
[**apiV1AppCustomersGet**](AppApi.md#apiv1appcustomersget) | **GET** /api/v1/app/customers | 
[**apiV1AppCustomersIdentifyPost**](AppApi.md#apiv1appcustomersidentifypost) | **POST** /api/v1/app/customers/identify | 
[**apiV1AppDiscountsGet**](AppApi.md#apiv1appdiscountsget) | **GET** /api/v1/app/discounts | 
[**apiV1AppLoyaltyPreviewPost**](AppApi.md#apiv1apployaltypreviewpost) | **POST** /api/v1/app/loyalty/preview | 
[**apiV1AppLoyaltyRewardsRewardIdRedeemPost**](AppApi.md#apiv1apployaltyrewardsrewardidredeempost) | **POST** /api/v1/app/loyalty/rewards/{rewardId}/redeem | 
[**apiV1AppOrdersGet**](AppApi.md#apiv1appordersget) | **GET** /api/v1/app/orders | 
[**apiV1AppOrdersOrderIdCancelPost**](AppApi.md#apiv1appordersorderidcancelpost) | **POST** /api/v1/app/orders/{orderId}/cancel | 
[**apiV1AppOrdersOrderIdGet**](AppApi.md#apiv1appordersorderidget) | **GET** /api/v1/app/orders/{orderId} | 
[**apiV1AppOrdersOrderIdRefundPost**](AppApi.md#apiv1appordersorderidrefundpost) | **POST** /api/v1/app/orders/{orderId}/refund | 
[**apiV1AppOrdersPost**](AppApi.md#apiv1apporderspost) | **POST** /api/v1/app/orders | 
[**apiV1AppPosGet**](AppApi.md#apiv1appposget) | **GET** /api/v1/app/pos | 
[**apiV1AppPosPosIdProductsGet**](AppApi.md#apiv1appposposidproductsget) | **GET** /api/v1/app/pos/{posId}/products | 
[**apiV1AppProductsGet**](AppApi.md#apiv1appproductsget) | **GET** /api/v1/app/products | 
[**apiV1AppStoresGet**](AppApi.md#apiv1appstoresget) | **GET** /api/v1/app/stores | 


# **apiV1AppCategoriesGet**
> BuiltList<CategoryDto> apiV1AppCategoriesGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AppCategoriesGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppCategoriesGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 

### Return type

[**BuiltList<CategoryDto>**](CategoryDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppCustomersCustomerIdCardTokenPost**
> CustomerCardTokenResponse apiV1AppCustomersCustomerIdCardTokenPost(customerId, issueCustomerCardTokenApiRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var customerId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var issueCustomerCardTokenApiRequest = new IssueCustomerCardTokenApiRequest(); // IssueCustomerCardTokenApiRequest | 

try {
    var result = api_instance.apiV1AppCustomersCustomerIdCardTokenPost(customerId, issueCustomerCardTokenApiRequest);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppCustomersCustomerIdCardTokenPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerId** | **String**|  | 
 **issueCustomerCardTokenApiRequest** | [**IssueCustomerCardTokenApiRequest**](IssueCustomerCardTokenApiRequest.md)|  | 

### Return type

[**CustomerCardTokenResponse**](CustomerCardTokenResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppCustomersGet**
> BuiltList<CustomerDto> apiV1AppCustomersGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AppCustomersGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppCustomersGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 

### Return type

[**BuiltList<CustomerDto>**](CustomerDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppCustomersIdentifyPost**
> IdentifiedCustomerDto apiV1AppCustomersIdentifyPost(identifyCustomerRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var identifyCustomerRequest = new IdentifyCustomerRequest(); // IdentifyCustomerRequest | 

try {
    var result = api_instance.apiV1AppCustomersIdentifyPost(identifyCustomerRequest);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppCustomersIdentifyPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **identifyCustomerRequest** | [**IdentifyCustomerRequest**](IdentifyCustomerRequest.md)|  | 

### Return type

[**IdentifiedCustomerDto**](IdentifiedCustomerDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppDiscountsGet**
> BuiltList<DiscountDto> apiV1AppDiscountsGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AppDiscountsGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppDiscountsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 

### Return type

[**BuiltList<DiscountDto>**](DiscountDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppLoyaltyPreviewPost**
> LoyaltyPreviewResponse apiV1AppLoyaltyPreviewPost(loyaltyPreviewRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var loyaltyPreviewRequest = new LoyaltyPreviewRequest(); // LoyaltyPreviewRequest | 

try {
    var result = api_instance.apiV1AppLoyaltyPreviewPost(loyaltyPreviewRequest);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppLoyaltyPreviewPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **loyaltyPreviewRequest** | [**LoyaltyPreviewRequest**](LoyaltyPreviewRequest.md)|  | 

### Return type

[**LoyaltyPreviewResponse**](LoyaltyPreviewResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppLoyaltyRewardsRewardIdRedeemPost**
> RedeemRewardResponse apiV1AppLoyaltyRewardsRewardIdRedeemPost(rewardId, redeemRewardApiRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var rewardId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var redeemRewardApiRequest = new RedeemRewardApiRequest(); // RedeemRewardApiRequest | 

try {
    var result = api_instance.apiV1AppLoyaltyRewardsRewardIdRedeemPost(rewardId, redeemRewardApiRequest);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppLoyaltyRewardsRewardIdRedeemPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **rewardId** | **String**|  | 
 **redeemRewardApiRequest** | [**RedeemRewardApiRequest**](RedeemRewardApiRequest.md)|  | 

### Return type

[**RedeemRewardResponse**](RedeemRewardResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppOrdersGet**
> BuiltList<OrderListDto> apiV1AppOrdersGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AppOrdersGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppOrdersGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 

### Return type

[**BuiltList<OrderListDto>**](OrderListDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppOrdersOrderIdCancelPost**
> CancelOrderResponse apiV1AppOrdersOrderIdCancelPost(orderId, reasonRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var orderId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var reasonRequest = new ReasonRequest(); // ReasonRequest | 

try {
    var result = api_instance.apiV1AppOrdersOrderIdCancelPost(orderId, reasonRequest);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppOrdersOrderIdCancelPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **orderId** | **String**|  | 
 **reasonRequest** | [**ReasonRequest**](ReasonRequest.md)|  | 

### Return type

[**CancelOrderResponse**](CancelOrderResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppOrdersOrderIdGet**
> apiV1AppOrdersOrderIdGet(orderId, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var orderId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AppOrdersOrderIdGet(orderId, companyId);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppOrdersOrderIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **orderId** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppOrdersOrderIdRefundPost**
> CancelOrderResponse apiV1AppOrdersOrderIdRefundPost(orderId, reasonRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var orderId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var reasonRequest = new ReasonRequest(); // ReasonRequest | 

try {
    var result = api_instance.apiV1AppOrdersOrderIdRefundPost(orderId, reasonRequest);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppOrdersOrderIdRefundPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **orderId** | **String**|  | 
 **reasonRequest** | [**ReasonRequest**](ReasonRequest.md)|  | 

### Return type

[**CancelOrderResponse**](CancelOrderResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppOrdersPost**
> OrderResponse apiV1AppOrdersPost(createAppOrderRequest, idempotencyKey)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var createAppOrderRequest = new CreateAppOrderRequest(); // CreateAppOrderRequest | 
var idempotencyKey = idempotencyKey_example; // String | 

try {
    var result = api_instance.apiV1AppOrdersPost(createAppOrderRequest, idempotencyKey);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppOrdersPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **createAppOrderRequest** | [**CreateAppOrderRequest**](CreateAppOrderRequest.md)|  | 
 **idempotencyKey** | **String**|  | [optional] 

### Return type

[**OrderResponse**](OrderResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppPosGet**
> BuiltList<PosDto> apiV1AppPosGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AppPosGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppPosGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 

### Return type

[**BuiltList<PosDto>**](PosDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppPosPosIdProductsGet**
> PosProductCatalogResponse apiV1AppPosPosIdProductsGet(posId, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var posId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AppPosPosIdProductsGet(posId, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppPosPosIdProductsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **posId** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**PosProductCatalogResponse**](PosProductCatalogResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppProductsGet**
> BuiltList<ProductDto> apiV1AppProductsGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AppProductsGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppProductsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 

### Return type

[**BuiltList<ProductDto>**](ProductDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AppStoresGet**
> BuiltList<StoreDto> apiV1AppStoresGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AppApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AppStoresGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AppApi->apiV1AppStoresGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 

### Return type

[**BuiltList<StoreDto>**](StoreDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

