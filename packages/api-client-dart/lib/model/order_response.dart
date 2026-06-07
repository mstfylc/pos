//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/payment_summary.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'order_response.g.dart';

abstract class OrderResponse implements Built<OrderResponse, OrderResponseBuilder> {

    @BuiltValueField(wireName: r'orderId')
    String get orderId;

    @BuiltValueField(wireName: r'idempotencyKey')
    String get idempotencyKey;

    @BuiltValueField(wireName: r'total')
    double get total;

    @BuiltValueField(wireName: r'paymentSummary')
    PaymentSummary get paymentSummary;
    // enum paymentSummaryEnum {  Cash,  CreditCard,  Ticket,  Sodexo,  Multinet,  Mixed,  };

    @BuiltValueField(wireName: r'existing')
    bool get existing;

    OrderResponse._();

    static void _initializeBuilder(OrderResponseBuilder b) => b;

    factory OrderResponse([void updates(OrderResponseBuilder b)]) = _$OrderResponse;

    @BuiltValueSerializer(custom: true)
    static Serializer<OrderResponse> get serializer => _$OrderResponseSerializer();
}

class _$OrderResponseSerializer implements StructuredSerializer<OrderResponse> {

    @override
    final Iterable<Type> types = const [OrderResponse, _$OrderResponse];
    @override
    final String wireName = r'OrderResponse';

    @override
    Iterable<Object> serialize(Serializers serializers, OrderResponse object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'orderId')
            ..add(serializers.serialize(object.orderId,
                specifiedType: const FullType(String)));
        result
            ..add(r'idempotencyKey')
            ..add(serializers.serialize(object.idempotencyKey,
                specifiedType: const FullType(String)));
        result
            ..add(r'total')
            ..add(serializers.serialize(object.total,
                specifiedType: const FullType(double)));
        result
            ..add(r'paymentSummary')
            ..add(serializers.serialize(object.paymentSummary,
                specifiedType: const FullType(PaymentSummary)));
        result
            ..add(r'existing')
            ..add(serializers.serialize(object.existing,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    OrderResponse deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OrderResponseBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'orderId':
                    result.orderId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'idempotencyKey':
                    result.idempotencyKey = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'total':
                    result.total = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'paymentSummary':
                    result.paymentSummary = serializers.deserialize(value,
                        specifiedType: const FullType(PaymentSummary)) as PaymentSummary;
                    break;
                case r'existing':
                    result.existing = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

