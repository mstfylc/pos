# mansis_pos_api_client.model.StoreProductTransfer

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
**transferState** | [**ProductTransferState**](ProductTransferState.md) |  | 
**confirmedById** | **String** |  | [optional] 
**confirmedTime** | [**DateTime**](DateTime.md) |  | [optional] 
**receivedById** | **String** |  | [optional] 
**receivedTime** | [**DateTime**](DateTime.md) |  | [optional] 
**cancelledById** | **String** |  | [optional] 
**cancelledTime** | [**DateTime**](DateTime.md) |  | [optional] 
**cancelReason** | **String** |  | [optional] 
**transferDone** | **bool** |  | [optional] 
**lines** | [**BuiltList<StoreProductTransferLine>**](StoreProductTransferLine.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)


