# mansis_pos_api_client.model.CreateOrderRequest

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
**customerId** | **String** |  | [optional] 
**orderTime** | [**DateTime**](DateTime.md) |  | 
**idempotencyKey** | **String** |  | 
**lines** | [**BuiltList<OrderLine>**](OrderLine.md) |  | 
**payments** | [**BuiltList<OrderPayment>**](OrderPayment.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


