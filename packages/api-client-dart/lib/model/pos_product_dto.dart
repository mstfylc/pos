//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'pos_product_dto.g.dart';

abstract class PosProductDto implements Built<PosProductDto, PosProductDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'posId')
    String get posId;

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @nullable
    @BuiltValueField(wireName: r'purchasePrice')
    double get purchasePrice;

    @nullable
    @BuiltValueField(wireName: r'salePrice')
    double get salePrice;

    PosProductDto._();

    static void _initializeBuilder(PosProductDtoBuilder b) => b;

    factory PosProductDto([void updates(PosProductDtoBuilder b)]) = _$PosProductDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PosProductDto> get serializer => _$PosProductDtoSerializer();
}

class _$PosProductDtoSerializer implements StructuredSerializer<PosProductDto> {

    @override
    final Iterable<Type> types = const [PosProductDto, _$PosProductDto];
    @override
    final String wireName = r'PosProductDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PosProductDto object,
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
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'purchasePrice')
            ..add(object.purchasePrice == null ? null : serializers.serialize(object.purchasePrice,
                specifiedType: const FullType(double)));
        result
            ..add(r'salePrice')
            ..add(object.salePrice == null ? null : serializers.serialize(object.salePrice,
                specifiedType: const FullType(double)));
        return result;
    }

    @override
    PosProductDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PosProductDtoBuilder();

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
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'purchasePrice':
                    result.purchasePrice = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'salePrice':
                    result.salePrice = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
            }
        }
        return result.build();
    }
}

