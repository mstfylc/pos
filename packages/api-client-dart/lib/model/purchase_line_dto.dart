//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'purchase_line_dto.g.dart';

abstract class PurchaseLineDto implements Built<PurchaseLineDto, PurchaseLineDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @BuiltValueField(wireName: r'price')
    double get price;

    @BuiltValueField(wireName: r'total')
    double get total;

    @nullable
    @BuiltValueField(wireName: r'discount')
    int get discount;

    @nullable
    @BuiltValueField(wireName: r'tax')
    int get tax;

    PurchaseLineDto._();

    static void _initializeBuilder(PurchaseLineDtoBuilder b) => b;

    factory PurchaseLineDto([void updates(PurchaseLineDtoBuilder b)]) = _$PurchaseLineDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PurchaseLineDto> get serializer => _$PurchaseLineDtoSerializer();
}

class _$PurchaseLineDtoSerializer implements StructuredSerializer<PurchaseLineDto> {

    @override
    final Iterable<Type> types = const [PurchaseLineDto, _$PurchaseLineDto];
    @override
    final String wireName = r'PurchaseLineDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PurchaseLineDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'quantity')
            ..add(serializers.serialize(object.quantity,
                specifiedType: const FullType(int)));
        result
            ..add(r'price')
            ..add(serializers.serialize(object.price,
                specifiedType: const FullType(double)));
        result
            ..add(r'total')
            ..add(serializers.serialize(object.total,
                specifiedType: const FullType(double)));
        result
            ..add(r'discount')
            ..add(object.discount == null ? null : serializers.serialize(object.discount,
                specifiedType: const FullType(int)));
        result
            ..add(r'tax')
            ..add(object.tax == null ? null : serializers.serialize(object.tax,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    PurchaseLineDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PurchaseLineDtoBuilder();

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
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'quantity':
                    result.quantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'price':
                    result.price = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'total':
                    result.total = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'discount':
                    result.discount = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'tax':
                    result.tax = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

