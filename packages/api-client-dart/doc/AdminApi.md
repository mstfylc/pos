# mansis_pos_api_client.api.AdminApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *http://localhost:5088*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiV1AdminAssignmentsGet**](AdminApi.md#apiv1adminassignmentsget) | **GET** /api/v1/admin/assignments | 
[**apiV1AdminAssignmentsIdDelete**](AdminApi.md#apiv1adminassignmentsiddelete) | **DELETE** /api/v1/admin/assignments/{id} | 
[**apiV1AdminAssignmentsIdGet**](AdminApi.md#apiv1adminassignmentsidget) | **GET** /api/v1/admin/assignments/{id} | 
[**apiV1AdminAssignmentsIdPut**](AdminApi.md#apiv1adminassignmentsidput) | **PUT** /api/v1/admin/assignments/{id} | 
[**apiV1AdminAssignmentsPost**](AdminApi.md#apiv1adminassignmentspost) | **POST** /api/v1/admin/assignments | 
[**apiV1AdminCampaignsGet**](AdminApi.md#apiv1admincampaignsget) | **GET** /api/v1/admin/campaigns | 
[**apiV1AdminCampaignsIdDelete**](AdminApi.md#apiv1admincampaignsiddelete) | **DELETE** /api/v1/admin/campaigns/{id} | 
[**apiV1AdminCampaignsIdGet**](AdminApi.md#apiv1admincampaignsidget) | **GET** /api/v1/admin/campaigns/{id} | 
[**apiV1AdminCampaignsIdPut**](AdminApi.md#apiv1admincampaignsidput) | **PUT** /api/v1/admin/campaigns/{id} | 
[**apiV1AdminCampaignsPost**](AdminApi.md#apiv1admincampaignspost) | **POST** /api/v1/admin/campaigns | 
[**apiV1AdminCategoriesGet**](AdminApi.md#apiv1admincategoriesget) | **GET** /api/v1/admin/categories | 
[**apiV1AdminCategoriesIdDelete**](AdminApi.md#apiv1admincategoriesiddelete) | **DELETE** /api/v1/admin/categories/{id} | 
[**apiV1AdminCategoriesIdPut**](AdminApi.md#apiv1admincategoriesidput) | **PUT** /api/v1/admin/categories/{id} | 
[**apiV1AdminCategoriesPost**](AdminApi.md#apiv1admincategoriespost) | **POST** /api/v1/admin/categories | 
[**apiV1AdminCustomersGet**](AdminApi.md#apiv1admincustomersget) | **GET** /api/v1/admin/customers | 
[**apiV1AdminCustomersIdDelete**](AdminApi.md#apiv1admincustomersiddelete) | **DELETE** /api/v1/admin/customers/{id} | 
[**apiV1AdminCustomersIdGet**](AdminApi.md#apiv1admincustomersidget) | **GET** /api/v1/admin/customers/{id} | 
[**apiV1AdminCustomersIdLoyaltyAdjustmentsPost**](AdminApi.md#apiv1admincustomersidloyaltyadjustmentspost) | **POST** /api/v1/admin/customers/{id}/loyalty-adjustments | 
[**apiV1AdminCustomersIdPut**](AdminApi.md#apiv1admincustomersidput) | **PUT** /api/v1/admin/customers/{id} | 
[**apiV1AdminCustomersIdWalletAdjustmentsPost**](AdminApi.md#apiv1admincustomersidwalletadjustmentspost) | **POST** /api/v1/admin/customers/{id}/wallet-adjustments | 
[**apiV1AdminCustomersPost**](AdminApi.md#apiv1admincustomerspost) | **POST** /api/v1/admin/customers | 
[**apiV1AdminDiscountsGet**](AdminApi.md#apiv1admindiscountsget) | **GET** /api/v1/admin/discounts | 
[**apiV1AdminDiscountsIdDelete**](AdminApi.md#apiv1admindiscountsiddelete) | **DELETE** /api/v1/admin/discounts/{id} | 
[**apiV1AdminDiscountsIdGet**](AdminApi.md#apiv1admindiscountsidget) | **GET** /api/v1/admin/discounts/{id} | 
[**apiV1AdminDiscountsIdPut**](AdminApi.md#apiv1admindiscountsidput) | **PUT** /api/v1/admin/discounts/{id} | 
[**apiV1AdminDiscountsPost**](AdminApi.md#apiv1admindiscountspost) | **POST** /api/v1/admin/discounts | 
[**apiV1AdminEarnRulesGet**](AdminApi.md#apiv1adminearnrulesget) | **GET** /api/v1/admin/earn-rules | 
[**apiV1AdminEarnRulesIdDelete**](AdminApi.md#apiv1adminearnrulesiddelete) | **DELETE** /api/v1/admin/earn-rules/{id} | 
[**apiV1AdminEarnRulesIdGet**](AdminApi.md#apiv1adminearnrulesidget) | **GET** /api/v1/admin/earn-rules/{id} | 
[**apiV1AdminEarnRulesIdPut**](AdminApi.md#apiv1adminearnrulesidput) | **PUT** /api/v1/admin/earn-rules/{id} | 
[**apiV1AdminEarnRulesPost**](AdminApi.md#apiv1adminearnrulespost) | **POST** /api/v1/admin/earn-rules | 
[**apiV1AdminLoyaltyTiersGet**](AdminApi.md#apiv1adminloyaltytiersget) | **GET** /api/v1/admin/loyalty-tiers | 
[**apiV1AdminLoyaltyTiersIdDelete**](AdminApi.md#apiv1adminloyaltytiersiddelete) | **DELETE** /api/v1/admin/loyalty-tiers/{id} | 
[**apiV1AdminLoyaltyTiersIdGet**](AdminApi.md#apiv1adminloyaltytiersidget) | **GET** /api/v1/admin/loyalty-tiers/{id} | 
[**apiV1AdminLoyaltyTiersIdPut**](AdminApi.md#apiv1adminloyaltytiersidput) | **PUT** /api/v1/admin/loyalty-tiers/{id} | 
[**apiV1AdminLoyaltyTiersPost**](AdminApi.md#apiv1adminloyaltytierspost) | **POST** /api/v1/admin/loyalty-tiers | 
[**apiV1AdminOrdersGet**](AdminApi.md#apiv1adminordersget) | **GET** /api/v1/admin/orders | 
[**apiV1AdminPermissionsGet**](AdminApi.md#apiv1adminpermissionsget) | **GET** /api/v1/admin/permissions | 
[**apiV1AdminPosGet**](AdminApi.md#apiv1adminposget) | **GET** /api/v1/admin/pos | 
[**apiV1AdminPosIdDelete**](AdminApi.md#apiv1adminposiddelete) | **DELETE** /api/v1/admin/pos/{id} | 
[**apiV1AdminPosIdPut**](AdminApi.md#apiv1adminposidput) | **PUT** /api/v1/admin/pos/{id} | 
[**apiV1AdminPosPost**](AdminApi.md#apiv1adminpospost) | **POST** /api/v1/admin/pos | 
[**apiV1AdminPosProductsIdPut**](AdminApi.md#apiv1adminposproductsidput) | **PUT** /api/v1/admin/pos-products/{id} | 
[**apiV1AdminPosProductsPost**](AdminApi.md#apiv1adminposproductspost) | **POST** /api/v1/admin/pos-products | 
[**apiV1AdminProductsGet**](AdminApi.md#apiv1adminproductsget) | **GET** /api/v1/admin/products | 
[**apiV1AdminProductsIdDelete**](AdminApi.md#apiv1adminproductsiddelete) | **DELETE** /api/v1/admin/products/{id} | 
[**apiV1AdminProductsIdPut**](AdminApi.md#apiv1adminproductsidput) | **PUT** /api/v1/admin/products/{id} | 
[**apiV1AdminProductsPost**](AdminApi.md#apiv1adminproductspost) | **POST** /api/v1/admin/products | 
[**apiV1AdminProductsProductIdPosProductsGet**](AdminApi.md#apiv1adminproductsproductidposproductsget) | **GET** /api/v1/admin/products/{productId}/pos-products | 
[**apiV1AdminPurchasesGet**](AdminApi.md#apiv1adminpurchasesget) | **GET** /api/v1/admin/purchases | 
[**apiV1AdminPurchasesIdDelete**](AdminApi.md#apiv1adminpurchasesiddelete) | **DELETE** /api/v1/admin/purchases/{id} | 
[**apiV1AdminPurchasesIdGet**](AdminApi.md#apiv1adminpurchasesidget) | **GET** /api/v1/admin/purchases/{id} | 
[**apiV1AdminPurchasesIdPut**](AdminApi.md#apiv1adminpurchasesidput) | **PUT** /api/v1/admin/purchases/{id} | 
[**apiV1AdminPurchasesPost**](AdminApi.md#apiv1adminpurchasespost) | **POST** /api/v1/admin/purchases | 
[**apiV1AdminRewardsGet**](AdminApi.md#apiv1adminrewardsget) | **GET** /api/v1/admin/rewards | 
[**apiV1AdminRewardsIdDelete**](AdminApi.md#apiv1adminrewardsiddelete) | **DELETE** /api/v1/admin/rewards/{id} | 
[**apiV1AdminRewardsIdGet**](AdminApi.md#apiv1adminrewardsidget) | **GET** /api/v1/admin/rewards/{id} | 
[**apiV1AdminRewardsIdPut**](AdminApi.md#apiv1adminrewardsidput) | **PUT** /api/v1/admin/rewards/{id} | 
[**apiV1AdminRewardsPost**](AdminApi.md#apiv1adminrewardspost) | **POST** /api/v1/admin/rewards | 
[**apiV1AdminRolesGet**](AdminApi.md#apiv1adminrolesget) | **GET** /api/v1/admin/roles | 
[**apiV1AdminRolesIdDelete**](AdminApi.md#apiv1adminrolesiddelete) | **DELETE** /api/v1/admin/roles/{id} | 
[**apiV1AdminRolesIdGet**](AdminApi.md#apiv1adminrolesidget) | **GET** /api/v1/admin/roles/{id} | 
[**apiV1AdminRolesIdPermissionsPut**](AdminApi.md#apiv1adminrolesidpermissionsput) | **PUT** /api/v1/admin/roles/{id}/permissions | 
[**apiV1AdminRolesIdPut**](AdminApi.md#apiv1adminrolesidput) | **PUT** /api/v1/admin/roles/{id} | 
[**apiV1AdminRolesPost**](AdminApi.md#apiv1adminrolespost) | **POST** /api/v1/admin/roles | 
[**apiV1AdminStampCardsGet**](AdminApi.md#apiv1adminstampcardsget) | **GET** /api/v1/admin/stamp-cards | 
[**apiV1AdminStampCardsIdDelete**](AdminApi.md#apiv1adminstampcardsiddelete) | **DELETE** /api/v1/admin/stamp-cards/{id} | 
[**apiV1AdminStampCardsIdGet**](AdminApi.md#apiv1adminstampcardsidget) | **GET** /api/v1/admin/stamp-cards/{id} | 
[**apiV1AdminStampCardsIdPut**](AdminApi.md#apiv1adminstampcardsidput) | **PUT** /api/v1/admin/stamp-cards/{id} | 
[**apiV1AdminStampCardsPost**](AdminApi.md#apiv1adminstampcardspost) | **POST** /api/v1/admin/stamp-cards | 
[**apiV1AdminStoresGet**](AdminApi.md#apiv1adminstoresget) | **GET** /api/v1/admin/stores | 
[**apiV1AdminStoresIdDelete**](AdminApi.md#apiv1adminstoresiddelete) | **DELETE** /api/v1/admin/stores/{id} | 
[**apiV1AdminStoresIdPut**](AdminApi.md#apiv1adminstoresidput) | **PUT** /api/v1/admin/stores/{id} | 
[**apiV1AdminStoresPost**](AdminApi.md#apiv1adminstorespost) | **POST** /api/v1/admin/stores | 
[**apiV1AdminSuppliersGet**](AdminApi.md#apiv1adminsuppliersget) | **GET** /api/v1/admin/suppliers | 
[**apiV1AdminSuppliersIdDelete**](AdminApi.md#apiv1adminsuppliersiddelete) | **DELETE** /api/v1/admin/suppliers/{id} | 
[**apiV1AdminSuppliersIdGet**](AdminApi.md#apiv1adminsuppliersidget) | **GET** /api/v1/admin/suppliers/{id} | 
[**apiV1AdminSuppliersIdPut**](AdminApi.md#apiv1adminsuppliersidput) | **PUT** /api/v1/admin/suppliers/{id} | 
[**apiV1AdminSuppliersPost**](AdminApi.md#apiv1adminsupplierspost) | **POST** /api/v1/admin/suppliers | 
[**apiV1AdminUsersGet**](AdminApi.md#apiv1adminusersget) | **GET** /api/v1/admin/users | 
[**apiV1AdminUsersIdDelete**](AdminApi.md#apiv1adminusersiddelete) | **DELETE** /api/v1/admin/users/{id} | 
[**apiV1AdminUsersIdGet**](AdminApi.md#apiv1adminusersidget) | **GET** /api/v1/admin/users/{id} | 
[**apiV1AdminUsersIdPut**](AdminApi.md#apiv1adminusersidput) | **PUT** /api/v1/admin/users/{id} | 
[**apiV1AdminUsersPost**](AdminApi.md#apiv1adminuserspost) | **POST** /api/v1/admin/users | 


# **apiV1AdminAssignmentsGet**
> BuiltList<AssignmentDto> apiV1AdminAssignmentsGet(companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminAssignmentsGet(companyId, userId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminAssignmentsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

[**BuiltList<AssignmentDto>**](AssignmentDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminAssignmentsIdDelete**
> apiV1AdminAssignmentsIdDelete(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminAssignmentsIdDelete(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminAssignmentsIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminAssignmentsIdGet**
> AssignmentDto apiV1AdminAssignmentsIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminAssignmentsIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminAssignmentsIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**AssignmentDto**](AssignmentDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminAssignmentsIdPut**
> AssignmentDto apiV1AdminAssignmentsIdPut(id, assignmentWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var assignmentWriteDto = new AssignmentWriteDto(); // AssignmentWriteDto | 

try {
    var result = api_instance.apiV1AdminAssignmentsIdPut(id, assignmentWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminAssignmentsIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **assignmentWriteDto** | [**AssignmentWriteDto**](AssignmentWriteDto.md)|  | 

### Return type

[**AssignmentDto**](AssignmentDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminAssignmentsPost**
> AssignmentDto apiV1AdminAssignmentsPost(assignmentWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var assignmentWriteDto = new AssignmentWriteDto(); // AssignmentWriteDto | 

try {
    var result = api_instance.apiV1AdminAssignmentsPost(assignmentWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminAssignmentsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **assignmentWriteDto** | [**AssignmentWriteDto**](AssignmentWriteDto.md)|  | 

### Return type

[**AssignmentDto**](AssignmentDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCampaignsGet**
> PagedResultOfCampaignDto apiV1AdminCampaignsGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminCampaignsGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCampaignsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfCampaignDto**](PagedResultOfCampaignDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCampaignsIdDelete**
> apiV1AdminCampaignsIdDelete(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminCampaignsIdDelete(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCampaignsIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCampaignsIdGet**
> CampaignDto apiV1AdminCampaignsIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminCampaignsIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCampaignsIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**CampaignDto**](CampaignDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCampaignsIdPut**
> CampaignDto apiV1AdminCampaignsIdPut(id, campaignWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var campaignWriteDto = new CampaignWriteDto(); // CampaignWriteDto | 

try {
    var result = api_instance.apiV1AdminCampaignsIdPut(id, campaignWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCampaignsIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **campaignWriteDto** | [**CampaignWriteDto**](CampaignWriteDto.md)|  | 

### Return type

[**CampaignDto**](CampaignDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCampaignsPost**
> CampaignDto apiV1AdminCampaignsPost(campaignWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var campaignWriteDto = new CampaignWriteDto(); // CampaignWriteDto | 

try {
    var result = api_instance.apiV1AdminCampaignsPost(campaignWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCampaignsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **campaignWriteDto** | [**CampaignWriteDto**](CampaignWriteDto.md)|  | 

### Return type

[**CampaignDto**](CampaignDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCategoriesGet**
> BuiltList<CategoryDto> apiV1AdminCategoriesGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminCategoriesGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCategoriesGet: $e\n');
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

# **apiV1AdminCategoriesIdDelete**
> apiV1AdminCategoriesIdDelete(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminCategoriesIdDelete(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCategoriesIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCategoriesIdPut**
> CategoryDto apiV1AdminCategoriesIdPut(id, categoryWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var categoryWriteDto = new CategoryWriteDto(); // CategoryWriteDto | 

try {
    var result = api_instance.apiV1AdminCategoriesIdPut(id, categoryWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCategoriesIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **categoryWriteDto** | [**CategoryWriteDto**](CategoryWriteDto.md)|  | 

### Return type

[**CategoryDto**](CategoryDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCategoriesPost**
> CategoryDto apiV1AdminCategoriesPost(categoryWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var categoryWriteDto = new CategoryWriteDto(); // CategoryWriteDto | 

try {
    var result = api_instance.apiV1AdminCategoriesPost(categoryWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCategoriesPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **categoryWriteDto** | [**CategoryWriteDto**](CategoryWriteDto.md)|  | 

### Return type

[**CategoryDto**](CategoryDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCustomersGet**
> PagedResultOfCustomerDto apiV1AdminCustomersGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminCustomersGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCustomersGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfCustomerDto**](PagedResultOfCustomerDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCustomersIdDelete**
> apiV1AdminCustomersIdDelete(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminCustomersIdDelete(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCustomersIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCustomersIdGet**
> CustomerDetailDto apiV1AdminCustomersIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminCustomersIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCustomersIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**CustomerDetailDto**](CustomerDetailDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCustomersIdLoyaltyAdjustmentsPost**
> LoyaltyAdjustmentDto apiV1AdminCustomersIdLoyaltyAdjustmentsPost(id, customerLoyaltyAdjustmentRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var customerLoyaltyAdjustmentRequest = new CustomerLoyaltyAdjustmentRequest(); // CustomerLoyaltyAdjustmentRequest | 

try {
    var result = api_instance.apiV1AdminCustomersIdLoyaltyAdjustmentsPost(id, customerLoyaltyAdjustmentRequest);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCustomersIdLoyaltyAdjustmentsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **customerLoyaltyAdjustmentRequest** | [**CustomerLoyaltyAdjustmentRequest**](CustomerLoyaltyAdjustmentRequest.md)|  | 

### Return type

[**LoyaltyAdjustmentDto**](LoyaltyAdjustmentDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCustomersIdPut**
> CustomerDto apiV1AdminCustomersIdPut(id, customerWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var customerWriteDto = new CustomerWriteDto(); // CustomerWriteDto | 

try {
    var result = api_instance.apiV1AdminCustomersIdPut(id, customerWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCustomersIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **customerWriteDto** | [**CustomerWriteDto**](CustomerWriteDto.md)|  | 

### Return type

[**CustomerDto**](CustomerDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCustomersIdWalletAdjustmentsPost**
> WalletAdjustmentDto apiV1AdminCustomersIdWalletAdjustmentsPost(id, customerWalletAdjustmentRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var customerWalletAdjustmentRequest = new CustomerWalletAdjustmentRequest(); // CustomerWalletAdjustmentRequest | 

try {
    var result = api_instance.apiV1AdminCustomersIdWalletAdjustmentsPost(id, customerWalletAdjustmentRequest);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCustomersIdWalletAdjustmentsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **customerWalletAdjustmentRequest** | [**CustomerWalletAdjustmentRequest**](CustomerWalletAdjustmentRequest.md)|  | 

### Return type

[**WalletAdjustmentDto**](WalletAdjustmentDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminCustomersPost**
> CustomerDto apiV1AdminCustomersPost(customerWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var customerWriteDto = new CustomerWriteDto(); // CustomerWriteDto | 

try {
    var result = api_instance.apiV1AdminCustomersPost(customerWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminCustomersPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerWriteDto** | [**CustomerWriteDto**](CustomerWriteDto.md)|  | 

### Return type

[**CustomerDto**](CustomerDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminDiscountsGet**
> PagedResultOfDiscountDto apiV1AdminDiscountsGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminDiscountsGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminDiscountsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfDiscountDto**](PagedResultOfDiscountDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminDiscountsIdDelete**
> apiV1AdminDiscountsIdDelete(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminDiscountsIdDelete(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminDiscountsIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminDiscountsIdGet**
> DiscountDto apiV1AdminDiscountsIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminDiscountsIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminDiscountsIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**DiscountDto**](DiscountDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminDiscountsIdPut**
> DiscountDto apiV1AdminDiscountsIdPut(id, discountWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var discountWriteDto = new DiscountWriteDto(); // DiscountWriteDto | 

try {
    var result = api_instance.apiV1AdminDiscountsIdPut(id, discountWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminDiscountsIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **discountWriteDto** | [**DiscountWriteDto**](DiscountWriteDto.md)|  | 

### Return type

[**DiscountDto**](DiscountDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminDiscountsPost**
> DiscountDto apiV1AdminDiscountsPost(discountWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var discountWriteDto = new DiscountWriteDto(); // DiscountWriteDto | 

try {
    var result = api_instance.apiV1AdminDiscountsPost(discountWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminDiscountsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **discountWriteDto** | [**DiscountWriteDto**](DiscountWriteDto.md)|  | 

### Return type

[**DiscountDto**](DiscountDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminEarnRulesGet**
> PagedResultOfEarnRuleDto apiV1AdminEarnRulesGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminEarnRulesGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminEarnRulesGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfEarnRuleDto**](PagedResultOfEarnRuleDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminEarnRulesIdDelete**
> apiV1AdminEarnRulesIdDelete(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminEarnRulesIdDelete(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminEarnRulesIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminEarnRulesIdGet**
> EarnRuleDto apiV1AdminEarnRulesIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminEarnRulesIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminEarnRulesIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**EarnRuleDto**](EarnRuleDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminEarnRulesIdPut**
> EarnRuleDto apiV1AdminEarnRulesIdPut(id, earnRuleWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var earnRuleWriteDto = new EarnRuleWriteDto(); // EarnRuleWriteDto | 

try {
    var result = api_instance.apiV1AdminEarnRulesIdPut(id, earnRuleWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminEarnRulesIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **earnRuleWriteDto** | [**EarnRuleWriteDto**](EarnRuleWriteDto.md)|  | 

### Return type

[**EarnRuleDto**](EarnRuleDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminEarnRulesPost**
> EarnRuleDto apiV1AdminEarnRulesPost(earnRuleWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var earnRuleWriteDto = new EarnRuleWriteDto(); // EarnRuleWriteDto | 

try {
    var result = api_instance.apiV1AdminEarnRulesPost(earnRuleWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminEarnRulesPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **earnRuleWriteDto** | [**EarnRuleWriteDto**](EarnRuleWriteDto.md)|  | 

### Return type

[**EarnRuleDto**](EarnRuleDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminLoyaltyTiersGet**
> PagedResultOfLoyaltyTierDto apiV1AdminLoyaltyTiersGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminLoyaltyTiersGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminLoyaltyTiersGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfLoyaltyTierDto**](PagedResultOfLoyaltyTierDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminLoyaltyTiersIdDelete**
> apiV1AdminLoyaltyTiersIdDelete(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminLoyaltyTiersIdDelete(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminLoyaltyTiersIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminLoyaltyTiersIdGet**
> LoyaltyTierDto apiV1AdminLoyaltyTiersIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminLoyaltyTiersIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminLoyaltyTiersIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**LoyaltyTierDto**](LoyaltyTierDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminLoyaltyTiersIdPut**
> LoyaltyTierDto apiV1AdminLoyaltyTiersIdPut(id, loyaltyTierWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var loyaltyTierWriteDto = new LoyaltyTierWriteDto(); // LoyaltyTierWriteDto | 

try {
    var result = api_instance.apiV1AdminLoyaltyTiersIdPut(id, loyaltyTierWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminLoyaltyTiersIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **loyaltyTierWriteDto** | [**LoyaltyTierWriteDto**](LoyaltyTierWriteDto.md)|  | 

### Return type

[**LoyaltyTierDto**](LoyaltyTierDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminLoyaltyTiersPost**
> LoyaltyTierDto apiV1AdminLoyaltyTiersPost(loyaltyTierWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var loyaltyTierWriteDto = new LoyaltyTierWriteDto(); // LoyaltyTierWriteDto | 

try {
    var result = api_instance.apiV1AdminLoyaltyTiersPost(loyaltyTierWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminLoyaltyTiersPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **loyaltyTierWriteDto** | [**LoyaltyTierWriteDto**](LoyaltyTierWriteDto.md)|  | 

### Return type

[**LoyaltyTierDto**](LoyaltyTierDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminOrdersGet**
> PagedResultOfOrderListDto apiV1AdminOrdersGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminOrdersGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminOrdersGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfOrderListDto**](PagedResultOfOrderListDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPermissionsGet**
> BuiltList<PermissionDto> apiV1AdminPermissionsGet()



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();

try {
    var result = api_instance.apiV1AdminPermissionsGet();
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPermissionsGet: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**BuiltList<PermissionDto>**](PermissionDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPosGet**
> BuiltList<PosDto> apiV1AdminPosGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminPosGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPosGet: $e\n');
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

# **apiV1AdminPosIdDelete**
> apiV1AdminPosIdDelete(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminPosIdDelete(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPosIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPosIdPut**
> PosDto apiV1AdminPosIdPut(id, posWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var posWriteDto = new PosWriteDto(); // PosWriteDto | 

try {
    var result = api_instance.apiV1AdminPosIdPut(id, posWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPosIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **posWriteDto** | [**PosWriteDto**](PosWriteDto.md)|  | 

### Return type

[**PosDto**](PosDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPosPost**
> PosDto apiV1AdminPosPost(posWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var posWriteDto = new PosWriteDto(); // PosWriteDto | 

try {
    var result = api_instance.apiV1AdminPosPost(posWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPosPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **posWriteDto** | [**PosWriteDto**](PosWriteDto.md)|  | 

### Return type

[**PosDto**](PosDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPosProductsIdPut**
> PosProductDto apiV1AdminPosProductsIdPut(id, posProductWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var posProductWriteDto = new PosProductWriteDto(); // PosProductWriteDto | 

try {
    var result = api_instance.apiV1AdminPosProductsIdPut(id, posProductWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPosProductsIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **posProductWriteDto** | [**PosProductWriteDto**](PosProductWriteDto.md)|  | 

### Return type

[**PosProductDto**](PosProductDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPosProductsPost**
> PosProductDto apiV1AdminPosProductsPost(posProductWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var posProductWriteDto = new PosProductWriteDto(); // PosProductWriteDto | 

try {
    var result = api_instance.apiV1AdminPosProductsPost(posProductWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPosProductsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **posProductWriteDto** | [**PosProductWriteDto**](PosProductWriteDto.md)|  | 

### Return type

[**PosProductDto**](PosProductDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminProductsGet**
> PagedResultOfProductDto apiV1AdminProductsGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminProductsGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminProductsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfProductDto**](PagedResultOfProductDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminProductsIdDelete**
> apiV1AdminProductsIdDelete(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminProductsIdDelete(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminProductsIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminProductsIdPut**
> ProductDto apiV1AdminProductsIdPut(id, productWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var productWriteDto = new ProductWriteDto(); // ProductWriteDto | 

try {
    var result = api_instance.apiV1AdminProductsIdPut(id, productWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminProductsIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **productWriteDto** | [**ProductWriteDto**](ProductWriteDto.md)|  | 

### Return type

[**ProductDto**](ProductDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminProductsPost**
> ProductDto apiV1AdminProductsPost(productWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var productWriteDto = new ProductWriteDto(); // ProductWriteDto | 

try {
    var result = api_instance.apiV1AdminProductsPost(productWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminProductsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **productWriteDto** | [**ProductWriteDto**](ProductWriteDto.md)|  | 

### Return type

[**ProductDto**](ProductDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminProductsProductIdPosProductsGet**
> BuiltList<PosProductDto> apiV1AdminProductsProductIdPosProductsGet(productId, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var productId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminProductsProductIdPosProductsGet(productId, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminProductsProductIdPosProductsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **productId** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**BuiltList<PosProductDto>**](PosProductDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPurchasesGet**
> PagedResultOfPurchaseDto apiV1AdminPurchasesGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminPurchasesGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPurchasesGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfPurchaseDto**](PagedResultOfPurchaseDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPurchasesIdDelete**
> apiV1AdminPurchasesIdDelete(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminPurchasesIdDelete(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPurchasesIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPurchasesIdGet**
> PurchaseDto apiV1AdminPurchasesIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminPurchasesIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPurchasesIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**PurchaseDto**](PurchaseDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPurchasesIdPut**
> PurchaseDto apiV1AdminPurchasesIdPut(id, purchaseWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var purchaseWriteDto = new PurchaseWriteDto(); // PurchaseWriteDto | 

try {
    var result = api_instance.apiV1AdminPurchasesIdPut(id, purchaseWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPurchasesIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **purchaseWriteDto** | [**PurchaseWriteDto**](PurchaseWriteDto.md)|  | 

### Return type

[**PurchaseDto**](PurchaseDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminPurchasesPost**
> PurchaseDto apiV1AdminPurchasesPost(purchaseWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var purchaseWriteDto = new PurchaseWriteDto(); // PurchaseWriteDto | 

try {
    var result = api_instance.apiV1AdminPurchasesPost(purchaseWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminPurchasesPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **purchaseWriteDto** | [**PurchaseWriteDto**](PurchaseWriteDto.md)|  | 

### Return type

[**PurchaseDto**](PurchaseDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRewardsGet**
> PagedResultOfRewardDto apiV1AdminRewardsGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminRewardsGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRewardsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfRewardDto**](PagedResultOfRewardDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRewardsIdDelete**
> apiV1AdminRewardsIdDelete(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminRewardsIdDelete(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRewardsIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRewardsIdGet**
> RewardDto apiV1AdminRewardsIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminRewardsIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRewardsIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**RewardDto**](RewardDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRewardsIdPut**
> RewardDto apiV1AdminRewardsIdPut(id, rewardWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var rewardWriteDto = new RewardWriteDto(); // RewardWriteDto | 

try {
    var result = api_instance.apiV1AdminRewardsIdPut(id, rewardWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRewardsIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **rewardWriteDto** | [**RewardWriteDto**](RewardWriteDto.md)|  | 

### Return type

[**RewardDto**](RewardDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRewardsPost**
> RewardDto apiV1AdminRewardsPost(rewardWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var rewardWriteDto = new RewardWriteDto(); // RewardWriteDto | 

try {
    var result = api_instance.apiV1AdminRewardsPost(rewardWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRewardsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **rewardWriteDto** | [**RewardWriteDto**](RewardWriteDto.md)|  | 

### Return type

[**RewardDto**](RewardDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRolesGet**
> BuiltList<RoleDto> apiV1AdminRolesGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminRolesGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRolesGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 

### Return type

[**BuiltList<RoleDto>**](RoleDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRolesIdDelete**
> apiV1AdminRolesIdDelete(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminRolesIdDelete(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRolesIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRolesIdGet**
> RoleDto apiV1AdminRolesIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminRolesIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRolesIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**RoleDto**](RoleDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRolesIdPermissionsPut**
> RoleDto apiV1AdminRolesIdPermissionsPut(id, rolePermissionWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var rolePermissionWriteDto = new RolePermissionWriteDto(); // RolePermissionWriteDto | 

try {
    var result = api_instance.apiV1AdminRolesIdPermissionsPut(id, rolePermissionWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRolesIdPermissionsPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **rolePermissionWriteDto** | [**RolePermissionWriteDto**](RolePermissionWriteDto.md)|  | 

### Return type

[**RoleDto**](RoleDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRolesIdPut**
> RoleDto apiV1AdminRolesIdPut(id, roleWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var roleWriteDto = new RoleWriteDto(); // RoleWriteDto | 

try {
    var result = api_instance.apiV1AdminRolesIdPut(id, roleWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRolesIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **roleWriteDto** | [**RoleWriteDto**](RoleWriteDto.md)|  | 

### Return type

[**RoleDto**](RoleDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminRolesPost**
> RoleDto apiV1AdminRolesPost(roleWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var roleWriteDto = new RoleWriteDto(); // RoleWriteDto | 

try {
    var result = api_instance.apiV1AdminRolesPost(roleWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminRolesPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleWriteDto** | [**RoleWriteDto**](RoleWriteDto.md)|  | 

### Return type

[**RoleDto**](RoleDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminStampCardsGet**
> PagedResultOfStampCardDto apiV1AdminStampCardsGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminStampCardsGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminStampCardsGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfStampCardDto**](PagedResultOfStampCardDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminStampCardsIdDelete**
> apiV1AdminStampCardsIdDelete(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminStampCardsIdDelete(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminStampCardsIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminStampCardsIdGet**
> StampCardDto apiV1AdminStampCardsIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminStampCardsIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminStampCardsIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**StampCardDto**](StampCardDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminStampCardsIdPut**
> StampCardDto apiV1AdminStampCardsIdPut(id, stampCardWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var stampCardWriteDto = new StampCardWriteDto(); // StampCardWriteDto | 

try {
    var result = api_instance.apiV1AdminStampCardsIdPut(id, stampCardWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminStampCardsIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **stampCardWriteDto** | [**StampCardWriteDto**](StampCardWriteDto.md)|  | 

### Return type

[**StampCardDto**](StampCardDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminStampCardsPost**
> StampCardDto apiV1AdminStampCardsPost(stampCardWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var stampCardWriteDto = new StampCardWriteDto(); // StampCardWriteDto | 

try {
    var result = api_instance.apiV1AdminStampCardsPost(stampCardWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminStampCardsPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stampCardWriteDto** | [**StampCardWriteDto**](StampCardWriteDto.md)|  | 

### Return type

[**StampCardDto**](StampCardDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminStoresGet**
> BuiltList<StoreDto> apiV1AdminStoresGet(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminStoresGet(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminStoresGet: $e\n');
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

# **apiV1AdminStoresIdDelete**
> apiV1AdminStoresIdDelete(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminStoresIdDelete(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminStoresIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminStoresIdPut**
> StoreDto apiV1AdminStoresIdPut(id, storeWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var storeWriteDto = new StoreWriteDto(); // StoreWriteDto | 

try {
    var result = api_instance.apiV1AdminStoresIdPut(id, storeWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminStoresIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **storeWriteDto** | [**StoreWriteDto**](StoreWriteDto.md)|  | 

### Return type

[**StoreDto**](StoreDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminStoresPost**
> StoreDto apiV1AdminStoresPost(storeWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var storeWriteDto = new StoreWriteDto(); // StoreWriteDto | 

try {
    var result = api_instance.apiV1AdminStoresPost(storeWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminStoresPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **storeWriteDto** | [**StoreWriteDto**](StoreWriteDto.md)|  | 

### Return type

[**StoreDto**](StoreDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminSuppliersGet**
> PagedResultOfSupplierDto apiV1AdminSuppliersGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminSuppliersGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminSuppliersGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfSupplierDto**](PagedResultOfSupplierDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminSuppliersIdDelete**
> apiV1AdminSuppliersIdDelete(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminSuppliersIdDelete(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminSuppliersIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminSuppliersIdGet**
> SupplierDto apiV1AdminSuppliersIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminSuppliersIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminSuppliersIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**SupplierDto**](SupplierDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminSuppliersIdPut**
> SupplierDto apiV1AdminSuppliersIdPut(id, supplierWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var supplierWriteDto = new SupplierWriteDto(); // SupplierWriteDto | 

try {
    var result = api_instance.apiV1AdminSuppliersIdPut(id, supplierWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminSuppliersIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **supplierWriteDto** | [**SupplierWriteDto**](SupplierWriteDto.md)|  | 

### Return type

[**SupplierDto**](SupplierDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminSuppliersPost**
> SupplierDto apiV1AdminSuppliersPost(supplierWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var supplierWriteDto = new SupplierWriteDto(); // SupplierWriteDto | 

try {
    var result = api_instance.apiV1AdminSuppliersPost(supplierWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminSuppliersPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **supplierWriteDto** | [**SupplierWriteDto**](SupplierWriteDto.md)|  | 

### Return type

[**SupplierDto**](SupplierDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminUsersGet**
> PagedResultOfUserDto apiV1AdminUsersGet(companyId, page, pageSize, sort, filter)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var page = 56; // int | 
var pageSize = 56; // int | 
var sort = sort_example; // String | 
var filter = filter_example; // String | 

try {
    var result = api_instance.apiV1AdminUsersGet(companyId, page, pageSize, sort, filter);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminUsersGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | [optional] 
 **page** | **int**|  | [optional] [default to 1]
 **pageSize** | **int**|  | [optional] [default to 50]
 **sort** | **String**|  | [optional] 
 **filter** | **String**|  | [optional] 

### Return type

[**PagedResultOfUserDto**](PagedResultOfUserDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminUsersIdDelete**
> apiV1AdminUsersIdDelete(id, companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.apiV1AdminUsersIdDelete(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminUsersIdDelete: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 
 **userId** | **String**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminUsersIdGet**
> UserDto apiV1AdminUsersIdGet(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.apiV1AdminUsersIdGet(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminUsersIdGet: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | [optional] 

### Return type

[**UserDto**](UserDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminUsersIdPut**
> UserDto apiV1AdminUsersIdPut(id, userWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userWriteDto = new UserWriteDto(); // UserWriteDto | 

try {
    var result = api_instance.apiV1AdminUsersIdPut(id, userWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminUsersIdPut: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **userWriteDto** | [**UserWriteDto**](UserWriteDto.md)|  | 

### Return type

[**UserDto**](UserDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AdminUsersPost**
> UserDto apiV1AdminUsersPost(userWriteDto)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AdminApi();
var userWriteDto = new UserWriteDto(); // UserWriteDto | 

try {
    var result = api_instance.apiV1AdminUsersPost(userWriteDto);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->apiV1AdminUsersPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userWriteDto** | [**UserWriteDto**](UserWriteDto.md)|  | 

### Return type

[**UserDto**](UserDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

