//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'dart:async';
import 'package:dio/dio.dart';
import 'package:built_value/serializer.dart';

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/problem_details.dart';
import 'package:mansis_pos_api_client/model/stock_movement.dart';

class StockApi {

  final Dio _dio;

  final Serializers _serializers;

  const StockApi(this._dio, this._serializers);

  /// 
  ///
  /// 
  Future<Response<BuiltList<StockMovement>>> listStockMovements(
    String companyId, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/stock/movements',
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        r'companyId': companyId,
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

    const _responseType = FullType(BuiltList, [FullType(StockMovement)]);
    final BuiltList<StockMovement> _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as BuiltList<StockMovement>;

    return Response<BuiltList<StockMovement>>(
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
