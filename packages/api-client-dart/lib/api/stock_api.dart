//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'dart:async';
import 'package:dio/dio.dart';
import 'package:built_value/serializer.dart';

import 'package:mansis_pos_api_client/model/cancel_transfer_request.dart';
import 'package:mansis_pos_api_client/model/confirm_transfer_request.dart';
import 'package:mansis_pos_api_client/model/create_transfer_request.dart';
import 'package:mansis_pos_api_client/model/destroy_stock_request.dart';
import 'package:mansis_pos_api_client/model/paged_result_of_stock_movement_dto.dart';
import 'package:mansis_pos_api_client/model/receive_transfer_request.dart';
import 'package:mansis_pos_api_client/model/stock_adjustment_request.dart';
import 'package:mansis_pos_api_client/model/stock_count_request.dart';
import 'package:mansis_pos_api_client/model/stock_movement_dto.dart';
import 'package:mansis_pos_api_client/model/store_product_transfer_dto.dart';

class StockApi {

  final Dio _dio;

  final Serializers _serializers;

  const StockApi(this._dio, this._serializers);

  /// 
  ///
  /// 
  Future<Response<StockMovementDto>> apiV1StockCountPost(
    StockCountRequest stockCountRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/stock/count',
      method: 'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      validateStatus: validateStatus,
      contentType: 'application/json',
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    dynamic _bodyData;

    const _type = FullType(StockCountRequest);
    _bodyData = _serializers.serialize(stockCountRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(StockMovementDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as StockMovementDto;

    return Response<StockMovementDto>(
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

  /// 
  ///
  /// 
  Future<Response<StockMovementDto>> apiV1StockDestroyPost(
    DestroyStockRequest destroyStockRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/stock/destroy',
      method: 'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      validateStatus: validateStatus,
      contentType: 'application/json',
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    dynamic _bodyData;

    const _type = FullType(DestroyStockRequest);
    _bodyData = _serializers.serialize(destroyStockRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(StockMovementDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as StockMovementDto;

    return Response<StockMovementDto>(
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

  /// 
  ///
  /// 
  Future<Response<PagedResultOfStockMovementDto>> apiV1StockMovementsGet({ 
    String companyId,
    String storeId,
    String productId,
    int movementType,
    DateTime from,
    DateTime to,
    int page,
    int pageSize,
    String sort,
    String filter,
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
        if (companyId != null) r'companyId': companyId,
        if (storeId != null) r'storeId': storeId,
        if (productId != null) r'productId': productId,
        if (movementType != null) r'movementType': movementType,
        if (from != null) r'from': from,
        if (to != null) r'to': to,
        if (page != null) r'page': page,
        if (pageSize != null) r'pageSize': pageSize,
        if (sort != null) r'sort': sort,
        if (filter != null) r'filter': filter,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
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

    const _responseType = FullType(PagedResultOfStockMovementDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as PagedResultOfStockMovementDto;

    return Response<PagedResultOfStockMovementDto>(
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

  /// 
  ///
  /// 
  Future<Response<StockMovementDto>> apiV1StockStockInPost(
    StockAdjustmentRequest stockAdjustmentRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/stock/stock-in',
      method: 'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      validateStatus: validateStatus,
      contentType: 'application/json',
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    dynamic _bodyData;

    const _type = FullType(StockAdjustmentRequest);
    _bodyData = _serializers.serialize(stockAdjustmentRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(StockMovementDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as StockMovementDto;

    return Response<StockMovementDto>(
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

  /// 
  ///
  /// 
  Future<Response<StockMovementDto>> apiV1StockStockOutPost(
    StockAdjustmentRequest stockAdjustmentRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/stock/stock-out',
      method: 'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      validateStatus: validateStatus,
      contentType: 'application/json',
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    dynamic _bodyData;

    const _type = FullType(StockAdjustmentRequest);
    _bodyData = _serializers.serialize(stockAdjustmentRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(StockMovementDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as StockMovementDto;

    return Response<StockMovementDto>(
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

  /// 
  ///
  /// 
  Future<Response<StoreProductTransferDto>> apiV1StockTransfersIdCancelPost(
    String id,
    CancelTransferRequest cancelTransferRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/stock/transfers/{id}/cancel'.replaceAll('{' r'id' '}', id.toString()),
      method: 'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      validateStatus: validateStatus,
      contentType: 'application/json',
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    dynamic _bodyData;

    const _type = FullType(CancelTransferRequest);
    _bodyData = _serializers.serialize(cancelTransferRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(StoreProductTransferDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as StoreProductTransferDto;

    return Response<StoreProductTransferDto>(
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

  /// 
  ///
  /// 
  Future<Response<StoreProductTransferDto>> apiV1StockTransfersIdConfirmPost(
    String id,
    ConfirmTransferRequest confirmTransferRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/stock/transfers/{id}/confirm'.replaceAll('{' r'id' '}', id.toString()),
      method: 'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      validateStatus: validateStatus,
      contentType: 'application/json',
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    dynamic _bodyData;

    const _type = FullType(ConfirmTransferRequest);
    _bodyData = _serializers.serialize(confirmTransferRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(StoreProductTransferDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as StoreProductTransferDto;

    return Response<StoreProductTransferDto>(
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

  /// 
  ///
  /// 
  Future<Response<StoreProductTransferDto>> apiV1StockTransfersIdReceivePost(
    String id,
    ReceiveTransferRequest receiveTransferRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/stock/transfers/{id}/receive'.replaceAll('{' r'id' '}', id.toString()),
      method: 'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      validateStatus: validateStatus,
      contentType: 'application/json',
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    dynamic _bodyData;

    const _type = FullType(ReceiveTransferRequest);
    _bodyData = _serializers.serialize(receiveTransferRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(StoreProductTransferDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as StoreProductTransferDto;

    return Response<StoreProductTransferDto>(
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

  /// 
  ///
  /// 
  Future<Response<StoreProductTransferDto>> apiV1StockTransfersPost(
    CreateTransferRequest createTransferRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/stock/transfers',
      method: 'POST',
      headers: <String, dynamic>{
        ...?headers,
      },
      extra: <String, dynamic>{
        'secure': <Map<String, String>>[],
        ...?extra,
      },
      validateStatus: validateStatus,
      contentType: 'application/json',
      cancelToken: cancelToken,
      onSendProgress: onSendProgress,
      onReceiveProgress: onReceiveProgress,
    );

    dynamic _bodyData;

    const _type = FullType(CreateTransferRequest);
    _bodyData = _serializers.serialize(createTransferRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(StoreProductTransferDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as StoreProductTransferDto;

    return Response<StoreProductTransferDto>(
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
