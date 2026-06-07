# mansis_pos_api_client.api.AdminApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *https://api.example.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**createAdminAssignment**](AdminApi.md#createadminassignment) | **POST** /api/v1/admin/assignments | 
[**createAdminCampaign**](AdminApi.md#createadmincampaign) | **POST** /api/v1/admin/campaigns | 
[**createAdminCategory**](AdminApi.md#createadmincategory) | **POST** /api/v1/admin/categories | 
[**createAdminCustomer**](AdminApi.md#createadmincustomer) | **POST** /api/v1/admin/customers | 
[**createAdminDiscount**](AdminApi.md#createadmindiscount) | **POST** /api/v1/admin/discounts | 
[**createAdminEarnRule**](AdminApi.md#createadminearnrule) | **POST** /api/v1/admin/earn-rules | 
[**createAdminLoyaltyTier**](AdminApi.md#createadminloyaltytier) | **POST** /api/v1/admin/loyalty-tiers | 
[**createAdminPos**](AdminApi.md#createadminpos) | **POST** /api/v1/admin/pos | 
[**createAdminPosProduct**](AdminApi.md#createadminposproduct) | **POST** /api/v1/admin/pos-products | 
[**createAdminProduct**](AdminApi.md#createadminproduct) | **POST** /api/v1/admin/products | 
[**createAdminReward**](AdminApi.md#createadminreward) | **POST** /api/v1/admin/rewards | 
[**createAdminRole**](AdminApi.md#createadminrole) | **POST** /api/v1/admin/roles | 
[**createAdminStampCard**](AdminApi.md#createadminstampcard) | **POST** /api/v1/admin/stamp-cards | 
[**createAdminStore**](AdminApi.md#createadminstore) | **POST** /api/v1/admin/stores | 
[**createAdminUser**](AdminApi.md#createadminuser) | **POST** /api/v1/admin/users | 
[**deleteAdminAssignment**](AdminApi.md#deleteadminassignment) | **DELETE** /api/v1/admin/assignments/{id} | 
[**deleteAdminCampaign**](AdminApi.md#deleteadmincampaign) | **DELETE** /api/v1/admin/campaigns/{id} | 
[**deleteAdminCategory**](AdminApi.md#deleteadmincategory) | **DELETE** /api/v1/admin/categories/{id} | 
[**deleteAdminCustomer**](AdminApi.md#deleteadmincustomer) | **DELETE** /api/v1/admin/customers/{id} | 
[**deleteAdminDiscount**](AdminApi.md#deleteadmindiscount) | **DELETE** /api/v1/admin/discounts/{id} | 
[**deleteAdminEarnRule**](AdminApi.md#deleteadminearnrule) | **DELETE** /api/v1/admin/earn-rules/{id} | 
[**deleteAdminLoyaltyTier**](AdminApi.md#deleteadminloyaltytier) | **DELETE** /api/v1/admin/loyalty-tiers/{id} | 
[**deleteAdminPos**](AdminApi.md#deleteadminpos) | **DELETE** /api/v1/admin/pos/{id} | 
[**deleteAdminProduct**](AdminApi.md#deleteadminproduct) | **DELETE** /api/v1/admin/products/{id} | 
[**deleteAdminReward**](AdminApi.md#deleteadminreward) | **DELETE** /api/v1/admin/rewards/{id} | 
[**deleteAdminRole**](AdminApi.md#deleteadminrole) | **DELETE** /api/v1/admin/roles/{id} | 
[**deleteAdminStampCard**](AdminApi.md#deleteadminstampcard) | **DELETE** /api/v1/admin/stamp-cards/{id} | 
[**deleteAdminStore**](AdminApi.md#deleteadminstore) | **DELETE** /api/v1/admin/stores/{id} | 
[**deleteAdminUser**](AdminApi.md#deleteadminuser) | **DELETE** /api/v1/admin/users/{id} | 
[**getAdminAssignment**](AdminApi.md#getadminassignment) | **GET** /api/v1/admin/assignments/{id} | 
[**getAdminCampaign**](AdminApi.md#getadmincampaign) | **GET** /api/v1/admin/campaigns/{id} | 
[**getAdminDiscount**](AdminApi.md#getadmindiscount) | **GET** /api/v1/admin/discounts/{id} | 
[**getAdminEarnRule**](AdminApi.md#getadminearnrule) | **GET** /api/v1/admin/earn-rules/{id} | 
[**getAdminLoyaltyTier**](AdminApi.md#getadminloyaltytier) | **GET** /api/v1/admin/loyalty-tiers/{id} | 
[**getAdminReward**](AdminApi.md#getadminreward) | **GET** /api/v1/admin/rewards/{id} | 
[**getAdminRole**](AdminApi.md#getadminrole) | **GET** /api/v1/admin/roles/{id} | 
[**getAdminStampCard**](AdminApi.md#getadminstampcard) | **GET** /api/v1/admin/stamp-cards/{id} | 
[**getAdminUser**](AdminApi.md#getadminuser) | **GET** /api/v1/admin/users/{id} | 
[**listAdminAssignments**](AdminApi.md#listadminassignments) | **GET** /api/v1/admin/assignments | 
[**listAdminCampaigns**](AdminApi.md#listadmincampaigns) | **GET** /api/v1/admin/campaigns | 
[**listAdminCategories**](AdminApi.md#listadmincategories) | **GET** /api/v1/admin/categories | 
[**listAdminCompanies**](AdminApi.md#listadmincompanies) | **GET** /api/v1/admin/companies | 
[**listAdminCustomers**](AdminApi.md#listadmincustomers) | **GET** /api/v1/admin/customers | 
[**listAdminDiscounts**](AdminApi.md#listadmindiscounts) | **GET** /api/v1/admin/discounts | 
[**listAdminEarnRules**](AdminApi.md#listadminearnrules) | **GET** /api/v1/admin/earn-rules | 
[**listAdminLoyaltyTiers**](AdminApi.md#listadminloyaltytiers) | **GET** /api/v1/admin/loyalty-tiers | 
[**listAdminOrders**](AdminApi.md#listadminorders) | **GET** /api/v1/admin/orders | 
[**listAdminPermissions**](AdminApi.md#listadminpermissions) | **GET** /api/v1/admin/permissions | 
[**listAdminPos**](AdminApi.md#listadminpos) | **GET** /api/v1/admin/pos | 
[**listAdminProducts**](AdminApi.md#listadminproducts) | **GET** /api/v1/admin/products | 
[**listAdminRewards**](AdminApi.md#listadminrewards) | **GET** /api/v1/admin/rewards | 
[**listAdminRoles**](AdminApi.md#listadminroles) | **GET** /api/v1/admin/roles | 
[**listAdminStampCards**](AdminApi.md#listadminstampcards) | **GET** /api/v1/admin/stamp-cards | 
[**listAdminStores**](AdminApi.md#listadminstores) | **GET** /api/v1/admin/stores | 
[**listAdminUsers**](AdminApi.md#listadminusers) | **GET** /api/v1/admin/users | 
[**updateAdminAssignment**](AdminApi.md#updateadminassignment) | **PUT** /api/v1/admin/assignments/{id} | 
[**updateAdminCampaign**](AdminApi.md#updateadmincampaign) | **PUT** /api/v1/admin/campaigns/{id} | 
[**updateAdminCategory**](AdminApi.md#updateadmincategory) | **PUT** /api/v1/admin/categories/{id} | 
[**updateAdminCustomer**](AdminApi.md#updateadmincustomer) | **PUT** /api/v1/admin/customers/{id} | 
[**updateAdminDiscount**](AdminApi.md#updateadmindiscount) | **PUT** /api/v1/admin/discounts/{id} | 
[**updateAdminEarnRule**](AdminApi.md#updateadminearnrule) | **PUT** /api/v1/admin/earn-rules/{id} | 
[**updateAdminLoyaltyTier**](AdminApi.md#updateadminloyaltytier) | **PUT** /api/v1/admin/loyalty-tiers/{id} | 
[**updateAdminPos**](AdminApi.md#updateadminpos) | **PUT** /api/v1/admin/pos/{id} | 
[**updateAdminPosProduct**](AdminApi.md#updateadminposproduct) | **PUT** /api/v1/admin/pos-products/{id} | 
[**updateAdminProduct**](AdminApi.md#updateadminproduct) | **PUT** /api/v1/admin/products/{id} | 
[**updateAdminReward**](AdminApi.md#updateadminreward) | **PUT** /api/v1/admin/rewards/{id} | 
[**updateAdminRole**](AdminApi.md#updateadminrole) | **PUT** /api/v1/admin/roles/{id} | 
[**updateAdminRolePermissions**](AdminApi.md#updateadminrolepermissions) | **PUT** /api/v1/admin/roles/{id}/permissions | 
[**updateAdminStampCard**](AdminApi.md#updateadminstampcard) | **PUT** /api/v1/admin/stamp-cards/{id} | 
[**updateAdminStore**](AdminApi.md#updateadminstore) | **PUT** /api/v1/admin/stores/{id} | 
[**updateAdminUser**](AdminApi.md#updateadminuser) | **PUT** /api/v1/admin/users/{id} | 


# **createAdminAssignment**
> Assignment createAdminAssignment(assignmentWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var assignmentWrite = new AssignmentWrite(); // AssignmentWrite | 

try {
    var result = api_instance.createAdminAssignment(assignmentWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminAssignment: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **assignmentWrite** | [**AssignmentWrite**](AssignmentWrite.md)|  | 

### Return type

[**Assignment**](Assignment.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminCampaign**
> Campaign createAdminCampaign(campaignWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var campaignWrite = new CampaignWrite(); // CampaignWrite | 

try {
    var result = api_instance.createAdminCampaign(campaignWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminCampaign: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **campaignWrite** | [**CampaignWrite**](CampaignWrite.md)|  | 

### Return type

[**Campaign**](Campaign.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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

# **createAdminEarnRule**
> EarnRule createAdminEarnRule(earnRuleWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var earnRuleWrite = new EarnRuleWrite(); // EarnRuleWrite | 

try {
    var result = api_instance.createAdminEarnRule(earnRuleWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminEarnRule: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **earnRuleWrite** | [**EarnRuleWrite**](EarnRuleWrite.md)|  | 

### Return type

[**EarnRule**](EarnRule.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminLoyaltyTier**
> LoyaltyTier createAdminLoyaltyTier(loyaltyTierWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var loyaltyTierWrite = new LoyaltyTierWrite(); // LoyaltyTierWrite | 

try {
    var result = api_instance.createAdminLoyaltyTier(loyaltyTierWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminLoyaltyTier: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **loyaltyTierWrite** | [**LoyaltyTierWrite**](LoyaltyTierWrite.md)|  | 

### Return type

[**LoyaltyTier**](LoyaltyTier.md)

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

# **createAdminReward**
> Reward createAdminReward(rewardWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var rewardWrite = new RewardWrite(); // RewardWrite | 

try {
    var result = api_instance.createAdminReward(rewardWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminReward: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **rewardWrite** | [**RewardWrite**](RewardWrite.md)|  | 

### Return type

[**Reward**](Reward.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminRole**
> Role createAdminRole(roleWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var roleWrite = new RoleWrite(); // RoleWrite | 

try {
    var result = api_instance.createAdminRole(roleWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminRole: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleWrite** | [**RoleWrite**](RoleWrite.md)|  | 

### Return type

[**Role**](Role.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **createAdminStampCard**
> StampCard createAdminStampCard(stampCardWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var stampCardWrite = new StampCardWrite(); // StampCardWrite | 

try {
    var result = api_instance.createAdminStampCard(stampCardWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminStampCard: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **stampCardWrite** | [**StampCardWrite**](StampCardWrite.md)|  | 

### Return type

[**StampCard**](StampCard.md)

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

# **createAdminUser**
> User createAdminUser(userWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var userWrite = new UserWrite(); // UserWrite | 

try {
    var result = api_instance.createAdminUser(userWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->createAdminUser: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userWrite** | [**UserWrite**](UserWrite.md)|  | 

### Return type

[**User**](User.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminAssignment**
> deleteAdminAssignment(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminAssignment(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminAssignment: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminCampaign**
> deleteAdminCampaign(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminCampaign(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminCampaign: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

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

# **deleteAdminEarnRule**
> deleteAdminEarnRule(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminEarnRule(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminEarnRule: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminLoyaltyTier**
> deleteAdminLoyaltyTier(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminLoyaltyTier(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminLoyaltyTier: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

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

# **deleteAdminReward**
> deleteAdminReward(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminReward(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminReward: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

void (empty response body)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **deleteAdminRole**
> deleteAdminRole(id, companyId, userId)



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
    api_instance.deleteAdminRole(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminRole: $e\n');
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

# **deleteAdminStampCard**
> deleteAdminStampCard(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    api_instance.deleteAdminStampCard(id, companyId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminStampCard: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

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

# **deleteAdminUser**
> deleteAdminUser(id, companyId, userId)



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
    api_instance.deleteAdminUser(id, companyId, userId);
} catch (e) {
    print('Exception when calling AdminApi->deleteAdminUser: $e\n');
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

# **getAdminAssignment**
> Assignment getAdminAssignment(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAdminAssignment(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->getAdminAssignment: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

[**Assignment**](Assignment.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getAdminCampaign**
> Campaign getAdminCampaign(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAdminCampaign(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->getAdminCampaign: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

[**Campaign**](Campaign.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getAdminDiscount**
> Discount getAdminDiscount(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAdminDiscount(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->getAdminDiscount: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

[**Discount**](Discount.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getAdminEarnRule**
> EarnRule getAdminEarnRule(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAdminEarnRule(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->getAdminEarnRule: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

[**EarnRule**](EarnRule.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getAdminLoyaltyTier**
> LoyaltyTier getAdminLoyaltyTier(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAdminLoyaltyTier(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->getAdminLoyaltyTier: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

[**LoyaltyTier**](LoyaltyTier.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getAdminReward**
> Reward getAdminReward(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAdminReward(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->getAdminReward: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

[**Reward**](Reward.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getAdminRole**
> Role getAdminRole(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAdminRole(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->getAdminRole: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

[**Role**](Role.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getAdminStampCard**
> StampCard getAdminStampCard(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAdminStampCard(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->getAdminStampCard: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

[**StampCard**](StampCard.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **getAdminUser**
> User getAdminUser(id, companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.getAdminUser(id, companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->getAdminUser: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **companyId** | **String**|  | 

### Return type

[**User**](User.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminAssignments**
> BuiltList<Assignment> listAdminAssignments(companyId, userId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminAssignments(companyId, userId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminAssignments: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 
 **userId** | **String**|  | [optional] 

### Return type

[**BuiltList<Assignment>**](Assignment.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminCampaigns**
> BuiltList<Campaign> listAdminCampaigns(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminCampaigns(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminCampaigns: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<Campaign>**](Campaign.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

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

# **listAdminEarnRules**
> BuiltList<EarnRule> listAdminEarnRules(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminEarnRules(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminEarnRules: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<EarnRule>**](EarnRule.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminLoyaltyTiers**
> BuiltList<LoyaltyTier> listAdminLoyaltyTiers(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminLoyaltyTiers(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminLoyaltyTiers: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<LoyaltyTier>**](LoyaltyTier.md)

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

# **listAdminPermissions**
> BuiltList<Permission> listAdminPermissions()



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();

try {
    var result = api_instance.listAdminPermissions();
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminPermissions: $e\n');
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**BuiltList<Permission>**](Permission.md)

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

# **listAdminRewards**
> BuiltList<Reward> listAdminRewards(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminRewards(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminRewards: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<Reward>**](Reward.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminRoles**
> BuiltList<Role> listAdminRoles(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminRoles(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminRoles: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<Role>**](Role.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **listAdminStampCards**
> BuiltList<StampCard> listAdminStampCards(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminStampCards(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminStampCards: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<StampCard>**](StampCard.md)

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

# **listAdminUsers**
> BuiltList<User> listAdminUsers(companyId)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var companyId = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 

try {
    var result = api_instance.listAdminUsers(companyId);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->listAdminUsers: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **companyId** | **String**|  | 

### Return type

[**BuiltList<User>**](User.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminAssignment**
> Assignment updateAdminAssignment(id, assignmentWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var assignmentWrite = new AssignmentWrite(); // AssignmentWrite | 

try {
    var result = api_instance.updateAdminAssignment(id, assignmentWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminAssignment: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **assignmentWrite** | [**AssignmentWrite**](AssignmentWrite.md)|  | 

### Return type

[**Assignment**](Assignment.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminCampaign**
> Campaign updateAdminCampaign(id, campaignWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var campaignWrite = new CampaignWrite(); // CampaignWrite | 

try {
    var result = api_instance.updateAdminCampaign(id, campaignWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminCampaign: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **campaignWrite** | [**CampaignWrite**](CampaignWrite.md)|  | 

### Return type

[**Campaign**](Campaign.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
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

# **updateAdminEarnRule**
> EarnRule updateAdminEarnRule(id, earnRuleWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var earnRuleWrite = new EarnRuleWrite(); // EarnRuleWrite | 

try {
    var result = api_instance.updateAdminEarnRule(id, earnRuleWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminEarnRule: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **earnRuleWrite** | [**EarnRuleWrite**](EarnRuleWrite.md)|  | 

### Return type

[**EarnRule**](EarnRule.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminLoyaltyTier**
> LoyaltyTier updateAdminLoyaltyTier(id, loyaltyTierWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var loyaltyTierWrite = new LoyaltyTierWrite(); // LoyaltyTierWrite | 

try {
    var result = api_instance.updateAdminLoyaltyTier(id, loyaltyTierWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminLoyaltyTier: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **loyaltyTierWrite** | [**LoyaltyTierWrite**](LoyaltyTierWrite.md)|  | 

### Return type

[**LoyaltyTier**](LoyaltyTier.md)

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

# **updateAdminReward**
> Reward updateAdminReward(id, rewardWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var rewardWrite = new RewardWrite(); // RewardWrite | 

try {
    var result = api_instance.updateAdminReward(id, rewardWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminReward: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **rewardWrite** | [**RewardWrite**](RewardWrite.md)|  | 

### Return type

[**Reward**](Reward.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminRole**
> Role updateAdminRole(id, roleWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var roleWrite = new RoleWrite(); // RoleWrite | 

try {
    var result = api_instance.updateAdminRole(id, roleWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminRole: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **roleWrite** | [**RoleWrite**](RoleWrite.md)|  | 

### Return type

[**Role**](Role.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminRolePermissions**
> Role updateAdminRolePermissions(id, rolePermissionWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var rolePermissionWrite = new RolePermissionWrite(); // RolePermissionWrite | 

try {
    var result = api_instance.updateAdminRolePermissions(id, rolePermissionWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminRolePermissions: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **rolePermissionWrite** | [**RolePermissionWrite**](RolePermissionWrite.md)|  | 

### Return type

[**Role**](Role.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **updateAdminStampCard**
> StampCard updateAdminStampCard(id, stampCardWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var stampCardWrite = new StampCardWrite(); // StampCardWrite | 

try {
    var result = api_instance.updateAdminStampCard(id, stampCardWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminStampCard: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **stampCardWrite** | [**StampCardWrite**](StampCardWrite.md)|  | 

### Return type

[**StampCard**](StampCard.md)

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

# **updateAdminUser**
> User updateAdminUser(id, userWrite)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';
// TODO Configure HTTP basic authorization: bearerAuth
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').username = 'YOUR_USERNAME'
//defaultApiClient.getAuthentication<HttpBasicAuth>('bearerAuth').password = 'YOUR_PASSWORD';

var api_instance = new AdminApi();
var id = 38400000-8cf0-11bd-b23e-10b96e4ef00d; // String | 
var userWrite = new UserWrite(); // UserWrite | 

try {
    var result = api_instance.updateAdminUser(id, userWrite);
    print(result);
} catch (e) {
    print('Exception when calling AdminApi->updateAdminUser: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **String**|  | 
 **userWrite** | [**UserWrite**](UserWrite.md)|  | 

### Return type

[**User**](User.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

