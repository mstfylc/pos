//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/pos_product_sale_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'pos_product_category_dto.g.dart';

abstract class PosProductCategoryDto implements Built<PosProductCategoryDto, PosProductCategoryDtoBuilder> {

    @BuiltValueField(wireName: r'categoryId')
    String get categoryId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'sortOrder')
    int get sortOrder;

    @nullable
    @BuiltValueField(wireName: r'colorName')
    String get colorName;

    @nullable
    @BuiltValueField(wireName: r'colorContent')
    String get colorContent;

    @nullable
    @BuiltValueField(wireName: r'shapeName')
    String get shapeName;

    @nullable
    @BuiltValueField(wireName: r'shapeContent')
    String get shapeContent;

    @BuiltValueField(wireName: r'products')
    BuiltList<PosProductSaleDto> get products;

    PosProductCategoryDto._();

    static void _initializeBuilder(PosProductCategoryDtoBuilder b) => b;

    factory PosProductCategoryDto([void updates(PosProductCategoryDtoBuilder b)]) = _$PosProductCategoryDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PosProductCategoryDto> get serializer => _$PosProductCategoryDtoSerializer();
}

class _$PosProductCategoryDtoSerializer implements StructuredSerializer<PosProductCategoryDto> {

    @override
    final Iterable<Type> types = const [PosProductCategoryDto, _$PosProductCategoryDto];
    @override
    final String wireName = r'PosProductCategoryDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PosProductCategoryDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'categoryId')
            ..add(serializers.serialize(object.categoryId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'sortOrder')
            ..add(serializers.serialize(object.sortOrder,
                specifiedType: const FullType(int)));
        result
            ..add(r'colorName')
            ..add(object.colorName == null ? null : serializers.serialize(object.colorName,
                specifiedType: const FullType(String)));
        result
            ..add(r'colorContent')
            ..add(object.colorContent == null ? null : serializers.serialize(object.colorContent,
                specifiedType: const FullType(String)));
        result
            ..add(r'shapeName')
            ..add(object.shapeName == null ? null : serializers.serialize(object.shapeName,
                specifiedType: const FullType(String)));
        result
            ..add(r'shapeContent')
            ..add(object.shapeContent == null ? null : serializers.serialize(object.shapeContent,
                specifiedType: const FullType(String)));
        result
            ..add(r'products')
            ..add(serializers.serialize(object.products,
                specifiedType: const FullType(BuiltList, [FullType(PosProductSaleDto)])));
        return result;
    }

    @override
    PosProductCategoryDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PosProductCategoryDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'categoryId':
                    result.categoryId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'sortOrder':
                    result.sortOrder = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'colorName':
                    result.colorName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'colorContent':
                    result.colorContent = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'shapeName':
                    result.shapeName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'shapeContent':
                    result.shapeContent = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'products':
                    result.products.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(PosProductSaleDto)])) as BuiltList<PosProductSaleDto>);
                    break;
            }
        }
        return result.build();
    }
}

