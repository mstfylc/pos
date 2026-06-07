//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'dart:async';
import 'package:dio/dio.dart';
import 'package:built_value/serializer.dart';

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/cancel_order_response.dart';
import 'package:mansis_pos_api_client/model/category_dto.dart';
import 'package:mansis_pos_api_client/model/create_app_order_request.dart';
import 'package:mansis_pos_api_client/model/customer_card_token_response.dart';
import 'package:mansis_pos_api_client/model/customer_dto.dart';
import 'package:mansis_pos_api_client/model/discount_dto.dart';
import 'package:mansis_pos_api_client/model/identified_customer_dto.dart';
import 'package:mansis_pos_api_client/model/identify_customer_request.dart';
import 'package:mansis_pos_api_client/model/issue_customer_card_token_api_request.dart';
import 'package:mansis_pos_api_client/model/loyalty_preview_request.dart';
import 'package:mansis_pos_api_client/model/loyalty_preview_response.dart';
import 'package:mansis_pos_api_client/model/order_list_dto.dart';
import 'package:mansis_pos_api_client/model/order_response.dart';
import 'package:mansis_pos_api_client/model/pos_dto.dart';
import 'package:mansis_pos_api_client/model/pos_product_catalog_response.dart';
import 'package:mansis_pos_api_client/model/problem_details.dart';
import 'package:mansis_pos_api_client/model/product_dto.dart';
import 'package:mansis_pos_api_client/model/reason_request.dart';
import 'package:mansis_pos_api_client/model/redeem_reward_api_request.dart';
import 'package:mansis_pos_api_client/model/redeem_reward_response.dart';
import 'package:mansis_pos_api_client/model/store_dto.dart';

class AppApi {

  final Dio _dio;

  final Serializers _serializers;

  const AppApi(this._dio, this._serializers);

