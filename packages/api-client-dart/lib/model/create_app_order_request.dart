//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/create_app_order_line_request.dart';
import 'package:mansis_pos_api_client/model/create_app_order_discount_request.dart';
import 'package:mansis_pos_api_client/model/create_app_order_payment_request.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'create_app_order_request.g.dart';

abstract class CreateAppOrderRequest implements Built<CreateAppOrderRequest, CreateAppOrderRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'posId')
    String get posId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @nullable
    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @BuiltValueField(wireName: r'shippingType')
    int get shippingType;

    @BuiltValueField(wireName: r'orderTime')
    DateTime get orderTime;

    @nullable
    @BuiltValueField(wireName: r'idempotencyKey')
    String get idempotencyKey;

    @BuiltValueField(wireName: r'offlineOrder')
    bool get offlineOrder;

    @BuiltValueField(wireName: r'lines')
    BuiltList<CreateAppOrderLineRequest> get lines;

    @BuiltValueField(wireName: r'payments')
    BuiltList<CreateAppOrderPaymentRequest> get payments;

    @BuiltValueField(wireName: r'discounts')
    BuiltList<CreateAppOrderDiscountRequest> get discounts;

    CreateAppOrderRequest._();

    static void _initializeBuilder(CreateAppOrderRequestBuilder b) => b;

    factory CreateAppOrderRequest([void updates(CreateAppOrderRequestBuilder b)]) = _$CreateAppOrderRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<CreateAppOrderRequest> get serializer => _$CreateAppOrderRequestSerializer();
}

class _$CreateAppOrderRequestSerializer implements StructuredSerializer<CreateAppOrderRequest> {

    @override
    final Iterable<Type> types = const [CreateAppOrderRequest, _$CreateAppOrderRequest];
    @override
    final String wireName = r'CreateAppOrderRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, CreateAppOrderRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'posId')
            ..add(serializers.serialize(object.posId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'customerId')
            ..add(object.customerId == null ? null : serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'shippingType')
            ..add(serializers.serialize(object.shippingType,
                specifiedType: const FullType(int)));
        result
            ..add(r'orderTime')
            ..add(serializers.serialize(object.orderTime,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'idempotencyKey')
            ..add(object.idempotencyKey == null ? null : serializers.serialize(object.idempotencyKey,
                specifiedType: const FullType(String)));
        result
            ..add(r'offlineOrder')
            ..add(serializers.serialize(object.offlineOrder,
                specifiedType: const FullType(bool)));
        result
            ..add(r'lines')
            ..add(serializers.serialize(object.lines,
                specifiedType: const FullType(BuiltList, [FullType(CreateAppOrderLineRequest)])));
        result
            ..add(r'payments')
            ..add(serializers.serialize(object.payments,
                specifiedType: const FullType(BuiltList, [FullType(CreateAppOrderPaymentRequest)])));
        result
            ..add(r'discounts')
            ..add(serializers.serialize(object.discounts,
                specifiedType: const FullType(BuiltList, [FullType(CreateAppOrderDiscountRequest)])));
        return result;
    }

    @override
    CreateAppOrderRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CreateAppOrderRequestBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'posId':
                    result.posId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'shippingType':
                    result.shippingType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'orderTime':
                    result.orderTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'idempotencyKey':
                    result.idempotencyKey = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'offlineOrder':
                    result.offlineOrder = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'lines':
                    result.lines.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(CreateAppOrderLineRequest)])) as BuiltList<CreateAppOrderLineRequest>);
                    break;
                case r'payments':
                    result.payments.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(CreateAppOrderPaymentRequest)])) as BuiltList<CreateAppOrderPaymentRequest>);
                    break;
                case r'discounts':
                    result.discounts.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(CreateAppOrderDiscountRequest)])) as BuiltList<CreateAppOrderDiscountRequest>);
                    break;
            }
        }
        return result.build();
    }
}

