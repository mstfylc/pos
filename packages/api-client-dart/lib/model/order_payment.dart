//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/payment_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'order_payment.g.dart';

abstract class OrderPayment implements Built<OrderPayment, OrderPaymentBuilder> {

    @BuiltValueField(wireName: r'paymentType')
    PaymentType get paymentType;
    // enum paymentTypeEnum {  Cash,  CreditCard,  Ticket,  Sodexo,  Multinet,  };

    @BuiltValueField(wireName: r'amount')
    double get amount;

    OrderPayment._();

    static void _initializeBuilder(OrderPaymentBuilder b) => b;

    factory OrderPayment([void updates(OrderPaymentBuilder b)]) = _$OrderPayment;

    @BuiltValueSerializer(custom: true)
    static Serializer<OrderPayment> get serializer => _$OrderPaymentSerializer();
}

class _$OrderPaymentSerializer implements StructuredSerializer<OrderPayment> {

    @override
    final Iterable<Type> types = const [OrderPayment, _$OrderPayment];
    @override
    final String wireName = r'OrderPayment';

    @override
    Iterable<Object> serialize(Serializers serializers, OrderPayment object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'paymentType')
            ..add(serializers.serialize(object.paymentType,
                specifiedType: const FullType(PaymentType)));
        result
            ..add(r'amount')
            ..add(serializers.serialize(object.amount,
                specifiedType: const FullType(double)));
        return result;
    }

    @override
    OrderPayment deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OrderPaymentBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'paymentType':
                    result.paymentType = serializers.deserialize(value,
                        specifiedType: const FullType(PaymentType)) as PaymentType;
                    break;
                case r'amount':
                    result.amount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
            }
        }
        return result.build();
    }
}

