# mansis_pos_api_client.model.StockMovement

## Load the model package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **String** |  | 
**companyId** | **String** |  | 
**storeId** | **String** |  | 
**productId** | **String** |  | 
**operationId** | **String** |  | [optional] 
**movementType** | [**StoreProductMovementType**](StoreProductMovementType.md) |  | 
**direction** | [**LedgerDirection**](LedgerDirection.md) |  | 
**quantity** | **int** |  | 
**state** | [**LedgerEntryState**](LedgerEntryState.md) |  | 
**reversalOfId** | **String** |  | [optional] 
**description** | **String** |  | [optional] 
**occurredAt** | [**DateTime**](DateTime.md) |  | 
**currentQuantity** | **int** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


