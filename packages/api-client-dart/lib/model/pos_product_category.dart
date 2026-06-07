//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/pos_product_sale.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'pos_product_category.g.dart';

abstract class PosProductCategory implements Built<PosProductCategory, PosProductCategoryBuilder> {

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
    BuiltList<PosProductSale> get products;

    PosProductCategory._();

    static void _initializeBuilder(PosProductCategoryBuilder b) => b;

    factory PosProductCategory([void updates(PosProductCategoryBuilder b)]) = _$PosProductCategory;

    @BuiltValueSerializer(custom: true)
    static Serializer<PosProductCategory> get serializer => _$PosProductCategorySerializer();
}

class _$PosProductCategorySerializer implements StructuredSerializer<PosProductCategory> {

    @override
    final Iterable<Type> types = const [PosProductCategory, _$PosProductCategory];
    @override
    final String wireName = r'PosProductCategory';

    @override
    Iterable<Object> serialize(Serializers serializers, PosProductCategory object,
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
        if (object.colorName != null) {
            result
                ..add(r'colorName')
                ..add(serializers.serialize(object.colorName,
                    specifiedType: const FullType(String)));
        }
        if (object.colorContent != null) {
            result
                ..add(r'colorContent')
                ..add(serializers.serialize(object.colorContent,
                    specifiedType: const FullType(String)));
        }
        if (object.shapeName != null) {
            result
                ..add(r'shapeName')
                ..add(serializers.serialize(object.shapeName,
                    specifiedType: const FullType(String)));
        }
        if (object.shapeContent != null) {
            result
                ..add(r'shapeContent')
                ..add(serializers.serialize(object.shapeContent,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'products')
            ..add(serializers.serialize(object.products,
                specifiedType: const FullType(BuiltList, [FullType(PosProductSale)])));
        return result;
    }

    @override
    PosProductCategory deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PosProductCategoryBuilder();

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
                        specifiedType: const FullType(BuiltList, [FullType(PosProductSale)])) as BuiltList<PosProductSale>);
                    break;
            }
        }
        return result.build();
    }
}

