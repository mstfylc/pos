# mansis_pos_api_client.api.AuthApi

## Load the API package
```dart
import 'package:mansis_pos_api_client/api.dart';
```

All URIs are relative to *https://api.example.com*

Method | HTTP request | Description
------------- | ------------- | -------------
[**login**](AuthApi.md#login) | **POST** /api/v1/auth/login | 
[**refresh**](AuthApi.md#refresh) | **POST** /api/v1/auth/refresh | 
[**requestOtp**](AuthApi.md#requestotp) | **POST** /api/v1/auth/otp/request | 
[**verifyOtp**](AuthApi.md#verifyotp) | **POST** /api/v1/auth/otp/verify | 


# **login**
> AuthTokenResult login(loginRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AuthApi();
var loginRequest = new LoginRequest(); // LoginRequest | 

try {
    var result = api_instance.login(loginRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthApi->login: $e\n');
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

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **refresh**
> AuthTokenResult refresh(refreshTokenRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AuthApi();
var refreshTokenRequest = new RefreshTokenRequest(); // RefreshTokenRequest | 

try {
    var result = api_instance.refresh(refreshTokenRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthApi->refresh: $e\n');
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

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **requestOtp**
> OtpResult requestOtp(otpRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AuthApi();
var otpRequest = new OtpRequest(); // OtpRequest | 

try {
    var result = api_instance.requestOtp(otpRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthApi->requestOtp: $e\n');
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

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **verifyOtp**
> OtpResult verifyOtp(otpVerifyRequest)



### Example
```dart
import 'package:mansis_pos_api_client/api.dart';

var api_instance = new AuthApi();
var otpVerifyRequest = new OtpVerifyRequest(); // OtpVerifyRequest | 

try {
    var result = api_instance.verifyOtp(otpVerifyRequest);
    print(result);
} catch (e) {
    print('Exception when calling AuthApi->verifyOtp: $e\n');
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

 - **Content-Type**: application/json
 - **Accept**: application/json, application/problem+json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

