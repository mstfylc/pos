//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'product_dto.g.dart';

abstract class ProductDto implements Built<ProductDto, ProductDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'categoryId')
    String get categoryId;

    @nullable
    @BuiltValueField(wireName: r'purchasePrice')
    double get purchasePrice;

    @nullable
    @BuiltValueField(wireName: r'salePrice')
    double get salePrice;

    @nullable
    @BuiltValueField(wireName: r'barcode')
    String get barcode;

    @nullable
    @BuiltValueField(wireName: r'stockCode')
    String get stockCode;

    @BuiltValueField(wireName: r'productUnitType')
    int get productUnitType;

    @BuiltValueField(wireName: r'taxType')
    int get taxType;

    @BuiltValueField(wireName: r'stocktaking')
    bool get stocktaking;

    @nullable
    @BuiltValueField(wireName: r'image')
    String get image;

    @BuiltValueField(wireName: r'storeProduct')
    bool get storeProduct;

    @BuiltValueField(wireName: r'posProduct')
    bool get posProduct;

    @BuiltValueField(wireName: r'entryProduct')
    bool get entryProduct;

    @BuiltValueField(wireName: r'favoriteProduct')
    bool get favoriteProduct;

    @BuiltValueField(wireName: r'sortOrder')
    int get sortOrder;

    @nullable
    @BuiltValueField(wireName: r'description')
    String get description;

    @BuiltValueField(wireName: r'main')
    bool get main;

    @nullable
    @BuiltValueField(wireName: r'parentId')
    String get parentId;

    @BuiltValueField(wireName: r'active')
    bool get active;

    ProductDto._();

    static void _initializeBuilder(ProductDtoBuilder b) => b;

    factory ProductDto([void updates(ProductDtoBuilder b)]) = _$ProductDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<ProductDto> get serializer => _$ProductDtoSerializer();
}

class _$ProductDtoSerializer implements StructuredSerializer<ProductDto> {

    @override
    final Iterable<Type> types = const [ProductDto, _$ProductDto];
    @override
    final String wireName = r'ProductDto';

    @override
    Iterable<Object> serialize(Serializers serializers, ProductDto object,
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
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'categoryId')
            ..add(serializers.serialize(object.categoryId,
                specifiedType: const FullType(String)));
        result
            ..add(r'purchasePrice')
            ..add(object.purchasePrice == null ? null : serializers.serialize(object.purchasePrice,
                specifiedType: const FullType(double)));
        result
            ..add(r'salePrice')
            ..add(object.salePrice == null ? null : serializers.serialize(object.salePrice,
                specifiedType: const FullType(double)));
        result
            ..add(r'barcode')
            ..add(object.barcode == null ? null : serializers.serialize(object.barcode,
                specifiedType: const FullType(String)));
        result
            ..add(r'stockCode')
            ..add(object.stockCode == null ? null : serializers.serialize(object.stockCode,
                specifiedType: const FullType(String)));
        result
            ..add(r'productUnitType')
            ..add(serializers.serialize(object.productUnitType,
                specifiedType: const FullType(int)));
        result
            ..add(r'taxType')
            ..add(serializers.serialize(object.taxType,
                specifiedType: const FullType(int)));
        result
            ..add(r'stocktaking')
            ..add(serializers.serialize(object.stocktaking,
                specifiedType: const FullType(bool)));
        result
            ..add(r'image')
            ..add(object.image == null ? null : serializers.serialize(object.image,
                specifiedType: const FullType(String)));
        result
            ..add(r'storeProduct')
            ..add(serializers.serialize(object.storeProduct,
                specifiedType: const FullType(bool)));
        result
            ..add(r'posProduct')
            ..add(serializers.serialize(object.posProduct,
                specifiedType: const FullType(bool)));
        result
            ..add(r'entryProduct')
            ..add(serializers.serialize(object.entryProduct,
                specifiedType: const FullType(bool)));
        result
            ..add(r'favoriteProduct')
            ..add(serializers.serialize(object.favoriteProduct,
                specifiedType: const FullType(bool)));
        result
            ..add(r'sortOrder')
            ..add(serializers.serialize(object.sortOrder,
                specifiedType: const FullType(int)));
        result
            ..add(r'description')
            ..add(object.description == null ? null : serializers.serialize(object.description,
                specifiedType: const FullType(String)));
        result
            ..add(r'main')
            ..add(serializers.serialize(object.main,
                specifiedType: const FullType(bool)));
        result
            ..add(r'parentId')
            ..add(object.parentId == null ? null : serializers.serialize(object.parentId,
                specifiedType: const FullType(String)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    ProductDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = ProductDtoBuilder();

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
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'categoryId':
                    result.categoryId = serializers.deserialize(value,
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
                case r'barcode':
                    result.barcode = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'stockCode':
                    result.stockCode = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'productUnitType':
                    result.productUnitType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'taxType':
                    result.taxType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'stocktaking':
                    result.stocktaking = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'image':
                    result.image = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'storeProduct':
                    result.storeProduct = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'posProduct':
                    result.posProduct = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'entryProduct':
                    result.entryProduct = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'favoriteProduct':
                    result.favoriteProduct = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'sortOrder':
                    result.sortOrder = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'description':
                    result.description = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'main':
                    result.main = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'parentId':
                    result.parentId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

