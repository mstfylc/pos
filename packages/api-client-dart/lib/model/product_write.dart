//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/tax_type.dart';
import 'package:mansis_pos_api_client/model/product_unit_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'product_write.g.dart';

abstract class ProductWrite implements Built<ProductWrite, ProductWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'categoryId')
    String get categoryId;

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
    ProductUnitType get productUnitType;
    // enum productUnitTypeEnum {  Adet,  MiliLitre,  Gram,  };

    @BuiltValueField(wireName: r'taxType')
    TaxType get taxType;
    // enum taxTypeEnum {  Bir,  Sekiz,  OnSekiz,  };

    @BuiltValueField(wireName: r'stocktaking')
    bool get stocktaking;

    ProductWrite._();

    static void _initializeBuilder(ProductWriteBuilder b) => b;

    factory ProductWrite([void updates(ProductWriteBuilder b)]) = _$ProductWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<ProductWrite> get serializer => _$ProductWriteSerializer();
}

class _$ProductWriteSerializer implements StructuredSerializer<ProductWrite> {

    @override
    final Iterable<Type> types = const [ProductWrite, _$ProductWrite];
    @override
    final String wireName = r'ProductWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, ProductWrite object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'categoryId')
            ..add(serializers.serialize(object.categoryId,
                specifiedType: const FullType(String)));
        if (object.salePrice != null) {
            result
                ..add(r'salePrice')
                ..add(serializers.serialize(object.salePrice,
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
        return result;
    }

    @override
    ProductWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = ProductWriteBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
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
            }
        }
        return result.build();
    }
}

