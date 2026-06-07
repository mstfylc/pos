//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'dart:async';
import 'package:dio/dio.dart';
import 'package:built_value/serializer.dart';

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/entry_product_delivery_report_row.dart';

class ReportsApi {

  final Dio _dio;

  final Serializers _serializers;

  const ReportsApi(this._dio, this._serializers);

  /// 
  ///
  /// 
  Future<Response<BuiltList<EntryProductDeliveryReportRow>>> apiV1ReportsEntryProductsGet({ 
    String companyId,
    DateTime from,
    DateTime to,
    String branchId,
    String posId,
    String productId,
    CancelToken cancelToken,
    Map<String, dynamic> headers,
    Map<String, dynamic> extra,
    ValidateStatus validateStatus,
    ProgressCallback onSendProgress,
    ProgressCallback onReceiveProgress,
  }) async {
    final _request = RequestOptions(
      path: r'/api/v1/reports/entry-products',
      method: 'GET',
      headers: <String, dynamic>{
        ...?headers,
      },
      queryParameters: <String, dynamic>{
        if (companyId != null) r'companyId': companyId,
        if (from != null) r'from': from,
        if (to != null) r'to': to,
        if (branchId != null) r'branchId': branchId,
        if (posId != null) r'posId': posId,
        if (productId != null) r'productId': productId,
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

    const _responseType = FullType(BuiltList, [FullType(EntryProductDeliveryReportRow)]);
    final BuiltList<EntryProductDeliveryReportRow> _responseData = _serializers.deserialize(
      _response.data,
      specifiedType: _responseType,
    ) as BuiltList<EntryProductDeliveryReportRow>;

    return Response<BuiltList<EntryProductDeliveryReportRow>>(
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
