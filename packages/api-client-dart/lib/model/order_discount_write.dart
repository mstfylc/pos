//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'order_discount_write.g.dart';

abstract class OrderDiscountWrite implements Built<OrderDiscountWrite, OrderDiscountWriteBuilder> {

    @BuiltValueField(wireName: r'discountId')
    String get discountId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'amount')
    double get amount;

    OrderDiscountWrite._();

    static void _initializeBuilder(OrderDiscountWriteBuilder b) => b;

    factory OrderDiscountWrite([void updates(OrderDiscountWriteBuilder b)]) = _$OrderDiscountWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<OrderDiscountWrite> get serializer => _$OrderDiscountWriteSerializer();
}

class _$OrderDiscountWriteSerializer implements StructuredSerializer<OrderDiscountWrite> {

    @override
    final Iterable<Type> types = const [OrderDiscountWrite, _$OrderDiscountWrite];
    @override
    final String wireName = r'OrderDiscountWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, OrderDiscountWrite object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'discountId')
            ..add(serializers.serialize(object.discountId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'amount')
            ..add(serializers.serialize(object.amount,
                specifiedType: const FullType(double)));
        return result;
    }

    @override
    OrderDiscountWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OrderDiscountWriteBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'discountId':
                    result.discountId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
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

