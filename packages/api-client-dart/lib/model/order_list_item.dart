//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/order_state.dart';
import 'package:mansis_pos_api_client/model/payment_summary.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'order_list_item.g.dart';

abstract class OrderListItem implements Built<OrderListItem, OrderListItemBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'posId')
    String get posId;

    @nullable
    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @BuiltValueField(wireName: r'orderTime')
    DateTime get orderTime;

    @BuiltValueField(wireName: r'total')
    double get total;

    @BuiltValueField(wireName: r'orderState')
    OrderState get orderState;
    // enum orderStateEnum {  Received,  Preparing,  Completed,  Cancelled,  Deleted,  Transferring,  };

    @BuiltValueField(wireName: r'paymentSummary')
    PaymentSummary get paymentSummary;
    // enum paymentSummaryEnum {  Cash,  CreditCard,  Ticket,  Sodexo,  Multinet,  Mixed,  };

    OrderListItem._();

    static void _initializeBuilder(OrderListItemBuilder b) => b;

    factory OrderListItem([void updates(OrderListItemBuilder b)]) = _$OrderListItem;

    @BuiltValueSerializer(custom: true)
    static Serializer<OrderListItem> get serializer => _$OrderListItemSerializer();
}

class _$OrderListItemSerializer implements StructuredSerializer<OrderListItem> {

    @override
    final Iterable<Type> types = const [OrderListItem, _$OrderListItem];
    @override
    final String wireName = r'OrderListItem';

    @override
    Iterable<Object> serialize(Serializers serializers, OrderListItem object,
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
            ..add(r'posId')
            ..add(serializers.serialize(object.posId,
                specifiedType: const FullType(String)));
        if (object.customerId != null) {
            result
                ..add(r'customerId')
                ..add(serializers.serialize(object.customerId,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'orderTime')
            ..add(serializers.serialize(object.orderTime,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'total')
            ..add(serializers.serialize(object.total,
                specifiedType: const FullType(double)));
        result
            ..add(r'orderState')
            ..add(serializers.serialize(object.orderState,
                specifiedType: const FullType(OrderState)));
        result
            ..add(r'paymentSummary')
            ..add(serializers.serialize(object.paymentSummary,
                specifiedType: const FullType(PaymentSummary)));
        return result;
    }

    @override
    OrderListItem deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OrderListItemBuilder();

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
                case r'posId':
                    result.posId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'orderTime':
                    result.orderTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'total':
                    result.total = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'orderState':
                    result.orderState = serializers.deserialize(value,
                        specifiedType: const FullType(OrderState)) as OrderState;
                    break;
                case r'paymentSummary':
                    result.paymentSummary = serializers.deserialize(value,
                        specifiedType: const FullType(PaymentSummary)) as PaymentSummary;
                    break;
            }
        }
        return result.build();
    }
}

