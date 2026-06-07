# mansis_pos_api_client.model.StoreProductTransferDto

## Load the model package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

## Properties
Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **String** |  | 
**companyId** | **String** |  | 
**sourceStoreId** | **String** |  | 
**targetStoreId** | **String** |  | 
**requestedById** | **String** |  | 
**requestedTime** | [**DateTime**](DateTime.md) |  | 
**transferState** | **int** |  | 
**confirmedById** | **String** |  | 
**confirmedTime** | [**DateTime**](DateTime.md) |  | 
**receivedById** | **String** |  | 
**receivedTime** | [**DateTime**](DateTime.md) |  | 
**cancelledById** | **String** |  | 
**cancelledTime** | [**DateTime**](DateTime.md) |  | 
**cancelReason** | **String** |  | 
**transferDone** | **bool** |  | 
**lines** | [**BuiltList<StoreProductTransferLineDto>**](StoreProductTransferLineDto.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


