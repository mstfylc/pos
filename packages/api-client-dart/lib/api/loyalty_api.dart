//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'dart:async';
import 'package:dio/dio.dart';
import 'package:built_value/serializer.dart';

import 'package:mansis_pos_api_client/model/loyalty_account.dart';
import 'package:mansis_pos_api_client/model/problem_details.dart';

class LoyaltyApi {

  final Dio _dio;

  final Serializers _serializers;

  const LoyaltyApi(this._dio, this._serializers);

  /// 
  ///
  /// 
  Future<Response<LoyaltyAccount>> getLoyaltyAccount(
    String customerId, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/loyalty/accounts/{customerId}'.replaceAll('{' r'customerId' '}', customerId.toString()),
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[
          {
            'type': 'http',
            'name': 'bearerAuth',
          },
        ],
        ...?extra,
      },
      validateStatus: validateStatus,
      contentType: 'application/json',
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    dynamic _bodyData;

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(LoyaltyAccount);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as LoyaltyAccount;

    return Response<LoyaltyAccount>(
      data: _responseData,
      headers: _response.headers,
      isRedirect: _response.isRedirect,
      request: _response.request,
      redirects: _response.redirects,
      statusCode: _response.statusCode,
      statusMessage: _response.statusMessage,
      extra: _response.extra,
    );
  }

}