  /// 
  ///
  /// 
  Future<Response<BuiltList<CategoryDto>>> apiV1AppCategoriesGet({ 
    String companyId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/categories',
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
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

    const _responseType = FullType(BuiltList, [FullType(CategoryDto)]);
    final BuiltList<CategoryDto> _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as BuiltList<CategoryDto>;

    return Response<BuiltList<CategoryDto>>(
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
  Future<Response<CustomerCardTokenResponse>> apiV1AppCustomersCustomerIdCardTokenPost(
    String customerId,
    IssueCustomerCardTokenApiRequest issueCustomerCardTokenApiRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/customers/{customerId}/card-token'.replaceAll('{' r'customerId' '}', customerId.toString()),
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

    const _type = FullType(IssueCustomerCardTokenApiRequest);
    _bodyData = _serializers.serialize(issueCustomerCardTokenApiRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(CustomerCardTokenResponse);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as CustomerCardTokenResponse;

    return Response<CustomerCardTokenResponse>(
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
  Future<Response<BuiltList<CustomerDto>>> apiV1AppCustomersGet({ 
    String companyId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/customers',
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
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

    const _responseType = FullType(BuiltList, [FullType(CustomerDto)]);
    final BuiltList<CustomerDto> _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as BuiltList<CustomerDto>;

    return Response<BuiltList<CustomerDto>>(
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
  Future<Response<IdentifiedCustomerDto>> apiV1AppCustomersIdentifyPost(
    IdentifyCustomerRequest identifyCustomerRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/customers/identify',
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

    const _type = FullType(IdentifyCustomerRequest);
    _bodyData = _serializers.serialize(identifyCustomerRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(IdentifiedCustomerDto);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as IdentifiedCustomerDto;

    return Response<IdentifiedCustomerDto>(
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
  Future<Response<BuiltList<DiscountDto>>> apiV1AppDiscountsGet({ 
    String companyId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/discounts',
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
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

    const _responseType = FullType(BuiltList, [FullType(DiscountDto)]);
    final BuiltList<DiscountDto> _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as BuiltList<DiscountDto>;

    return Response<BuiltList<DiscountDto>>(
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
  Future<Response<LoyaltyPreviewResponse>> apiV1AppLoyaltyPreviewPost(
    LoyaltyPreviewRequest loyaltyPreviewRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/loyalty/preview',
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

    const _type = FullType(LoyaltyPreviewRequest);
    _bodyData = _serializers.serialize(loyaltyPreviewRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(LoyaltyPreviewResponse);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as LoyaltyPreviewResponse;

    return Response<LoyaltyPreviewResponse>(
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
  Future<Response<RedeemRewardResponse>> apiV1AppLoyaltyRewardsRewardIdRedeemPost(
    String rewardId,
    RedeemRewardApiRequest redeemRewardApiRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/loyalty/rewards/{rewardId}/redeem'.replaceAll('{' r'rewardId' '}', rewardId.toString()),
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

    const _type = FullType(RedeemRewardApiRequest);
    _bodyData = _serializers.serialize(redeemRewardApiRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(RedeemRewardResponse);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as RedeemRewardResponse;

    return Response<RedeemRewardResponse>(
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
  Future<Response<BuiltList<OrderListDto>>> apiV1AppOrdersGet({ 
    String companyId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/orders',
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
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

    const _responseType = FullType(BuiltList, [FullType(OrderListDto)]);
    final BuiltList<OrderListDto> _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as BuiltList<OrderListDto>;

    return Response<BuiltList<OrderListDto>>(
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
  Future<Response<CancelOrderResponse>> apiV1AppOrdersOrderIdCancelPost(
    String orderId,
    ReasonRequest reasonRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/orders/{orderId}/cancel'.replaceAll('{' r'orderId' '}', orderId.toString()),
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

    const _type = FullType(ReasonRequest);
    _bodyData = _serializers.serialize(reasonRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(CancelOrderResponse);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as CancelOrderResponse;

    return Response<CancelOrderResponse>(
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
  Future<Response<void>> apiV1AppOrdersOrderIdGet(
    String orderId, { 
    String companyId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/orders/{orderId}'.replaceAll('{' r'orderId' '}', orderId.toString()),
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
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

    return _response;
  }

  /// 
  ///
  /// 
  Future<Response<CancelOrderResponse>> apiV1AppOrdersOrderIdRefundPost(
    String orderId,
    ReasonRequest reasonRequest, { 
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/orders/{orderId}/refund'.replaceAll('{' r'orderId' '}', orderId.toString()),
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

    const _type = FullType(ReasonRequest);
    _bodyData = _serializers.serialize(reasonRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(CancelOrderResponse);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as CancelOrderResponse;

    return Response<CancelOrderResponse>(
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
  Future<Response<OrderResponse>> apiV1AppOrdersPost(
    CreateAppOrderRequest createAppOrderRequest, { 
    String idempotencyKey,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/orders',
      method: 'POST',
      headers: <String, dynamic>{
        if (idempotencyKey != null) r'Idempotency-Key': idempotencyKey,
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

    const _type = FullType(CreateAppOrderRequest);
    _bodyData = _serializers.serialize(createAppOrderRequest, specifiedType: _type);

    final _response = await _dio.request<dynamic>(
      _request.path,
      data: _bodyData,
      options: _request,
    );

    const _responseType = FullType(OrderResponse);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as OrderResponse;

    return Response<OrderResponse>(
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
  Future<Response<BuiltList<PosDto>>> apiV1AppPosGet({ 
    String companyId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/pos',
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
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

    const _responseType = FullType(BuiltList, [FullType(PosDto)]);
    final BuiltList<PosDto> _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as BuiltList<PosDto>;

    return Response<BuiltList<PosDto>>(
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
  Future<Response<PosProductCatalogResponse>> apiV1AppPosPosIdProductsGet(
    String posId, { 
    String companyId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/pos/{posId}/products'.replaceAll('{' r'posId' '}', posId.toString()),
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
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

    const _responseType = FullType(PosProductCatalogResponse);
    final _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as PosProductCatalogResponse;

    return Response<PosProductCatalogResponse>(
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
  Future<Response<BuiltList<ProductDto>>> apiV1AppProductsGet({ 
    String companyId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/products',
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
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

    const _responseType = FullType(BuiltList, [FullType(ProductDto)]);
    final BuiltList<ProductDto> _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as BuiltList<ProductDto>;

    return Response<BuiltList<ProductDto>>(
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
  Future<Response<BuiltList<StoreDto>>> apiV1AppStoresGet({ 
    String companyId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/app/stores',
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
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

    const _responseType = FullType(BuiltList, [FullType(StoreDto)]);
    final BuiltList<StoreDto> _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as BuiltList<StoreDto>;

    return Response<BuiltList<StoreDto>>(
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
