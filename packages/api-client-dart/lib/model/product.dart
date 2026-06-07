//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/tax_type.dart';
import 'package:mansis_pos_api_client/model/product_unit_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'product.g.dart';

abstract class Product implements Built<Product, ProductBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @nullable
    @BuiltValueField(wireName: r'salePrice')
    double get salePrice;

    @BuiltValueField(wireName: r'taxType')
    TaxType get taxType;
    // enum taxTypeEnum {  Bir,  Sekiz,  OnSekiz,  };

    @BuiltValueField(wireName: r'unitType')
    ProductUnitType get unitType;
    // enum unitTypeEnum {  Adet,  MiliLitre,  Gram,  };

    @BuiltValueField(wireName: r'active')
    bool get active;

    Product._();

    static void _initializeBuilder(ProductBuilder b) => b;

    factory Product([void updates(ProductBuilder b)]) = _$Product;

    @BuiltValueSerializer(custom: true)
    static Serializer<Product> get serializer => _$ProductSerializer();
}

class _$ProductSerializer implements StructuredSerializer<Product> {

    @override
    final Iterable<Type> types = const [Product, _$Product];
    @override
    final String wireName = r'Product';

    @override
    Iterable<Object> serialize(Serializers serializers, Product object,
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
        if (object.salePrice != null) {
            result
                ..add(r'salePrice')
                ..add(serializers.serialize(object.salePrice,
                    specifiedType: const FullType(double)));
        }
        result
            ..add(r'taxType')
            ..add(serializers.serialize(object.taxType,
                specifiedType: const FullType(TaxType)));
        result
            ..add(r'unitType')
            ..add(serializers.serialize(object.unitType,
                specifiedType: const FullType(ProductUnitType)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    Product deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = ProductBuilder();

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
                case r'salePrice':
                    result.salePrice = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'taxType':
                    result.taxType = serializers.deserialize(value,
                        specifiedType: const FullType(TaxType)) as TaxType;
                    break;
                case r'unitType':
                    result.unitType = serializers.deserialize(value,
                        specifiedType: const FullType(ProductUnitType)) as ProductUnitType;
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

