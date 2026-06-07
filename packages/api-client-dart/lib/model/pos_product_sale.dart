//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/tax_type.dart';
import 'package:mansis_pos_api_client/model/product_unit_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'pos_product_sale.g.dart';

abstract class PosProductSale implements Built<PosProductSale, PosProductSaleBuilder> {

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @BuiltValueField(wireName: r'posProductId')
    String get posProductId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'categoryId')
    String get categoryId;

    @nullable
    @BuiltValueField(wireName: r'baseSalePrice')
    double get baseSalePrice;

    @nullable
    @BuiltValueField(wireName: r'salePrice')
    double get salePrice;

    @nullable
    @BuiltValueField(wireName: r'purchasePrice')
    double get purchasePrice;

    @nullable
    @BuiltValueField(wireName: r'barcode')
    String get barcode;

    @nullable
    @BuiltValueField(wireName: r'stockCode')
    String get stockCode;

    @nullable
    @BuiltValueField(wireName: r'image')
    String get image;

    @BuiltValueField(wireName: r'productUnitType')
    ProductUnitType get productUnitType;
    // enum productUnitTypeEnum {  Adet,  MiliLitre,  Gram,  };

    @BuiltValueField(wireName: r'taxType')
    TaxType get taxType;
    // enum taxTypeEnum {  Sifir,  Bir,  Sekiz,  OnSekiz,  };

    @BuiltValueField(wireName: r'stocktaking')
    bool get stocktaking;

    @BuiltValueField(wireName: r'favoriteProduct')
    bool get favoriteProduct;

    @BuiltValueField(wireName: r'sortOrder')
    int get sortOrder;

    @BuiltValueField(wireName: r'stockQuantity')
    int get stockQuantity;

    PosProductSale._();

    static void _initializeBuilder(PosProductSaleBuilder b) => b;

    factory PosProductSale([void updates(PosProductSaleBuilder b)]) = _$PosProductSale;

    @BuiltValueSerializer(custom: true)
    static Serializer<PosProductSale> get serializer => _$PosProductSaleSerializer();
}

class _$PosProductSaleSerializer implements StructuredSerializer<PosProductSale> {

    @override
    final Iterable<Type> types = const [PosProductSale, _$PosProductSale];
    @override
    final String wireName = r'PosProductSale';

    @override
    Iterable<Object> serialize(Serializers serializers, PosProductSale object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'posProductId')
            ..add(serializers.serialize(object.posProductId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'categoryId')
            ..add(serializers.serialize(object.categoryId,
                specifiedType: const FullType(String)));
        if (object.baseSalePrice != null) {
            result
                ..add(r'baseSalePrice')
                ..add(serializers.serialize(object.baseSalePrice,
                    specifiedType: const FullType(double)));
        }
        if (object.salePrice != null) {
            result
                ..add(r'salePrice')
                ..add(serializers.serialize(object.salePrice,
                    specifiedType: const FullType(double)));
        }
        if (object.purchasePrice != null) {
            result
                ..add(r'purchasePrice')
                ..add(serializers.serialize(object.purchasePrice,
                    specifiedType: const FullType(double)));
        }
        if (object.barcode != null) {
            result
                ..add(r'barcode')
                ..add(serializers.serialize(object.barcode,
                    specifiedType: const FullType(String)));
        }
        if (object.stockCode != null) {
            result
                ..add(r'stockCode')
                ..add(serializers.serialize(object.stockCode,
                    specifiedType: const FullType(String)));
        }
        if (object.image != null) {
            result
                ..add(r'image')
                ..add(serializers.serialize(object.image,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'productUnitType')
            ..add(serializers.serialize(object.productUnitType,
                specifiedType: const FullType(ProductUnitType)));
        result
            ..add(r'taxType')
            ..add(serializers.serialize(object.taxType,
                specifiedType: const FullType(TaxType)));
        result
            ..add(r'stocktaking')
            ..add(serializers.serialize(object.stocktaking,
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
            ..add(r'stockQuantity')
            ..add(serializers.serialize(object.stockQuantity,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    PosProductSale deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PosProductSaleBuilder();

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
                case r'posProductId':
                    result.posProductId = serializers.deserialize(value,
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
                case r'baseSalePrice':
                    result.baseSalePrice = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'salePrice':
                    result.salePrice = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'purchasePrice':
                    result.purchasePrice = serializers.deserialize(value,
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
                case r'image':
                    result.image = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'productUnitType':
                    result.productUnitType = serializers.deserialize(value,
                        specifiedType: const FullType(ProductUnitType)) as ProductUnitType;
                    break;
                case r'taxType':
                    result.taxType = serializers.deserialize(value,
                        specifiedType: const FullType(TaxType)) as TaxType;
                    break;
                case r'stocktaking':
                    result.stocktaking = serializers.deserialize(value,
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
                case r'stockQuantity':
                    result.stockQuantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

