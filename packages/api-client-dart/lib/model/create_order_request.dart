//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/shipping_type.dart';
import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/order_line.dart';
import 'package:mansis_pos_api_client/model/order_payment.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'create_order_request.g.dart';

abstract class CreateOrderRequest implements Built<CreateOrderRequest, CreateOrderRequestBuilder> {

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
    ShippingType get shippingType;
    // enum shippingTypeEnum {  Self,  ComeTake,  Order,  Customer,  };

    @BuiltValueField(wireName: r'orderTime')
    DateTime get orderTime;

    @nullable
    @BuiltValueField(wireName: r'idempotencyKey')
    String get idempotencyKey;

    @BuiltValueField(wireName: r'lines')
    BuiltList<OrderLine> get lines;

    @BuiltValueField(wireName: r'payments')
    BuiltList<OrderPayment> get payments;

    CreateOrderRequest._();

    static void _initializeBuilder(CreateOrderRequestBuilder b) => b;

    factory CreateOrderRequest([void updates(CreateOrderRequestBuilder b)]) = _$CreateOrderRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<CreateOrderRequest> get serializer => _$CreateOrderRequestSerializer();
}

class _$CreateOrderRequestSerializer implements StructuredSerializer<CreateOrderRequest> {

    @override
    final Iterable<Type> types = const [CreateOrderRequest, _$CreateOrderRequest];
    @override
    final String wireName = r'CreateOrderRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, CreateOrderRequest object,
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
        if (object.customerId != null) {
            result
                ..add(r'customerId')
                ..add(serializers.serialize(object.customerId,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'shippingType')
            ..add(serializers.serialize(object.shippingType,
                specifiedType: const FullType(ShippingType)));
        result
            ..add(r'orderTime')
            ..add(serializers.serialize(object.orderTime,
                specifiedType: const FullType(DateTime)));
        if (object.idempotencyKey != null) {
            result
                ..add(r'idempotencyKey')
                ..add(serializers.serialize(object.idempotencyKey,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'lines')
            ..add(serializers.serialize(object.lines,
                specifiedType: const FullType(BuiltList, [FullType(OrderLine)])));
        result
            ..add(r'payments')
            ..add(serializers.serialize(object.payments,
                specifiedType: const FullType(BuiltList, [FullType(OrderPayment)])));
        return result;
    }

    @override
    CreateOrderRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CreateOrderRequestBuilder();

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
                        specifiedType: const FullType(ShippingType)) as ShippingType;
                    break;
                case r'orderTime':
                    result.orderTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'idempotencyKey':
                    result.idempotencyKey = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'lines':
                    result.lines.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(OrderLine)])) as BuiltList<OrderLine>);
                    break;
                case r'payments':
                    result.payments.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(OrderPayment)])) as BuiltList<OrderPayment>);
                    break;
            }
        }
        return result.build();
    }
}

