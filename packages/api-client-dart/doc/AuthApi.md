# mansis_pos_api_client.api.AuthApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *http://localhost:5088*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiV1AuthLoginPost**](AuthApi.md#apiv1authloginpost) | **POST** /api/v1/auth/login | 
[**apiV1AuthOtpRequestPost**](AuthApi.md#apiv1authotprequestpost) | **POST** /api/v1/auth/otp/request | 
[**apiV1AuthOtpVerifyPost**](AuthApi.md#apiv1authotpverifypost) | **POST** /api/v1/auth/otp/verify | 
[**apiV1AuthRefreshPost**](AuthApi.md#apiv1authrefreshpost) | **POST** /api/v1/auth/refresh | 


# **apiV1AuthLoginPost**
> AuthTokenResult apiV1AuthLoginPost(loginRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AuthApi();
var loginRequest = new LoginRequest(); // LoginRequest | 

try {
    var result = api_instance.apiV1AuthLoginPost(loginRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthApi->apiV1AuthLoginPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **loginRequest** | [**LoginRequest**](LoginRequest.md)|  | 

### Return type

[**AuthTokenResult**](AuthTokenResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AuthOtpRequestPost**
> OtpResult apiV1AuthOtpRequestPost(otpRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AuthApi();
var otpRequest = new OtpRequest(); // OtpRequest | 

try {
    var result = api_instance.apiV1AuthOtpRequestPost(otpRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthApi->apiV1AuthOtpRequestPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **otpRequest** | [**OtpRequest**](OtpRequest.md)|  | 

### Return type

[**OtpResult**](OtpResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AuthOtpVerifyPost**
> OtpResult apiV1AuthOtpVerifyPost(otpVerifyRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AuthApi();
var otpVerifyRequest = new OtpVerifyRequest(); // OtpVerifyRequest | 

try {
    var result = api_instance.apiV1AuthOtpVerifyPost(otpVerifyRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthApi->apiV1AuthOtpVerifyPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **otpVerifyRequest** | [**OtpVerifyRequest**](OtpVerifyRequest.md)|  | 

### Return type

[**OtpResult**](OtpResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiV1AuthRefreshPost**
> AuthTokenResult apiV1AuthRefreshPost(refreshTokenRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AuthApi();
var refreshTokenRequest = new RefreshTokenRequest(); // RefreshTokenRequest | 

try {
    var result = api_instance.apiV1AuthRefreshPost(refreshTokenRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthApi->apiV1AuthRefreshPost: $e\n');
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **refreshTokenRequest** | [**RefreshTokenRequest**](RefreshTokenRequest.md)|  | 

### Return type

[**AuthTokenResult**](AuthTokenResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/_*+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

