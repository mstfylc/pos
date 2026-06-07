//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'order_line.g.dart';

abstract class OrderLine implements Built<OrderLine, OrderLineBuilder> {

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @BuiltValueField(wireName: r'unitPrice')
    double get unitPrice;

    OrderLine._();

    static void _initializeBuilder(OrderLineBuilder b) => b;

    factory OrderLine([void updates(OrderLineBuilder b)]) = _$OrderLine;

    @BuiltValueSerializer(custom: true)
    static Serializer<OrderLine> get serializer => _$OrderLineSerializer();
}

class _$OrderLineSerializer implements StructuredSerializer<OrderLine> {

    @override
    final Iterable<Type> types = const [OrderLine, _$OrderLine];
    @override
    final String wireName = r'OrderLine';

    @override
    Iterable<Object> serialize(Serializers serializers, OrderLine object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'quantity')
            ..add(serializers.serialize(object.quantity,
                specifiedType: const FullType(int)));
        result
            ..add(r'unitPrice')
            ..add(serializers.serialize(object.unitPrice,
                specifiedType: const FullType(double)));
        return result;
    }

    @override
    OrderLine deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OrderLineBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'quantity':
                    result.quantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'unitPrice':
                    result.unitPrice = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
            }
        }
        return result.build();
    }
}

