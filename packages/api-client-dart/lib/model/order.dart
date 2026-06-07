//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/order_state.dart';
import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/order_payment.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'order.g.dart';

abstract class Order implements Built<Order, OrderBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'total')
    double get total;

    @BuiltValueField(wireName: r'state')
    OrderState get state;
    // enum stateEnum {  Received,  Preparing,  Completed,  Cancelled,  Deleted,  Transferring,  };

    @BuiltValueField(wireName: r'orderTime')
    DateTime get orderTime;

    @BuiltValueField(wireName: r'payments')
    BuiltList<OrderPayment> get payments;

    Order._();

    static void _initializeBuilder(OrderBuilder b) => b;

    factory Order([void updates(OrderBuilder b)]) = _$Order;

    @BuiltValueSerializer(custom: true)
    static Serializer<Order> get serializer => _$OrderSerializer();
}

class _$OrderSerializer implements StructuredSerializer<Order> {

    @override
    final Iterable<Type> types = const [Order, _$Order];
    @override
    final String wireName = r'Order';

    @override
    Iterable<Object> serialize(Serializers serializers, Order object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'total')
            ..add(serializers.serialize(object.total,
                specifiedType: const FullType(double)));
        result
            ..add(r'state')
            ..add(serializers.serialize(object.state,
                specifiedType: const FullType(OrderState)));
        result
            ..add(r'orderTime')
            ..add(serializers.serialize(object.orderTime,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'payments')
            ..add(serializers.serialize(object.payments,
                specifiedType: const FullType(BuiltList, [FullType(OrderPayment)])));
        return result;
    }

    @override
    Order deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OrderBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'total':
                    result.total = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'state':
                    result.state = serializers.deserialize(value,
                        specifiedType: const FullType(OrderState)) as OrderState;
                    break;
                case r'orderTime':
                    result.orderTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
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

