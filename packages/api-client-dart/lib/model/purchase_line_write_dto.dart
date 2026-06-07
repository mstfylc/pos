//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'purchase_line_write_dto.g.dart';

abstract class PurchaseLineWriteDto implements Built<PurchaseLineWriteDto, PurchaseLineWriteDtoBuilder> {

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @BuiltValueField(wireName: r'price')
    double get price;

    @nullable
    @BuiltValueField(wireName: r'discount')
    int get discount;

    @nullable
    @BuiltValueField(wireName: r'tax')
    int get tax;

    PurchaseLineWriteDto._();

    static void _initializeBuilder(PurchaseLineWriteDtoBuilder b) => b;

    factory PurchaseLineWriteDto([void updates(PurchaseLineWriteDtoBuilder b)]) = _$PurchaseLineWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PurchaseLineWriteDto> get serializer => _$PurchaseLineWriteDtoSerializer();
}

class _$PurchaseLineWriteDtoSerializer implements StructuredSerializer<PurchaseLineWriteDto> {

    @override
    final Iterable<Type> types = const [PurchaseLineWriteDto, _$PurchaseLineWriteDto];
    @override
    final String wireName = r'PurchaseLineWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PurchaseLineWriteDto object,
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
            ..add(r'price')
            ..add(serializers.serialize(object.price,
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
    PurchaseLineWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PurchaseLineWriteDtoBuilder();

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
                case r'price':
                    result.price = serializers.deserialize(value,
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

