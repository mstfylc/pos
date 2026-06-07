# mansis_pos_api_client.model.CreateAppOrderRequest

## Load the model package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**companyId** | **String** |  | 
**posId** | **String** |  | 
**userId** | **String** |  | 
**customerId** | **String** |  | 
**shippingType** | **int** |  | 
**orderTime** | [**DateTime**](DateTime.md) |  | 
**idempotencyKey** | **String** |  | 
**offlineOrder** | **bool** |  | 
**lines** | [**BuiltList<CreateAppOrderLineRequest>**](CreateAppOrderLineRequest.md) |  | 
**payments** | [**BuiltList<CreateAppOrderPaymentRequest>**](CreateAppOrderPaymentRequest.md) |  | 
**discounts** | [**BuiltList<CreateAppOrderDiscountRequest>**](CreateAppOrderDiscountRequest.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


